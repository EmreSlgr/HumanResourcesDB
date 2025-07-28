using System;
using System.Drawing;
using System.Windows.Forms;

namespace HumanResourcesDB
{
    partial class LeaveRequestForm : Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblLeaveType;
        private System.Windows.Forms.ComboBox cmbLeaveTypes;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label lblReason;
        private System.Windows.Forms.TextBox txtReason;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label lblMessage;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LeaveRequestForm));
            this.lblLeaveType = new Label();
            this.cmbLeaveTypes = new ComboBox();
            this.lblStartDate = new Label();
            this.dtpStartDate = new DateTimePicker();
            this.lblEndDate = new Label();
            this.dtpEndDate = new DateTimePicker();
            this.lblReason = new Label();
            this.txtReason = new TextBox();
            this.btnSubmit = new Button();
            this.lblMessage = new Label();
            this.SuspendLayout();

            // Genel font ayarı
            Font defaultFont = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);

            // lblLeaveType
            this.lblLeaveType.AutoSize = true;
            this.lblLeaveType.Font = defaultFont;
            this.lblLeaveType.Location = new Point(30, 25);
            this.lblLeaveType.Text = "İzin Türü:";

            // cmbLeaveTypes
            this.cmbLeaveTypes.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbLeaveTypes.Font = defaultFont;
            this.cmbLeaveTypes.Location = new Point(140, 22);
            this.cmbLeaveTypes.Size = new Size(250, 25);

            // lblStartDate
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Font = defaultFont;
            this.lblStartDate.Location = new Point(30, 70);
            this.lblStartDate.Text = "Başlangıç Tarihi:";

            // dtpStartDate
            this.dtpStartDate.Font = defaultFont;
            this.dtpStartDate.Format = DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new Point(140, 67);
            this.dtpStartDate.Size = new Size(250, 25);

            // lblEndDate
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Font = defaultFont;
            this.lblEndDate.Location = new Point(30, 110);
            this.lblEndDate.Text = "Bitiş Tarihi:";

            // dtpEndDate
            this.dtpEndDate.Font = defaultFont;
            this.dtpEndDate.Format = DateTimePickerFormat.Short;
            this.dtpEndDate.Location = new Point(140, 107);
            this.dtpEndDate.Size = new Size(250, 25);

            // lblReason
            this.lblReason.AutoSize = true;
            this.lblReason.Font = defaultFont;
            this.lblReason.Location = new Point(30, 150);
            this.lblReason.Text = "İzin Sebebi:";

            // txtReason
            this.txtReason.Font = defaultFont;
            this.txtReason.Location = new Point(140, 147);
            this.txtReason.Multiline = true;
            this.txtReason.ScrollBars = ScrollBars.Vertical;
            this.txtReason.Size = new Size(250, 90);

            // btnSubmit
            this.btnSubmit.Text = "İzin Talebini Gönder";
            this.btnSubmit.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnSubmit.BackColor = Color.MediumSeaGreen;
            this.btnSubmit.ForeColor = Color.White;
            this.btnSubmit.FlatStyle = FlatStyle.Flat;
            this.btnSubmit.Location = new Point(140, 250);
            this.btnSubmit.Size = new Size(250, 35);
            this.btnSubmit.Click += new EventHandler(this.btnSubmit_Click);

            // lblMessage
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblMessage.ForeColor = Color.DarkRed;
            this.lblMessage.Location = new Point(30, 300);
            this.lblMessage.Text = "";
            this.lblMessage.Visible = false;

            // LeaveRequestForm
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(440, 340);
            this.Controls.AddRange(new Control[] {
            lblLeaveType, cmbLeaveTypes,
            lblStartDate, dtpStartDate,
            lblEndDate, dtpEndDate,
            lblReason, txtReason,
            btnSubmit, lblMessage
            });
            this.Font = defaultFont;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.Icon = (Icon)(resources.GetObject("$this.Icon"));
            this.MaximizeBox = false;
            this.Name = "LeaveRequestForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "İzin Talebi";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
