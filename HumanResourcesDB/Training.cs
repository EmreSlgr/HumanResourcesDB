using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesDB
{
    public class Training
    {
        public int TrainingID { get; set; }
        public int EmployeeID { get; set; }
        public string TrainingName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
        public string Notes { get; set; }
    }
}
