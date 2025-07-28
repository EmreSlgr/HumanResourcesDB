using HumanResourcesDB;
using HumanResourcesDB.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

public class EmployeeDataAccess
{
    private string connectionString;

    public EmployeeDataAccess()
    {
        connectionString = ConfigurationManager.ConnectionStrings["HRDbConnection"].ConnectionString;
    }

    public void EnsureDefaultAdminExists()
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();

            // --- Departments başlangıç kayıtları ---
            string checkDeptCountQuery = "SELECT COUNT(*) FROM Departments";
            SqlCommand checkDeptCountCmd = new SqlCommand(checkDeptCountQuery, conn);
            int deptCount = (int)checkDeptCountCmd.ExecuteScalar();

            if (deptCount == 0)
            {
                string[] departments = { "Yönetim", "İnsan Kaynakları", "Muhasebe", "Satış", "IT" };
                foreach (var dept in departments)
                {
                    string insertDeptQuery = "INSERT INTO Departments (DepartmentName) VALUES (@DeptName)";
                    SqlCommand insertDeptCmd = new SqlCommand(insertDeptQuery, conn);
                    insertDeptCmd.Parameters.AddWithValue("@DeptName", dept);
                    insertDeptCmd.ExecuteNonQuery();
                }
            }

            // --- Roles başlangıç kayıtları ---
            string checkRoleCountQuery = "SELECT COUNT(*) FROM Roles";
            SqlCommand checkRoleCountCmd = new SqlCommand(checkRoleCountQuery, conn);
            int roleCount = (int)checkRoleCountCmd.ExecuteScalar();

            if (roleCount == 0)
            {
                string[] roles = { "Admin", "HR Manager", "Employee" };
                foreach (var role in roles)
                {
                    string insertRoleQuery = "INSERT INTO Roles (RoleName) VALUES (@RoleName)";
                    SqlCommand insertRoleCmd = new SqlCommand(insertRoleQuery, conn);
                    insertRoleCmd.Parameters.AddWithValue("@RoleName", role);
                    insertRoleCmd.ExecuteNonQuery();
                }
            }

            // --- LeaveTypes başlangıç kayıtları ---
            string checkLeaveTypeCountQuery = "SELECT COUNT(*) FROM LeaveTypes";
            SqlCommand checkLeaveTypeCountCmd = new SqlCommand(checkLeaveTypeCountQuery, conn);
            int leaveTypeCount = (int)checkLeaveTypeCountCmd.ExecuteScalar();

            if (leaveTypeCount == 0)
            {
                string[,] leaveTypes =
                {
                { "Yıllık İzin", "Yıllık ücretli izin" },
                { "Hastalık İzni", "Raporlu sağlık izni" },
                { "Ücretsiz İzin", "Maaşsız izin" },
                { "Doğum İzni", "Kadın çalışanlar için doğum izni" },
                { "Babalık İzni", "Erkek çalışanlar için doğum sonrası izin" }
            };

                for (int i = 0; i < leaveTypes.GetLength(0); i++)
                {
                    string insertLeaveTypeQuery = "INSERT INTO LeaveTypes (LeaveTypeName, Description) VALUES (@Name, @Desc)";
                    SqlCommand insertLeaveTypeCmd = new SqlCommand(insertLeaveTypeQuery, conn);
                    insertLeaveTypeCmd.Parameters.AddWithValue("@Name", leaveTypes[i, 0]);
                    insertLeaveTypeCmd.Parameters.AddWithValue("@Desc", leaveTypes[i, 1]);
                    insertLeaveTypeCmd.ExecuteNonQuery();
                }
            }

            // Departments tablosundan Yönetim ID'si al
            string getDeptIdQuery = "SELECT DepartmentID FROM Departments WHERE DepartmentName = 'Yönetim'";
            SqlCommand getDeptIdCmd = new SqlCommand(getDeptIdQuery, conn);
            int departmentId = (int)getDeptIdCmd.ExecuteScalar();

            // Positions tablosunda 'Yönetici' var mı kontrol et, yoksa ekle
            string checkPosQuery = "SELECT PositionID FROM Positions WHERE PositionName = 'Yönetici'";
            SqlCommand checkPosCmd = new SqlCommand(checkPosQuery, conn);
            object posIdObj = checkPosCmd.ExecuteScalar();

            int positionId;
            if (posIdObj == null)
            {
                string insertPosQuery = "INSERT INTO Positions (PositionName, DepartmentID) OUTPUT INSERTED.PositionID VALUES ('Yönetici', @DepartmentID)";
                SqlCommand insertPosCmd = new SqlCommand(insertPosQuery, conn);
                insertPosCmd.Parameters.AddWithValue("@DepartmentID", departmentId);
                positionId = (int)insertPosCmd.ExecuteScalar();
            }
            else
            {
                positionId = (int)posIdObj;
            }

            // Roles tablosundan Admin rolünün ID'sini al
            string getRoleIdQuery = "SELECT RoleID FROM Roles WHERE RoleName = 'Admin'";
            SqlCommand getRoleIdCmd = new SqlCommand(getRoleIdQuery, conn);
            int roleId = (int)getRoleIdCmd.ExecuteScalar();

            // Users tablosunda kayıt var mı kontrol et
            string checkUserQuery = "SELECT COUNT(*) FROM Users";
            SqlCommand checkUserCmd = new SqlCommand(checkUserQuery, conn);
            int userCount = (int)checkUserCmd.ExecuteScalar();

