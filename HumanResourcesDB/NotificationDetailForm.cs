using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HumanResourcesDB
{
    public partial class NotificationDetailForm : Form
    {
        private string contentToCopy;

        public NotificationDetailForm(string title, string content)
        {
            InitializeComponent();
            lblTitle.Text = title;
            txtContent.Text = content;
            contentToCopy = content;
            this.Text = title;
            this.Opacity = 0; // Başlangıçta görünmez
        }

        private void NotificationDetailForm_Load(object sender, EventArgs e)
        {
            fadeTimer.Start(); // Açılır pencere efekti
        }

        private void fadeTimer_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 1)
            {
                this.Opacity += opacityStep;
            }
            else
            {
                fadeTimer.Stop();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(contentToCopy);
            MessageBox.Show("İçerik panoya kopyalandı.", "Kopyalandı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Geçişli (gradient) arka plan
        private void NotificationDetailForm_Paint(object sender, PaintEventArgs e)
        {
            using (var brush = new System.Drawing.Drawing2D.LinearGradientBrush(this.ClientRectangle,
                System.Drawing.Color.WhiteSmoke,
                System.Drawing.Color.LightSteelBlue,
                90F))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }
    }
}
