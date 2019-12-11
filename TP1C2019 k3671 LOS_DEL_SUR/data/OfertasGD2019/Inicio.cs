using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using OfertasGD2019.AbmCliente;
using OfertasGD2019.AbmProveedor;

namespace OfertasGD2019
{
    public partial class Inicio : Form
    {
    
        public Inicio()
        {
            InitializeComponent();
        }
        

             private void btnIniciar_Click(object sender, EventArgs e)
             {
                 Login login = new Login();
                 this.Hide();
                 login.Show();
                 
             }

             private void btnRegistro_Click(object sender, EventArgs e)
             {
                 RegistroCliente registro = new RegistroCliente();
                 this.Hide();
                 registro.Show();
             }

             private void button1_Click(object sender, EventArgs e)
             {
                 RegistroProveedor registro = new RegistroProveedor();
                 this.Hide();
                 registro.Show();
             }
    }
}
