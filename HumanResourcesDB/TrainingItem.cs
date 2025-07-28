using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesDB
{
    public class TrainingItem
    {
        public int TrainingID { get; set; }
        public string DisplayText { get; set; }

        public override string ToString() => DisplayText;
    }

}
