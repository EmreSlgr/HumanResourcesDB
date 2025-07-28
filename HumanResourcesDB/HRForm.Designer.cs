namespace HumanResourcesDB
{
    partial class HRForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageEmployees;

        private System.Windows.Forms.DataGridView dgvEmployees;
        private System.Windows.Forms.GroupBox grpEmployeeDetails;
        private System.Windows.Forms.PictureBox picEmployeePhoto;

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;

        private System.Windows.Forms.Button btnUploadPhoto;
        private System.Windows.Forms.Button btnUploadDocument;
        private System.Windows.Forms.Button btnDeleteDocument;
        private System.Windows.Forms.Button btnPrintDocument;

        private System.Windows.Forms.ListBox lstBoxDocuments;

        private System.Windows.Forms.ComboBox cmbDepartment;
        private System.Windows.Forms.ComboBox cmbPosition;
        private System.Windows.Forms.ComboBox cmbGender;
        private System.Windows.Forms.ComboBox cmbRole;

        private System.Windows.Forms.DateTimePicker dtBirthDate;
        private System.Windows.Forms.DateTimePicker dtHireDate;

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtSurname;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtRelativePhone;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtEmail;

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblSurname;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.Label lblBirthDate;
        private System.Windows.Forms.Label lblHireDate;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblRelativePhone;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblRole;

        private System.Windows.Forms.Label lblEmployeeFullName;
        private System.Windows.Forms.Label lblEmployeeDepartment;
        private System.Windows.Forms.Label lblEmployeePosition;
        private System.Windows.Forms.Label lblEmployeePhone;
        private System.Windows.Forms.Label lblEmployeeEmail;
        private System.Windows.Forms.Label lblEmployeeStartDate;
        // ==== tabPage2 alanları (Performans ve Maaş) ====
        private System.Windows.Forms.TabPage tabPagePerformance;
        private System.Windows.Forms.ComboBox cmbEmployeesPerformance;
        private System.Windows.Forms.ComboBox cmbPerformanceScore;
        private System.Windows.Forms.DateTimePicker dtPeriod;
        private System.Windows.Forms.TextBox txtPerformanceNote;
        private System.Windows.Forms.DataGridView dgvPerformance;
        private System.Windows.Forms.Button btnAddPerformance;
        private System.Windows.Forms.Button btnDeletePerformance;
        private System.Windows.Forms.Button btnClearPerformance;
        private System.Windows.Forms.TabPage tabPageTrainingAndCertificates;
        private System.Windows.Forms.ComboBox cmbEmployeesTraining;
        private System.Windows.Forms.Label lblSelectEmployeeTraining;
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HRForm));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageEmployees = new System.Windows.Forms.TabPage();
            this.btnPrintDocument = new System.Windows.Forms.Button();
            this.lblRole = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.cmbRole = new System.Windows.Forms.ComboBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtRelativePhone = new System.Windows.Forms.TextBox();
            this.lblRelativePhone = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.dtHireDate = new System.Windows.Forms.DateTimePicker();
            this.lblHireDate = new System.Windows.Forms.Label();
            this.dtBirthDate = new System.Windows.Forms.DateTimePicker();
            this.lblBirthDate = new System.Windows.Forms.Label();
            this.cmbGender = new System.Windows.Forms.ComboBox();
            this.lblGender = new System.Windows.Forms.Label();
            this.btnDeleteDocument = new System.Windows.Forms.Button();
            this.lstBoxDocuments = new System.Windows.Forms.ListBox();
            this.btnUploadDocument = new System.Windows.Forms.Button();
            this.btnUploadPhoto = new System.Windows.Forms.Button();
            this.grpEmployeeDetails = new System.Windows.Forms.GroupBox();
            this.lblEmployeeEmail = new System.Windows.Forms.Label();
            this.lblEmployeeStartDate = new System.Windows.Forms.Label();
            this.lblEmployeePhone = new System.Windows.Forms.Label();
            this.lblEmployeePosition = new System.Windows.Forms.Label();
            this.lblEmployeeDepartment = new System.Windows.Forms.Label();
            this.lblEmployeeFullName = new System.Windows.Forms.Label();
            this.picEmployeePhoto = new System.Windows.Forms.PictureBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dgvEmployees = new System.Windows.Forms.DataGridView();
            this.cmbPosition = new System.Windows.Forms.ComboBox();
            this.cmbDepartment = new System.Windows.Forms.ComboBox();
            this.txtSurname = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblPosition = new System.Windows.Forms.Label();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.lblSurname = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.tabPagePerformance = new System.Windows.Forms.TabPage();
            this.btnExport = new System.Windows.Forms.Button();
            this.cmbExportFormat = new System.Windows.Forms.ComboBox();
            this.cmbEmployeesFilter = new System.Windows.Forms.ComboBox();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.btnUpdatePerformance = new System.Windows.Forms.Button();
            this.lblPeriod = new System.Windows.Forms.Label();
            this.lblPerformanceScore = new System.Windows.Forms.Label();
            this.lblEmployeesPerformance = new System.Windows.Forms.Label();
            this.lstPerformanceDocuments = new System.Windows.Forms.ListBox();
            this.chartPerformanceTrend = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.cmbEmployeesPerformance = new System.Windows.Forms.ComboBox();
            this.cmbPerformanceScore = new System.Windows.Forms.ComboBox();
            this.dtPeriod = new System.Windows.Forms.DateTimePicker();
            this.txtPerformanceNote = new System.Windows.Forms.TextBox();
            this.dgvPerformance = new System.Windows.Forms.DataGridView();
            this.btnAddPerformance = new System.Windows.Forms.Button();
            this.btnDeletePerformance = new System.Windows.Forms.Button();
            this.btnClearPerformance = new System.Windows.Forms.Button();
            this.tabPageTrainingAndCertificates = new System.Windows.Forms.TabPage();
            this.lblTrainingName = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lstbxEmployeeTraining = new System.Windows.Forms.ListBox();
            this.btnDeleteTraining = new System.Windows.Forms.Button();
            this.btnUpdateTraining = new System.Windows.Forms.Button();
            this.btnAddTraining = new System.Windows.Forms.Button();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.dtpTrainingEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpTrainingStart = new System.Windows.Forms.DateTimePicker();
            this.txtTrainingName = new System.Windows.Forms.TextBox();
            this.lblSelectEmployeeTraining = new System.Windows.Forms.Label();
            this.cmbEmployeesTraining = new System.Windows.Forms.ComboBox();
            this.printDialog = new System.Windows.Forms.PrintDialog();
            this.printDoc = new System.Drawing.Printing.PrintDocument();
            this.tabControl.SuspendLayout();
            this.tabPageEmployees.SuspendLayout();
            this.grpEmployeeDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picEmployeePhoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).BeginInit();
            this.tabPagePerformance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartPerformanceTrend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPerformance)).BeginInit();
            this.tabPageTrainingAndCertificates.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageEmployees);
            this.tabControl.Controls.Add(this.tabPagePerformance);
            this.tabControl.Controls.Add(this.tabPageTrainingAndCertificates);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(970, 578);
            this.tabControl.TabIndex = 0;
            // 
            // tabPageEmployees
            // 
            this.tabPageEmployees.Controls.Add(this.btnPrintDocument);
            this.tabPageEmployees.Controls.Add(this.lblRole);
            this.tabPageEmployees.Controls.Add(this.lblPassword);
            this.tabPageEmployees.Controls.Add(this.lblUserName);
            this.tabPageEmployees.Controls.Add(this.cmbRole);
            this.tabPageEmployees.Controls.Add(this.txtPassword);
            this.tabPageEmployees.Controls.Add(this.txtUsername);
            this.tabPageEmployees.Controls.Add(this.txtEmail);
            this.tabPageEmployees.Controls.Add(this.lblEmail);
            this.tabPageEmployees.Controls.Add(this.txtAddress);
            this.tabPageEmployees.Controls.Add(this.lblAddress);
            this.tabPageEmployees.Controls.Add(this.txtRelativePhone);
            this.tabPageEmployees.Controls.Add(this.lblRelativePhone);
            this.tabPageEmployees.Controls.Add(this.txtPhone);
            this.tabPageEmployees.Controls.Add(this.lblPhone);
            this.tabPageEmployees.Controls.Add(this.dtHireDate);
            this.tabPageEmployees.Controls.Add(this.lblHireDate);
            this.tabPageEmployees.Controls.Add(this.dtBirthDate);
            this.tabPageEmployees.Controls.Add(this.lblBirthDate);
            this.tabPageEmployees.Controls.Add(this.cmbGender);
            this.tabPageEmployees.Controls.Add(this.lblGender);
            this.tabPageEmployees.Controls.Add(this.btnDeleteDocument);
            this.tabPageEmployees.Controls.Add(this.lstBoxDocuments);
            this.tabPageEmployees.Controls.Add(this.btnUploadDocument);
            this.tabPageEmployees.Controls.Add(this.btnUploadPhoto);
            this.tabPageEmployees.Controls.Add(this.grpEmployeeDetails);
            this.tabPageEmployees.Controls.Add(this.btnDelete);
            this.tabPageEmployees.Controls.Add(this.btnUpdate);
            this.tabPageEmployees.Controls.Add(this.btnAdd);
            this.tabPageEmployees.Controls.Add(this.dgvEmployees);
            this.tabPageEmployees.Controls.Add(this.cmbPosition);
            this.tabPageEmployees.Controls.Add(this.cmbDepartment);
            this.tabPageEmployees.Controls.Add(this.txtSurname);
            this.tabPageEmployees.Controls.Add(this.txtName);
            this.tabPageEmployees.Controls.Add(this.lblPosition);
            this.tabPageEmployees.Controls.Add(this.lblDepartment);
            this.tabPageEmployees.Controls.Add(this.lblSurname);
            this.tabPageEmployees.Controls.Add(this.lblName);
            this.tabPageEmployees.Location = new System.Drawing.Point(4, 22);
            this.tabPageEmployees.Name = "tabPageEmployees";
            this.tabPageEmployees.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageEmployees.Size = new System.Drawing.Size(962, 552);
            this.tabPageEmployees.TabIndex = 0;
            this.tabPageEmployees.Text = "Personel Yönetimi";
            this.tabPageEmployees.UseVisualStyleBackColor = true;
            // 
            // btnPrintDocument
            // 
            this.btnPrintDocument.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnPrintDocument.Location = new System.Drawing.Point(504, 278);
            this.btnPrintDocument.Name = "btnPrintDocument";
            this.btnPrintDocument.Size = new System.Drawing.Size(191, 23);
            this.btnPrintDocument.TabIndex = 80;
            this.btnPrintDocument.Text = "Seçilen Dökümanı Çıktı Al";
            this.btnPrintDocument.UseVisualStyleBackColor = true;
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Location = new System.Drawing.Point(305, 61);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(32, 13);
            this.lblRole.TabIndex = 81;
            this.lblRole.Text = "Rolü:";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(305, 35);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(31, 13);
            this.lblPassword.TabIndex = 82;
            this.lblPassword.Text = "Şifre:";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(305, 9);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(67, 13);
            this.lblUserName.TabIndex = 83;
            this.lblUserName.Text = "Kullanıcı Adı:";
            // 
            // cmbRole
            // 
            this.cmbRole.FormattingEnabled = true;
            this.cmbRole.Items.AddRange(new object[] {
            "Admin",
            "HR",
            "Manager",
            "Employee"});
            this.cmbRole.Location = new System.Drawing.Point(377, 55);
            this.cmbRole.Name = "cmbRole";
            this.cmbRole.Size = new System.Drawing.Size(121, 21);
            this.cmbRole.TabIndex = 76;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(377, 29);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(121, 20);
            this.txtPassword.TabIndex = 75;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(377, 3);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(121, 20);
            this.txtUsername.TabIndex = 74;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(108, 310);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(147, 20);
            this.txtEmail.TabIndex = 69;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(9, 316);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(38, 13);
            this.lblEmail.TabIndex = 84;
            this.lblEmail.Text = "E-mail:";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(108, 241);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(147, 63);
            this.txtAddress.TabIndex = 68;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(9, 247);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(37, 13);
            this.lblAddress.TabIndex = 85;
            this.lblAddress.Text = "Adres:";
            // 
            // txtRelativePhone
            // 
            this.txtRelativePhone.Location = new System.Drawing.Point(108, 215);
            this.txtRelativePhone.Name = "txtRelativePhone";
            this.txtRelativePhone.Size = new System.Drawing.Size(147, 20);
            this.txtRelativePhone.TabIndex = 67;
            this.txtRelativePhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRelativePhone_KeyPress);
            // 
            // lblRelativePhone
            // 
            this.lblRelativePhone.AutoSize = true;
            this.lblRelativePhone.Location = new System.Drawing.Point(9, 221);
            this.lblRelativePhone.Name = "lblRelativePhone";
            this.lblRelativePhone.Size = new System.Drawing.Size(82, 13);
            this.lblRelativePhone.TabIndex = 86;
            this.lblRelativePhone.Text = "Yakın Telefonu:";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(108, 189);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(147, 20);
            this.txtPhone.TabIndex = 66;
            this.txtPhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPhone_KeyPress);
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(9, 195);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(46, 13);
            this.lblPhone.TabIndex = 87;
            this.lblPhone.Text = "Telefon:";
            // 
            // dtHireDate
            // 
            this.dtHireDate.Location = new System.Drawing.Point(108, 162);
            this.dtHireDate.Name = "dtHireDate";
            this.dtHireDate.Size = new System.Drawing.Size(147, 20);
            this.dtHireDate.TabIndex = 65;
            // 
            // lblHireDate
            // 
            this.lblHireDate.AutoSize = true;
            this.lblHireDate.Location = new System.Drawing.Point(9, 168);
            this.lblHireDate.Name = "lblHireDate";
            this.lblHireDate.Size = new System.Drawing.Size(76, 13);
            this.lblHireDate.TabIndex = 88;
            this.lblHireDate.Text = "İşe Giriş Tarihi:";
            // 
            // dtBirthDate
            // 
            this.dtBirthDate.Location = new System.Drawing.Point(108, 82);
            this.dtBirthDate.Name = "dtBirthDate";
            this.dtBirthDate.Size = new System.Drawing.Size(147, 20);
            this.dtBirthDate.TabIndex = 63;
            // 
            // lblBirthDate
            // 
            this.lblBirthDate.AutoSize = true;
            this.lblBirthDate.Location = new System.Drawing.Point(9, 88);
            this.lblBirthDate.Name = "lblBirthDate";
            this.lblBirthDate.Size = new System.Drawing.Size(73, 13);
            this.lblBirthDate.TabIndex = 89;
            this.lblBirthDate.Text = "Doğum Tarihi:";
            // 
            // cmbGender
            // 
            this.cmbGender.FormattingEnabled = true;
            this.cmbGender.Items.AddRange(new object[] {
            "Erkek",
            "Kadın"});
            this.cmbGender.Location = new System.Drawing.Point(108, 55);
            this.cmbGender.Name = "cmbGender";
            this.cmbGender.Size = new System.Drawing.Size(147, 21);
            this.cmbGender.TabIndex = 61;
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Location = new System.Drawing.Point(9, 61);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(30, 13);
            this.lblGender.TabIndex = 90;
            this.lblGender.Text = "Cins:";
            // 
            // btnDeleteDocument
            // 
            this.btnDeleteDocument.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnDeleteDocument.Location = new System.Drawing.Point(504, 249);
            this.btnDeleteDocument.Name = "btnDeleteDocument";
            this.btnDeleteDocument.Size = new System.Drawing.Size(191, 23);
            this.btnDeleteDocument.TabIndex = 59;
            this.btnDeleteDocument.Text = "Döküman Sil";
            this.btnDeleteDocument.UseVisualStyleBackColor = true;
            // 
            // lstBoxDocuments
            // 
            this.lstBoxDocuments.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lstBoxDocuments.FormattingEnabled = true;
            this.lstBoxDocuments.ItemHeight = 17;
            this.lstBoxDocuments.Location = new System.Drawing.Point(504, 148);
            this.lstBoxDocuments.Name = "lstBoxDocuments";
            this.lstBoxDocuments.Size = new System.Drawing.Size(191, 89);
            this.lstBoxDocuments.TabIndex = 58;
            // 
            // btnUploadDocument
            // 
            this.btnUploadDocument.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnUploadDocument.Location = new System.Drawing.Point(504, 119);
            this.btnUploadDocument.Name = "btnUploadDocument";
            this.btnUploadDocument.Size = new System.Drawing.Size(191, 23);
            this.btnUploadDocument.TabIndex = 57;
            this.btnUploadDocument.Text = "Döküman Ekle";
            this.btnUploadDocument.UseVisualStyleBackColor = true;
            // 
            // btnUploadPhoto
            // 
            this.btnUploadPhoto.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnUploadPhoto.Location = new System.Drawing.Point(504, 90);
            this.btnUploadPhoto.Name = "btnUploadPhoto";
            this.btnUploadPhoto.Size = new System.Drawing.Size(191, 23);
            this.btnUploadPhoto.TabIndex = 56;
            this.btnUploadPhoto.Text = "Fotoğraf Ekle";
            this.btnUploadPhoto.UseVisualStyleBackColor = true;
            // 
            // grpEmployeeDetails
            // 
            this.grpEmployeeDetails.Controls.Add(this.lblEmployeeEmail);
            this.grpEmployeeDetails.Controls.Add(this.lblEmployeeStartDate);
            this.grpEmployeeDetails.Controls.Add(this.lblEmployeePhone);
            this.grpEmployeeDetails.Controls.Add(this.lblEmployeePosition);
            this.grpEmployeeDetails.Controls.Add(this.lblEmployeeDepartment);
            this.grpEmployeeDetails.Controls.Add(this.lblEmployeeFullName);
            this.grpEmployeeDetails.Controls.Add(this.picEmployeePhoto);
            this.grpEmployeeDetails.Location = new System.Drawing.Point(701, 3);
            this.grpEmployeeDetails.Name = "grpEmployeeDetails";
            this.grpEmployeeDetails.Size = new System.Drawing.Size(251, 322);
            this.grpEmployeeDetails.TabIndex = 55;
            this.grpEmployeeDetails.TabStop = false;
            this.grpEmployeeDetails.Text = "Çalışan Bilgileri";
            // 
            // lblEmployeeEmail
            // 
            this.lblEmployeeEmail.AutoSize = true;
            this.lblEmployeeEmail.Location = new System.Drawing.Point(16, 262);
            this.lblEmployeeEmail.Name = "lblEmployeeEmail";
            this.lblEmployeeEmail.Size = new System.Drawing.Size(45, 13);
            this.lblEmployeeEmail.TabIndex = 6;
            this.lblEmployeeEmail.Text = "E Mail : ";
            // 
            // lblEmployeeStartDate
            // 
            this.lblEmployeeStartDate.AutoSize = true;
            this.lblEmployeeStartDate.Location = new System.Drawing.Point(16, 296);
            this.lblEmployeeStartDate.Name = "lblEmployeeStartDate";
            this.lblEmployeeStartDate.Size = new System.Drawing.Size(79, 13);
            this.lblEmployeeStartDate.TabIndex = 5;
            this.lblEmployeeStartDate.Text = "İşe Giriş Tarihi :";
            // 
            // lblEmployeePhone
            // 
            this.lblEmployeePhone.AutoSize = true;
            this.lblEmployeePhone.Location = new System.Drawing.Point(16, 230);
            this.lblEmployeePhone.Name = "lblEmployeePhone";
            this.lblEmployeePhone.Size = new System.Drawing.Size(52, 13);
            this.lblEmployeePhone.TabIndex = 4;
            this.lblEmployeePhone.Text = "Telefon : ";
            // 
            // lblEmployeePosition
            // 
            this.lblEmployeePosition.AutoSize = true;
            this.lblEmployeePosition.Location = new System.Drawing.Point(16, 163);
            this.lblEmployeePosition.Name = "lblEmployeePosition";
            this.lblEmployeePosition.Size = new System.Drawing.Size(55, 13);
            this.lblEmployeePosition.TabIndex = 3;
            this.lblEmployeePosition.Text = "Pozisyon :";
            // 
            // lblEmployeeDepartment
            // 
            this.lblEmployeeDepartment.AutoSize = true;
            this.lblEmployeeDepartment.Location = new System.Drawing.Point(16, 197);
            this.lblEmployeeDepartment.Name = "lblEmployeeDepartment";
            this.lblEmployeeDepartment.Size = new System.Drawing.Size(68, 13);
            this.lblEmployeeDepartment.TabIndex = 2;
            this.lblEmployeeDepartment.Text = "Departman : ";
            // 
            // lblEmployeeFullName
            // 
            this.lblEmployeeFullName.AutoSize = true;
            this.lblEmployeeFullName.Location = new System.Drawing.Point(16, 131);
            this.lblEmployeeFullName.Name = "lblEmployeeFullName";
            this.lblEmployeeFullName.Size = new System.Drawing.Size(26, 13);
            this.lblEmployeeFullName.TabIndex = 1;
            this.lblEmployeeFullName.Text = "Ad :";
            // 
            // picEmployeePhoto
            // 
            this.picEmployeePhoto.Location = new System.Drawing.Point(125, 15);
            this.picEmployeePhoto.Name = "picEmployeePhoto";
            this.picEmployeePhoto.Size = new System.Drawing.Size(123, 95);
            this.picEmployeePhoto.TabIndex = 0;
            this.picEmployeePhoto.TabStop = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnDelete.Location = new System.Drawing.Point(504, 61);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(191, 23);
            this.btnDelete.TabIndex = 54;
            this.btnDelete.Text = "Personel Sil";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnUpdate.Location = new System.Drawing.Point(504, 32);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(191, 23);
            this.btnUpdate.TabIndex = 53;
            this.btnUpdate.Text = "Personel Güncelle";
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnAdd.Location = new System.Drawing.Point(504, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(191, 23);
            this.btnAdd.TabIndex = 52;
            this.btnAdd.Text = "Personel Ekle";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // dgvEmployees
            // 
            this.dgvEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployees.Location = new System.Drawing.Point(8, 393);
            this.dgvEmployees.Name = "dgvEmployees";
            this.dgvEmployees.Size = new System.Drawing.Size(944, 150);
            this.dgvEmployees.TabIndex = 51;
            // 
            // cmbPosition
            // 
            this.cmbPosition.FormattingEnabled = true;
            this.cmbPosition.Location = new System.Drawing.Point(108, 135);
            this.cmbPosition.Name = "cmbPosition";
            this.cmbPosition.Size = new System.Drawing.Size(147, 21);
            this.cmbPosition.TabIndex = 50;
            // 
            // cmbDepartment
            // 
            this.cmbDepartment.FormattingEnabled = true;
            this.cmbDepartment.Location = new System.Drawing.Point(108, 108);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new System.Drawing.Size(147, 21);
            this.cmbDepartment.TabIndex = 49;
            // 
            // txtSurname
            // 
            this.txtSurname.Location = new System.Drawing.Point(108, 29);
            this.txtSurname.Name = "txtSurname";
            this.txtSurname.Size = new System.Drawing.Size(147, 20);
            this.txtSurname.TabIndex = 48;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(108, 3);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(147, 20);
            this.txtName.TabIndex = 47;
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.Location = new System.Drawing.Point(9, 141);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(52, 13);
            this.lblPosition.TabIndex = 91;
            this.lblPosition.Text = "Pozisyon:";
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Location = new System.Drawing.Point(9, 114);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(62, 13);
            this.lblDepartment.TabIndex = 92;
            this.lblDepartment.Text = "Departman:";
            // 
            // lblSurname
            // 
            this.lblSurname.AutoSize = true;
            this.lblSurname.Location = new System.Drawing.Point(9, 35);
            this.lblSurname.Name = "lblSurname";
            this.lblSurname.Size = new System.Drawing.Size(40, 13);
            this.lblSurname.TabIndex = 93;
            this.lblSurname.Text = "Soyad:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(9, 9);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(23, 13);
            this.lblName.TabIndex = 94;
            this.lblName.Text = "Ad:";
            // 
            // tabPagePerformance
            // 
            this.tabPagePerformance.Controls.Add(this.btnExport);
            this.tabPagePerformance.Controls.Add(this.cmbExportFormat);
            this.tabPagePerformance.Controls.Add(this.cmbEmployeesFilter);
            this.tabPagePerformance.Controls.Add(this.dtpEnd);
            this.tabPagePerformance.Controls.Add(this.dtpStart);
            this.tabPagePerformance.Controls.Add(this.btnUpdatePerformance);
            this.tabPagePerformance.Controls.Add(this.lblPeriod);
            this.tabPagePerformance.Controls.Add(this.lblPerformanceScore);
            this.tabPagePerformance.Controls.Add(this.lblEmployeesPerformance);
            this.tabPagePerformance.Controls.Add(this.lstPerformanceDocuments);
            this.tabPagePerformance.Controls.Add(this.chartPerformanceTrend);
            this.tabPagePerformance.Controls.Add(this.cmbEmployeesPerformance);
            this.tabPagePerformance.Controls.Add(this.cmbPerformanceScore);
            this.tabPagePerformance.Controls.Add(this.dtPeriod);
            this.tabPagePerformance.Controls.Add(this.txtPerformanceNote);
            this.tabPagePerformance.Controls.Add(this.dgvPerformance);
            this.tabPagePerformance.Controls.Add(this.btnAddPerformance);
            this.tabPagePerformance.Controls.Add(this.btnDeletePerformance);
            this.tabPagePerformance.Controls.Add(this.btnClearPerformance);
            this.tabPagePerformance.Location = new System.Drawing.Point(4, 22);
            this.tabPagePerformance.Name = "tabPagePerformance";
            this.tabPagePerformance.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePerformance.Size = new System.Drawing.Size(962, 552);
            this.tabPagePerformance.TabIndex = 1;
            this.tabPagePerformance.Text = "Performans ve Ek Maaş";
            this.tabPagePerformance.UseVisualStyleBackColor = true;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(782, 112);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(100, 30);
            this.btnExport.TabIndex = 19;
            this.btnExport.Text = "Dışa Aktar";
            this.btnExport.UseVisualStyleBackColor = true;
            // 
            // cmbExportFormat
            // 
            this.cmbExportFormat.FormattingEnabled = true;
            this.cmbExportFormat.Location = new System.Drawing.Point(761, 85);
            this.cmbExportFormat.Name = "cmbExportFormat";
            this.cmbExportFormat.Size = new System.Drawing.Size(121, 21);
            this.cmbExportFormat.TabIndex = 18;
            // 
            // cmbEmployeesFilter
            // 
            this.cmbEmployeesFilter.FormattingEnabled = true;
            this.cmbEmployeesFilter.Location = new System.Drawing.Point(761, 58);
            this.cmbEmployeesFilter.Name = "cmbEmployeesFilter";
            this.cmbEmployeesFilter.Size = new System.Drawing.Size(121, 21);
            this.cmbEmployeesFilter.TabIndex = 17;
            // 
            // dtpEnd
            // 
            this.dtpEnd.Location = new System.Drawing.Point(682, 32);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(200, 20);
            this.dtpEnd.TabIndex = 16;
            // 
            // dtpStart
            // 
            this.dtpStart.Location = new System.Drawing.Point(682, 6);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(200, 20);
            this.dtpStart.TabIndex = 15;
            // 
            // btnUpdatePerformance
            // 
            this.btnUpdatePerformance.Location = new System.Drawing.Point(414, 111);
            this.btnUpdatePerformance.Name = "btnUpdatePerformance";
            this.btnUpdatePerformance.Size = new System.Drawing.Size(100, 30);
            this.btnUpdatePerformance.TabIndex = 14;
            this.btnUpdatePerformance.Text = "Güncelle";
            this.btnUpdatePerformance.UseVisualStyleBackColor = true;
            // 
            // lblPeriod
            // 
            this.lblPeriod.AutoSize = true;
            this.lblPeriod.Location = new System.Drawing.Point(296, 3);
            this.lblPeriod.Name = "lblPeriod";
            this.lblPeriod.Size = new System.Drawing.Size(31, 13);
            this.lblPeriod.TabIndex = 13;
            this.lblPeriod.Text = "Tarih";
            // 
            // lblPerformanceScore
            // 
            this.lblPerformanceScore.AutoSize = true;
            this.lblPerformanceScore.Location = new System.Drawing.Point(222, 3);
            this.lblPerformanceScore.Name = "lblPerformanceScore";
            this.lblPerformanceScore.Size = new System.Drawing.Size(32, 13);
            this.lblPerformanceScore.TabIndex = 12;
            this.lblPerformanceScore.Text = "Puan";
            // 
            // lblEmployeesPerformance
            // 
            this.lblEmployeesPerformance.AutoSize = true;
            this.lblEmployeesPerformance.Location = new System.Drawing.Point(8, 3);
            this.lblEmployeesPerformance.Name = "lblEmployeesPerformance";
            this.lblEmployeesPerformance.Size = new System.Drawing.Size(48, 13);
            this.lblEmployeesPerformance.TabIndex = 11;
            this.lblEmployeesPerformance.Text = "Personel";
            // 
            // lstPerformanceDocuments
            // 
            this.lstPerformanceDocuments.FormattingEnabled = true;
            this.lstPerformanceDocuments.Location = new System.Drawing.Point(520, 6);
            this.lstPerformanceDocuments.Name = "lstPerformanceDocuments";
            this.lstPerformanceDocuments.Size = new System.Drawing.Size(156, 134);
            this.lstPerformanceDocuments.TabIndex = 10;
            // 
            // chartPerformanceTrend
            // 
            chartArea1.Name = "ChartArea1";
            this.chartPerformanceTrend.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartPerformanceTrend.Legends.Add(legend1);
            this.chartPerformanceTrend.Location = new System.Drawing.Point(8, 309);
            this.chartPerformanceTrend.Name = "chartPerformanceTrend";
            this.chartPerformanceTrend.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartPerformanceTrend.Series.Add(series1);
            this.chartPerformanceTrend.Size = new System.Drawing.Size(506, 187);
            this.chartPerformanceTrend.TabIndex = 9;
            this.chartPerformanceTrend.Text = "chart1";
            // 
            // cmbEmployeesPerformance
            // 
            this.cmbEmployeesPerformance.FormattingEnabled = true;
            this.cmbEmployeesPerformance.Location = new System.Drawing.Point(8, 19);
            this.cmbEmployeesPerformance.Name = "cmbEmployeesPerformance";
            this.cmbEmployeesPerformance.Size = new System.Drawing.Size(200, 21);
            this.cmbEmployeesPerformance.TabIndex = 0;
            // 
            // cmbPerformanceScore
            // 
            this.cmbPerformanceScore.FormattingEnabled = true;
            this.cmbPerformanceScore.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.cmbPerformanceScore.Location = new System.Drawing.Point(225, 19);
            this.cmbPerformanceScore.Name = "cmbPerformanceScore";
            this.cmbPerformanceScore.Size = new System.Drawing.Size(50, 21);
            this.cmbPerformanceScore.TabIndex = 1;
            // 
            // dtPeriod
            // 
            this.dtPeriod.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtPeriod.Location = new System.Drawing.Point(299, 19);
            this.dtPeriod.Name = "dtPeriod";
            this.dtPeriod.Size = new System.Drawing.Size(100, 20);
            this.dtPeriod.TabIndex = 3;
            // 
            // txtPerformanceNote
            // 
            this.txtPerformanceNote.Location = new System.Drawing.Point(8, 46);
            this.txtPerformanceNote.Multiline = true;
            this.txtPerformanceNote.Name = "txtPerformanceNote";
            this.txtPerformanceNote.Size = new System.Drawing.Size(391, 95);
            this.txtPerformanceNote.TabIndex = 4;
            // 
            // dgvPerformance
            // 
            this.dgvPerformance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPerformance.Location = new System.Drawing.Point(8, 147);
            this.dgvPerformance.Name = "dgvPerformance";
            this.dgvPerformance.Size = new System.Drawing.Size(506, 156);
            this.dgvPerformance.TabIndex = 5;
            // 
            // btnAddPerformance
            // 
            this.btnAddPerformance.Location = new System.Drawing.Point(414, 3);
            this.btnAddPerformance.Name = "btnAddPerformance";
            this.btnAddPerformance.Size = new System.Drawing.Size(100, 30);
            this.btnAddPerformance.TabIndex = 6;
            this.btnAddPerformance.Text = "Ekle";
            this.btnAddPerformance.UseVisualStyleBackColor = true;
            // 
            // btnDeletePerformance
            // 
            this.btnDeletePerformance.Location = new System.Drawing.Point(414, 39);
            this.btnDeletePerformance.Name = "btnDeletePerformance";
            this.btnDeletePerformance.Size = new System.Drawing.Size(100, 30);
            this.btnDeletePerformance.TabIndex = 7;
            this.btnDeletePerformance.Text = "Sil";
            this.btnDeletePerformance.UseVisualStyleBackColor = true;
            // 
            // btnClearPerformance
            // 
            this.btnClearPerformance.Location = new System.Drawing.Point(414, 75);
            this.btnClearPerformance.Name = "btnClearPerformance";
            this.btnClearPerformance.Size = new System.Drawing.Size(100, 30);
            this.btnClearPerformance.TabIndex = 8;
            this.btnClearPerformance.Text = "Temizle";
            this.btnClearPerformance.UseVisualStyleBackColor = true;
            // 
            // tabPageTrainingAndCertificates
            // 
            this.tabPageTrainingAndCertificates.Controls.Add(this.lblTrainingName);
            this.tabPageTrainingAndCertificates.Controls.Add(this.lblDescription);
            this.tabPageTrainingAndCertificates.Controls.Add(this.lblStatus);
            this.tabPageTrainingAndCertificates.Controls.Add(this.cmbStatus);
            this.tabPageTrainingAndCertificates.Controls.Add(this.lstbxEmployeeTraining);
            this.tabPageTrainingAndCertificates.Controls.Add(this.btnDeleteTraining);
            this.tabPageTrainingAndCertificates.Controls.Add(this.btnUpdateTraining);
            this.tabPageTrainingAndCertificates.Controls.Add(this.btnAddTraining);
            this.tabPageTrainingAndCertificates.Controls.Add(this.txtDescription);
            this.tabPageTrainingAndCertificates.Controls.Add(this.dtpTrainingEnd);
            this.tabPageTrainingAndCertificates.Controls.Add(this.dtpTrainingStart);
            this.tabPageTrainingAndCertificates.Controls.Add(this.txtTrainingName);
            this.tabPageTrainingAndCertificates.Controls.Add(this.lblSelectEmployeeTraining);
            this.tabPageTrainingAndCertificates.Controls.Add(this.cmbEmployeesTraining);
            this.tabPageTrainingAndCertificates.Location = new System.Drawing.Point(4, 22);
            this.tabPageTrainingAndCertificates.Name = "tabPageTrainingAndCertificates";
            this.tabPageTrainingAndCertificates.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTrainingAndCertificates.Size = new System.Drawing.Size(962, 552);
            this.tabPageTrainingAndCertificates.TabIndex = 2;
            this.tabPageTrainingAndCertificates.Text = "Eğitim ve Sertifikalar";
            this.tabPageTrainingAndCertificates.UseVisualStyleBackColor = true;
            // 
            // lblTrainingName
            // 
            this.lblTrainingName.AutoSize = true;
            this.lblTrainingName.Location = new System.Drawing.Point(8, 43);
            this.lblTrainingName.Name = "lblTrainingName";
            this.lblTrainingName.Size = new System.Drawing.Size(162, 13);
            this.lblTrainingName.TabIndex = 20;
            this.lblTrainingName.Text = "İlgili Eğitimin veya Sertifikanın Adı";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(8, 82);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(94, 13);
            this.lblDescription.TabIndex = 19;
            this.lblDescription.Text = "İlgili Eğitim Konusu";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(8, 121);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(142, 13);
            this.lblStatus.TabIndex = 18;
            this.lblStatus.Text = "İlgili Eğitimin Mevcut Durumu";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(11, 137);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(250, 21);
            this.cmbStatus.TabIndex = 17;
            // 
            // lstbxEmployeeTraining
            // 
            this.lstbxEmployeeTraining.FormattingEnabled = true;
            this.lstbxEmployeeTraining.Location = new System.Drawing.Point(267, 6);
            this.lstbxEmployeeTraining.Name = "lstbxEmployeeTraining";
            this.lstbxEmployeeTraining.Size = new System.Drawing.Size(153, 290);
            this.lstbxEmployeeTraining.TabIndex = 16;
            // 
            // btnDeleteTraining
            // 
            this.btnDeleteTraining.Location = new System.Drawing.Point(161, 274);
            this.btnDeleteTraining.Name = "btnDeleteTraining";
            this.btnDeleteTraining.Size = new System.Drawing.Size(100, 23);
            this.btnDeleteTraining.TabIndex = 14;
            this.btnDeleteTraining.Text = "Eğitim Sil";
            this.btnDeleteTraining.UseVisualStyleBackColor = true;
            // 
            // btnUpdateTraining
            // 
            this.btnUpdateTraining.Location = new System.Drawing.Point(161, 245);
            this.btnUpdateTraining.Name = "btnUpdateTraining";
            this.btnUpdateTraining.Size = new System.Drawing.Size(100, 23);
            this.btnUpdateTraining.TabIndex = 13;
            this.btnUpdateTraining.Text = "Eğitim Güncelle";
            this.btnUpdateTraining.UseVisualStyleBackColor = true;
            // 
            // btnAddTraining
            // 
            this.btnAddTraining.Location = new System.Drawing.Point(161, 216);
            this.btnAddTraining.Name = "btnAddTraining";
            this.btnAddTraining.Size = new System.Drawing.Size(100, 23);
            this.btnAddTraining.TabIndex = 12;
            this.btnAddTraining.Text = "Eğitim Ekle";
            this.btnAddTraining.UseVisualStyleBackColor = true;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(11, 98);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(250, 20);
            this.txtDescription.TabIndex = 10;
            // 
            // dtpTrainingEnd
            // 
            this.dtpTrainingEnd.Location = new System.Drawing.Point(61, 190);
            this.dtpTrainingEnd.Name = "dtpTrainingEnd";
            this.dtpTrainingEnd.Size = new System.Drawing.Size(200, 20);
            this.dtpTrainingEnd.TabIndex = 9;
            // 
            // dtpTrainingStart
            // 
            this.dtpTrainingStart.Location = new System.Drawing.Point(61, 164);
            this.dtpTrainingStart.Name = "dtpTrainingStart";
            this.dtpTrainingStart.Size = new System.Drawing.Size(200, 20);
            this.dtpTrainingStart.TabIndex = 8;
            // 
            // txtTrainingName
            // 
            this.txtTrainingName.Location = new System.Drawing.Point(11, 59);
            this.txtTrainingName.Name = "txtTrainingName";
            this.txtTrainingName.Size = new System.Drawing.Size(250, 20);
            this.txtTrainingName.TabIndex = 7;
            // 
            // lblSelectEmployeeTraining
            // 
            this.lblSelectEmployeeTraining.AutoSize = true;
            this.lblSelectEmployeeTraining.Location = new System.Drawing.Point(8, 3);
            this.lblSelectEmployeeTraining.Name = "lblSelectEmployeeTraining";
            this.lblSelectEmployeeTraining.Size = new System.Drawing.Size(223, 13);
            this.lblSelectEmployeeTraining.TabIndex = 0;
            this.lblSelectEmployeeTraining.Text = "İlgili Eğitim veya Sertifika İçin Personel Seçiniz";
            // 
            // cmbEmployeesTraining
            // 
            this.cmbEmployeesTraining.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmployeesTraining.FormattingEnabled = true;
            this.cmbEmployeesTraining.Location = new System.Drawing.Point(11, 19);
            this.cmbEmployeesTraining.Name = "cmbEmployeesTraining";
            this.cmbEmployeesTraining.Size = new System.Drawing.Size(250, 21);
            this.cmbEmployeesTraining.TabIndex = 1;
            // 
            // printDialog
            // 
            this.printDialog.UseEXDialog = true;
            // 
            // HRForm
            // 
            this.ClientSize = new System.Drawing.Size(970, 578);
            this.Controls.Add(this.tabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HRForm";
            this.Text = "Personel Yönetimi";
            this.tabControl.ResumeLayout(false);
            this.tabPageEmployees.ResumeLayout(false);
            this.tabPageEmployees.PerformLayout();
            this.grpEmployeeDetails.ResumeLayout(false);
            this.grpEmployeeDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picEmployeePhoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).EndInit();
            this.tabPagePerformance.ResumeLayout(false);
            this.tabPagePerformance.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartPerformanceTrend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPerformance)).EndInit();
            this.tabPageTrainingAndCertificates.ResumeLayout(false);
            this.tabPageTrainingAndCertificates.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PrintDialog printDialog;
        private System.Drawing.Printing.PrintDocument printDoc;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPerformanceTrend;
        private System.Windows.Forms.ListBox lstPerformanceDocuments;
        private System.Windows.Forms.Label lblPeriod;
        private System.Windows.Forms.Label lblPerformanceScore;
        private System.Windows.Forms.Label lblEmployeesPerformance;
        private System.Windows.Forms.Button btnUpdatePerformance;
        private System.Windows.Forms.ComboBox cmbEmployeesFilter;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.ComboBox cmbExportFormat;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.DateTimePicker dtpTrainingEnd;
        private System.Windows.Forms.DateTimePicker dtpTrainingStart;
        private System.Windows.Forms.TextBox txtTrainingName;
        private System.Windows.Forms.Button btnDeleteTraining;
        private System.Windows.Forms.Button btnUpdateTraining;
        private System.Windows.Forms.Button btnAddTraining;
        private System.Windows.Forms.ListBox lstbxEmployeeTraining;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label lblTrainingName;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblStatus;
    }
}