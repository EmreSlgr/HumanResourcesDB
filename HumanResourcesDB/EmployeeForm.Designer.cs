using System.Drawing;
using System.Windows.Forms;

namespace HumanResourcesDB
{
    partial class EmployeeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnChangePassword;
        private System.Windows.Forms.TextBox txtNewPasswordConfirm;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.TextBox txtOldPassword;
        private System.Windows.Forms.Label newPasswordConfirm;
        private System.Windows.Forms.Label newPassword;
        private System.Windows.Forms.Label oldPassword;
        private System.Windows.Forms.PictureBox pictureBoxProfile;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Button btnLeaveRequestForm;
        private System.Windows.Forms.Label lblSubject;
        private System.Windows.Forms.Label lblSender;
        private System.Windows.Forms.TextBox txtBody;
        private System.Windows.Forms.Button btnReadMessage;
        private System.Windows.Forms.ListBox lstMessages;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeeForm));
            this.pictureBoxProfile = new System.Windows.Forms.PictureBox();
            this.lblPersonalInfoHeader = new System.Windows.Forms.Label();
            this.lblFullName = new System.Windows.Forms.Label();
            this.lblPosition = new System.Windows.Forms.Label();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.btnLeaveRequestForm = new System.Windows.Forms.Button();
            this.lblChangePasswordHeader = new System.Windows.Forms.Label();
            this.oldPassword = new System.Windows.Forms.Label();
            this.txtOldPassword = new System.Windows.Forms.TextBox();
            this.newPassword = new System.Windows.Forms.Label();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.newPasswordConfirm = new System.Windows.Forms.Label();
            this.txtNewPasswordConfirm = new System.Windows.Forms.TextBox();
            this.btnChangePassword = new System.Windows.Forms.Button();
            this.lblMessagesHeader = new System.Windows.Forms.Label();
            this.lblSubject = new System.Windows.Forms.Label();
            this.lblSender = new System.Windows.Forms.Label();
            this.lstMessages = new System.Windows.Forms.ListBox();
            this.txtBody = new System.Windows.Forms.TextBox();
            this.btnReadMessage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfile)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxProfile
            // 
            this.pictureBoxProfile.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pictureBoxProfile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxProfile.Location = new System.Drawing.Point(20, 20);
            this.pictureBoxProfile.Name = "pictureBoxProfile";
            this.pictureBoxProfile.Size = new System.Drawing.Size(140, 140);
            this.pictureBoxProfile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxProfile.TabIndex = 0;
            this.pictureBoxProfile.TabStop = false;
            // 
            // lblPersonalInfoHeader
            // 
            this.lblPersonalInfoHeader.AutoSize = true;
            this.lblPersonalInfoHeader.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblPersonalInfoHeader.Location = new System.Drawing.Point(180, 10);
            this.lblPersonalInfoHeader.Name = "lblPersonalInfoHeader";
            this.lblPersonalInfoHeader.Size = new System.Drawing.Size(160, 25);
            this.lblPersonalInfoHeader.TabIndex = 1;
            this.lblPersonalInfoHeader.Text = "Personel Bilgileri";
            // 
            // lblFullName
            // 
            this.lblFullName.AutoSize = true;
            this.lblFullName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblFullName.Location = new System.Drawing.Point(180, 45);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(83, 19);
            this.lblFullName.TabIndex = 2;
            this.lblFullName.Text = "Ad Soyad: ...";
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPosition.Location = new System.Drawing.Point(180, 75);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(78, 19);
            this.lblPosition.TabIndex = 3;
            this.lblPosition.Text = "Pozisyon: ...";
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDepartment.Location = new System.Drawing.Point(180, 105);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(94, 19);
            this.lblDepartment.TabIndex = 4;
            this.lblDepartment.Text = "Departman: ...";
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPhone.Location = new System.Drawing.Point(180, 135);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(68, 19);
            this.lblPhone.TabIndex = 5;
            this.lblPhone.Text = "Telefon: ...";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblEmail.Location = new System.Drawing.Point(180, 165);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(71, 19);
            this.lblEmail.TabIndex = 6;
            this.lblEmail.Text = "E-Posta: ...";
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblStartDate.Location = new System.Drawing.Point(180, 195);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(131, 19);
            this.lblStartDate.TabIndex = 7;
            this.lblStartDate.Text = "İşe Başlama Tarihi: ...";
            // 
            // btnLeaveRequestForm
            // 
            this.btnLeaveRequestForm.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnLeaveRequestForm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLeaveRequestForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLeaveRequestForm.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnLeaveRequestForm.ForeColor = System.Drawing.Color.White;
            this.btnLeaveRequestForm.Location = new System.Drawing.Point(20, 180);
            this.btnLeaveRequestForm.Name = "btnLeaveRequestForm";
            this.btnLeaveRequestForm.Size = new System.Drawing.Size(140, 40);
            this.btnLeaveRequestForm.TabIndex = 8;
            this.btnLeaveRequestForm.Text = "İzin Talebi Oluştur";
            this.btnLeaveRequestForm.UseVisualStyleBackColor = false;
            this.btnLeaveRequestForm.Click += new System.EventHandler(this.btnLeaveRequestForm_Click);
            // 
            // lblChangePasswordHeader
            // 
            this.lblChangePasswordHeader.AutoSize = true;
            this.lblChangePasswordHeader.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblChangePasswordHeader.Location = new System.Drawing.Point(520, 10);
            this.lblChangePasswordHeader.Name = "lblChangePasswordHeader";
            this.lblChangePasswordHeader.Size = new System.Drawing.Size(127, 25);
            this.lblChangePasswordHeader.TabIndex = 9;
            this.lblChangePasswordHeader.Text = "Şifre Değiştir";
            // 
            // oldPassword
            // 
            this.oldPassword.AutoSize = true;
            this.oldPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.oldPassword.Location = new System.Drawing.Point(520, 50);
            this.oldPassword.Name = "oldPassword";
            this.oldPassword.Size = new System.Drawing.Size(65, 19);
            this.oldPassword.TabIndex = 10;
            this.oldPassword.Text = "Eski Şifre:";
            // 
            // txtOldPassword
            // 
            this.txtOldPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOldPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtOldPassword.Location = new System.Drawing.Point(520, 75);
            this.txtOldPassword.Name = "txtOldPassword";
            this.txtOldPassword.Size = new System.Drawing.Size(260, 25);
            this.txtOldPassword.TabIndex = 11;
            this.txtOldPassword.UseSystemPasswordChar = true;
            // 
            // newPassword
            // 
            this.newPassword.AutoSize = true;
            this.newPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.newPassword.Location = new System.Drawing.Point(520, 110);
            this.newPassword.Name = "newPassword";
            this.newPassword.Size = new System.Drawing.Size(67, 19);
            this.newPassword.TabIndex = 12;
            this.newPassword.Text = "Yeni Şifre:";
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNewPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNewPassword.Location = new System.Drawing.Point(520, 135);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.Size = new System.Drawing.Size(260, 25);
            this.txtNewPassword.TabIndex = 13;
            this.txtNewPassword.UseSystemPasswordChar = true;
            // 
            // newPasswordConfirm
            // 
            this.newPasswordConfirm.AutoSize = true;
            this.newPasswordConfirm.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.newPasswordConfirm.Location = new System.Drawing.Point(520, 170);
            this.newPasswordConfirm.Name = "newPasswordConfirm";
            this.newPasswordConfirm.Size = new System.Drawing.Size(116, 19);
            this.newPasswordConfirm.TabIndex = 14;
            this.newPasswordConfirm.Text = "Yeni Şifre (Tekrar):";
            // 
            // txtNewPasswordConfirm
            // 
            this.txtNewPasswordConfirm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNewPasswordConfirm.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNewPasswordConfirm.Location = new System.Drawing.Point(520, 195);
            this.txtNewPasswordConfirm.Name = "txtNewPasswordConfirm";
            this.txtNewPasswordConfirm.Size = new System.Drawing.Size(260, 25);
            this.txtNewPasswordConfirm.TabIndex = 15;
            this.txtNewPasswordConfirm.UseSystemPasswordChar = true;
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnChangePassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChangePassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangePassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnChangePassword.ForeColor = System.Drawing.Color.White;
            this.btnChangePassword.Location = new System.Drawing.Point(520, 235);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(260, 40);
            this.btnChangePassword.TabIndex = 16;
            this.btnChangePassword.Text = "Şifre Değiştir";
            this.btnChangePassword.UseVisualStyleBackColor = false;
            this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);
            // 
            // lblMessagesHeader
            // 
            this.lblMessagesHeader.AutoSize = true;
            this.lblMessagesHeader.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblMessagesHeader.Location = new System.Drawing.Point(20, 240);
            this.lblMessagesHeader.Name = "lblMessagesHeader";
            this.lblMessagesHeader.Size = new System.Drawing.Size(86, 25);
            this.lblMessagesHeader.TabIndex = 17;
            this.lblMessagesHeader.Text = "Mesajlar";
            // 
            // lblSubject
            // 
            this.lblSubject.AutoSize = true;
            this.lblSubject.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubject.Location = new System.Drawing.Point(20, 280);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(98, 19);
            this.lblSubject.TabIndex = 18;
            this.lblSubject.Text = "Mesaj Konusu:";
            // 
            // lblSender
            // 
            this.lblSender.AutoSize = true;
            this.lblSender.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSender.Location = new System.Drawing.Point(20, 305);
            this.lblSender.Name = "lblSender";
            this.lblSender.Size = new System.Drawing.Size(126, 19);
            this.lblSender.TabIndex = 19;
            this.lblSender.Text = "Gönderen Kullanıcı:";
            // 
            // lstMessages
            // 
            this.lstMessages.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstMessages.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lstMessages.ItemHeight = 17;
            this.lstMessages.Location = new System.Drawing.Point(20, 330);
            this.lstMessages.Name = "lstMessages";
            this.lstMessages.Size = new System.Drawing.Size(430, 104);
            this.lstMessages.TabIndex = 20;
            // 
            // txtBody
            // 
            this.txtBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBody.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtBody.Location = new System.Drawing.Point(470, 280);
            this.txtBody.Multiline = true;
            this.txtBody.Name = "txtBody";
            this.txtBody.ReadOnly = true;
            this.txtBody.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBody.Size = new System.Drawing.Size(310, 160);
            this.txtBody.TabIndex = 21;
            // 
            // btnReadMessage
            // 
            this.btnReadMessage.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnReadMessage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReadMessage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReadMessage.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnReadMessage.ForeColor = System.Drawing.Color.White;
            this.btnReadMessage.Location = new System.Drawing.Point(340, 294);
            this.btnReadMessage.Name = "btnReadMessage";
            this.btnReadMessage.Size = new System.Drawing.Size(110, 30);
            this.btnReadMessage.TabIndex = 22;
            this.btnReadMessage.Text = "Mesajı Oku";
            this.btnReadMessage.UseVisualStyleBackColor = false;
            this.btnReadMessage.Click += new System.EventHandler(this.btnReadMessage_Click);
            // 
            // EmployeeForm
            // 
            this.ClientSize = new System.Drawing.Size(800, 453);
            this.Controls.Add(this.pictureBoxProfile);
            this.Controls.Add(this.lblPersonalInfoHeader);
            this.Controls.Add(this.lblFullName);
            this.Controls.Add(this.lblPosition);
            this.Controls.Add(this.lblDepartment);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblStartDate);
            this.Controls.Add(this.btnLeaveRequestForm);
            this.Controls.Add(this.lblChangePasswordHeader);
            this.Controls.Add(this.oldPassword);
            this.Controls.Add(this.txtOldPassword);
            this.Controls.Add(this.newPassword);
            this.Controls.Add(this.txtNewPassword);
            this.Controls.Add(this.newPasswordConfirm);
            this.Controls.Add(this.txtNewPasswordConfirm);
            this.Controls.Add(this.btnChangePassword);
            this.Controls.Add(this.lblMessagesHeader);
            this.Controls.Add(this.lblSubject);
            this.Controls.Add(this.lblSender);
            this.Controls.Add(this.lstMessages);
            this.Controls.Add(this.txtBody);
            this.Controls.Add(this.btnReadMessage);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "EmployeeForm";
            this.Text = "Personel Bilgi & Talep & İşlemler Formu";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfile)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Label lblPersonalInfoHeader;
        private Label lblChangePasswordHeader;
        private Label lblMessagesHeader;
    }
    #endregion
}
