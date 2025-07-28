using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesDB.Models
{
    public class Evaluation
    {
        public int EvaluationID { get; set; }
        public int EmployeeID { get; set; }
        public int EvaluatorID { get; set; }
        public int Score { get; set; }
        public string Comment { get; set; }
        public DateTime EvaluationDate { get; set; }
    }
}
