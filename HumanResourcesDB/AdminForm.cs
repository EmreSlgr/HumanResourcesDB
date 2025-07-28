using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using System.Windows.Forms;

namespace HumanResourcesDB
{
    public partial class AdminForm : Form
    {
        EmployeeDataAccess employeeData;
        private int currentEmployeeId;
        private int currentUserId;
        private int userId;
        private int employeeId;
        private string username;
        string dokumanlarKlasoru = @"C:\Users\emres\source\repos\HumanResourcesDB\dokumanlarKlasoru"; // Dosya yolun

        public AdminForm(int userId, int employeeId, string username, int roleId)
        {
            InitializeComponent();
            // Timer ayarı
            timerDashboardRefresh.Interval = 30000; // 30 saniye (milisaniye)
            timerDashboardRefresh.Tick += TimerDashboardRefresh_Tick;
            timerDashboardRefresh.Start();
            LoadDashboardData();
            lstAnnouncements.DoubleClick += LstAnnouncements_DoubleClick;
            employeeData = new EmployeeDataAccess();
            btnDeleteDocument.Click += btnDeleteDocument_Click;
            picEmployeePhoto.SizeMode = PictureBoxSizeMode.Zoom;
            dgvEmployees.AllowUserToAddRows = false;
            this.userId = userId;
            this.employeeId = employeeId;
            this.username = username;
            this.currentUserId = userId;
            this.StartPosition = FormStartPosition.CenterScreen;

            switch (roleId)
            {
                case 1: // Admin
                    btnAdd.Enabled = true;
                    btnDelete.Enabled = true;
                    btnUploadPhoto.Enabled = true;
                    break;
                case 2: // HR
                    btnAdd.Enabled = true;
                    btnDelete.Enabled = false;
                    btnUploadPhoto.Enabled = true;
                    break;
                case 3: // Employee
                    btnAdd.Enabled = false;
                    btnDelete.Enabled = false;
                    btnUploadPhoto.Enabled = false;
                    break;
            }

            lblWelcome.Text = $"Hoş geldin, {username}!";

            LoadDepartments();
            LoadPositions();
            LoadEmployees();
            LoadRolesToCombo();

            dgvEmployees.SelectionChanged += DgvEmployees_SelectionChanged;
            btnAdd.Click += BtnAdd_Click;
            btnUpdate.Click += BtnUpdate_Click;
            btnDelete.Click += BtnDelete_Click;
            btnUploadPhoto.Click += BtnUploadPhoto_Click;
            btnUploadDocument.Click += BtnUploadDocument_Click;

        }

        private void TimerDashboardRefresh_Tick(object sender, EventArgs e)
        {
            LoadDashboardData();
        }
        private void AdminForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            timerDashboardRefresh.Stop();
        }

        #region cmbRole İÇERİSİNE ROL BİLGİLERİNİ YÜKLEYEN KOD
        private void LoadRolesToCombo()
        {
            DataTable roles = employeeData.GetRoles(); // employeeData içinde yukarıdaki GetRoles olmalı
            cmbRole.DataSource = roles;
            cmbRole.DisplayMember = "RoleName";
            cmbRole.ValueMember = "RoleID";
            cmbRole.SelectedIndex = -1;
        }
        #endregion

        #region cmbDepartment İÇERİSİNE DEPARTMAN BİLGİLERİNİ YÜKLEYEN KOD
        private void LoadDepartments()
        {
            cmbDepartment.Items.Clear();
            cmbDepartment.Items.Add(new ComboBoxItem(1, "İnsan Kaynakları"));
            cmbDepartment.Items.Add(new ComboBoxItem(2, "Finans"));
            cmbDepartment.Items.Add(new ComboBoxItem(3, "IT"));
            cmbDepartment.SelectedIndex = 0;
        }
        #endregion

        #region cmbPosition İÇERİSİNE POZİSYON BİLGİLERİ YÜKLEYEN KOD
        private void LoadPositions()
        {
            cmbPosition.Items.Clear();
            cmbPosition.Items.Add(new ComboBoxItem(1, "Uzman"));
            cmbPosition.Items.Add(new ComboBoxItem(2, "Müdür"));
            cmbPosition.Items.Add(new ComboBoxItem(3, "Yönetici"));
            cmbPosition.SelectedIndex = 0;
        }
        #endregion

