using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static HumanResourcesDB.AdminForm;

namespace HumanResourcesDB
{
    public partial class HRForm : Form
    {
        EmployeeDataAccess employeeData;
        private int currentEmployeeId;
        private int userId;
        private int employeeId;
        private string username;
        private int currentUserId;
        string dokumanlarKlasoru = @"C:\Users\emres\source\repos\HumanResourcesDB\dokumanlarKlasoru"; // Dosya yolun
        private List<PerformanceRecord> performanceRecords = new List<PerformanceRecord>();
        private Timer notificationTimer;
        private NotificationForm activeNotificationForm = null;
        public HRForm(EmployeeDataAccess employeeData, int userId, int employeeId, string username)
        {
            this.userId = userId;
            this.employeeId = employeeId;
            this.username = username;
            this.employeeData = employeeData;
            this.currentUserId = userId;
            this.FormClosing += HRForm_FormClosing;

            InitializeComponent();

            InitializeForm();
            LoadInitialData();
            AttachEventHandlers();

            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void InitializeForm()
        {
            picEmployeePhoto.SizeMode = PictureBoxSizeMode.Zoom;
            dgvEmployees.AllowUserToAddRows = false;
            dgvPerformance.SelectionChanged += dgvPerformance_SelectionChanged;
            cmbEmployeesPerformance.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPerformanceScore.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void LoadInitialData()
        {
            LoadDepartments();
            LoadPositions();
            LoadEmployees();
            LoadEmployeesToPerformanceCombo();
            RefreshPerformanceGrid();
            LoadExportFormats();
            LoadEmployeesToComboBox();
            LoadEmployeesToTrainingCombo();
            LoadStatusCombo();
            SetupNotificationTimer();
        }

        private void AttachEventHandlers()
        {
            btnAdd.Click += BtnAdd_Click;
            btnUpdate.Click += BtnUpdate_Click;
            btnDelete.Click += BtnDelete_Click;
            btnUploadPhoto.Click += BtnUploadPhoto_Click;
            btnUploadDocument.Click += BtnUploadDocument_Click;
            btnDeleteDocument.Click += BtnDeleteDocument_Click;
            btnPrintDocument.Click += BtnPrintDocument_Click;

            btnAddPerformance.Click += btnAddPerformance_Click;
            btnDeletePerformance.Click += btnDeletePerformance_Click;
            btnClearPerformance.Click += btnClearPerformance_Click;
            btnUpdatePerformance.Click += btnUpdatePerformance_Click;
            btnExport.Click += btnExport_Click;

            btnAddTraining.Click += btnAddTraining_Click;
            btnUpdateTraining.Click += btnUpdateTraining_Click;
            btnDeleteTraining.Click += btnDeleteTraining_Click;

            cmbEmployeesPerformance.SelectedIndexChanged += cmbEmployeesPerformance_SelectedIndexChanged;
            dgvEmployees.SelectionChanged += DgvEmployees_SelectionChanged;
            lstPerformanceDocuments.DoubleClick += lstPerformanceDocuments_DoubleClick;
            cmbEmployeesTraining.SelectedIndexChanged += cmbEmployeesTraining_SelectedIndexChanged;
            lstbxEmployeeTraining.SelectedIndexChanged += lstbxEmployeeTraining_SelectedIndexChanged;
        }

        private void LoadExportFormats()
        {
            cmbExportFormat.DataSource = Enum.GetValues(typeof(ExportFormat));
            cmbExportFormat.SelectedIndex = -1; // seçili olmasın
            cmbEmployeesFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbExportFormat.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        #region employeeData DAKİ GetEmployees İLE VT DEN ÇEKİLEN BİLGİLERİ cmbEmployeesPerformance YANSITAN KOD
        private void LoadEmployeesToPerformanceCombo()
        {
            DataTable dt = employeeData.GetEmployees();

            // Yeni "FullName" sütunu ekle
            if (!dt.Columns.Contains("FullName"))
                dt.Columns.Add("FullName", typeof(string));

            foreach (DataRow row in dt.Rows)
            {
                row["FullName"] = row["Name"].ToString() + " " + row["Surname"].ToString();
            }

            cmbEmployeesPerformance.DataSource = dt;
            cmbEmployeesPerformance.DisplayMember = "FullName";
            cmbEmployeesPerformance.ValueMember = "EmployeeID";
            cmbEmployeesPerformance.SelectedIndex = -1;
        }
        #endregion

        #region EĞİTİM VE SERTİFİKALAR SEKMESİNDEKİ cmbStatus DOLDURAN KOD
        private void LoadStatusCombo()
        {
            cmbStatus.Items.Clear();

            cmbStatus.Items.Add("Devam Ediyor (Eğitim/sertifika henüz tamamlanmamış)");
            cmbStatus.Items.Add("Tamamlandı (Eğitim/sertifika başarıyla bitirildi)");
            cmbStatus.Items.Add("Başarısız (Eğitim tamamlandı ama başarılı olunamadı)");
            cmbStatus.Items.Add("İptal Edildi (Eğitime katılım veya sertifika süreci iptal oldu)");
            cmbStatus.Items.Add("Beklemede (Eğitim veya sertifika planlandı ama henüz başlamadı)");

            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList; // Sadece seçim, serbest yazma yok
        }
        #endregion

        #region cmbDepartment İÇERİĞİNİ DOLDURAN KOD
        private void LoadDepartments()
        {
            cmbDepartment.Items.Clear();
            cmbDepartment.Items.Add(new ComboBoxItem(1, "İnsan Kaynakları"));
            cmbDepartment.Items.Add(new ComboBoxItem(2, "Finans"));
            cmbDepartment.Items.Add(new ComboBoxItem(3, "IT"));
            cmbDepartment.SelectedIndex = 0;
        }
        #endregion

        #region cmbPosition İÇERİĞİNİ DOLDURAN KOD
        private void LoadPositions()
        {
            cmbPosition.Items.Clear();
            cmbPosition.Items.Add(new ComboBoxItem(1, "Uzman"));
            cmbPosition.Items.Add(new ComboBoxItem(2, "Müdür"));
            cmbPosition.Items.Add(new ComboBoxItem(3, "Yönetici"));
            cmbPosition.SelectedIndex = 0;
        }
        #endregion

        #region employeeData DAKİ GetEmployees GELEN BİLGİLERİ dgvEmployees YANSITAN KOD
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

        #region txtPhone SADECE RAKAMLARA İZİN VEREN VE 11 HANE İLE KISITLAYAN KOD
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

        #region txtRelativePhone SADECE RAKAMLARA İZİN VEREN VE 11 HANE İLE KISITLAYAN KOD
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

        #region PERSONEL VE KULLANICI KAYDI YAPAN BUTON KODU
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            var selectedDept = (ComboBoxItem)cmbDepartment.SelectedItem;
            var selectedPos = (ComboBoxItem)cmbPosition.SelectedItem;
            var gender = cmbGender.SelectedItem?.ToString() ?? "Belirtilmedi";
            var birthDate = dtBirthDate.Value.Date;
            var hireDate = dtHireDate.Value.Date;

            // StartDate yoksa hireDate ile aynı atayabiliriz
            DateTime? startDate = hireDate;

            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;
            string passwordHash = employeeData.ComputePasswordHash(password);
            int roleId = cmbRole.SelectedIndex + 1;

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
                roleId
            );

            LoadEmployees();
            ClearInputs();
            MessageBox.Show("Personel ve kullanıcı hesabı eklendi.");
        }
        #endregion

        #region PERSONEL VE KULLANICI KAYDINI GÜNCELLEYEN BUTON KODU
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

        #region PERSONEL VE KULLANICI KAYDINI SİLEN BUTON KODU
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

        #region PERSONEL'E FOTOĞRAF YÜKLEMESİ İÇİN E KRAN AÇILMASINI VE YÜKLENMESİNİ SAĞLAYAN BUTON KODU
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

        #region PERSONEL'E DÖKÜMAN YÜKLENMESİ İÇİN AÇILAN EKRAN BUTONU KODU
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

        #region PERSONELE YÜKLENEN DÖKÜMANLARI DÖKÜMAN ALANINA SEÇİM SONRASI YÜKLEYEN KOD
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
        #endregion

        #region PERSONELE YÜKLENEN DÖKÜMANLARI SEÇTİREN VE ONAY İLE SİLEN BUTON KODU
        private void BtnDeleteDocument_Click(object sender, EventArgs e)
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
        #endregion

        #region PERSONELE YÜKLENEN DÖKÜMANI SEÇTİREN VE ÇIKTI ALMASINA YARDIMCI OLAN BUTON KODU
        private void BtnPrintDocument_Click(object sender, EventArgs e)
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
        #endregion

        #region employeeData DAN GetEmployeeById İLE ÇEKİLEN PERSONEL BİLGİLERİNİ grpEmployeeDetails İÇERİSİNE YANSITAN KOD
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
        #endregion

        #region ListItemWithId SINIFINDAKİ TAŞINAN VERİLERİ lstPerformanceDocuments GETİREN KOD 
        private void LoadPerformanceDocuments(int evaluationId)
        {
            lstPerformanceDocuments.Items.Clear();

            var documents = employeeData.GetPerformanceDocuments(evaluationId);

            if (documents == null || documents.Count == 0)
            {
                lstPerformanceDocuments.Items.Add("Belge bulunamadı.");
                lstPerformanceDocuments.Enabled = false;
                return;
            }

            lstPerformanceDocuments.Enabled = true;

            foreach (var doc in documents)
            {
                lstPerformanceDocuments.Items.Add(new ListItemWithId($"{doc.DocumentName} ({doc.FileType})", doc.DocumentID));
            }
        }
        #endregion

        #region lstPerformanceDocuments LİSTELENEN BELGEYİ ÇİFT TIK İLE AÇMAK İÇİN GEREKLİ KOD
        private void lstPerformanceDocuments_DoubleClick(object sender, EventArgs e)
        {
            if (lstPerformanceDocuments.SelectedItem == null)
                return;

            // Eğer "Belge bulunamadı." gibi metin seçiliyse açma
            if (lstPerformanceDocuments.SelectedItem.ToString() == "Belge bulunamadı.")
                return;

            if (lstPerformanceDocuments.SelectedItem is ListItemWithId item)
            {
                OpenPerformanceDocument(item.Id);
            }
            else if (lstPerformanceDocuments.SelectedItem is DocumentItem docItem)
            {
                OpenPerformanceDocument(docItem.DocumentID);
            }
            else
            {
                // Seçilen tip beklenmedik, işlemi durdur
                return;
            }
        }
        private void OpenPerformanceDocument(int documentId)
        {
            byte[] fileData = employeeData.GetPerformanceDocumentData(documentId);
            if (fileData == null || fileData.Length == 0)
            {
                MessageBox.Show("Dosya verisi alınamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Dosya adını ve uzantısını da çekebiliriz
            var docInfo = employeeData.GetPerformanceDocumentInfo(documentId);
            string fileName = docInfo?.DocumentName ?? "document";

            // Geçici dosya yolu oluştur
            string tempPath = Path.Combine(Path.GetTempPath(), fileName);

            try
            {
                File.WriteAllBytes(tempPath, fileData);

                // Dosyayı varsayılan programla aç
                Process.Start(new ProcessStartInfo()
                {
                    FileName = tempPath,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dosya açılamadı: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region dgvPerformance GELEN VERİLERİ DEĞİŞTİRDİKTEN SONRA GÜNCELLEYEN BUTON KODU BLOĞU
        private void btnUpdatePerformance_Click(object sender, EventArgs e)
        {
            if (dgvPerformance.CurrentRow == null || dgvPerformance.CurrentRow.Cells["EvaluationID"].Value == null)
            {
                MessageBox.Show("Güncellenecek performans kaydı seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int evaluationId;
            if (!int.TryParse(dgvPerformance.CurrentRow.Cells["EvaluationID"].Value.ToString(), out evaluationId))
            {
                MessageBox.Show("Geçersiz EvaluationID.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbEmployeesPerformance.SelectedValue == null)
            {
                MessageBox.Show("Lütfen bir personel seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int employeeId;
            if (!int.TryParse(cmbEmployeesPerformance.SelectedValue.ToString(), out employeeId))
            {
                MessageBox.Show("Geçersiz personel ID.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbPerformanceScore.SelectedItem == null)
            {
                MessageBox.Show("Lütfen geçerli bir performans puanı seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int score;
            if (!int.TryParse(cmbPerformanceScore.SelectedItem.ToString(), out score))
            {
                MessageBox.Show("Geçersiz puan.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPerformanceNote.Text))
            {
                MessageBox.Show("Lütfen performans açıklaması giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var comment = txtPerformanceNote.Text.Trim();
            var evaluationDate = dtPeriod.Value;

            if (employeeData.UpdateEvaluation(evaluationId, employeeId, score, comment, evaluationDate))
            {
                MessageBox.Show("Performans kaydı başarıyla güncellendi.");
                RefreshPerformanceGrid();

                if (MessageBox.Show(
                        "Performans kaydı güncellendi. Bu kayıt için belge yüklemek ister misiniz?",
                        "Belge Yükleme",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    UploadPerformanceDocument(evaluationId);
                }

                RefreshPerformanceGrid();
            }
            else
            {
                MessageBox.Show("Performans kaydı güncellenirken hata oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UploadPerformanceDocument(int evaluationId)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Belge Seçiniz";
                openFileDialog.Filter = "Tüm Dosyalar|*.*|PDF Dosyaları|*.pdf|Word Dosyaları|*.doc;*.docx|Resim Dosyaları|*.jpg;*.jpeg;*.png";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    string fileName = Path.GetFileName(filePath);
                    string fileType = Path.GetExtension(filePath).TrimStart('.');

                    byte[] fileData = File.ReadAllBytes(filePath);

                    bool uploadSuccess = employeeData.AddPerformanceDocument(evaluationId, fileName, fileType, fileData, DateTime.Now);

                    if (uploadSuccess)
                    {
                        MessageBox.Show("Belge başarıyla yüklendi.");
                        LoadPerformanceDocuments(evaluationId); // ListBox'u güncelle
                    }
                    else
                    {
                        MessageBox.Show("Belge yüklenirken hata oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        #endregion

        #region dgvPerformance SEÇİLEN KİŞİYE AİT VERİLERİ İLGİLİ ALANLARA YANSITAN KOD BLOĞU
        private void dgvPerformance_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPerformance.CurrentRow != null && dgvPerformance.CurrentRow.Cells["EvaluationID"].Value != null)
            {
                if (dgvPerformance.CurrentRow == null)
                    return;

                // Seçilen performans kaydının ID'sini al
                int evaluationId = Convert.ToInt32(dgvPerformance.CurrentRow.Cells["EvaluationID"].Value);

                // Performans detaylarını veritabanından al
                var evaluation = employeeData.GetEvaluationById(evaluationId);
                if (evaluation == null)
                    return;

                // Personeli comboBox'ta seç
                cmbEmployeesPerformance.SelectedValue = evaluation.EmployeeID;

                // Performans puanını comboBox'ta seç
                cmbPerformanceScore.SelectedItem = evaluation.Score.ToString();

                // Performans notunu textbox'a koy
                txtPerformanceNote.Text = evaluation.Comment;

                // Performans dönemi tarihini ayarla
                dtPeriod.Value = evaluation.EvaluationDate;

                // Performansa ait belgeleri listele
                LoadPerformanceDocuments(evaluationId);

                // Performans trend grafiğini güncelle
                LoadPerformanceTrend(evaluation.EmployeeID);

                // btnAddPerformance yerine btnUpdatePerformance aktif olabilir, isteğe göre ayarla
            }
        }
        #endregion

        #region PERFORMANS VE MAAŞ EKRANINDAKİ btnAddPerformance BUTONU İLE İLGİLİ TABLOYA VERİ EKLEYEN KOD
        private void btnAddPerformance_Click(object sender, EventArgs e)
        {
            if (cmbEmployeesPerformance.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen bir personel seçiniz.", "Uyarı");
                return;
            }

            int employeeId = (int)cmbEmployeesPerformance.SelectedValue;
            int evaluatorId = userId;
            if (evaluatorId <= 0)
            {
                MessageBox.Show("Evaluator bilgisi alınamadı.", "Hata");
                return;
            }

            if (!int.TryParse(cmbPerformanceScore.SelectedItem?.ToString(), out int score))
            {
                MessageBox.Show("Geçerli bir puan seçiniz.", "Uyarı");
                return;
            }

            string comment = txtPerformanceNote.Text.Trim();
            if (string.IsNullOrEmpty(comment))
            {
                MessageBox.Show("Performans açıklaması giriniz.", "Uyarı");
                return;
            }

            DateTime period = dtPeriod.Value.Date;

            // Performans kaydını ekle ve ID'yi al
            int evaluationId = employeeData.AddEvaluationAndReturnId(employeeId, evaluatorId, score, comment, period);

            if (evaluationId > 0)
            {
                // 📎 Belge seçmek ister misiniz?
                DialogResult dr = MessageBox.Show("Belge eklemek ister misiniz?", "Belge Ekle", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    using (OpenFileDialog ofd = new OpenFileDialog())
                    {
                        ofd.Title = "Performans Belgesi Seç";
                        ofd.Filter = "Tüm Dosyalar|*.*";

                        if (ofd.ShowDialog() == DialogResult.OK)
                        {
                            byte[] fileBytes = File.ReadAllBytes(ofd.FileName);
                            string fileName = Path.GetFileName(ofd.FileName);
                            string fileType = Path.GetExtension(ofd.FileName);
                            DateTime uploadedDate = DateTime.Now;

                            employeeData.AddPerformanceDocument(evaluationId, fileName, fileType, fileBytes, uploadedDate);
                        }

                    }
                }

                MessageBox.Show("Performans kaydı eklendi.");
                RefreshPerformanceGrid();
                txtPerformanceNote.Clear();
                cmbPerformanceScore.SelectedIndex = -1;
                cmbEmployeesPerformance.SelectedIndex = -1;
            }
            else
            {
                MessageBox.Show("Kayıt eklenemedi.");
            }
        }
        #endregion

        #region PERFORMANS VE MAAŞ EKRANINDA btnAddPerformance BUTONU İLE VERİ EKLENDİKTEN SONRA dgvPerformance YENİLEYEN KOD
        private void RefreshPerformanceGrid()
        {
            EmployeeDataAccess dataAccess = new EmployeeDataAccess();
            DataTable dt = dataAccess.GetEvaluations();

            dgvPerformance.DataSource = null;
            dgvPerformance.DataSource = dt;

            if (dgvPerformance.Columns.Contains("EmployeeID"))
                dgvPerformance.Columns["EmployeeID"].Visible = false;

            dgvPerformance.Columns["EmployeeName"].HeaderText = "Personel";
            dgvPerformance.Columns["EvaluationDate"].HeaderText = "Tarih";
            dgvPerformance.Columns["Comment"].HeaderText = "Açıklama";
            dgvPerformance.Columns["Score"].HeaderText = "Puan";
        }
        #endregion

        #region PERFORMAN VE MAAŞ EKRANINDA btnDeletePerformance BUTONU İLE dgvPerformance SEÇİLEN KAYIDI SİLEN KOD
        private void btnDeletePerformance_Click(object sender, EventArgs e)
        {
            if (dgvPerformance.CurrentRow == null)
            {
                MessageBox.Show("Lütfen silinecek kaydı seçiniz.");
                return;
            }

            int evaluationId = Convert.ToInt32(dgvPerformance.CurrentRow.Cells["EvaluationID"].Value);
            DialogResult dr = MessageBox.Show("Performans kaydını ve ilgili belgeleri silmek istiyor musunuz?", "Silme Onayı", MessageBoxButtons.YesNo);

            if (dr == DialogResult.Yes)
            {
                // Önce belge varsa sil
                employeeData.DeletePerformanceDocumentsByEvaluationId(evaluationId);

                // Ardından performans kaydını sil
                bool deleted = employeeData.DeleteEvaluation(evaluationId);
                if (deleted)
                {
                    MessageBox.Show("Kayıt ve belgeler silindi.");
                    RefreshPerformanceGrid();
                }
                else
                {
                    MessageBox.Show("Silme işlemi başarısız.");
                }
            }
        }
        #endregion

        #region btnClearPerformance İLE cmbEmployeesPerformance,cmbPerformanceScore,txtPerformanceNote ALANLARI TEMİZLEYEN KOD
        private void btnClearPerformance_Click(object sender, EventArgs e)
        {
            cmbEmployeesPerformance.SelectedIndex = -1;   // Personel seçimini temizle
            cmbPerformanceScore.SelectedIndex = -1;       // Performans puanı seçimini temizle
            txtPerformanceNote.Clear();                    // Performans açıklamasını temizle
        }
        #endregion

        #region LoadPerformanceTrend DEN GELEN VERİLERİ cmbEmployeesPerformance_SelectedIndexChanged SEÇİM İLE chartPerformanceTrend İLE GRAFİK HALİNE GETİREN KOD
        private void LoadPerformanceTrend(int employeeId)
        {
            var dt = employeeData.GetEvaluationsByEmployee(employeeId);

            chartPerformanceTrend.Series.Clear();
            chartPerformanceTrend.ChartAreas.Clear();

            if (dt == null || dt.Rows.Count == 0)
            {
                chartPerformanceTrend.Visible = false;
                return;
            }

            chartPerformanceTrend.Visible = true;

            ChartArea area = new ChartArea("PerformanceArea");
            chartPerformanceTrend.ChartAreas.Add(area);

            Series series = new Series("Performans Puanı");
            series.ChartType = SeriesChartType.Column; // DİKEY GRAFİK
            series.XValueType = ChartValueType.Date;
            series.BorderWidth = 2;
            series.Color = Color.SteelBlue;

            foreach (DataRow row in dt.Rows)
            {
                DateTime date = Convert.ToDateTime(row["EvaluationDate"]);
                int score = Convert.ToInt32(row["Score"]);  // 1–5 arası olmalı
                series.Points.AddXY(date.ToString("dd.MM.yyyy"), score);
            }

            chartPerformanceTrend.Series.Add(series);

            // X ekseni
            area.AxisX.LabelStyle.Angle = -45;
            area.AxisX.Title = "Tarih";
            area.AxisX.Interval = 1;

            // Y ekseni
            area.AxisY.Minimum = 0;
            area.AxisY.Maximum = 5;
            area.AxisY.Interval = 1;
            area.AxisY.Title = "Puan (1–5)";

            chartPerformanceTrend.Titles.Clear();
            chartPerformanceTrend.Titles.Add("Performans Trend Grafiği");
        }

        private void cmbEmployeesPerformance_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEmployeesPerformance.SelectedIndex != -1)
            {
                int selectedEmployeeId = (int)cmbEmployeesPerformance.SelectedValue;
                LoadPerformanceTrend(selectedEmployeeId);
            }
            else
            {
                chartPerformanceTrend.Visible = false;
            }
        }
        #endregion

        #region btnExport KİŞİYE GİRİLMİŞ OLAN PERFORMANS VERİLERİNİ İLGİLİ ALANA KAYIT ALAN BUTON KODU
        private void btnExport_Click(object sender, EventArgs e)
        {
            if (cmbEmployeesFilter.SelectedValue == null || cmbEmployeesFilter.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen bir personel seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime start = dtpStart.Value.Date;
            DateTime end = dtpEnd.Value.Date;

            if (start > end)
            {
                MessageBox.Show("Başlangıç tarihi bitiş tarihinden büyük olamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int employeeId = (int)cmbEmployeesFilter.SelectedValue;
            var dtPerformance = employeeData.GetPerformanceRecords(employeeId, start, end);

            if (dtPerformance == null || dtPerformance.Rows.Count == 0)
            {
                MessageBox.Show("Seçilen aralıkta kayıt bulunamadı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbExportFormat.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bir dosya biçimi seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ExportFormat selectedFormat = (ExportFormat)Enum.Parse(typeof(ExportFormat), cmbExportFormat.SelectedItem.ToString());

            SaveFileDialog sfd = new SaveFileDialog();
            switch (selectedFormat)
            {
                case ExportFormat.Excel:
                    sfd.Filter = "Excel Dosyası (*.xlsx)|*.xlsx";
                    break;
                case ExportFormat.PDF:
                    sfd.Filter = "PDF Dosyası (*.pdf)|*.pdf";
                    break;
                case ExportFormat.Word:
                    sfd.Filter = "Word Belgesi (*.docx)|*.docx";
                    break;
            }

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                ExportManager.Export(dtPerformance, selectedFormat, sfd.FileName);
                MessageBox.Show("Dosya başarıyla oluşturuldu.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region HRForm KAPANDIKTAN SONRA TİMER DURDURAN KOD
        private void HRForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (notificationTimer != null)
            {
                notificationTimer.Stop();
                notificationTimer.Dispose();
                notificationTimer = null;
            }
        }
        #endregion

        #region İLGİLİ DUYURU POPUNI OKUNDU KAPAT DEDİKTEN SONRA VT DE GÜNCELLEYEN KOD
        private void MarkNotificationAsRead(int notificationId)
        {
            string connStr = ConfigurationManager.ConnectionStrings["HRDbConnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string updateQuery = "UPDATE Notifications SET IsRead = 1 WHERE NotificationID = @id";
                SqlCommand cmd = new SqlCommand(updateQuery, conn);
                cmd.Parameters.AddWithValue("@id", notificationId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        #endregion

        #region TIMER BAŞLATAN VE 30 SANİYE BİR SORGULAYAN KOD
        private void SetupNotificationTimer()
        {
            notificationTimer = new Timer();
            notificationTimer.Interval = 30000; // 30 saniye
            notificationTimer.Tick += NotificationTimer_Tick;
            notificationTimer.Start();
        }
        private void NotificationTimer_Tick(object sender, EventArgs e)
        {
            ShowUnreadNotifications();
        }
        #endregion

        #region AKTİF OLAN DUYURU FORMUNU KAPATAN KOD
        private void ActiveNotificationForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (sender is NotificationForm form)
            {
                MarkNotificationAsRead(form.NotificationID);
            }
            activeNotificationForm = null;
        }
        #endregion

        #region AKTİF DUYURU EKRANINI SORGULAYAN VARSA EKRANA GETİRMEYEN YOKSA EKRANA GETİREN KOD
        private void ShowUnreadNotifications()
        {
            if (activeNotificationForm != null && !activeNotificationForm.IsDisposed)
            {
                // Zaten bir popup açık, yenisini açma
                return;
            }
            string connStr = ConfigurationManager.ConnectionStrings["HRDbConnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = @"SELECT TOP 1 NotificationID, Title, Content FROM Notifications
                             WHERE UserID = @userId AND IsRead = 0
                             ORDER BY Date ASC";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@userId", currentUserId);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int notificationId = reader.GetInt32(0);
                        string title = reader.GetString(1);
                        string content = reader.GetString(2);

                        activeNotificationForm = new NotificationForm(title, content, notificationId);
                        activeNotificationForm.FormClosed += ActiveNotificationForm_FormClosed;
                        activeNotificationForm.Show();
                    }
                }
            }
        }
        #endregion

        #region cmbEmployeesTraining İLE SEÇİLEN PERSONELE EĞİTİM VEYA SERTİFİKA EKLEME KODU
        // Eğitim ekleme
        private void btnAddTraining_Click(object sender, EventArgs e)
        {
            if (cmbEmployeesTraining.SelectedIndex == -1 || string.IsNullOrWhiteSpace(txtTrainingName.Text))
            {
                MessageBox.Show("Lütfen tüm zorunlu alanları doldurun.");
                return;
            }

            int employeeId = (int)cmbEmployeesTraining.SelectedValue;
            string name = txtTrainingName.Text.Trim();
            DateTime start = dtpTrainingStart.Value;
            DateTime end = dtpTrainingEnd.Value;
            string status = cmbStatus.Text.Trim();
            string notes = txtDescription.Text.Trim();

            bool success = employeeData.AddTraining(employeeId, name, start, end, status, notes);
            if (success)
            {
                MessageBox.Show("Eğitim eklendi.");
                LoadEmployeeTrainingsList(employeeId);
                ClearTrainingInputFields();
            }
            else
            {
                MessageBox.Show("Ekleme başarısız.");
            }
        }
        #endregion

        #region cmbEmployeesTraining İLE SEÇİLEN PERSONELE EĞİTİM VEYA SERTİFİKA GÜNCELLEME KODU
        private void btnUpdateTraining_Click(object sender, EventArgs e)
        {
            if (lstbxEmployeeTraining.SelectedItem == null)
            {
                MessageBox.Show("Lütfen güncellenecek bir eğitim seçin.");
                return;
            }

            TrainingItem selectedTraining = (TrainingItem)lstbxEmployeeTraining.SelectedItem;
            int trainingId = selectedTraining.TrainingID;

            string name = txtTrainingName.Text.Trim();
            DateTime start = dtpTrainingStart.Value;
            DateTime end = dtpTrainingEnd.Value;
            string status = cmbStatus.Text.Trim();
            string notes = txtDescription.Text.Trim();

            bool success = employeeData.UpdateTraining(trainingId, name, start, end, status, notes);
            if (success)
            {
                MessageBox.Show("Eğitim güncellendi.");
                if (cmbEmployeesTraining.SelectedItem is Employee emp)
                    LoadEmployeeTrainingsList(emp.EmployeeID);
                ClearTrainingInputFields();
            }
            else
            {
                MessageBox.Show("Güncelleme başarısız.");
            }
        }
        #endregion

        #region cmbEmployeesTraining İLE SEÇİLEN PERSONELE EĞİTİM VEYA SERTİFİKA SİLME KODU
        private void btnDeleteTraining_Click(object sender, EventArgs e)
        {
            if (lstbxEmployeeTraining.SelectedItem == null)
            {
                MessageBox.Show("Lütfen silinecek bir eğitim seçin.");
                return;
            }

            TrainingItem selectedTraining = (TrainingItem)lstbxEmployeeTraining.SelectedItem;
            int trainingId = selectedTraining.TrainingID;

            var result = MessageBox.Show("Silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                if (employeeData.DeleteTraining(trainingId))
                {
                    MessageBox.Show("Silindi.");
                    if (cmbEmployeesTraining.SelectedItem is Employee emp)
                        LoadEmployeeTrainingsList(emp.EmployeeID);
                    ClearTrainingInputFields();
                }
                else
                {
                    MessageBox.Show("Silme başarısız.");
                }
            }
        }
        #endregion

        #region lstbxEmployeeTraining ALANINA GetTrainings İLE GELEN EĞİTİM VE SERTİFİKALARI YÜKLEME KODU
        // ListBox'a eğitimleri yükleme
        private void LoadEmployeeTrainingsList(int employeeId)
        {
            lstbxEmployeeTraining.Items.Clear();

            DataTable dt = employeeData.GetTrainings(employeeId);

            foreach (DataRow row in dt.Rows)
            {
                int trainingId = Convert.ToInt32(row["TrainingID"]);
                string trainingName = row["TrainingName"].ToString();
                string startDate = Convert.ToDateTime(row["StartDate"]).ToShortDateString();
                string endDate = Convert.ToDateTime(row["EndDate"]).ToShortDateString();

                TrainingItem item = new TrainingItem
                {
                    TrainingID = trainingId,
                    DisplayText = $"{trainingName} ({startDate} - {endDate})"
                };

                lstbxEmployeeTraining.Items.Add(item);
            }
        }
        private void lstbxEmployeeTraining_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstbxEmployeeTraining.SelectedItem == null)
                return;

            TrainingItem selectedTraining = (TrainingItem)lstbxEmployeeTraining.SelectedItem;

            // Tek kayıt getiren metodu yazmak daha sağlıklı:
            DataTable dt = employeeData.GetTrainingById(selectedTraining.TrainingID);

            if (dt.Rows.Count == 0)
                return;

            DataRow row = dt.Rows[0];

            txtTrainingName.Text = row["TrainingName"].ToString();
            txtDescription.Text = row["Notes"].ToString();
            cmbStatus.Text = row["Status"].ToString();
            dtpTrainingStart.Value = Convert.ToDateTime(row["StartDate"]);
            dtpTrainingEnd.Value = Convert.ToDateTime(row["EndDate"]);
        }
        #endregion

        // Çalışanları ComboBox'a yükleme
        private void LoadEmployeesToTrainingCombo()
        {
            var employees = employeeData.GetAllEmployees(); // Zaten var olan metot

            if (employees != null && employees.Count > 0)
            {
                cmbEmployeesTraining.DataSource = employees;
                cmbEmployeesTraining.DisplayMember = "FullName";  // Employee sınıfında varsa
                cmbEmployeesTraining.ValueMember = "EmployeeID";
                cmbEmployeesTraining.SelectedIndex = -1; // Hiçbiri seçili olmasın
            }
            else
            {
                cmbEmployeesTraining.DataSource = null;
                MessageBox.Show("Sistemde tanımlı personel bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // ComboBox seçim değiştiğinde ListBox güncelle
        private void cmbEmployeesTraining_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedItem = cmbEmployeesTraining.SelectedItem;
            if (selectedItem == null || !(selectedItem is Employee))
                return;

            var selectedEmployee = (Employee)selectedItem;
            LoadEmployeeTrainingsList(selectedEmployee.EmployeeID);
        }

        // Eğitim bilgileri inputlarını temizle
        private void ClearTrainingInputFields()
        {
            txtTrainingName.Clear();
            cmbStatus.SelectedIndex = -1;  // Seçimi kaldırır
            txtDescription.Clear();
            dtpTrainingStart.Value = DateTime.Now;
            dtpTrainingEnd.Value = DateTime.Now;
        }


        private void LoadEmployeesToComboBox()
        {
            List<Employee> employees = employeeData.GetAllEmployees(); // Eğer doğrudan çağırıyorsan: GetAllEmployees()

            cmbEmployeesFilter.DataSource = employees;
            cmbEmployeesFilter.DisplayMember = "FullName";    // Görüntülenecek olan ad-soyad
            cmbEmployeesFilter.ValueMember = "EmployeeID";    // Seçildiğinde kullanılacak ID
        }


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
    }
}
