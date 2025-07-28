using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;

namespace HumanResourcesDB
{
    public partial class LeaveApprovalForm : Form
    {
        private EmployeeDataAccess employeeData = new EmployeeDataAccess();
        private int currentUserId;
        private BindingSource pendingRequestsBindingSource = new BindingSource();
        private List<LeaveRequestViewModel> _fullPendingRequests;

        public LeaveApprovalForm(int userId)
        {
            InitializeComponent();
            currentUserId = userId;
            this.Load += LeaveApprovalForm_Load;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string filter = txtSearch.Text.Trim().ToLower();

            if (_fullPendingRequests == null) return;

            var filtered = _fullPendingRequests
                .Where(x => !string.IsNullOrEmpty(x.EmployeeName) && x.EmployeeName.ToLower().Contains(filter))
                .ToList();

            pendingRequestsBindingSource.DataSource = filtered;
            pendingRequestsBindingSource.ResetBindings(false);
        }


        private void LeaveApprovalForm_Load(object sender, EventArgs e)
        {
            dgvPendingRequests.AutoGenerateColumns = true;
            LoadPendingRequests();
            LoadApprovedAndRejectedLeaves();
            dgvPastLeaves.RowPrePaint += dgvPastLeaves_RowPrePaint;
        }

        private void LoadApprovedAndRejectedLeaves()
        {
            string connStr = ConfigurationManager.ConnectionStrings["HRDbConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = @"
            SELECT 
                LR.LeaveRequestID,
                E.Name + ' ' + E.Surname AS FullName,
                LT.LeaveTypeName,
                LR.StartDate,
                LR.EndDate,
                LR.TotalDays,
                LR.Reason,
                LR.Status,
                LR.RequestedDate,
                LR.ApprovalDate
            FROM LeaveRequests LR
            INNER JOIN Employees E ON LR.EmployeeID = E.EmployeeID
            INNER JOIN LeaveTypes LT ON LR.LeaveTypeID = LT.LeaveTypeID
            WHERE LOWER(LR.Status) IN ('approved', 'rejected')
            ORDER BY LR.ApprovalDate DESC";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvPastLeaves.DataSource = dt;

                if (dgvPastLeaves.Columns.Contains("LeaveRequestID"))
                    dgvPastLeaves.Columns["LeaveRequestID"].Visible = false;

                // Başlıkları ayarla
                dgvPastLeaves.Columns["FullName"].HeaderText = "Personel";
                dgvPastLeaves.Columns["LeaveTypeName"].HeaderText = "İzin Türü";
                dgvPastLeaves.Columns["StartDate"].HeaderText = "Başlangıç";
                dgvPastLeaves.Columns["EndDate"].HeaderText = "Bitiş";
                dgvPastLeaves.Columns["TotalDays"].HeaderText = "Gün";
                dgvPastLeaves.Columns["Reason"].HeaderText = "Açıklama";
                dgvPastLeaves.Columns["Status"].HeaderText = "Durum";
                dgvPastLeaves.Columns["RequestedDate"].HeaderText = "Talep Tarihi";
                dgvPastLeaves.Columns["ApprovalDate"].HeaderText = "Onay Tarihi";
            }
        }

        private void dgvPastLeaves_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            var row = dgvPastLeaves.Rows[e.RowIndex];
            var cell = row.Cells["Status"];

            if (cell?.Value == null)
                return;

            string status = cell.Value.ToString().ToLower();

            if (status == "Approved")
                row.DefaultCellStyle.BackColor = Color.LightGreen;
            else if (status == "Rejected")
                row.DefaultCellStyle.BackColor = Color.LightCoral;
        }

        private void LoadPendingRequests()
        {
            _fullPendingRequests = employeeData.GetPendingLeaveRequests();

            if (_fullPendingRequests == null || _fullPendingRequests.Count == 0)
            {
                dgvPendingRequests.DataSource = null;
                return;
            }

            pendingRequestsBindingSource.DataSource = _fullPendingRequests;
            dgvPendingRequests.DataSource = pendingRequestsBindingSource;

            // Sütunları gizleme ve başlıkları ayarlama
            if (dgvPendingRequests.Columns.Contains("LeaveRequestID"))
                dgvPendingRequests.Columns["LeaveRequestID"].Visible = false;

            if (dgvPendingRequests.Columns.Contains("EmployeeID"))
                dgvPendingRequests.Columns["EmployeeID"].Visible = false;

            if (dgvPendingRequests.Columns.Contains("Status"))
                dgvPendingRequests.Columns["Status"].Visible = false;

            if (dgvPendingRequests.Columns.Contains("EmployeeName"))
                dgvPendingRequests.Columns["EmployeeName"].HeaderText = "Çalışan";

            if (dgvPendingRequests.Columns.Contains("LeaveTypeName"))
                dgvPendingRequests.Columns["LeaveTypeName"].HeaderText = "İzin Türü";

            if (dgvPendingRequests.Columns.Contains("StartDate"))
                dgvPendingRequests.Columns["StartDate"].HeaderText = "Başlangıç";

            if (dgvPendingRequests.Columns.Contains("EndDate"))
                dgvPendingRequests.Columns["EndDate"].HeaderText = "Bitiş";

            if (dgvPendingRequests.Columns.Contains("Reason"))
                dgvPendingRequests.Columns["Reason"].HeaderText = "Sebep";

            if (dgvPendingRequests.Columns.Contains("RequestedDate"))
                dgvPendingRequests.Columns["RequestedDate"].HeaderText = "Talep Tarihi";
        }




        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (dgvPendingRequests.CurrentRow == null)
            {
                MessageBox.Show("Lütfen onaylamak için bir izin talebi seçin.");
                return;
            }

            int leaveRequestId = Convert.ToInt32(dgvPendingRequests.CurrentRow.Cells["LeaveRequestID"].Value);

            bool success = employeeData.ApproveLeaveRequest(leaveRequestId, currentUserId);

            if (success)
            {
                MessageBox.Show("İzin talebi onaylandı.");
                LoadPendingRequests();
            }
            else
            {
                MessageBox.Show("Onaylama sırasında hata oluştu.");
            }
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            if (dgvPendingRequests.CurrentRow == null)
            {
                MessageBox.Show("Lütfen reddetmek için bir izin talebi seçin.");
                return;
            }

            int leaveRequestId = Convert.ToInt32(dgvPendingRequests.CurrentRow.Cells["LeaveRequestID"].Value);

            bool success = employeeData.RejectLeaveRequest(leaveRequestId, currentUserId);

            if (success)
            {
                MessageBox.Show("İzin talebi reddedildi.");
                LoadPendingRequests();
            }
            else
            {
                MessageBox.Show("Reddetme sırasında hata oluştu.");
            }
        }
    }
}