        #region pnlDashboard İÇİNDEKİ ÖZELLİKLERİ SORGULAYAN VE EKRANA GETİREN KOD
        private void LoadDashboardData()
        {
            string connStr = ConfigurationManager.ConnectionStrings["HRDbConnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                // Aktif personel sayısı
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Users WHERE IsActive = 1", conn))
                {
                    lblActiveEmployees.Text = "Aktif Personel: " + cmd.ExecuteScalar().ToString();
                }

                // Bugün izinli personel sayısı
                using (SqlCommand cmd = new SqlCommand(
                    "SELECT COUNT(DISTINCT EmployeeID) FROM LeaveRequests WHERE Status = 'Approved' AND @Today BETWEEN StartDate AND EndDate", conn))
                {
                    cmd.Parameters.AddWithValue("@Today", DateTime.Today);
                    lblEmployeesOnLeave.Text = "Bugün İzinli: " + cmd.ExecuteScalar().ToString();
                }

                // Bugün izinli personelleri listbox'a ekle
                using (SqlCommand cmd = new SqlCommand(
                    @"SELECT E.Name, E.Surname 
              FROM LeaveRequests LR
              INNER JOIN Employees E ON LR.EmployeeID = E.EmployeeID
              WHERE LR.Status = 'Approved'
              AND @Today BETWEEN LR.StartDate AND LR.EndDate", conn))
                {
                    cmd.Parameters.AddWithValue("@Today", DateTime.Today);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        listBoxTodayOnLeave.Items.Clear();
                        while (reader.Read())
                        {
                            string fullName = reader.GetString(0) + " " + reader.GetString(1);
                            listBoxTodayOnLeave.Items.Add(fullName);
                        }
                    }
                }

                // Bugün doğum günü olanlar
                using (SqlCommand cmd = new SqlCommand(
                    "SELECT Name, Surname FROM Employees WHERE MONTH(BirthDate) = @Month AND DAY(BirthDate) = @Day", conn))
                {
                    cmd.Parameters.AddWithValue("@Month", DateTime.Today.Month);
                    cmd.Parameters.AddWithValue("@Day", DateTime.Today.Day);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        lstBirthdayToday.Items.Clear();
                        while (reader.Read())
                        {
                            string fullName = reader.GetString(0) + " " + reader.GetString(1);
                            lstBirthdayToday.Items.Add(fullName);
                        }
                    }
                }

                // Bekleyen izin talepleri sayısı
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM LeaveRequests WHERE Status = 'Pending'", conn))
                {
                    lblPendingLeaves.Text = "Bekleyen İzin Talepleri: " + cmd.ExecuteScalar().ToString();
                }

                // Son 5 duyuru
                using (SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT TOP 5 NotificationID, Title FROM Notifications ORDER BY Date DESC", conn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    lstAnnouncements.DisplayMember = "Title";
                    lstAnnouncements.ValueMember = "NotificationID";
                    lstAnnouncements.DataSource = dt;
                }
            }
        }
        #endregion

