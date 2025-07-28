namespace HumanResourcesDB
{
    partial class LoadEmployeeStatistics
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDepartments;
        private System.Windows.Forms.Label lblTotalEmployees;

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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoadEmployeeStatistics));
            this.chartDepartments = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblTotalEmployees = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartDepartments)).BeginInit();
            this.SuspendLayout();
            // 
            // chartDepartments
            // 
            chartArea1.Name = "ChartArea1";
            this.chartDepartments.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartDepartments.Legends.Add(legend1);
            this.chartDepartments.Location = new System.Drawing.Point(20, 140);
            this.chartDepartments.Name = "chartDepartments";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "EmployeesCount";
            this.chartDepartments.Series.Add(series1);
            this.chartDepartments.Size = new System.Drawing.Size(760, 320);
            this.chartDepartments.TabIndex = 0;
            this.chartDepartments.Text = "Personel Departman Dağılımı";
            // 
            // lblTotalEmployees
            // 
            this.lblTotalEmployees.AutoSize = false;
            this.lblTotalEmployees.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTotalEmployees.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTotalEmployees.Location = new System.Drawing.Point(12, 90);
            this.lblTotalEmployees.Name = "lblTotalEmployees";
            this.lblTotalEmployees.Size = new System.Drawing.Size(776, 30);
            this.lblTotalEmployees.TabIndex = 1;
            this.lblTotalEmployees.Text = "Toplam Personel Sayısı: 0";
            // 
            // LoadEmployeeStatistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(800, 480);
            this.Controls.Add(this.lblTotalEmployees);
            this.Controls.Add(this.chartDepartments);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LoadEmployeeStatistics";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Personel Sayısı ve Departman Bazlı Dağılım";
            ((System.ComponentModel.ISupportInitialize)(this.chartDepartments)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
    }
}