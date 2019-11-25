using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiLibreria
{
    public class ABMCliente
    {

        public static Boolean GuardarForm(Control Objeto, ErrorProvider errorProvider)
        {
            //Valida obligatoriedad de los campos
            Boolean camposOblig = Validaciones.ValidarTextBox(Objeto, errorProvider);

            if (camposOblig)
            {
                try
                {
                    errorProvider.Clear();
                    return true;
                }
                catch (Exception error)
                {
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Algunos campos no estan correctos");
                return false;
            }
        }

    }
}