        #region LstAnnouncements DE İLGİLİ DUYURUYA TIKLAYINCA EKRANA GETİREN KOD
        private void LstAnnouncements_DoubleClick(object sender, EventArgs e)
        {
            if (lstAnnouncements.SelectedValue == null ||
                !int.TryParse(lstAnnouncements.SelectedValue.ToString(), out var notificationId))
            {
                MessageBox.Show("Geçersiz duyuru seçimi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string connStr = ConfigurationManager.ConnectionStrings["HRDbConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "SELECT Title, Content FROM Notifications WHERE NotificationID = @Id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", notificationId);
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string title = reader.GetString(0);
                            string content = reader.GetString(1);

                            using (NotificationDetailForm form = new NotificationDetailForm(title, content))
                            {
                                form.ShowDialog();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Duyuru bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }

        #endregion

        #region EMPLOYEEDATAACCESS DE OKUNAN ÇALIŞAN BİLGİLERİNİ dgvEmployees İÇERİSİNE GETİREN KOD
        private void LoadEmployees()
        {
            var dt = employeeData.GetEmployees();

            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("Veri bulunamadı veya yüklenemedi.");
                dgvEmployees.DataSource = null;
                return;
            }

            dgvEmployees.DataSource = dt;

            // Sütun başlıklarını Türkçe yap
            if (dgvEmployees.Columns["EmployeeID"] != null)
                dgvEmployees.Columns["EmployeeID"].Visible = false; // gizle

            if (dgvEmployees.Columns["Name"] != null)
                dgvEmployees.Columns["Name"].HeaderText = "Ad";

            if (dgvEmployees.Columns["Surname"] != null)
                dgvEmployees.Columns["Surname"].HeaderText = "Soyad";

            if (dgvEmployees.Columns["Gender"] != null)
                dgvEmployees.Columns["Gender"].HeaderText = "Cinsiyet";

            if (dgvEmployees.Columns["BirthDate"] != null)
                dgvEmployees.Columns["BirthDate"].HeaderText = "Doğum Tarihi";

            if (dgvEmployees.Columns["HireDate"] != null)
                dgvEmployees.Columns["HireDate"].HeaderText = "İşe Başlama Tarihi";

            if (dgvEmployees.Columns["Phone"] != null)
                dgvEmployees.Columns["Phone"].HeaderText = "Telefon";

            if (dgvEmployees.Columns["RelativePhone"] != null)
                dgvEmployees.Columns["RelativePhone"].HeaderText = "Yakını Telefon";

            if (dgvEmployees.Columns["Address"] != null)
                dgvEmployees.Columns["Address"].HeaderText = "Adres";

            if (dgvEmployees.Columns["Email"] != null)
                dgvEmployees.Columns["Email"].HeaderText = "E-Posta";
        }
        #endregion

        #region PERSONEL VE KULLANICI BİLGİLERİ EKLEYEN BUTON KODU
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            var selectedDept = (ComboBoxItem)cmbDepartment.SelectedItem;
            var selectedPos = (ComboBoxItem)cmbPosition.SelectedItem;
            var gender = cmbGender.SelectedItem?.ToString() ?? "Belirtilmedi";
            var birthDate = dtBirthDate.Value.Date;
            var hireDate = dtHireDate.Value.Date;

            DateTime? startDate = hireDate;

            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;
            string passwordHash = employeeData.ComputePasswordHash(password);
            int roleId = cmbRole.SelectedIndex + 1;

            // Fotoğrafı byte[] dizisine çevir
            byte[] photoData = null;
            if (picEmployeePhoto.Image != null)
            {
                using (var ms = new System.IO.MemoryStream())
                {
                    picEmployeePhoto.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    photoData = ms.ToArray();
                }
            }

            employeeData.AddEmployeeWithUser(
                txtName.Text.Trim(),
                txtSurname.Text.Trim(),
                gender,
                birthDate,
                selectedDept.Id,
                selectedPos.Id,
                hireDate,
                startDate,
                txtPhone.Text.Trim(),
                txtRelativePhone.Text.Trim(),
                txtAddress.Text.Trim(),
                txtEmail.Text.Trim(),
                username,
                passwordHash,
                roleId,
                photoData  // Fotoğraf parametresi eklendi
            );

            LoadEmployees();
            ClearInputs();
            MessageBox.Show("Personel ve kullanıcı hesabı eklendi.");
        }

        #endregion

