using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace HumanResourcesDB
{
    public partial class EmployeeForm : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["HRDbConnection"].ConnectionString;
        private EmployeeDataAccess employeeData = new EmployeeDataAccess();
        private NotificationForm activeNotificationForm = null;
        private int employeeId;
        private int userId;
        private string username;
        private int currentUserId;
        private Timer notificationTimer;

        public EmployeeForm(int userId, int employeeId, string username)
        {
            InitializeComponent();

            this.userId = userId;
            this.employeeId = employeeId;
            this.username = username;
            currentUserId = userId;
            LoadMessages();

            btnChangePassword.Click += btnChangePassword_Click;
            lstMessages.DrawMode = DrawMode.OwnerDrawFixed;
            lstMessages.DrawItem += LstMessage_DrawItem;
            SetupNotificationTimer();
            LoadEmployeeProfile();
            this.FormClosing += EmployeeForm_FormClosing;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        #region TIMER BAŞLATAN VE 30 SANİYE BİR SORGULAYAN KOD
        private void SetupNotificationTimer()
        {
            notificationTimer = new Timer();
            notificationTimer.Interval = 30000; // 30 saniye
            notificationTimer.Tick += NotificationTimer_Tick;
            notificationTimer.Start();
        }
        #endregion

        #region EMPLOYEEFORM KAPANDIKTAN SONRA TİMER DURDURAN KOD
        private void EmployeeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (notificationTimer != null)
            {
                notificationTimer.Stop();
                notificationTimer.Dispose();
                notificationTimer = null;
            }
        }
        #endregion

        private void NotificationTimer_Tick(object sender, EventArgs e)
        {
            ShowUnreadNotifications();
        }

        #region AKTİF DUYURU EKRANINI SORGULAYAN VARSA EKRANA GETİRMEYEN YOKSA EKRANA GETİREN KOD
        private void ShowUnreadNotifications()
        {
            if (activeNotificationForm != null && !activeNotificationForm.IsDisposed)
            {
                // Zaten bir popup açık, yenisini açma
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT TOP 1 NotificationID, Title, Content FROM Notifications
                         WHERE UserID = @userId AND IsRead = 0
                         ORDER BY Date ASC";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@userId", currentUserId);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int notificationId = reader.GetInt32(0);
                        string title = reader.GetString(1);
                        string content = reader.GetString(2);

                        activeNotificationForm = new NotificationForm(title, content, notificationId);
                        activeNotificationForm.FormClosed += ActiveNotificationForm_FormClosed;
                        activeNotificationForm.Show();
                    }
                }
            }
        }
        #endregion

        #region AKTİF OLAN DUYURU FORMUNU KAPATAN KOD
        private void ActiveNotificationForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (sender is NotificationForm form)
            {
                MarkNotificationAsRead(form.NotificationID);
            }
            activeNotificationForm = null;
        }
        #endregion

        #region İLGİLİ DUYURU POPUNI OKUNDU KAPAT DEDİKTEN SONRA VT DE GÜNCELLEYEN KOD
        private void MarkNotificationAsRead(int notificationId)
        {
            string connStr = ConfigurationManager.ConnectionStrings["HRDbConnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string updateQuery = "UPDATE Notifications SET IsRead = 1 WHERE NotificationID = @id";
                SqlCommand cmd = new SqlCommand(updateQuery, conn);
                cmd.Parameters.AddWithValue("@id", notificationId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        #endregion

        #region PERSONEL BİLGİLERİNİ EKRANA YANSITAN KOD
        private void LoadEmployeeProfile()
        {
            var emp = employeeData.GetEmployeeByUsername(username);

            if (emp != null)
            {
                lblFullName.Text = "Ad Soyad: " + $"{emp.Name} {emp.Surname}";
                lblPosition.Text = "Pozisyon: " + (emp.PositionName ?? "N/A");
                lblDepartment.Text = "Departman: " + (emp.DepartmentName ?? "N/A");
                lblPhone.Text = "Telefon: " + (emp.Phone ?? "N/A");
                lblEmail.Text = "E-posta: " + (emp.Email ?? "N/A");
                lblStartDate.Text = "Başlangıç Tarihi: " + (emp.StartDate?.ToString("dd.MM.yyyy") ?? "N/A");

                if (emp.Photo != null && emp.Photo.Length > 0)
                {
                    using (MemoryStream ms = new MemoryStream(emp.Photo))
                    {
                        pictureBoxProfile.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    pictureBoxProfile.Image = Properties.Resources.default_user;
                }
            }
            else
            {
                MessageBox.Show("Çalışan bilgisi alınamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        private void LstMessage_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            MessageListItem item = (MessageListItem)lstMessages.Items[e.Index];

            e.DrawBackground();

            Font font = item.IsRead ? e.Font : new Font(e.Font, FontStyle.Bold);
            Brush brush = new SolidBrush(e.ForeColor);

            e.Graphics.DrawString(item.DisplayText, font, brush, e.Bounds);

            e.DrawFocusRectangle();
        }

        #region MEVCUT ŞİFRE KONTROL VE ŞİFRE DEĞİŞTİRME BUTONU KODU
        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            string currentPassword = txtOldPassword.Text;
            string newPassword = txtNewPassword.Text;
            string confirmPassword = txtNewPasswordConfirm.Text;

            if (string.IsNullOrWhiteSpace(currentPassword) ||
                string.IsNullOrWhiteSpace(newPassword) ||
                string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("Yeni şifreler eşleşmiyor.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string hashedCurrent = employeeData.ComputePasswordHash(currentPassword);

            // 1. Mevcut şifre doğru mu?
            bool isCurrentPasswordValid = employeeData.ValidateUserPassword(userId, hashedCurrent);
            if (!isCurrentPasswordValid)
            {
                MessageBox.Show("Mevcut şifre hatalı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Yeni şifreyi güncelle
            string hashedNew = employeeData.ComputePasswordHash(newPassword);
            bool updated = employeeData.UpdateUserPassword(userId, hashedNew);

            if (updated)
            {
                MessageBox.Show("Şifreniz başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtOldPassword.Clear();
                txtNewPassword.Clear();
                txtNewPasswordConfirm.Clear();
            }
            else
            {
                MessageBox.Show("Şifre güncellenemedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region İZİN TALEBİ GÖNDERME BUTONU KODU
        private void btnLeaveRequestForm_Click(object sender, EventArgs e)
        {
            this.Hide(); // EmployeeForm geçici gizlenir

            using (LeaveRequestForm leaveForm = new LeaveRequestForm(employeeId, userId, username))
            {
                leaveForm.ShowDialog();
            }

            this.Show(); // LeaveRequestForm kapanınca EmployeeForm yeniden gösterilir
        }
        #endregion

        #region lstMessages ÖĞESİNE MESAJLARI YÜKLEME KODU
        private void LoadMessages()
        {
            lstMessages.Items.Clear();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT M.MessageID, M.Subject, U.Username AS Sender, M.IsRead
            FROM Messages M
            INNER JOIN Users U ON M.SenderUserID = U.UserID
            WHERE M.ReceiverUserID = @receiverId";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@receiverId", currentUserId);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int msgId = (int)reader["MessageID"];
                    string subject = reader["Subject"].ToString();
                    string sender = reader["Sender"].ToString();
                    bool isRead = reader["IsRead"] != DBNull.Value && (bool)reader["IsRead"];

                    lstMessages.Items.Add(new MessageListItem
                    {
                        MessageID = msgId,
                        DisplayText = (isRead ? "" : "* ") + $"Konu: {subject} - Gönderen: {sender}",
                        IsRead = isRead
                    });
                }
            }
        }
        #endregion

        #region MESAJ OKUNDU BUTONU VE OKUNDU İŞARETLE KODU
        private void btnReadMessage_Click(object sender, EventArgs e)
        {
            if (lstMessages.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bir mesaj seçin.");
                return;
            }

            MessageListItem selectedMessage = (MessageListItem)lstMessages.SelectedItem;
            int messageId = selectedMessage.MessageID;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT Subject, Body FROM Messages WHERE MessageID = @msgId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@msgId", messageId);

                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        lblSubject.Text = reader["Subject"].ToString();
                        txtBody.Text = reader["Body"].ToString();
                    }
                }
            }

            // Mesajı okundu olarak işaretle
            MarkMessageAsRead(messageId);

            // Listeyi yenile
            LoadMessages();
        }

        private void MarkMessageAsRead(int messageId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string updateQuery = "UPDATE Messages SET IsRead = 1 WHERE MessageID = @msgId";
                SqlCommand cmd = new SqlCommand(updateQuery, conn);
                cmd.Parameters.AddWithValue("@msgId", messageId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        #endregion


    }
}
