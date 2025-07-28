using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesDB
{
    // Bu sınıf ListBox’a hem görüntülenecek metin hem ID taşımak için
    public class ListItemWithId
    {
        public string Text { get; set; }
        public int Id { get; set; }

        public ListItemWithId(string text, int id)
        {
            Text = text;
            Id = id;
        }

        public override string ToString()
        {
            return Text;
        }
    }
}
