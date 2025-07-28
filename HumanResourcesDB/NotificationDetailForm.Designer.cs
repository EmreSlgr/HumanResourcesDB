namespace HumanResourcesDB
{
    partial class NotificationDetailForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Timer fadeTimer;
        private float opacityStep = 0.05f;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NotificationDetailForm));
            this.headerPanel = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.fadeTimer = new System.Windows.Forms.Timer();
            this.SuspendLayout();

            // headerPanel
            this.headerPanel.BackColor = System.Drawing.Color.SteelBlue;
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Height = 50;
            this.headerPanel.Controls.Add(this.lblTitle);

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 13);
            this.lblTitle.Text = "Duyuru Başlığı";

            // txtContent
            this.txtContent.Multiline = true;
            this.txtContent.ReadOnly = true;
            this.txtContent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtContent.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtContent.Location = new System.Drawing.Point(20, 70);
            this.txtContent.Size = new System.Drawing.Size(740, 300);
            this.txtContent.BackColor = System.Drawing.Color.WhiteSmoke;

            // btnCopy
            this.btnCopy.Text = "İçeriği Kopyala";
            this.btnCopy.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCopy.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnCopy.ForeColor = System.Drawing.Color.White;
            this.btnCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopy.Location = new System.Drawing.Point(480, 390);
            this.btnCopy.Size = new System.Drawing.Size(140, 35);
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);

            // btnClose
            this.btnClose.Text = "Kapat";
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnClose.BackColor = System.Drawing.Color.IndianRed;
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(640, 390);
            this.btnClose.Size = new System.Drawing.Size(120, 35);
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            // fadeTimer
            this.fadeTimer.Interval = 30;
            this.fadeTimer.Tick += new System.EventHandler(this.fadeTimer_Tick);

            // NotificationDetailForm
            this.ClientSize = new System.Drawing.Size(780, 460);
            this.Controls.Add(this.headerPanel);
            this.Controls.Add(this.txtContent);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnCopy);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Text = "Duyuru Detayı";
            this.Load += new System.EventHandler(this.NotificationDetailForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.NotificationDetailForm_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}