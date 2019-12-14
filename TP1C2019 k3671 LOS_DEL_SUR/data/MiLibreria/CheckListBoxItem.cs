using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiLibreria
{
    public class CheckListBoxItem
    {
        public object Tag;
        public string Text;
        public override string ToString() { return Text; }
    }
}
