using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiLibreria
{
    public partial class DateTxtBox : TextBox
    {
        public DateTxtBox()
        {
            InitializeComponent();
        }

        //Acepta solo numeros
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            // Check if the pressed character was a backspace or numeric.
            if (e.KeyChar != (char)8 && !char.IsNumber(e.KeyChar) && e.KeyChar != '/')
            {
                e.Handled = true;
            }
        }

        public Boolean Validar
        {
            set;
            get;
        }
    }
}
