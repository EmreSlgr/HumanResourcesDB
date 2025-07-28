namespace HumanResourcesDB
{
    partial class AdminForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminForm));
            this.lblName = new System.Windows.Forms.Label();
            this.lblSurname = new System.Windows.Forms.Label();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.lblPosition = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtSurname = new System.Windows.Forms.TextBox();
            this.cmbDepartment = new System.Windows.Forms.ComboBox();
            this.cmbPosition = new System.Windows.Forms.ComboBox();
            this.dgvEmployees = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.grpEmployeeDetails = new System.Windows.Forms.GroupBox();
            this.lblEmployeeEmail = new System.Windows.Forms.Label();
            this.lblEmployeeStartDate = new System.Windows.Forms.Label();
            this.lblEmployeePhone = new System.Windows.Forms.Label();
            this.lblEmployeePosition = new System.Windows.Forms.Label();
            this.lblEmployeeDepartment = new System.Windows.Forms.Label();
            this.lblEmployeeFullName = new System.Windows.Forms.Label();
            this.picEmployeePhoto = new System.Windows.Forms.PictureBox();
            this.btnUploadPhoto = new System.Windows.Forms.Button();
            this.btnUploadDocument = new System.Windows.Forms.Button();
            this.lstBoxDocuments = new System.Windows.Forms.ListBox();
            this.btnDeleteDocument = new System.Windows.Forms.Button();
            this.lblGender = new System.Windows.Forms.Label();
            this.cmbGender = new System.Windows.Forms.ComboBox();
            this.lblBirthDate = new System.Windows.Forms.Label();
            this.dtBirthDate = new System.Windows.Forms.DateTimePicker();
            this.lblHireDate = new System.Windows.Forms.Label();
            this.dtHireDate = new System.Windows.Forms.DateTimePicker();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblRelativePhone = new System.Windows.Forms.Label();
            this.txtRelativePhone = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.cmbRole = new System.Windows.Forms.ComboBox();
            this.lblRole = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.btnLeaveApprovalForm = new System.Windows.Forms.Button();
            this.btnLoadEmployeeStatistics = new System.Windows.Forms.Button();
            this.btnMessage = new System.Windows.Forms.Button();
            this.btnContext = new System.Windows.Forms.Button();
            this.btnPrintDocument = new System.Windows.Forms.Button();
            this.printDialog = new System.Windows.Forms.PrintDialog();
            this.printDoc = new System.Drawing.Printing.PrintDocument();
            this.lblActiveEmployees = new System.Windows.Forms.Label();
            this.lblEmployeesOnLeave = new System.Windows.Forms.Label();
            this.pnlDashboard = new System.Windows.Forms.Panel();
            this.listBoxTodayOnLeave = new System.Windows.Forms.ListBox();
            this.lblPendingLeaves = new System.Windows.Forms.Label();
            this.lstAnnouncements = new System.Windows.Forms.ListBox();
            this.lstBirthdayToday = new System.Windows.Forms.ListBox();
            this.timerDashboardRefresh = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).BeginInit();
            this.grpEmployeeDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picEmployeePhoto)).BeginInit();
            this.pnlDashboard.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblName.Location = new System.Drawing.Point(163, 12);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(31, 17);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Ad :";
            // 
            // lblSurname
            // 
            this.lblSurname.AutoSize = true;
            this.lblSurname.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSurname.Location = new System.Drawing.Point(163, 38);
            this.lblSurname.Name = "lblSurname";
            this.lblSurname.Size = new System.Drawing.Size(51, 17);
            this.lblSurname.TabIndex = 1;
            this.lblSurname.Text = "Soyad :";
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblDepartment.Location = new System.Drawing.Point(163, 117);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(80, 17);
            this.lblDepartment.TabIndex = 2;
            this.lblDepartment.Text = "Departman :";
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblPosition.Location = new System.Drawing.Point(163, 144);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(66, 17);
            this.lblPosition.TabIndex = 3;
            this.lblPosition.Text = "Pozisyon :";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(263, 12);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(147, 20);
            this.txtName.TabIndex = 4;
            // 
            // txtSurname
            // 
            this.txtSurname.Location = new System.Drawing.Point(263, 38);
            this.txtSurname.Name = "txtSurname";
            this.txtSurname.Size = new System.Drawing.Size(147, 20);
            this.txtSurname.TabIndex = 5;
            // 
            // cmbDepartment
            // 
            this.cmbDepartment.FormattingEnabled = true;
            this.cmbDepartment.Location = new System.Drawing.Point(263, 117);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new System.Drawing.Size(147, 21);
            this.cmbDepartment.TabIndex = 6;
            // 
            // cmbPosition
            // 
            this.cmbPosition.FormattingEnabled = true;
            this.cmbPosition.Location = new System.Drawing.Point(263, 144);
            this.cmbPosition.Name = "cmbPosition";
            this.cmbPosition.Size = new System.Drawing.Size(147, 21);
            this.cmbPosition.TabIndex = 7;
            // 
            // dgvEmployees
            // 
            this.dgvEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployees.Location = new System.Drawing.Point(163, 402);
            this.dgvEmployees.Name = "dgvEmployees";
            this.dgvEmployees.Size = new System.Drawing.Size(944, 150);
            this.dgvEmployees.TabIndex = 8;
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAdd.Location = new System.Drawing.Point(659, 12);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(191, 23);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "Personel Ekle";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnUpdate.Location = new System.Drawing.Point(659, 41);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(191, 23);
            this.btnUpdate.TabIndex = 10;
            this.btnUpdate.Text = "Personel Güncelle";
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnDelete.Location = new System.Drawing.Point(659, 70);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(191, 23);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Text = "Personel Sil";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblWelcome.Location = new System.Drawing.Point(3, 13);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(57, 15);
            this.lblWelcome.TabIndex = 12;
            this.lblWelcome.Text = "Welcome";
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
            this.grpEmployeeDetails.Location = new System.Drawing.Point(856, 12);
            this.grpEmployeeDetails.Name = "grpEmployeeDetails";
            this.grpEmployeeDetails.Size = new System.Drawing.Size(258, 322);
            this.grpEmployeeDetails.TabIndex = 13;
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
            // btnUploadPhoto
            // 
            this.btnUploadPhoto.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnUploadPhoto.Location = new System.Drawing.Point(659, 99);
            this.btnUploadPhoto.Name = "btnUploadPhoto";
            this.btnUploadPhoto.Size = new System.Drawing.Size(191, 23);
            this.btnUploadPhoto.TabIndex = 14;
            this.btnUploadPhoto.Text = "Fotoğraf Ekle";
            this.btnUploadPhoto.UseVisualStyleBackColor = true;
            // 
            // btnUploadDocument
            // 
            this.btnUploadDocument.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnUploadDocument.Location = new System.Drawing.Point(659, 128);
            this.btnUploadDocument.Name = "btnUploadDocument";
            this.btnUploadDocument.Size = new System.Drawing.Size(191, 23);
            this.btnUploadDocument.TabIndex = 15;
            this.btnUploadDocument.Text = "Döküman Ekle";
            this.btnUploadDocument.UseVisualStyleBackColor = true;
            // 
            // lstBoxDocuments
            // 
            this.lstBoxDocuments.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lstBoxDocuments.FormattingEnabled = true;
            this.lstBoxDocuments.ItemHeight = 17;
            this.lstBoxDocuments.Location = new System.Drawing.Point(659, 157);
            this.lstBoxDocuments.Name = "lstBoxDocuments";
            this.lstBoxDocuments.Size = new System.Drawing.Size(191, 89);
            this.lstBoxDocuments.TabIndex = 16;
            // 
            // btnDeleteDocument
            // 
            this.btnDeleteDocument.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnDeleteDocument.Location = new System.Drawing.Point(659, 258);
            this.btnDeleteDocument.Name = "btnDeleteDocument";
            this.btnDeleteDocument.Size = new System.Drawing.Size(191, 23);
            this.btnDeleteDocument.TabIndex = 17;
            this.btnDeleteDocument.Text = "Döküman Sil";
            this.btnDeleteDocument.UseVisualStyleBackColor = true;
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblGender.Location = new System.Drawing.Point(163, 64);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(59, 17);
            this.lblGender.TabIndex = 18;
            this.lblGender.Text = "Cinsiyet :";
            // 
            // cmbGender
            // 
            this.cmbGender.FormattingEnabled = true;
            this.cmbGender.Items.AddRange(new object[] {
            "Erkek",
            "Kadın"});
            this.cmbGender.Location = new System.Drawing.Point(263, 64);
            this.cmbGender.Name = "cmbGender";
            this.cmbGender.Size = new System.Drawing.Size(147, 21);
            this.cmbGender.TabIndex = 19;
            // 
            // lblBirthDate
            // 
            this.lblBirthDate.AutoSize = true;
            this.lblBirthDate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBirthDate.Location = new System.Drawing.Point(163, 91);
            this.lblBirthDate.Name = "lblBirthDate";
            this.lblBirthDate.Size = new System.Drawing.Size(93, 17);
            this.lblBirthDate.TabIndex = 20;
            this.lblBirthDate.Text = "Doğum Tarihi :";
            // 
            // dtBirthDate
            // 
            this.dtBirthDate.Location = new System.Drawing.Point(263, 91);
            this.dtBirthDate.Name = "dtBirthDate";
            this.dtBirthDate.Size = new System.Drawing.Size(147, 20);
            this.dtBirthDate.TabIndex = 21;
            // 
            // lblHireDate
            // 
            this.lblHireDate.AutoSize = true;
            this.lblHireDate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblHireDate.Location = new System.Drawing.Point(163, 171);
            this.lblHireDate.Name = "lblHireDate";
            this.lblHireDate.Size = new System.Drawing.Size(96, 17);
            this.lblHireDate.TabIndex = 22;
            this.lblHireDate.Text = "İşe Giriş Tarihi :";
            // 
            // dtHireDate
            // 
            this.dtHireDate.Location = new System.Drawing.Point(263, 171);
            this.dtHireDate.Name = "dtHireDate";
            this.dtHireDate.Size = new System.Drawing.Size(147, 20);
            this.dtHireDate.TabIndex = 23;
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblPhone.Location = new System.Drawing.Point(163, 197);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(57, 17);
            this.lblPhone.TabIndex = 24;
            this.lblPhone.Text = "Telefon :";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(263, 197);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(147, 20);
            this.txtPhone.TabIndex = 25;
            this.txtPhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPhone_KeyPress);
            // 
            // lblRelativePhone
            // 
            this.lblRelativePhone.AutoSize = true;
            this.lblRelativePhone.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblRelativePhone.Location = new System.Drawing.Point(163, 223);
            this.lblRelativePhone.Name = "lblRelativePhone";
            this.lblRelativePhone.Size = new System.Drawing.Size(93, 17);
            this.lblRelativePhone.TabIndex = 26;
            this.lblRelativePhone.Text = "Yakını Telefon :";
            // 
            // txtRelativePhone
            // 
            this.txtRelativePhone.Location = new System.Drawing.Point(263, 223);
            this.txtRelativePhone.Name = "txtRelativePhone";
            this.txtRelativePhone.Size = new System.Drawing.Size(147, 20);
            this.txtRelativePhone.TabIndex = 27;
            this.txtRelativePhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRelativePhone_KeyPress);
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblAddress.Location = new System.Drawing.Point(163, 249);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(49, 17);
            this.lblAddress.TabIndex = 28;
            this.lblAddress.Text = "Adres :";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(263, 249);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(149, 98);
            this.txtAddress.TabIndex = 29;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblEmail.Location = new System.Drawing.Point(163, 353);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(46, 17);
            this.lblEmail.TabIndex = 30;
            this.lblEmail.Text = "Email :";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(263, 353);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(147, 20);
            this.txtEmail.TabIndex = 31;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(532, 12);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(121, 20);
            this.txtUsername.TabIndex = 32;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(532, 38);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(121, 20);
            this.txtPassword.TabIndex = 33;
            // 
            // cmbRole
            // 
            this.cmbRole.FormattingEnabled = true;
            this.cmbRole.Location = new System.Drawing.Point(532, 64);
            this.cmbRole.Name = "cmbRole";
            this.cmbRole.Size = new System.Drawing.Size(121, 21);
            this.cmbRole.TabIndex = 34;
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblRole.Location = new System.Drawing.Point(432, 64);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(92, 17);
            this.lblRole.TabIndex = 37;
            this.lblRole.Text = "Kullanıcı Rolü :";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblPassword.Location = new System.Drawing.Point(432, 38);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(92, 17);
            this.lblPassword.TabIndex = 36;
            this.lblPassword.Text = "Kullanıcı Şifre :";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblUserName.Location = new System.Drawing.Point(432, 12);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(85, 17);
            this.lblUserName.TabIndex = 35;
            this.lblUserName.Text = "Kullanıcı Adı :";
            // 
            // btnLeaveApprovalForm
            // 
            this.btnLeaveApprovalForm.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnLeaveApprovalForm.Location = new System.Drawing.Point(1120, 20);
            this.btnLeaveApprovalForm.Name = "btnLeaveApprovalForm";
            this.btnLeaveApprovalForm.Size = new System.Drawing.Size(118, 61);
            this.btnLeaveApprovalForm.TabIndex = 38;
            this.btnLeaveApprovalForm.Text = "İzin Taleplerini Gör";
            this.btnLeaveApprovalForm.UseVisualStyleBackColor = true;
            this.btnLeaveApprovalForm.Click += new System.EventHandler(this.btnLeaveApprovalForm_Click);
            // 
            // btnLoadEmployeeStatistics
            // 
            this.btnLoadEmployeeStatistics.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnLoadEmployeeStatistics.Location = new System.Drawing.Point(1124, 87);
            this.btnLoadEmployeeStatistics.Name = "btnLoadEmployeeStatistics";
            this.btnLoadEmployeeStatistics.Size = new System.Drawing.Size(118, 61);
            this.btnLoadEmployeeStatistics.TabIndex = 39;
            this.btnLoadEmployeeStatistics.Text = "Personel Sayısı ve Departman Bazlı Dağılım";
            this.btnLoadEmployeeStatistics.UseVisualStyleBackColor = true;
            this.btnLoadEmployeeStatistics.Click += new System.EventHandler(this.btnLoadEmployeeStatistics_Click);
            // 
            // btnMessage
            // 
            this.btnMessage.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnMessage.Location = new System.Drawing.Point(1248, 20);
            this.btnMessage.Name = "btnMessage";
            this.btnMessage.Size = new System.Drawing.Size(118, 61);
            this.btnMessage.TabIndex = 40;
            this.btnMessage.Text = "Seçilen Kullanıcıya Mesaj Gönder";
            this.btnMessage.UseVisualStyleBackColor = true;
            this.btnMessage.Click += new System.EventHandler(this.btnMessage_Click);
            // 
            // btnContext
            // 
            this.btnContext.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnContext.Location = new System.Drawing.Point(1248, 87);
            this.btnContext.Name = "btnContext";
            this.btnContext.Size = new System.Drawing.Size(118, 61);
            this.btnContext.TabIndex = 41;
            this.btnContext.Text = "Tüm Kullanıcılara Duyuru Gönder";
            this.btnContext.UseVisualStyleBackColor = true;
            this.btnContext.Click += new System.EventHandler(this.btnContext_Click);
            // 
            // btnPrintDocument
            // 
            this.btnPrintDocument.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnPrintDocument.Location = new System.Drawing.Point(659, 287);
            this.btnPrintDocument.Name = "btnPrintDocument";
            this.btnPrintDocument.Size = new System.Drawing.Size(191, 23);
            this.btnPrintDocument.TabIndex = 42;
            this.btnPrintDocument.Text = "Seçilen Dökümanı Çıktı Al";
            this.btnPrintDocument.UseVisualStyleBackColor = true;
            this.btnPrintDocument.Click += new System.EventHandler(this.btnPrintDocument_Click);
            // 
            // printDialog
            // 
            this.printDialog.UseEXDialog = true;
            // 
            // lblActiveEmployees
            // 
            this.lblActiveEmployees.AutoSize = true;
            this.lblActiveEmployees.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblActiveEmployees.Location = new System.Drawing.Point(3, 50);
            this.lblActiveEmployees.Name = "lblActiveEmployees";
            this.lblActiveEmployees.Size = new System.Drawing.Size(112, 15);
            this.lblActiveEmployees.TabIndex = 43;
            this.lblActiveEmployees.Text = "Aktif Personel Sayısı";
            // 
            // lblEmployeesOnLeave
            // 
            this.lblEmployeesOnLeave.AutoSize = true;
            this.lblEmployeesOnLeave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblEmployeesOnLeave.Location = new System.Drawing.Point(6, 82);
            this.lblEmployeesOnLeave.Name = "lblEmployeesOnLeave";
            this.lblEmployeesOnLeave.Size = new System.Drawing.Size(139, 15);
            this.lblEmployeesOnLeave.TabIndex = 44;
            this.lblEmployeesOnLeave.Text = "Aktif İzinli Personel Sayısı";
            // 
            // pnlDashboard
            // 
            this.pnlDashboard.Controls.Add(this.listBoxTodayOnLeave);
            this.pnlDashboard.Controls.Add(this.lblPendingLeaves);
            this.pnlDashboard.Controls.Add(this.lstAnnouncements);
            this.pnlDashboard.Controls.Add(this.lstBirthdayToday);
            this.pnlDashboard.Controls.Add(this.lblActiveEmployees);
            this.pnlDashboard.Controls.Add(this.lblEmployeesOnLeave);
            this.pnlDashboard.Controls.Add(this.lblWelcome);
            this.pnlDashboard.Location = new System.Drawing.Point(12, 14);
            this.pnlDashboard.Name = "pnlDashboard";
            this.pnlDashboard.Size = new System.Drawing.Size(145, 538);
            this.pnlDashboard.TabIndex = 45;
            // 
            // listBoxTodayOnLeave
            // 
            this.listBoxTodayOnLeave.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.listBoxTodayOnLeave.FormattingEnabled = true;
            this.listBoxTodayOnLeave.ItemHeight = 17;
            this.listBoxTodayOnLeave.Location = new System.Drawing.Point(6, 100);
            this.listBoxTodayOnLeave.Name = "listBoxTodayOnLeave";
            this.listBoxTodayOnLeave.Size = new System.Drawing.Size(135, 89);
            this.listBoxTodayOnLeave.TabIndex = 48;
            // 
            // lblPendingLeaves
            // 
            this.lblPendingLeaves.AutoSize = true;
            this.lblPendingLeaves.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblPendingLeaves.Location = new System.Drawing.Point(3, 65);
            this.lblPendingLeaves.Name = "lblPendingLeaves";
            this.lblPendingLeaves.Size = new System.Drawing.Size(138, 15);
            this.lblPendingLeaves.TabIndex = 47;
            this.lblPendingLeaves.Text = "Bekleyen İzin Talep Sayısı";
            // 
            // lstAnnouncements
            // 
            this.lstAnnouncements.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lstAnnouncements.FormattingEnabled = true;
            this.lstAnnouncements.ItemHeight = 17;
            this.lstAnnouncements.Location = new System.Drawing.Point(6, 195);
            this.lstAnnouncements.Name = "lstAnnouncements";
            this.lstAnnouncements.Size = new System.Drawing.Size(135, 89);
            this.lstAnnouncements.TabIndex = 46;
            // 
            // lstBirthdayToday
            // 
            this.lstBirthdayToday.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lstBirthdayToday.FormattingEnabled = true;
            this.lstBirthdayToday.ItemHeight = 17;
            this.lstBirthdayToday.Location = new System.Drawing.Point(6, 290);
            this.lstBirthdayToday.Name = "lstBirthdayToday";
            this.lstBirthdayToday.Size = new System.Drawing.Size(135, 89);
            this.lstBirthdayToday.TabIndex = 45;
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1372, 675);
            this.Controls.Add(this.pnlDashboard);
            this.Controls.Add(this.btnPrintDocument);
            this.Controls.Add(this.btnContext);
            this.Controls.Add(this.btnMessage);
            this.Controls.Add(this.btnLoadEmployeeStatistics);
            this.Controls.Add(this.btnLeaveApprovalForm);
            this.Controls.Add(this.lblRole);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.cmbRole);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.txtRelativePhone);
            this.Controls.Add(this.lblRelativePhone);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.dtHireDate);
            this.Controls.Add(this.lblHireDate);
            this.Controls.Add(this.dtBirthDate);
            this.Controls.Add(this.lblBirthDate);
            this.Controls.Add(this.cmbGender);
            this.Controls.Add(this.lblGender);
            this.Controls.Add(this.btnDeleteDocument);
            this.Controls.Add(this.lstBoxDocuments);
            this.Controls.Add(this.btnUploadDocument);
            this.Controls.Add(this.btnUploadPhoto);
            this.Controls.Add(this.grpEmployeeDetails);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dgvEmployees);
            this.Controls.Add(this.cmbPosition);
            this.Controls.Add(this.cmbDepartment);
            this.Controls.Add(this.txtSurname);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblPosition);
            this.Controls.Add(this.lblDepartment);
            this.Controls.Add(this.lblSurname);
            this.Controls.Add(this.lblName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AdminForm";
            this.Text = "AdminForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).EndInit();
            this.grpEmployeeDetails.ResumeLayout(false);
            this.grpEmployeeDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picEmployeePhoto)).EndInit();
            this.pnlDashboard.ResumeLayout(false);
            this.pnlDashboard.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblSurname;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtSurname;
        private System.Windows.Forms.ComboBox cmbDepartment;
        private System.Windows.Forms.ComboBox cmbPosition;
        private System.Windows.Forms.DataGridView dgvEmployees;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.GroupBox grpEmployeeDetails;
        private System.Windows.Forms.Label lblEmployeeEmail;
        private System.Windows.Forms.Label lblEmployeeStartDate;
        private System.Windows.Forms.Label lblEmployeePhone;
        private System.Windows.Forms.Label lblEmployeePosition;
        private System.Windows.Forms.Label lblEmployeeDepartment;
        private System.Windows.Forms.Label lblEmployeeFullName;
        private System.Windows.Forms.PictureBox picEmployeePhoto;
        private System.Windows.Forms.Button btnUploadPhoto;
        private System.Windows.Forms.Button btnUploadDocument;
        private System.Windows.Forms.ListBox lstBoxDocuments;
        private System.Windows.Forms.Button btnDeleteDocument;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.ComboBox cmbGender;
        private System.Windows.Forms.Label lblBirthDate;
        private System.Windows.Forms.DateTimePicker dtBirthDate;
        private System.Windows.Forms.Label lblHireDate;
        private System.Windows.Forms.DateTimePicker dtHireDate;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblRelativePhone;
        private System.Windows.Forms.TextBox txtRelativePhone;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.ComboBox cmbRole;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Button btnLeaveApprovalForm;
        private System.Windows.Forms.Button btnLoadEmployeeStatistics;
        private System.Windows.Forms.Button btnMessage;
        private System.Windows.Forms.Button btnContext;
        private System.Windows.Forms.Button btnPrintDocument;
        private System.Windows.Forms.PrintDialog printDialog;
        private System.Drawing.Printing.PrintDocument printDoc;
        private System.Windows.Forms.Label lblActiveEmployees;
        private System.Windows.Forms.Label lblEmployeesOnLeave;
        private System.Windows.Forms.Panel pnlDashboard;
        private System.Windows.Forms.Label lblPendingLeaves;
        private System.Windows.Forms.ListBox lstAnnouncements;
        private System.Windows.Forms.ListBox lstBirthdayToday;
        private System.Windows.Forms.ListBox listBoxTodayOnLeave;
        private System.Windows.Forms.Timer timerDashboardRefresh;
    }
}