using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace HumanResourcesDB
{
    public partial class NotificationForm : Form
    {
        public int NotificationID { get; set; }

        public NotificationForm(string title, string content, int notificationId)
        {
            InitializeComponent();
            this.NotificationID = notificationId;
            this.StartPosition = FormStartPosition.CenterScreen;
            lblTitle.Text = title;
            txtContent.Text = content;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            MarkNotificationAsRead(NotificationID);
            this.Close();
        }

        private void MarkNotificationAsRead(int id)
        {
            string connStr = ConfigurationManager.ConnectionStrings["HRDbConnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "UPDATE Notifications SET IsRead = 1 WHERE NotificationID = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        
    }
}
