using System;
using System.Drawing;
using System.Windows.Forms;

namespace HumanResourcesDB
{
    partial class Mesajlar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private ComboBox cmbReceiver;
        private TextBox txtSubject;
        private TextBox txtBody;
        private Button btnSendMessage;
        private ListBox lstSentMessages;
        private TextBox txtSentBody;
        private Label lblSentSubject;
        private Label lblReceiver;
        private Label lblSubject;
        private Label lblBody;
        private Label lblSentMessagesHeader;
        private Label lblSentBodyLabel;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mesajlar));
            this.lblReceiver = new System.Windows.Forms.Label();
            this.cmbReceiver = new System.Windows.Forms.ComboBox();
            this.lblSubject = new System.Windows.Forms.Label();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.lblBody = new System.Windows.Forms.Label();
            this.txtBody = new System.Windows.Forms.TextBox();
            this.btnSendMessage = new System.Windows.Forms.Button();
            this.lblSentMessagesHeader = new System.Windows.Forms.Label();
            this.lstSentMessages = new System.Windows.Forms.ListBox();
            this.lblSentSubject = new System.Windows.Forms.Label();
            this.lblSentBodyLabel = new System.Windows.Forms.Label();
            this.txtSentBody = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblReceiver
            // 
            this.lblReceiver.AutoSize = true;
            this.lblReceiver.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblReceiver.Location = new System.Drawing.Point(9, 18);
            this.lblReceiver.Name = "lblReceiver";
            this.lblReceiver.Size = new System.Drawing.Size(36, 19);
            this.lblReceiver.TabIndex = 0;
            this.lblReceiver.Text = "Alıcı:";
            // 
            // cmbReceiver
            // 
            this.cmbReceiver.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReceiver.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbReceiver.Location = new System.Drawing.Point(79, 15);
            this.cmbReceiver.Name = "cmbReceiver";
            this.cmbReceiver.Size = new System.Drawing.Size(220, 25);
            this.cmbReceiver.TabIndex = 1;
            // 
            // lblSubject
            // 
            this.lblSubject.AutoSize = true;
            this.lblSubject.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubject.Location = new System.Drawing.Point(9, 63);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(44, 19);
            this.lblSubject.TabIndex = 2;
            this.lblSubject.Text = "Konu:";
            // 
            // txtSubject
            // 
            this.txtSubject.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSubject.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSubject.Location = new System.Drawing.Point(79, 60);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(220, 25);
            this.txtSubject.TabIndex = 3;
            // 
            // lblBody
            // 
            this.lblBody.AutoSize = true;
            this.lblBody.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblBody.Location = new System.Drawing.Point(9, 108);
            this.lblBody.Name = "lblBody";
            this.lblBody.Size = new System.Drawing.Size(48, 19);
            this.lblBody.TabIndex = 4;
            this.lblBody.Text = "Mesaj:";
            // 
            // txtBody
            // 
            this.txtBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBody.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtBody.Location = new System.Drawing.Point(79, 105);
            this.txtBody.Multiline = true;
            this.txtBody.Name = "txtBody";
            this.txtBody.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBody.Size = new System.Drawing.Size(220, 143);
            this.txtBody.TabIndex = 5;
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnSendMessage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSendMessage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendMessage.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnSendMessage.ForeColor = System.Drawing.Color.White;
            this.btnSendMessage.Location = new System.Drawing.Point(79, 254);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(220, 40);
            this.btnSendMessage.TabIndex = 6;
            this.btnSendMessage.Text = "Mesaj Gönder";
            this.btnSendMessage.UseVisualStyleBackColor = false;
            this.btnSendMessage.Click += new System.EventHandler(this.btnSendMessage_Click);
            // 
            // lblSentMessagesHeader
            // 
            this.lblSentMessagesHeader.AutoSize = true;
            this.lblSentMessagesHeader.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblSentMessagesHeader.Location = new System.Drawing.Point(319, 9);
            this.lblSentMessagesHeader.Name = "lblSentMessagesHeader";
            this.lblSentMessagesHeader.Size = new System.Drawing.Size(191, 25);
            this.lblSentMessagesHeader.TabIndex = 7;
            this.lblSentMessagesHeader.Text = "Gönderilen Mesajlar";
            // 
            // lstSentMessages
            // 
            this.lstSentMessages.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstSentMessages.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lstSentMessages.ItemHeight = 17;
            this.lstSentMessages.Location = new System.Drawing.Point(324, 37);
            this.lstSentMessages.Name = "lstSentMessages";
            this.lstSentMessages.Size = new System.Drawing.Size(261, 257);
            this.lstSentMessages.TabIndex = 8;
            this.lstSentMessages.SelectedIndexChanged += new System.EventHandler(this.lstSentMessages_SelectedIndexChanged);
            // 
            // lblSentSubject
            // 
            this.lblSentSubject.AutoSize = true;
            this.lblSentSubject.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSentSubject.Location = new System.Drawing.Point(600, 15);
            this.lblSentSubject.Name = "lblSentSubject";
            this.lblSentSubject.Size = new System.Drawing.Size(44, 19);
            this.lblSentSubject.TabIndex = 9;
            this.lblSentSubject.Text = "Konu:";
            // 
            // lblSentBodyLabel
            // 
            this.lblSentBodyLabel.AutoSize = true;
            this.lblSentBodyLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSentBodyLabel.Location = new System.Drawing.Point(600, 50);
            this.lblSentBodyLabel.Name = "lblSentBodyLabel";
            this.lblSentBodyLabel.Size = new System.Drawing.Size(88, 19);
            this.lblSentBodyLabel.TabIndex = 10;
            this.lblSentBodyLabel.Text = "Mesaj İçeriği:";
            // 
            // txtSentBody
            // 
            this.txtSentBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSentBody.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSentBody.Location = new System.Drawing.Point(600, 75);
            this.txtSentBody.Multiline = true;
            this.txtSentBody.Name = "txtSentBody";
            this.txtSentBody.ReadOnly = true;
            this.txtSentBody.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSentBody.Size = new System.Drawing.Size(208, 219);
            this.txtSentBody.TabIndex = 11;
            // 
            // Mesajlar
            // 
            this.ClientSize = new System.Drawing.Size(820, 300);
            this.Controls.Add(this.lblReceiver);
            this.Controls.Add(this.cmbReceiver);
            this.Controls.Add(this.lblSubject);
            this.Controls.Add(this.txtSubject);
            this.Controls.Add(this.lblBody);
            this.Controls.Add(this.txtBody);
            this.Controls.Add(this.btnSendMessage);
            this.Controls.Add(this.lblSentMessagesHeader);
            this.Controls.Add(this.lstSentMessages);
            this.Controls.Add(this.lblSentSubject);
            this.Controls.Add(this.lblSentBodyLabel);
            this.Controls.Add(this.txtSentBody);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Mesajlar";
            this.Text = "Mesajlar";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}