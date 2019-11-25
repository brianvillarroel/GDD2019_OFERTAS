using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiLibreria;


namespace OfertasGD2019.AbmCliente
{
    public partial class RegistroCliente : Form
    {
        private ErrorProvider errProvider;
        public RegistroCliente()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        public  void Guardar(object sender, EventArgs e)
        {
            MiLibreria.ABMCliente.GuardarForm(this, errorProvider1);
        }

        private void Limpiar(object sender, EventArgs e)
        {
            this.txtUser.Text = "";
            this.txtPass.Text = "";
            this.txtConfPass.Text = "";
            this.txtName.Text = "";
            this.txtApellido.Text = "";
            this.numDni.Text = "";
            this.txtMail.Text = "";
            this.numTel.Text = "";
            this.txtCiudad.Text = "";
            this.txtDir.Text = "";
            this.numPiso.Text = "";
            this.txtDepto.Text = "";
            this.txtCP.Text = "";
           
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {

        }

        private void errorTxtBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void txtUser_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void txtUser_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void txtMail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUser_TextChanged_2(object sender, EventArgs e)
        {

        }

        private void dateNac_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void numDni_ValueChanged(object sender, EventArgs e)
        {

        }

        
       
    }
}
