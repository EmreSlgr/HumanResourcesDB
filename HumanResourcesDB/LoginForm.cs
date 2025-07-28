using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace HumanResourcesDB
{
    public partial class LoginForm : Form
    {
        EmployeeDataAccess employeeData = new EmployeeDataAccess();
        public int LoggedInUserId { get; private set; }
        public int LoggedInEmployeeId { get; private set; }
        public string LoggedInUsername { get; private set; }
        public int LoggedInRoleId { get; private set; }
        private Color loginButtonDefaultColor = Color.MediumSlateBlue;
        private Color loginButtonHoverColor = Color.SlateBlue;
        private Color loginButtonClickColor = Color.Indigo;

        public LoginForm()
        {
            InitializeComponent();
            btnLogin.Click += btnLogin_Click;
            employeeData.EnsureDefaultAdminExists();
            lblError.Visible = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormClosing += LoginForm_FormClosing;
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult != DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void btnLogin_MouseEnter(object sender, EventArgs e)
        {
            btnLogin.BackColor = loginButtonHoverColor;
        }

        private void btnLogin_MouseLeave(object sender, EventArgs e)
        {
            btnLogin.BackColor = loginButtonDefaultColor;
        }

        private void btnLogin_MouseDown(object sender, MouseEventArgs e)
        {
            btnLogin.BackColor = loginButtonClickColor;
        }

        private void btnLogin_MouseUp(object sender, MouseEventArgs e)
        {
            btnLogin.BackColor = loginButtonHoverColor;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;

            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;
            string hashedPassword = ComputeSha256Hash(password);

            string connectionString = ConfigurationManager.ConnectionStrings["HRDbConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = @"
            SELECT u.UserID, u.EmployeeID, u.RoleID, r.RoleName
            FROM Users u
            INNER JOIN Roles r ON u.RoleID = r.RoleID
            WHERE u.Username = @Username AND u.PasswordHash = @Password AND u.IsActive = 1";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", hashedPassword);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int userId = reader.GetInt32(reader.GetOrdinal("UserID"));
                            int employeeId = reader.IsDBNull(reader.GetOrdinal("EmployeeID")) ? -1 : reader.GetInt32(reader.GetOrdinal("EmployeeID"));
                            int roleId = reader.GetInt32(reader.GetOrdinal("RoleID"));
                            string roleName = reader.GetString(reader.GetOrdinal("RoleName"));

                            if (roleName == "Admin" || roleName == "HR Manager" || roleName == "Employee")
                            {
                                LoggedInUserId = userId;
                                LoggedInEmployeeId = employeeId;
                                LoggedInUsername = username;
                                LoggedInRoleId = roleId;

                                this.DialogResult = DialogResult.OK;
                                this.Close();
                            }
                            else
                            {
                                lblError.Text = "Yetkisiz rol ile giriş yapılamaz.";
                                lblError.Visible = true;
                            }
                        }
                        else
                        {
                            lblError.Text = "Kullanıcı adı veya şifre hatalı.";
                            lblError.Visible = true;
                        }
                    }
                }
            }
        }

        // SHA256 hash fonksiyonu
        private string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                return Convert.ToBase64String(bytes);
            }
        }
    }
}