            if (userCount == 0)
            {
                // Employees tablosuna admin kaydı ekle
                string insertEmployeeQuery = @"
                INSERT INTO Employees (Name, Surname, Gender, BirthDate, DepartmentID, PositionID, HireDate, Phone, RelativePhone, Address, Email)
                OUTPUT INSERTED.EmployeeID
                VALUES ('Admin', 'User', 'Erkek', '1980-01-01', @DepartmentID, @PositionID, GETDATE(), '', '', '', 'admin@example.com')";
                SqlCommand empCmd = new SqlCommand(insertEmployeeQuery, conn);
                empCmd.Parameters.AddWithValue("@DepartmentID", departmentId);
                empCmd.Parameters.AddWithValue("@PositionID", positionId);
                int newEmployeeId = (int)empCmd.ExecuteScalar();

                // Users tablosuna admin hesabı oluştur
                string hashedPassword = ComputePasswordHash("1234");
                string insertUserQuery = @"
                INSERT INTO Users (Username, PasswordHash, Email, IsActive, CreatedAt, RoleID, EmployeeID)
                OUTPUT INSERTED.UserID
                VALUES (@Username, @PasswordHash, @Email, 1, GETDATE(), @RoleID, @EmployeeID)";
                SqlCommand userCmd = new SqlCommand(insertUserQuery, conn);
                userCmd.Parameters.AddWithValue("@Username", "admin");
                userCmd.Parameters.AddWithValue("@PasswordHash", hashedPassword);
                userCmd.Parameters.AddWithValue("@Email", "admin@example.com");
                userCmd.Parameters.AddWithValue("@EmployeeID", newEmployeeId);
                userCmd.Parameters.AddWithValue("@RoleID", roleId);
                int newUserId = (int)userCmd.ExecuteScalar();

                // Employees tablosundaki UserID alanını güncelle (UserID = User tablosundaki UserID)
                string updateEmployeeUserIdQuery = "UPDATE Employees SET UserID = @UserID WHERE EmployeeID = @EmployeeID";
                SqlCommand updateCmd = new SqlCommand(updateEmployeeUserIdQuery, conn);
                updateCmd.Parameters.AddWithValue("@UserID", newUserId);
                updateCmd.Parameters.AddWithValue("@EmployeeID", newEmployeeId);
                updateCmd.ExecuteNonQuery();
            }
        }
    }







    // Kullanıcı adı + şifre doğrulama, başarılıysa UserID döner, başarısızsa -1
    public int ValidateLogin(string username, string password)
    {
        string hashedPassword = ComputePasswordHash(password); // Şifreyi hashle

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string query = "SELECT UserID FROM Users WHERE Username = @Username AND PasswordHash = @PasswordHash";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Username", username);
            cmd.Parameters.AddWithValue("@PasswordHash", hashedPassword);

            conn.Open();
            object result = cmd.ExecuteScalar();

            return result != null ? Convert.ToInt32(result) : -1;
        }
    }


    // Çalışan Ekleme
    public void AddEmployee(string name, string surname, string gender, DateTime birthDate, int departmentId, int positionId,
                        DateTime hireDate, string phone, string relativePhone, string address, string email)
    {
        string query = @"
        INSERT INTO Employees (Name, Surname, Gender, BirthDate, DepartmentID, PositionID, HireDate, Phone, RelativePhone, Address, Email)
        VALUES (@Name, @Surname, @Gender, @BirthDate, @DepartmentID, @PositionID, @HireDate, @Phone, @RelativePhone, @Address, @Email)";

        using (SqlConnection conn = new SqlConnection(connectionString))
        using (SqlCommand cmd = new SqlCommand(query, conn))
        {
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@Surname", surname);
            cmd.Parameters.AddWithValue("@Gender", gender);
            cmd.Parameters.AddWithValue("@BirthDate", birthDate);
            cmd.Parameters.AddWithValue("@DepartmentID", departmentId);
            cmd.Parameters.AddWithValue("@PositionID", positionId);
            cmd.Parameters.AddWithValue("@HireDate", hireDate);
            cmd.Parameters.AddWithValue("@Phone", phone);
            cmd.Parameters.AddWithValue("@RelativePhone", relativePhone);
            cmd.Parameters.AddWithValue("@Address", address);
            cmd.Parameters.AddWithValue("@Email", email);

            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }
    #region ÇALIŞANLARI İLGİLİ TABLODAN ÇEKİP DATATABLEDA TUTAN KOD
    // Çalışanları Listele
    public DataTable GetEmployees()
    {
        DataTable dt = new DataTable();

        try
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(@"
            SELECT 
                e.EmployeeID,
                e.Name,
                e.Surname,
                e.Gender,
                e.BirthDate,
                e.HireDate,
                e.Phone,
                e.RelativePhone,
                e.Address,
                e.Email
            FROM Employees e
            INNER JOIN Users u ON e.EmployeeID = u.EmployeeID
            WHERE u.IsActive = 1", conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    dt.Load(reader);
                }
            }
        }
        catch
        {
            dt = new DataTable();
        }

        return dt;
    }
    #endregion

    // 1. Eğitim Ekleme
    public bool AddTraining(int employeeId, string trainingName, DateTime startDate, DateTime endDate, string status, string notes)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string query = @"INSERT INTO Trainings (EmployeeID, TrainingName, StartDate, EndDate, Status, Notes)
                         VALUES (@EmployeeID, @TrainingName, @StartDate, @EndDate, @Status, @Notes)";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@EmployeeID", employeeId);
                cmd.Parameters.AddWithValue("@TrainingName", trainingName);
                cmd.Parameters.AddWithValue("@StartDate", startDate);
                cmd.Parameters.AddWithValue("@EndDate", endDate);
                cmd.Parameters.AddWithValue("@Status", status);
                cmd.Parameters.AddWithValue("@Notes", notes);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }

    public DataTable GetTrainingById(int trainingId)
    {
        DataTable dt = new DataTable();

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string query = @"SELECT TrainingID, EmployeeID, TrainingName, StartDate, EndDate, Status, Notes
                         FROM Trainings
                         WHERE TrainingID = @TrainingID";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@TrainingID", trainingId);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
        }

        return dt;
    }


    // 2. Eğitim Listeleme (Tüm eğitimler veya belirli bir personele ait)
    public DataTable GetTrainings(int? employeeId = null)
    {
        DataTable dt = new DataTable();
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string query = @"
            SELECT 
                t.TrainingID, 
                e.EmployeeID, 
                e.Name + ' ' + e.Surname AS FullName,
                t.TrainingName, 
                t.StartDate, 
                t.EndDate, 
                t.Status, 
                t.Notes
            FROM Trainings t
            INNER JOIN Employees e ON t.EmployeeID = e.EmployeeID
        ";

            if (employeeId.HasValue)
                query += " WHERE t.EmployeeID = @EmployeeID";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                if (employeeId.HasValue)
                    cmd.Parameters.AddWithValue("@EmployeeID", employeeId.Value);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
        }
        return dt;
    }
    
    // 3. Eğitim Güncelleme
    public bool UpdateTraining(int trainingId, string trainingName, DateTime startDate, DateTime endDate, string status, string notes)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string query = @"UPDATE Trainings
                         SET TrainingName = @TrainingName,
                             StartDate = @StartDate,
                             EndDate = @EndDate,
                             Status = @Status,
                             Notes = @Notes
                         WHERE TrainingID = @TrainingID";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@TrainingID", trainingId);
                cmd.Parameters.AddWithValue("@TrainingName", trainingName);
                cmd.Parameters.AddWithValue("@StartDate", startDate);
                cmd.Parameters.AddWithValue("@EndDate", endDate);
                cmd.Parameters.AddWithValue("@Status", status);
                cmd.Parameters.AddWithValue("@Notes", notes);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }

    // 4. Eğitim Silme
    public bool DeleteTraining(int trainingId)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string query = "DELETE FROM Trainings WHERE TrainingID = @TrainingID";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@TrainingID", trainingId);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }


    // Çalışan Güncelleme
    public void UpdateEmployee(int employeeId, string name, string surname, string gender, DateTime birthDate,
    int departmentId, int positionId, DateTime hireDate, DateTime? startDate,
    string phone, string relativePhone, string address, string email)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();

            string query = @"
            UPDATE Employees SET
                Name = @Name,
                Surname = @Surname,
                Gender = @Gender,
                BirthDate = @BirthDate,
                DepartmentID = @DepartmentID,
                PositionID = @PositionID,
                HireDate = @HireDate,
                StartDate = @StartDate,
                Phone = @Phone,
                RelativePhone = @RelativePhone,
                Address = @Address,
                Email = @Email
            WHERE EmployeeID = @EmployeeID";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@EmployeeID", employeeId);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Surname", surname);
                cmd.Parameters.AddWithValue("@Gender", gender);
                cmd.Parameters.AddWithValue("@BirthDate", birthDate);
                cmd.Parameters.AddWithValue("@DepartmentID", departmentId);
                cmd.Parameters.AddWithValue("@PositionID", positionId);
                cmd.Parameters.AddWithValue("@HireDate", hireDate);

                if (startDate.HasValue)
                    cmd.Parameters.AddWithValue("@StartDate", startDate.Value);
                else
                    cmd.Parameters.AddWithValue("@StartDate", DBNull.Value);

                cmd.Parameters.AddWithValue("@Phone", phone);
                cmd.Parameters.AddWithValue("@RelativePhone", relativePhone);
                cmd.Parameters.AddWithValue("@Address", address);
                cmd.Parameters.AddWithValue("@Email", email);

                cmd.ExecuteNonQuery();
            }
        }
    }

    #region ÇALIŞAN - KULLANICI - BELGE DÖKÜMAN - DUYURU SİLEN SORGU KODU
    // Çalışan Silme
    public void DeleteEmployee(int employeeId)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            SqlTransaction transaction = conn.BeginTransaction();

            try
            {
                // 1. İlgili belgeleri sil
                string deleteDocs = "DELETE FROM EmployeeDocuments WHERE EmployeeID = @EmployeeID";
                using (SqlCommand cmdDocs = new SqlCommand(deleteDocs, conn, transaction))
                {
                    cmdDocs.Parameters.AddWithValue("@EmployeeID", employeeId);
                    cmdDocs.ExecuteNonQuery();
                }

                // 2. UserID'yi bul (Users tablosunda EmployeeID ile)
                int? userId = null;
                string selectUserId = "SELECT UserID FROM Users WHERE EmployeeID = @EmployeeID";
                using (SqlCommand cmdSelectUser = new SqlCommand(selectUserId, conn, transaction))
                {
                    cmdSelectUser.Parameters.AddWithValue("@EmployeeID", employeeId);
                    var result = cmdSelectUser.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                        userId = Convert.ToInt32(result);
                }

                if (userId.HasValue)
                {
                    // 3. Notifications tablosundan sil
                    string deleteNotifications = "DELETE FROM Notifications WHERE UserID = @UserID";
                    using (SqlCommand cmdNotif = new SqlCommand(deleteNotifications, conn, transaction))
                    {
                        cmdNotif.Parameters.AddWithValue("@UserID", userId.Value);
                        cmdNotif.ExecuteNonQuery();
                    }

                    // 4. Users tablosundan kullanıcıyı sil
                    string deleteUser = "DELETE FROM Users WHERE UserID = @UserID";
                    using (SqlCommand cmdUser = new SqlCommand(deleteUser, conn, transaction))
                    {
                        cmdUser.Parameters.AddWithValue("@UserID", userId.Value);
                        cmdUser.ExecuteNonQuery();
                    }
                }

                // 5. Employees tablosundan çalışanın kendisini sil
                string deleteEmployee = "DELETE FROM Employees WHERE EmployeeID = @EmployeeID";
                using (SqlCommand cmdEmp = new SqlCommand(deleteEmployee, conn, transaction))
                {
                    cmdEmp.Parameters.AddWithValue("@EmployeeID", employeeId);
                    cmdEmp.ExecuteNonQuery();
                }

                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
    }
    #endregion

    // Çalışan Detaylarını Getir
    // Employee detaylarını döner
    public Employee GetEmployeeById(int employeeId)
    {
        Employee employee = null;

        string query = @"
        SELECT e.EmployeeID, e.Name, e.Surname, e.Phone, e.Email, e.StartDate, e.Photo,
               e.Gender, e.BirthDate, e.RelativePhone, e.Address,
               e.DepartmentID, e.PositionID,                              -- EKLENDİ
               d.DepartmentName, p.PositionName
        FROM Employees e
        LEFT JOIN Departments d ON e.DepartmentID = d.DepartmentID
        LEFT JOIN Positions p ON e.PositionID = p.PositionID
        WHERE e.EmployeeID = @EmployeeID";

        using (SqlConnection conn = new SqlConnection(connectionString))
        using (SqlCommand cmd = new SqlCommand(query, conn))
        {
            cmd.Parameters.AddWithValue("@EmployeeID", employeeId);
            conn.Open();

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    employee = new Employee
                    {
                        EmployeeID = (int)reader["EmployeeID"],
                        Name = reader["Name"].ToString(),
                        Surname = reader["Surname"].ToString(),
                        Gender = reader["Gender"] == DBNull.Value ? null : reader["Gender"].ToString(),
                        BirthDate = reader["BirthDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["BirthDate"]),
                        Phone = reader["Phone"] == DBNull.Value ? null : reader["Phone"].ToString(),
                        RelativePhone = reader["RelativePhone"] == DBNull.Value ? null : reader["RelativePhone"].ToString(),
                        Address = reader["Address"] == DBNull.Value ? null : reader["Address"].ToString(),
                        Email = reader["Email"] == DBNull.Value ? null : reader["Email"].ToString(),
                        StartDate = reader["StartDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["StartDate"]),
                        Photo = reader["Photo"] == DBNull.Value ? null : (byte[])reader["Photo"],
                        DepartmentID = reader["DepartmentID"] == DBNull.Value ? 0 : Convert.ToInt32(reader["DepartmentID"]),   // EKLENDİ
                        PositionID = reader["PositionID"] == DBNull.Value ? 0 : Convert.ToInt32(reader["PositionID"]),         // EKLENDİ
                        DepartmentName = reader["DepartmentName"] == DBNull.Value ? null : reader["DepartmentName"].ToString(),
                        PositionName = reader["PositionName"] == DBNull.Value ? null : reader["PositionName"].ToString()
                    };
                }
            }
        }

        return employee;
    }

    #region cmbEmployeesFilter DOLDURMAK İÇİN SORGU VE LİSTE KODU
    public List<Employee> GetAllEmployees()
    {
        List<Employee> list = new List<Employee>();

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string query = @"
            SELECT EmployeeID, Name, Surname
            FROM Employees";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Employee
                        {
                            EmployeeID = Convert.ToInt32(reader["EmployeeID"]),
                            Name = reader["Name"].ToString(),
                            Surname = reader["Surname"].ToString()
                        });
                    }
                }
            }
        }

        return list;
    }
    #endregion

    #region EMPLOYEES VE USERS TABLOLARINA KAYIT EKLEYEN SORGU KODU
    public void AddEmployeeWithUser(string name, string surname, string gender, DateTime birthDate, int departmentId, int positionId,
             DateTime hireDate, DateTime? startDate, string phone, string relativePhone, string address, string email,
             string username, string passwordHash, int roleId, byte[] photo = null)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            SqlTransaction transaction = conn.BeginTransaction();

            try
            {
                string insertEmployeeQuery = @"
        INSERT INTO Employees (Name, Surname, Gender, BirthDate, DepartmentID, PositionID, HireDate, Phone, RelativePhone, Address, Email, StartDate, Photo)
        OUTPUT INSERTED.EmployeeID
        VALUES (@Name, @Surname, @Gender, @BirthDate, @DepartmentID, @PositionID, @HireDate, @Phone, @RelativePhone, @Address, @Email, @StartDate, @Photo)";

                SqlCommand cmdEmp = new SqlCommand(insertEmployeeQuery, conn, transaction);
                cmdEmp.Parameters.AddWithValue("@Name", name);
                cmdEmp.Parameters.AddWithValue("@Surname", surname);
                cmdEmp.Parameters.AddWithValue("@Gender", gender);
                cmdEmp.Parameters.AddWithValue("@BirthDate", birthDate);
                cmdEmp.Parameters.AddWithValue("@DepartmentID", departmentId);
                cmdEmp.Parameters.AddWithValue("@PositionID", positionId);
                cmdEmp.Parameters.AddWithValue("@HireDate", hireDate);
                cmdEmp.Parameters.AddWithValue("@Phone", phone);
                cmdEmp.Parameters.AddWithValue("@RelativePhone", relativePhone);
                cmdEmp.Parameters.AddWithValue("@Address", address);
                cmdEmp.Parameters.AddWithValue("@Email", email);

                if (startDate.HasValue)
                    cmdEmp.Parameters.AddWithValue("@StartDate", startDate.Value);
                else
                    cmdEmp.Parameters.AddWithValue("@StartDate", DBNull.Value);

                if (photo != null)
                    cmdEmp.Parameters.AddWithValue("@Photo", photo);
                else
                    cmdEmp.Parameters.AddWithValue("@Photo", DBNull.Value);

                int newEmployeeId = (int)cmdEmp.ExecuteScalar();

                string insertUserQuery = @"
        INSERT INTO Users (Username, PasswordHash, Email, IsActive, CreatedAt, RoleID, EmployeeID)
        OUTPUT INSERTED.UserID
        VALUES (@Username, @PasswordHash, @Email, 1, GETDATE(), @RoleID, @EmployeeID)";

                SqlCommand cmdUser = new SqlCommand(insertUserQuery, conn, transaction);
                cmdUser.Parameters.AddWithValue("@Username", username);
                cmdUser.Parameters.AddWithValue("@PasswordHash", passwordHash);
                cmdUser.Parameters.AddWithValue("@Email", email);
                cmdUser.Parameters.AddWithValue("@RoleID", roleId);
                cmdUser.Parameters.AddWithValue("@EmployeeID", newEmployeeId);

                int newUserId = (int)cmdUser.ExecuteScalar();

                string updateEmployeeQuery = "UPDATE Employees SET UserID = @UserID WHERE EmployeeID = @EmployeeID";
                SqlCommand cmdUpdateEmp = new SqlCommand(updateEmployeeQuery, conn, transaction);
                cmdUpdateEmp.Parameters.AddWithValue("@UserID", newUserId);
                cmdUpdateEmp.Parameters.AddWithValue("@EmployeeID", newEmployeeId);
                cmdUpdateEmp.ExecuteNonQuery();

                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
    }

    #endregion

    public DataTable GetRoles()
    {
        DataTable dt = new DataTable();
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string query = "SELECT RoleID, RoleName FROM Roles ORDER BY RoleID"; // <-- sıralama eklendi
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
        }
        return dt;
    }


    #region FOTOĞRAF BİLGİSİNİ GÜNCELLEYEN SORGU KODU
    // Fotoğraf Güncelle
    public void UpdateEmployeePhoto(int employeeId, byte[] photoBytes)
    {
        string query = "UPDATE Employees SET Photo = @Photo WHERE EmployeeID = @EmployeeID";

        using (SqlConnection conn = new SqlConnection(connectionString))
        using (SqlCommand cmd = new SqlCommand(query, conn))
        {
            cmd.Parameters.AddWithValue("@Photo", photoBytes);
            cmd.Parameters.AddWithValue("@EmployeeID", employeeId);

            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }
    #endregion

    #region DÖKÜMAN - BELGE YÜKLEYEN SORGU KODU
    // Belge Ekle
    public void AddEmployeeDocument(int employeeId, string documentName, string documentType, byte[] documentData)
    {
        string sql = "INSERT INTO EmployeeDocuments (EmployeeID, DocumentName, DocumentType, DocumentData) VALUES (@empId, @docName, @docType, @docData)";
        using (SqlConnection conn = new SqlConnection(connectionString))
        using (SqlCommand cmd = new SqlCommand(sql, conn))
        {
            cmd.Parameters.AddWithValue("@empId", employeeId);
            cmd.Parameters.AddWithValue("@docName", documentName);
            cmd.Parameters.AddWithValue("@docType", documentType);
            cmd.Parameters.AddWithValue("@docData", documentData);

            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }
    #endregion

    #region DÖKÜMAN - BELGE LİSTELEYEN SORGU KODU
    // Belge Listele
    public List<EmployeeDocument> GetEmployeeDocuments(int employeeId)
    {
        List<EmployeeDocument> docs = new List<EmployeeDocument>();
        string sql = "SELECT DocumentID, DocumentName, DocumentType FROM EmployeeDocuments WHERE EmployeeID = @empId";

        using (SqlConnection conn = new SqlConnection(connectionString))
        using (SqlCommand cmd = new SqlCommand(sql, conn))
        {
            cmd.Parameters.AddWithValue("@empId", employeeId);
            conn.Open();

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    docs.Add(new EmployeeDocument
                    {
                        DocumentID = reader.GetInt32(0),
                        DocumentName = reader.GetString(1),
                        DocumentType = reader.GetString(2)
                    });
                }
            }
        }
        return docs;
    }
    #endregion

    #region DÖKÜMAN - BELGE SİLEN SORGU KODU
    // Belge Sil
    public bool DeleteEmployeeDocument(int documentId)
    {
        string sql = "DELETE FROM EmployeeDocuments WHERE DocumentID = @id";
        using (SqlConnection conn = new SqlConnection(connectionString))
        using (SqlCommand cmd = new SqlCommand(sql, conn))
        {
            cmd.Parameters.AddWithValue("@id", documentId);
            conn.Open();
            return cmd.ExecuteNonQuery() > 0;
        }
    }
    #endregion

    #region KULLANICI ŞİFRE BİLGİSİNİ GÜNCELLEYEN SORGU KODU
    // Şifre Güncelle (Kullanıcıdan gelen hash)
    public bool UpdateUserPassword(int userId, string hashedPassword)
    {
        string query = "UPDATE Users SET PasswordHash = @PasswordHash WHERE UserID = @UserID";

        using (SqlConnection conn = new SqlConnection(connectionString))
        using (SqlCommand cmd = new SqlCommand(query, conn))
        {
            cmd.Parameters.AddWithValue("@PasswordHash", hashedPassword);
            cmd.Parameters.AddWithValue("@UserID", userId);
            conn.Open();

            return cmd.ExecuteNonQuery() > 0;
        }
    }
    // Hash Hesapla
    // Şifreyi SHA256 ile hashler, base64 döner
    public string ComputePasswordHash(string password)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] bytes = Encoding.UTF8.GetBytes(password);
            byte[] hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
    }
    #endregion

    #region İZİN TÜRLERİNİ LİSTELEYEN SORGU KODU
    // İzin Türlerini Listele
    public List<LeaveType> GetLeaveTypes()
    {
        var types = new List<LeaveType>();
        using (SqlConnection conn = new SqlConnection(connectionString))
        using (SqlCommand cmd = new SqlCommand("SELECT LeaveTypeID, LeaveTypeName FROM LeaveTypes", conn))
        {
            conn.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    types.Add(new LeaveType
                    {
                        LeaveTypeID = reader.GetInt32(0),
                        LeaveTypeName = reader.GetString(1)
                    });
                }
            }
        }
        return types;
    }
    #endregion

    #region İZİN TALEBİNİ İLGİLİ TABLOYA KAYIT EDEN SORGU KODU
    // İzin Talebi Gönder
    public bool SubmitLeaveRequest(LeaveRequest leaveRequest)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string query = @"INSERT INTO LeaveRequests (EmployeeID, LeaveTypeID, StartDate, EndDate, TotalDays, Reason, Status, RequestedDate) 
                         VALUES (@EmployeeID, @LeaveTypeID, @StartDate, @EndDate, @TotalDays, @Reason, @Status, @RequestedDate)";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@EmployeeID", leaveRequest.EmployeeID);
            cmd.Parameters.AddWithValue("@LeaveTypeID", leaveRequest.LeaveTypeID);
            cmd.Parameters.AddWithValue("@StartDate", leaveRequest.StartDate);
            cmd.Parameters.AddWithValue("@EndDate", leaveRequest.EndDate);
            cmd.Parameters.AddWithValue("@TotalDays", leaveRequest.TotalDays);
            cmd.Parameters.AddWithValue("@Reason", leaveRequest.Reason);
            cmd.Parameters.AddWithValue("@Status", leaveRequest.Status);
            cmd.Parameters.AddWithValue("@RequestedDate", leaveRequest.RequestedDate);

            conn.Open();
            int result = cmd.ExecuteNonQuery();
            return result > 0;
        }
    }
    #endregion

    #region BEKLEYEN İZİN TALEPLERİNİ SORGULAYIP EKRANA GETİREN SORGU KODU
    // Bekleyen Talepleri Listele
    public List<LeaveRequestViewModel> GetPendingLeaveRequests()
    {
        var list = new List<LeaveRequestViewModel>();
        string query = @"
            SELECT lr.LeaveRequestID, lr.EmployeeID, 
                   ISNULL(e.Name + ' ' + e.Surname, 'Bilinmeyen') AS EmployeeName, 
                   ISNULL(lt.LeaveTypeName, 'Tanımsız') AS LeaveTypeName,
                   lr.StartDate, lr.EndDate, lr.Reason, lr.RequestedDate, lr.Status
            FROM LeaveRequests lr
            LEFT JOIN Employees e ON lr.EmployeeID = e.EmployeeID
            LEFT JOIN LeaveTypes lt ON lr.LeaveTypeID = lt.LeaveTypeID
            WHERE LTRIM(RTRIM(lr.Status)) IN ('Pending', 'Beklemede')";

        using (SqlConnection conn = new SqlConnection(connectionString))
        using (SqlCommand cmd = new SqlCommand(query, conn))
        {
            conn.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    list.Add(new LeaveRequestViewModel
                    {
                        LeaveRequestID = reader.GetInt32(0),
                        EmployeeID = reader.GetInt32(1),
                        EmployeeName = reader.GetString(2),
                        LeaveTypeName = reader.GetString(3),
                        StartDate = reader.GetDateTime(4),
                        EndDate = reader.GetDateTime(5),
                        Reason = reader.GetString(6),
                        RequestedDate = reader.GetDateTime(7),
                        Status = reader.GetString(8)
                    });
                }
            }
        }

        return list;
    }
    #endregion

    #region İZİN TALEBİ ONAYLANDIKTAN VEYA RED EDİLDİKTEN SONRA İLGİLİ TABLODA DURUM DEĞİŞTİREN SORGU KODU
    // İzin Onayla
    public bool ApproveLeaveRequest(int leaveRequestId, int approvedByUserId)
    {
        string query = @"UPDATE LeaveRequests SET Status = 'Approved', ApprovedBy = @approvedBy, ApprovalDate = GETDATE()
                         WHERE LeaveRequestID = @leaveRequestId AND LTRIM(RTRIM(Status)) IN ('Pending', 'Beklemede')";

        using (SqlConnection conn = new SqlConnection(connectionString))
        using (SqlCommand cmd = new SqlCommand(query, conn))
        {
            cmd.Parameters.AddWithValue("@approvedBy", approvedByUserId);
            cmd.Parameters.AddWithValue("@leaveRequestId", leaveRequestId);

            conn.Open();
            return cmd.ExecuteNonQuery() > 0;
        }
    }
    // İzin Reddet
    public bool RejectLeaveRequest(int leaveRequestId, int rejectedByUserId)
    {
        string query = @"UPDATE LeaveRequests SET Status = 'Rejected', ApprovedBy = @rejectedBy, ApprovalDate = GETDATE()
                         WHERE LeaveRequestID = @leaveRequestId AND LTRIM(RTRIM(Status)) IN ('Pending', 'Beklemede')";

        using (SqlConnection conn = new SqlConnection(connectionString))
        using (SqlCommand cmd = new SqlCommand(query, conn))
        {
            cmd.Parameters.AddWithValue("@rejectedBy", rejectedByUserId);
            cmd.Parameters.AddWithValue("@leaveRequestId", leaveRequestId);

            conn.Open();
            return cmd.ExecuteNonQuery() > 0;
        }
    }
    #endregion

    public bool ValidateUserPassword(int userId, string hashedPassword)
    {
        string query = "SELECT COUNT(*) FROM Users WHERE UserID = @UserID AND PasswordHash = @PasswordHash";

        using (SqlConnection conn = new SqlConnection(connectionString))
        using (SqlCommand cmd = new SqlCommand(query, conn))
        {
            cmd.Parameters.AddWithValue("@UserID", userId);
            cmd.Parameters.AddWithValue("@PasswordHash", hashedPassword);
            conn.Open();

            int count = (int)cmd.ExecuteScalar();
            return count > 0;
        }
    }


    public Employee GetEmployeeByUsername(string username)
    {
        Employee employee = null;

        string query = @"
            SELECT u.UserID, e.EmployeeID, e.Name, e.Surname, e.Phone, e.Email, e.StartDate, e.Photo,
                   d.DepartmentName, p.PositionName
            FROM Users u
            INNER JOIN Employees e ON u.EmployeeID = e.EmployeeID
            LEFT JOIN Departments d ON e.DepartmentID = d.DepartmentID
            LEFT JOIN Positions p ON e.PositionID = p.PositionID
            WHERE u.Username = @Username";

        using (SqlConnection conn = new SqlConnection(connectionString))
        using (SqlCommand cmd = new SqlCommand(query, conn))
        {
            cmd.Parameters.AddWithValue("@Username", username);
            conn.Open();

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    employee = new Employee
                    {
                        UserID = reader["UserID"] != DBNull.Value ? Convert.ToInt32(reader["UserID"]) : -1,
                        EmployeeID = reader["EmployeeID"] != DBNull.Value ? Convert.ToInt32(reader["EmployeeID"]) : -1,
                        Name = reader["Name"].ToString(),
                        Surname = reader["Surname"].ToString(),
                        Phone = reader["Phone"] == DBNull.Value ? null : reader["Phone"].ToString(),
                        Email = reader["Email"] == DBNull.Value ? null : reader["Email"].ToString(),
                        StartDate = reader["StartDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["StartDate"]),
                        Photo = reader["Photo"] == DBNull.Value ? null : (byte[])reader["Photo"],
                        DepartmentName = reader["DepartmentName"] == DBNull.Value ? null : reader["DepartmentName"].ToString(),
                        PositionName = reader["PositionName"] == DBNull.Value ? null : reader["PositionName"].ToString()
                    };
                }
            }
        }

        return employee;
    }

    public int GetTotalEmployeeCount()
    {
        int count = 0;
        string query = "SELECT COUNT(*) FROM Employees";

        using (SqlConnection conn = new SqlConnection(connectionString))
        using (SqlCommand cmd = new SqlCommand(query, conn))
        {
            conn.Open();
            count = (int)cmd.ExecuteScalar();
        }
        return count;
    }

    public Dictionary<string, int> GetEmployeeCountByDepartment()
    {
        var dict = new Dictionary<string, int>();
        string query = @"
        SELECT d.DepartmentName, COUNT(e.EmployeeID) AS EmployeeCount
        FROM Employees e
        LEFT JOIN Departments d ON e.DepartmentID = d.DepartmentID
        GROUP BY d.DepartmentName
        ORDER BY EmployeeCount DESC";

        using (SqlConnection conn = new SqlConnection(connectionString))
        using (SqlCommand cmd = new SqlCommand(query, conn))
        {
            conn.Open();
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    string dept = reader["DepartmentName"]?.ToString() ?? "Bilinmeyen";
                    int count = Convert.ToInt32(reader["EmployeeCount"]);
                    dict.Add(dept, count);
                }
            }
        }

        return dict;
    }

    public int AddEvaluationAndReturnId(int employeeId, int evaluatorId, int score, string comment, DateTime date)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string query = @"INSERT INTO Evaluations (EmployeeID, EvaluatorID, Score, Comment, EvaluationDate)
                         OUTPUT INSERTED.EvaluationID
                         VALUES (@EmployeeID, @EvaluatorID, @Score, @Comment, @EvaluationDate)";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@EmployeeID", employeeId);
                cmd.Parameters.AddWithValue("@EvaluatorID", evaluatorId);
                cmd.Parameters.AddWithValue("@Score", score);
                cmd.Parameters.AddWithValue("@Comment", comment);
                cmd.Parameters.AddWithValue("@EvaluationDate", date);

                conn.Open();
                return (int)cmd.ExecuteScalar(); // Yeni ID'yi döndür
            }
        }
    }


    #region VERİTABANINDAKİ PERFORMANCEDOCUMENTS DEKİ VERİLERİ SİLEN KOD BLOĞU
    public void DeletePerformanceDocumentsByEvaluationId(int evaluationId)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string query = "DELETE FROM PerformanceDocuments WHERE EvaluationID = @EvaluationID";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@EvaluationID", evaluationId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
    #endregion

    #region VERİTABANINDAKİ PERFORMANCEDOCUMENTS DEKİ VERİLERİ OKUYAN KOD BLOĞU
    public List<DocumentItem> GetPerformanceDocuments(int evaluationId)
    {
        var documents = new List<DocumentItem>();

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string query = @"SELECT DocumentID, DocumentName, FileType 
                         FROM PerformanceDocuments 
                         WHERE EvaluationID = @EvaluationID";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@EvaluationID", evaluationId);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        documents.Add(new DocumentItem
                        {
                            DocumentID = reader.GetInt32(0),
                            DocumentName = reader.GetString(1),
                            FileType = reader.GetString(2)
                        });
                    }
                }
            }
        }

        return documents;
    }
    #endregion

    #region VERİTABANINDAKİ PERFORMANCEDECOUMENTS TABLOSUNA VERİ EKLEYEN KOD BLOĞU
    public bool AddPerformanceDocument(int evaluationId, string documentName, string fileType, byte[] fileData, DateTime uploadedDate)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string query = @"INSERT INTO PerformanceDocuments 
                         (EvaluationID, DocumentName, FileType, FileData, UploadedDate) 
                         VALUES (@EvaluationID, @DocumentName, @FileType, @FileData, @UploadedDate)";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@EvaluationID", evaluationId);
                cmd.Parameters.AddWithValue("@DocumentName", documentName);
                cmd.Parameters.AddWithValue("@FileType", fileType);
                cmd.Parameters.AddWithValue("@FileData", fileData);
                cmd.Parameters.AddWithValue("@UploadedDate", uploadedDate);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }
    }
    #endregion

    #region VERİTABANINDAKİ EVALUATIONS TABLOSUNA VERİ EKLEYEN VE OKUYAN KOD BLOĞU
    public bool AddEvaluation(int employeeId, int evaluatorId, int score, string comment, DateTime evaluationDate)
    {
        string query = @"INSERT INTO Evaluations 
                     (EmployeeID, EvaluatorID, Score, Comment, EvaluationDate)
                     VALUES (@EmployeeID, @EvaluatorID, @Score, @Comment, @EvaluationDate)";

        using (SqlConnection conn = new SqlConnection(connectionString))
        using (SqlCommand cmd = new SqlCommand(query, conn))
        {
            cmd.Parameters.AddWithValue("@EmployeeID", employeeId);
            cmd.Parameters.AddWithValue("@EvaluatorID", evaluatorId);
            cmd.Parameters.AddWithValue("@Score", score);
            cmd.Parameters.AddWithValue("@Comment", comment);
            cmd.Parameters.AddWithValue("@EvaluationDate", evaluationDate);  // Buraya dikkat!

            conn.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
            return rowsAffected > 0;
        }
    }
    public DataTable GetEvaluations()
    {
        DataTable dt = new DataTable();

        string query = @"
                SELECT ev.EvaluationID, ev.EmployeeID, e.Name + ' ' + e.Surname AS EmployeeName,
                ev.EvaluatorID, ev.Score, ev.Comment, ev.EvaluationDate
                FROM Evaluations ev
                INNER JOIN Employees e ON ev.EmployeeID = e.EmployeeID
                ORDER BY ev.EvaluationDate DESC";

        using (SqlConnection conn = new SqlConnection(connectionString))
        using (SqlCommand cmd = new SqlCommand(query, conn))
        {
            conn.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                dt.Load(reader);
            }
        }

        return dt;
    }
    #endregion

    #region VERİTABANINDAKİ EVALUATIONS TABLOSUNA EKLENEN VERİYİ SİLEN KOD BLOĞU
    public bool DeleteEvaluation(int evaluationId)
    {
        string query = "DELETE FROM Evaluations WHERE EvaluationID = @EvaluationID";

        using (SqlConnection conn = new SqlConnection(connectionString))
        using (SqlCommand cmd = new SqlCommand(query, conn))
        {
            cmd.Parameters.AddWithValue("@EvaluationID", evaluationId);
            conn.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
            return rowsAffected > 0;
        }
    }
    #endregion

    #region VERİTABANINDAKİ EVALUATIONS TABLOSUNDA SCORE BİLGİSİNİ ALAN KOD BLOĞU
    public DataTable GetEvaluationsByEmployee(int employeeId)
    {
        DataTable dt = new DataTable();

        string query = @"
        SELECT EvaluationDate, Score
        FROM Evaluations
        WHERE EmployeeID = @EmployeeID
        ORDER BY EvaluationDate ASC";

        using (SqlConnection conn = new SqlConnection(connectionString))
        using (SqlCommand cmd = new SqlCommand(query, conn))
        {
            cmd.Parameters.AddWithValue("@EmployeeID", employeeId);
            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {
                adapter.Fill(dt);
            }
        }

        return dt;
    }
    #endregion

    #region VERİTABANINDAKİ PERFORMANCEDOCUMENTSDEN DOCUMENTID ALAN VE ALDIĞI ID İLE İLGİLİ TABLODAN VERİYİ GETİREN KOD BLOĞU
    public byte[] GetPerformanceDocumentData(int documentId)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string query = "SELECT FileData FROM PerformanceDocuments WHERE DocumentID = @DocumentID";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@DocumentID", documentId);
                conn.Open();
                var result = cmd.ExecuteScalar();
                return result as byte[];
            }
        }
    }
    public DocumentItem GetPerformanceDocumentInfo(int documentId)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string query = "SELECT DocumentName, FileType FROM PerformanceDocuments WHERE DocumentID = @DocumentID";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@DocumentID", documentId);
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new DocumentItem
                        {
                            DocumentID = documentId,
                            DocumentName = reader["DocumentName"].ToString(),
                            FileType = reader["FileType"].ToString()
                        };
                    }
                }
            }
        }
        return null;
    }
    #endregion

    public Evaluation GetEvaluationById(int evaluationId)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string query = @"SELECT EvaluationID, EmployeeID, EvaluatorID, Score, Comment, EvaluationDate 
                         FROM Evaluations WHERE EvaluationID = @EvaluationID";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@EvaluationID", evaluationId);
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Evaluation
                        {
                            EvaluationID = (int)reader["EvaluationID"],
                            EmployeeID = (int)reader["EmployeeID"],
                            EvaluatorID = (int)reader["EvaluatorID"],
                            Score = (int)reader["Score"],
                            Comment = reader["Comment"].ToString(),
                            EvaluationDate = Convert.ToDateTime(reader["EvaluationDate"])
                        };
                    }
                }
            }
        }
        return null;
    }
    public bool UpdateEvaluation(int evaluationId, int employeeId, int score, string comment, DateTime evaluationDate)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string query = @"UPDATE Evaluations
                         SET EmployeeID = @EmployeeID,
                             Score = @Score,
                             Comment = @Comment,
                             EvaluationDate = @EvaluationDate
                         WHERE EvaluationID = @EvaluationID";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@EmployeeID", employeeId);
                cmd.Parameters.AddWithValue("@Score", score);
                cmd.Parameters.AddWithValue("@Comment", comment);
                cmd.Parameters.AddWithValue("@EvaluationDate", evaluationDate);
                cmd.Parameters.AddWithValue("@EvaluationID", evaluationId);

                conn.Open();
                int affectedRows = cmd.ExecuteNonQuery();
                return affectedRows > 0;
            }
        }
    }

    public DataTable GetPerformanceRecords(int employeeId, DateTime startDate, DateTime endDate)
    {
        DataTable dt = new DataTable();

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string query = @"SELECT e.Name + ' ' + e.Surname AS [Personel],
                                ev.Score AS [Puan],
                                ev.Comment AS [Açıklama],
                                ev.EvaluationDate AS [Tarih]
                         FROM Evaluations ev
                         INNER JOIN Employees e ON ev.EmployeeID = e.EmployeeID
                         WHERE ev.EvaluationDate BETWEEN @StartDate AND @EndDate
                           AND ev.EmployeeID = @EmployeeID
                         ORDER BY ev.EvaluationDate DESC";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@StartDate", startDate);
                cmd.Parameters.AddWithValue("@EndDate", endDate);
                cmd.Parameters.AddWithValue("@EmployeeID", employeeId);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
        }

        return dt;
    }
    public List<Employee> GetEmployeesWithPerformanceBetween(DateTime startDate, DateTime endDate)
    {
        List<Employee> employees = new List<Employee>();

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string query = @"
            SELECT DISTINCT e.EmployeeID, e.Name, e.Surname
            FROM Employees e
            INNER JOIN Evaluations ev ON e.EmployeeID = ev.EmployeeID
            WHERE ev.EvaluationDate BETWEEN @StartDate AND @EndDate
            ORDER BY e.Name, e.Surname";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@StartDate", startDate);
                cmd.Parameters.AddWithValue("@EndDate", endDate);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        employees.Add(new Employee
                        {
                            EmployeeID = (int)reader["EmployeeID"],
                            Name = reader["Name"].ToString(),
                            Surname = reader["Surname"].ToString()
                        });
                    }
                }
            }
        }
        return employees;
    }



}
