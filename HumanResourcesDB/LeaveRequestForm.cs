using System;
using System.Windows.Forms;

namespace HumanResourcesDB
{
    public partial class LeaveRequestForm : Form
    {
        private EmployeeDataAccess employeeData = new EmployeeDataAccess();
        private int userId;
        private string username;
        private int currentEmployeeId;
        public LeaveRequestForm(int employeeId, int userId, string username)
        {
            InitializeComponent();
            this.userId = userId;
            this.username = username;
            currentEmployeeId = employeeId;
            LoadLeaveTypes();
        }

        private void LoadLeaveTypes()
        {
            var types = employeeData.GetLeaveTypes();
            cmbLeaveTypes.DataSource = types;
            cmbLeaveTypes.DisplayMember = "LeaveTypeName";
            cmbLeaveTypes.ValueMember = "LeaveTypeID";
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";  // Önceki mesajı temizle

            if (cmbLeaveTypes.SelectedIndex < 0)
            {
                lblMessage.Text = "Lütfen bir izin türü seçin.";
                return;
            }
            if (dtpEndDate.Value.Date < dtpStartDate.Value.Date)
            {
                lblMessage.Text = "Bitiş tarihi başlangıç tarihinden küçük olamaz.";
                return;
            }
            if (string.IsNullOrWhiteSpace(txtReason.Text))
            {
                lblMessage.Text = "Lütfen izin sebebini girin.";
                return;
            }

            int totalDays = (dtpEndDate.Value.Date - dtpStartDate.Value.Date).Days + 1;

            var leaveRequest = new LeaveRequest
            {
                EmployeeID = currentEmployeeId, // burası çok önemli
                LeaveTypeID = (int)cmbLeaveTypes.SelectedValue,
                StartDate = dtpStartDate.Value.Date,
                EndDate = dtpEndDate.Value.Date,
                TotalDays = totalDays,
                Reason = txtReason.Text.Trim(),
                Status = "Pending",
                RequestedDate = DateTime.Now
            };

            bool success = employeeData.SubmitLeaveRequest(leaveRequest);

            if (success)
            {
                MessageBox.Show("İzin talebiniz başarıyla gönderildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                lblMessage.Text = "İzin talebi gönderilirken hata oluştu.";
            }
        }
    }
}
