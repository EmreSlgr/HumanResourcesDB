using System;
using System.Drawing;
using System.Windows.Forms;

namespace HumanResourcesDB
{
    partial class LeaveApprovalForm
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dgvPendingRequests;
        private DataGridView dgvPastLeaves;
        private Button btnApprove;
        private Button btnReject;
        private TextBox txtSearch;
        private Label lblSearch;
        private Label lblPastLeaves;
        private Label lblPendingRequests;


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LeaveApprovalForm));
            this.dgvPendingRequests = new System.Windows.Forms.DataGridView();
            this.dgvPastLeaves = new System.Windows.Forms.DataGridView();
            this.btnApprove = new System.Windows.Forms.Button();
            this.btnReject = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.lblPastLeaves = new System.Windows.Forms.Label();
            this.lblPendingRequests = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPendingRequests)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPastLeaves)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPendingRequests
            // 
            this.dgvPendingRequests.AllowUserToAddRows = false;
            this.dgvPendingRequests.AllowUserToDeleteRows = false;
            this.dgvPendingRequests.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPendingRequests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPendingRequests.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvPendingRequests.Location = new System.Drawing.Point(20, 254);
            this.dgvPendingRequests.MultiSelect = false;
            this.dgvPendingRequests.Name = "dgvPendingRequests";
            this.dgvPendingRequests.ReadOnly = true;
            this.dgvPendingRequests.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPendingRequests.Size = new System.Drawing.Size(760, 166);
            this.dgvPendingRequests.TabIndex = 5;
            // 
            // dgvPastLeaves
            // 
            this.dgvPastLeaves.AllowUserToAddRows = false;
            this.dgvPastLeaves.AllowUserToDeleteRows = false;
            this.dgvPastLeaves.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPastLeaves.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPastLeaves.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvPastLeaves.Location = new System.Drawing.Point(20, 51);
            this.dgvPastLeaves.MultiSelect = false;
            this.dgvPastLeaves.Name = "dgvPastLeaves";
            this.dgvPastLeaves.ReadOnly = true;
            this.dgvPastLeaves.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPastLeaves.Size = new System.Drawing.Size(760, 180);
            this.dgvPastLeaves.TabIndex = 4;
            // 
            // btnApprove
            // 
            this.btnApprove.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnApprove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApprove.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnApprove.ForeColor = System.Drawing.Color.White;
            this.btnApprove.Location = new System.Drawing.Point(200, 440);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(160, 40);
            this.btnApprove.TabIndex = 6;
            this.btnApprove.Text = "✔ Onayla";
            this.btnApprove.UseVisualStyleBackColor = false;
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
            // 
            // btnReject
            // 
            this.btnReject.BackColor = System.Drawing.Color.IndianRed;
            this.btnReject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReject.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnReject.ForeColor = System.Drawing.Color.White;
            this.btnReject.Location = new System.Drawing.Point(420, 440);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(160, 40);
            this.btnReject.TabIndex = 7;
            this.btnReject.Text = "✖ Reddet";
            this.btnReject.UseVisualStyleBackColor = false;
            this.btnReject.Click += new System.EventHandler(this.btnReject_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearch.Location = new System.Drawing.Point(650, 18);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(130, 25);
            this.txtSearch.TabIndex = 3;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSearch.Location = new System.Drawing.Point(580, 20);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(63, 19);
            this.lblSearch.TabIndex = 2;
            this.lblSearch.Text = "Ad Filtre:";
            // 
            // lblPastLeaves
            // 
            this.lblPastLeaves.AutoSize = true;
            this.lblPastLeaves.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lblPastLeaves.Location = new System.Drawing.Point(20, 25);
            this.lblPastLeaves.Name = "lblPastLeaves";
            this.lblPastLeaves.Size = new System.Drawing.Size(173, 20);
            this.lblPastLeaves.TabIndex = 8;
            this.lblPastLeaves.Text = "📁 Geçmiş İzin Talepleri";
            // 
            // lblPendingRequests
            // 
            this.lblPendingRequests.AutoSize = true;
            this.lblPendingRequests.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lblPendingRequests.Location = new System.Drawing.Point(20, 231);
            this.lblPendingRequests.Name = "lblPendingRequests";
            this.lblPendingRequests.Size = new System.Drawing.Size(187, 20);
            this.lblPendingRequests.TabIndex = 9;
            this.lblPendingRequests.Text = "📨 Bekleyen İzin Talepleri";
            // 
            // LeaveApprovalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.dgvPastLeaves);
            this.Controls.Add(this.dgvPendingRequests);
            this.Controls.Add(this.btnApprove);
            this.Controls.Add(this.btnReject);
            this.Controls.Add(this.lblPastLeaves);
            this.Controls.Add(this.lblPendingRequests);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "LeaveApprovalForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "İzin Onaylama";
            this.Load += new System.EventHandler(this.LeaveApprovalForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPendingRequests)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPastLeaves)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
