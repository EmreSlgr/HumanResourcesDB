using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesDB
{
    internal class MessageListItem
    {
        public int MessageID { get; set; }
        public bool IsRead { get; set; }
        public string DisplayText { get; set; }


        public override string ToString()
        {
            return DisplayText;
        }
    }
}
