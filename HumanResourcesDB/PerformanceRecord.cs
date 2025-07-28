using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesDB
{
    public class PerformanceRecord
    {
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public int Score { get; set; }
    }

}