        #region PERSONEL BİLGİLERİ GÜNCELLEYEN BUTON KODU
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvEmployees.CurrentRow == null) return;

            int employeeId = Convert.ToInt32(dgvEmployees.CurrentRow.Cells["EmployeeID"].Value);
            var selectedDept = (ComboBoxItem)cmbDepartment.SelectedItem;
            var selectedPos = (ComboBoxItem)cmbPosition.SelectedItem;
            var gender = cmbGender.SelectedItem?.ToString() ?? "Belirtilmedi";
            var birthDate = dtBirthDate.Value.Date;
            var hireDate = dtHireDate.Value.Date;
            DateTime? startDate = hireDate;  // StartDate yoksa hireDate ile aynı olabilir

            string phone = txtPhone.Text.Trim();
            string relativePhone = txtRelativePhone.Text.Trim();
            string address = txtAddress.Text.Trim();
            string email = txtEmail.Text.Trim();

            // Güncelleme metodu çağrısı
            employeeData.UpdateEmployee(
                employeeId,
                txtName.Text.Trim(),
                txtSurname.Text.Trim(),
                gender,
                birthDate,
                selectedDept.Id,
                selectedPos.Id,
                hireDate,
                startDate,
                phone,
                relativePhone,
                address,
                email
            );

            // Fotoğraf güncelleme
            if (picEmployeePhoto.Image != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    picEmployeePhoto.Image.Save(ms, picEmployeePhoto.Image.RawFormat);
                    byte[] photoBytes = ms.ToArray();
                    employeeData.UpdateEmployeePhoto(employeeId, photoBytes);
                }
            }

            LoadEmployees();
            ClearInputs();
            MessageBox.Show("Personel güncellendi.");
        }
        #endregion

        #region PERSONEL BİLGİLERİ SİLEN BUTON KODU
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvEmployees.CurrentRow == null) return;

            int employeeId = Convert.ToInt32(dgvEmployees.CurrentRow.Cells["EmployeeID"].Value);

            var result = MessageBox.Show("Silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                employeeData.DeleteEmployee(employeeId);
                LoadEmployees();
                ClearInputs();
                MessageBox.Show("Personel silindi.");
            }
        }
        #endregion

        #region İLGİLİ PERSONELİ FOTOĞRAF YÜKLEME İÇİN KULLANILAN BUTON KODU
        private void BtnUploadPhoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Fotoğraf Seç";
            ofd.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.bmp";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                picEmployeePhoto.Image = System.Drawing.Image.FromFile(ofd.FileName);
            }
        }
        #endregion

        #region İLGİLİ PERSONELE DÖKÜMAN EKLEME BUTONU KODU
        private void BtnUploadDocument_Click(object sender, EventArgs e)
        {
            if (dgvEmployees.CurrentRow == null)
                return;

            int employeeId = Convert.ToInt32(dgvEmployees.CurrentRow.Cells["EmployeeID"].Value);

            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Belge Seç";
                ofd.Filter = "Tüm Dosyalar|*.*";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    byte[] fileBytes = File.ReadAllBytes(ofd.FileName);
                    string fileName = Path.GetFileName(ofd.FileName);
                    string fileType = Path.GetExtension(ofd.FileName); // örn: ".pdf", ".docx"

                    employeeData.AddEmployeeDocument(employeeId, fileName, fileType, fileBytes);

                    LoadEmployeeDocuments(employeeId);

                    MessageBox.Show("Belge yüklendi.");
                }
            }
        }
        #endregion

        private void DgvEmployees_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvEmployees.CurrentRow != null)
            {
                currentEmployeeId = Convert.ToInt32(dgvEmployees.CurrentRow.Cells["EmployeeID"].Value);
                ShowEmployeeDetails(currentEmployeeId);
                LoadEmployeeDocuments(currentEmployeeId); // lstBoxDocuments doldurulacak

                txtName.Text = dgvEmployees.CurrentRow.Cells["Name"].Value.ToString();
                txtSurname.Text = dgvEmployees.CurrentRow.Cells["Surname"].Value.ToString();
            }
        }

        private void ShowEmployeeDetails(int employeeId)
        {
            var employee = employeeData.GetEmployeeById(employeeId);
            if (employee != null)
            {
                // Label'lar
                lblEmployeeFullName.Text = $"{employee.Name} {employee.Surname}";
                lblEmployeePosition.Text = employee.PositionName ?? "";
                lblEmployeeDepartment.Text = employee.DepartmentName ?? "";
                lblEmployeePhone.Text = employee.Phone ?? "";
                lblEmployeeEmail.Text = employee.Email ?? "";
                lblEmployeeStartDate.Text = employee.StartDate?.ToShortDateString() ?? "";

                // TextBox ve diğer kontroller
                txtName.Text = employee.Name ?? "";
                txtSurname.Text = employee.Surname ?? "";
                txtPhone.Text = employee.Phone ?? "";
                txtRelativePhone.Text = employee.RelativePhone ?? "";
                txtEmail.Text = employee.Email ?? "";
                txtAddress.Text = employee.Address ?? "";

                // Gender ComboBox (Güvenli karşılaştırma)
                foreach (var item in cmbGender.Items)
                {
                    if (item.ToString() == employee.Gender)
                    {
                        cmbGender.SelectedItem = item;
                        break;
                    }
                }

                // DateTimePicker'lar
                dtBirthDate.Value = employee.BirthDate ?? DateTime.Today;
                dtHireDate.Value = employee.StartDate ?? DateTime.Today;

                // Department ve Position ComboBox'ları
                SelectComboBoxItemById(cmbDepartment, employee.DepartmentID);
                SelectComboBoxItemById(cmbPosition, employee.PositionID);

                // Fotoğraf
                if (employee.Photo != null && employee.Photo.Length > 0)
                {
                    using (MemoryStream ms = new MemoryStream(employee.Photo))
                    {
                        picEmployeePhoto.Image = System.Drawing.Image.FromStream(ms);
                    }
                }
                else
                {
                    picEmployeePhoto.Image = null;
                }
            }
            else
            {
                // Alanları temizle
                lblEmployeeFullName.Text = "";
                lblEmployeePosition.Text = "";
                lblEmployeeDepartment.Text = "";
                lblEmployeePhone.Text = "";
                lblEmployeeEmail.Text = "";
                lblEmployeeStartDate.Text = "";
                picEmployeePhoto.Image = null;

                txtName.Clear();
                txtSurname.Clear();
                txtPhone.Clear();
                txtRelativePhone.Clear();
                txtEmail.Clear();
                txtAddress.Clear();
                cmbGender.SelectedIndex = 0;
                dtBirthDate.Value = DateTime.Today;
                dtHireDate.Value = DateTime.Today;
            }
        }



        private void SelectComboBoxItemById(ComboBox comboBox, int id)
        {
            foreach (ComboBoxItem item in comboBox.Items)
            {
                if (item.Id == id)
                {
                    comboBox.SelectedItem = item;
                    break;
                }
            }
        }

        private void ClearInputs()
        {
            txtName.Clear();
            txtSurname.Clear();
            txtPhone.Clear();
            txtRelativePhone.Clear();
            txtAddress.Clear();
            txtEmail.Clear();
            cmbGender.SelectedIndex = 0;
            cmbDepartment.SelectedIndex = 0;
            cmbPosition.SelectedIndex = 0;
            dtBirthDate.Value = DateTime.Today;
            dtHireDate.Value = DateTime.Today;
            picEmployeePhoto.Image = null;
        }

        private void LoadEmployeeDocuments(int employeeId)
        {
            lstBoxDocuments.Items.Clear();
            var documents = employeeData.GetEmployeeDocuments(employeeId);

            foreach (var doc in documents)
            {
                lstBoxDocuments.Items.Add(new DocumentItem
                {
                    DocumentID = doc.DocumentID,     // EmployeeDocument'deki ID property'si
                    DocumentName = doc.DocumentName  // veya uygun isim alanı
                });
            }
        }
        private void btnDeleteDocument_Click(object sender, EventArgs e)
        {
            if (lstBoxDocuments.SelectedItem == null)
            {
                MessageBox.Show("Lütfen silmek istediğiniz belgeyi seçin.");
                return;
            }

            var selectedDoc = (DocumentItem)lstBoxDocuments.SelectedItem;
            int documentId = selectedDoc.DocumentID;

            var confirm = MessageBox.Show("Belgeyi silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                bool deleted = employeeData.DeleteEmployeeDocument(documentId);
                if (deleted)
                {
                    MessageBox.Show("Belge başarıyla silindi.");
                    LoadEmployeeDocuments(currentEmployeeId); // Güncelleme için mevcut çalışan ID'si
                }
                else
                {
                    MessageBox.Show("Belge silinirken hata oluştu.");
                }
            }
        }

        #region İZİN TALEPLERİ GÖSTEREN BUTON KODU

        // izin taleplerini gösteren buton kodları
        private void btnLeaveApprovalForm_Click(object sender, EventArgs e)
        {
            this.Hide(); // AdminForm'u gizle
            using (LeaveApprovalForm form = new LeaveApprovalForm(userId))
            {
                form.ShowDialog(); // LeaveApprovalForm kapanınca devam eder
            }
            this.Show(); // AdminForm geri gösterilir
        }
        #endregion

        #region TXTPHONE MAKS 11 HANE KISITLAMA VE SADECE RAKAM KODU
        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Sadece rakamlara izin ver, kontrol tuşları da dahil (Backspace vb.)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // girişi engelle
            }

            // Maksimum 11 karakter sınırı
            TextBox txt = sender as TextBox;
            if (!char.IsControl(e.KeyChar) && txt.Text.Length >= 11)
            {
                e.Handled = true; // fazla karakteri engelle
            }
        }
        #endregion

        #region TXTRELATİVEPHONE MAKS 11 HANE KISITLAMA VE SADECE RAKAM KODU
        private void txtRelativePhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Sadece rakamlara izin ver, kontrol tuşları da dahil (Backspace vb.)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // girişi engelle
            }

            // Maksimum 11 karakter sınırı
            TextBox txt = sender as TextBox;
            if (!char.IsControl(e.KeyChar) && txt.Text.Length >= 11)
            {
                e.Handled = true; // fazla karakteri engelle
            }
        }
        #endregion

        #region PERSONEL SAYISI VE DEPARTMAN BAZLI DAĞILIM GRAFİK EKRANI GÖSTEREN BUTON KODU
        private void btnLoadEmployeeStatistics_Click(object sender, EventArgs e)
        {
            LoadEmployeeStatistics statsForm = new LoadEmployeeStatistics();

            // AdminForm gizle
            this.Hide();

            // İstatistik formu modal değil, kapandığında AdminForm tekrar gösterilecek
            statsForm.FormClosed += (s, args) =>
            {
                this.Show();
            };

            statsForm.Show();
        }



        #endregion

        #region İLGİLİ KULLANICIYA btnMessage_Click İLE MESAJ GÖNDERİM SAYFASINI AÇAN KOD
        private void btnMessage_Click(object sender, EventArgs e)
        {
            // Giriş yapan kullanıcının userId'si elinde olmalı
            int userId = currentUserId; // ya da sakladığın değişken

            // AdminForm'u gizle
            this.Hide();

            // Mesaj formunu oluştur
            Mesajlar mesajForm = new Mesajlar(userId);

            // Kapatıldığında tekrar AdminForm’u göster
            mesajForm.FormClosed += (s, args) => this.Show();

            // Formu göster
            mesajForm.Show();
        }
        #endregion

        public class ComboBoxItem
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public ComboBoxItem(int id, string name)
            {
                Id = id;
                Name = name;
            }

            public override string ToString()
            {
                return Name;
            }
        }

        private void btnContext_Click(object sender, EventArgs e)
        {
            NotificationSendForm notifForm = new NotificationSendForm();
            notifForm.ShowDialog();
        }

        private void btnPrintDocument_Click(object sender, EventArgs e)
        {
            if (lstBoxDocuments.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bir dosya seçin.");
                return;
            }

            string secilenDosyaAdi = lstBoxDocuments.SelectedItem.ToString();
            string tamDosyaYolu = Path.Combine(dokumanlarKlasoru, secilenDosyaAdi);

            if (!File.Exists(tamDosyaYolu))
            {
                MessageBox.Show("Dosya bulunamadı:\n" + tamDosyaYolu);
                return;
            }

            string dosyaIcerigi = File.ReadAllText(tamDosyaYolu);

            printDoc.PrintPage -= PrintDoc_PrintPage; // Önce varsa eski event iptal edilir
            printDoc.PrintPage += PrintDoc_PrintPage;

            void PrintDoc_PrintPage(object senderPrint, PrintPageEventArgs ePrint)
            {
                ePrint.Graphics.DrawString(dosyaIcerigi, new Font("Arial", 12), Brushes.Black, ePrint.MarginBounds.Left, ePrint.MarginBounds.Top);
            }

            printDialog.Document = printDoc;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDoc.Print();
            }
        }
    }
}
