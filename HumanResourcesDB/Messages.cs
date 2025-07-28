using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace HumanResourcesDB
{
    public partial class Mesajlar : Form
    {
        private int currentUserId;
        private string connectionString = ConfigurationManager.ConnectionStrings["HRDbConnection"].ConnectionString;
        public Mesajlar(int userId)
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.Mesajlar_Load);
            currentUserId = userId;
            LoadUsersToComboBox();
            LoadSentMessages();
            lstSentMessages.SelectedIndexChanged += lstSentMessages_SelectedIndexChanged;
            lstSentMessages.DrawMode = DrawMode.OwnerDrawFixed;
            lstSentMessages.DrawItem += LstSentMessages_DrawItem;
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        private void Mesajlar_Load(object sender, EventArgs e)
        {
            LoadUsersToComboBox();
        }

        #region LoadUsersToComboBox İLGİLİ KİŞİLERE GETİRME VE LoadUsersToComboBox A VERİ GİRİŞİ ENGELLEME
        private void LoadUsersToComboBox()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["HRDbConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT UserID, Username FROM Users WHERE IsActive = 1";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dtUsers = new DataTable();

                adapter.Fill(dtUsers);

                cmbReceiver.DisplayMember = "Username";
                cmbReceiver.ValueMember = "UserID";
                cmbReceiver.DataSource = dtUsers;

                // Elle yazmayı engelle
                cmbReceiver.DropDownStyle = ComboBoxStyle.DropDownList;
            }
        }
        #endregion

        #region SEÇİLEN KULLANICI btnSendMessage İLE MESAJ GÖNDEREN BUTON KODU
        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            if (cmbReceiver.SelectedIndex < 0)
            {
                MessageBox.Show("Lütfen alıcı seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtSubject.Text))
            {
                MessageBox.Show("Lütfen mesaj konusu girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtBody.Text))
            {
                MessageBox.Show("Lütfen mesaj içeriği girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO Messages (SenderUserID, ReceiverUserID, Subject, Body)
                         VALUES (@sender, @receiver, @subject, @body)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@sender", currentUserId);
                cmd.Parameters.AddWithValue("@receiver", (int)cmbReceiver.SelectedValue);
                cmd.Parameters.AddWithValue("@subject", txtSubject.Text);
                cmd.Parameters.AddWithValue("@body", txtBody.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Mesaj gönderildi.");
            }

            // Mesaj gönderildikten sonra gönderilen mesajları listele
            LoadSentMessages();

            // Formdaki inputları temizle
            txtSubject.Clear();
            txtBody.Clear();
            cmbReceiver.SelectedIndex = -1;
        }
        #endregion

        #region MESSAGE.CS FORMUNDAKİ lstSentMessages GÖNDERİLEN MESAJLARI GÖSTERME KODU
        private void LoadSentMessages()
        {
            lstSentMessages.Items.Clear();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT M.MessageID, M.Subject, U.Username AS Receiver, M.IsRead
                         FROM Messages M
                         INNER JOIN Users U ON M.ReceiverUserID = U.UserID
                         WHERE M.SenderUserID = @senderId";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@senderId", currentUserId);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int msgId = (int)reader["MessageID"];
                    string subject = reader["Subject"].ToString();
                    string receiver = reader["Receiver"].ToString();
                    bool isRead = (bool)reader["IsRead"];

                    string readStatus = isRead ? " (Okundu)" : " (Bekliyor)";
                    lstSentMessages.Items.Add(new MessageListItem
                    {
                        MessageID = msgId,
                        IsRead = isRead,
                        DisplayText = $"Konu: {subject} - Alıcı: {receiver}{readStatus}"
                    });
                }
            }
        }
        #endregion

        #region MESAJ GÖNDER EKRANI lstSentMessages DE SEÇİLEN MESAJI txtSentBody DE GÖSTEREN KOD
        private void lstSentMessages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstSentMessages.SelectedItem is MessageListItem selectedMessage)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT Subject, Body FROM Messages WHERE MessageID = @msgId";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@msgId", selectedMessage.MessageID);

                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            lblSentSubject.Text = "Konu: " + reader["Subject"].ToString();
                            txtSentBody.Text = reader["Body"].ToString();
                        }
                    }
                }
            }
        }
        #endregion

        #region GÖNDERİLEN MESAJIN OKUNDUKTAN SONRA RENKLENDİRİLMESİ KODU
        private void LstSentMessages_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            var item = (MessageListItem)lstSentMessages.Items[e.Index];
            bool isRead = item.IsRead;

            e.DrawBackground();
            using (Brush textBrush = new SolidBrush(isRead ? Color.Black : Color.Red))
            {
                e.Graphics.DrawString(item.DisplayText, e.Font, textBrush, e.Bounds);
            }

            e.DrawFocusRectangle();
        }
        #endregion
    }
}
