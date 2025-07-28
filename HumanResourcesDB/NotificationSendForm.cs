using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HumanResourcesDB
{
    public partial class NotificationSendForm : Form
    {
        public NotificationSendForm()
        {
            InitializeComponent();
            btnSend.Click += BtnSend_Click;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        #region TÜM KULLANICILARA DUYURU GÖNDERMEK İÇİN GEREKLİ KOD
        private void BtnSend_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text.Trim();
            string content = txtContent.Text.Trim();

            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(content))
            {
                MessageBox.Show("Lütfen başlık ve içerik doldurunuz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string connStr = ConfigurationManager.ConnectionStrings["HRDbConnection"].ConnectionString;

            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();

                    // Aktif kullanıcıları çek
                    string getUsersQuery = "SELECT UserID FROM Users WHERE IsActive = 1";
                    List<int> userIds = new List<int>();

                    using (SqlCommand cmdGetUsers = new SqlCommand(getUsersQuery, conn))
                    using (SqlDataReader reader = cmdGetUsers.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            userIds.Add(reader.GetInt32(0));
                        }
                    } // reader kapandı

                    // Her kullanıcıya duyuru ekle
                    foreach (var userId in userIds)
                    {
                        string insertNotifQuery = @"INSERT INTO Notifications (UserID, Title, Content, Date, IsRead)
                                                   VALUES (@userId, @title, @content, @date, 0)";
                        using (SqlCommand cmdInsert = new SqlCommand(insertNotifQuery, conn))
                        {
                            cmdInsert.Parameters.AddWithValue("@userId", userId);
                            cmdInsert.Parameters.AddWithValue("@title", title);
                            cmdInsert.Parameters.AddWithValue("@content", content);
                            cmdInsert.Parameters.AddWithValue("@date", DateTime.Now);
                            cmdInsert.ExecuteNonQuery();
                        }
                    }
                }

                MessageBox.Show("Duyurular kullanıcılarına gönderildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Duyuru gönderilirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
