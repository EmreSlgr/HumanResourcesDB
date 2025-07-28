using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace HumanResourcesDB
{
    public partial class LoadEmployeeStatistics : Form
    {
        private EmployeeDataAccess employeeData = new EmployeeDataAccess();

        public LoadEmployeeStatistics()
        {
            InitializeComponent();
            this.Load += LoadEmployeeStatistics_Load;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void LoadEmployeeStatistics_Load(object sender, EventArgs e)
        {
            LoadStatistics();
        }

        private void LoadStatistics()
        {
            int totalEmployees = employeeData.GetTotalEmployeeCount();
            lblTotalEmployees.Text = $"Toplam Personel: {totalEmployees}";

            var deptCounts = employeeData.GetEmployeeCountByDepartment();

            chartDepartments.Series.Clear();
            chartDepartments.ChartAreas[0].AxisX.Title = "Departmanlar";
            chartDepartments.ChartAreas[0].AxisY.Title = "Çalışan Sayısı";

            var series = new Series
            {
                Name = "Departmanlar",
                ChartType = SeriesChartType.Column
            };

            chartDepartments.Series.Add(series);

            foreach (var kvp in deptCounts)
            {
                series.Points.AddXY(kvp.Key, kvp.Value);
            }
        }
    }

}
