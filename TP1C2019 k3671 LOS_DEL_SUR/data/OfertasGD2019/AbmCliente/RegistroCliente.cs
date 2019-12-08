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
using System.Data.SqlClient;


namespace OfertasGD2019.AbmCliente
{
    public partial class RegistroCliente : Form
    {
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
            if (Validaciones.ValidarRegistroCliente(this, errorProvider1))
            {
                List<SqlParameter> parametrosDNI = new List<SqlParameter>();
                List<SqlParameter> parametrosUsername = new List<SqlParameter>();
                SqlParameter parametro;

                //Chequeo que el dni no este registrado
                parametro = new SqlParameter("@DNI", SqlDbType.Int);
                parametro.Value = Int32.Parse(this.numDni.Text);
                parametrosDNI.Add(parametro);

                int dniValidado = BaseDatos.ValidarDniDisponible(parametrosDNI);
                
                //chequeo que el username no este registrado
                parametro = new SqlParameter("@USERNAME", SqlDbType.NVarChar, 225);
                parametro.Value = this.txtUser.Text;
                parametrosUsername.Add(parametro);

                int usernameValidado = BaseDatos.ValidarUsernameDisponible(parametrosUsername);

                if (1 == dniValidado && 1 == usernameValidado)
                {
                    List<SqlParameter> parametros = new List<SqlParameter>();

                    BaseDatos.RegistrarCliente(SetearParametros());

                    Inicio inicio = new Inicio();
                    inicio.Show();
                    this.Close();
                }
                else
                {
                    if (0 == dniValidado && 1 == usernameValidado)
                    {
                        errorProvider1.SetError(this.numDni, "El DNI ya está registrado con otro usuario");
                    }

                    if (1 == dniValidado && 0 == usernameValidado)
                    {
                        errorProvider1.SetError(this.txtUser, "El usuario ya está registrado con otro usuario");
                    }

                    if (0 == dniValidado && 0 == usernameValidado)
                    {
                        errorProvider1.SetError(this.numDni, "El DNI ya está registrado con otro usuario");
                        errorProvider1.SetError(this.txtUser, "El usuario ya está registrado con otro usuario");
                    }
                }
            }
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

        public  List<SqlParameter> SetearParametros()
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter parametro;
            //Chequeo que el dni no este registrado
            parametro = new SqlParameter("@username", SqlDbType.NVarChar, 225);
            parametro.Value = this.txtUser.Text;
            parametros.Add(parametro);

            parametro = new SqlParameter("@cliePassword", SqlDbType.NVarChar, 225);
            parametro.Value = this.txtPass.Text;
            parametros.Add(parametro);

            parametro = new SqlParameter("@clieNombre", SqlDbType.NVarChar, 225);
            parametro.Value = this.txtName.Text;
            parametros.Add(parametro);

            parametro = new SqlParameter("@clieApellido", SqlDbType.NVarChar, 225);
            parametro.Value = this.txtApellido.Text;
            parametros.Add(parametro);

            parametro = new SqlParameter("@clieDni", SqlDbType.Int);
            parametro.Value = Int32.Parse(this.numDni.Text);
            parametros.Add(parametro);

            parametro = new SqlParameter("@clieMail", SqlDbType.NVarChar, 225);
            parametro.Value = this.txtMail.Text;
            parametros.Add(parametro);

            parametro = new SqlParameter("@clieTelefono", SqlDbType.Int);
            parametro.Value = Int64.Parse(this.numTel.Text);
            parametros.Add(parametro);

            parametro = new SqlParameter("@clieCiudad", SqlDbType.NVarChar, 225);
            parametro.Value = this.txtCiudad.Text;
            parametros.Add(parametro);

            parametro = new SqlParameter("@clieDireccion", SqlDbType.NVarChar, 225);
            parametro.Value = this.txtDir.Text;
            parametros.Add(parametro);

            parametro = new SqlParameter("@cliePiso", SqlDbType.Int);
            if (this.numPiso.Text == "")
            {
                parametro.Value = DBNull.Value;

            }
            else
            {
                parametro.Value = Int32.Parse(this.numPiso.Text);
            }
            parametros.Add(parametro);

            parametro = new SqlParameter("@clieDepto", SqlDbType.NVarChar, 225);
            if (this.txtDepto.Text == "")
            {
                parametro.Value = DBNull.Value;

            }
            else
            {
                parametro.Value = this.txtDepto.Text;
            }
            parametro.Value = this.txtDepto.Text;
            parametros.Add(parametro);

            parametro = new SqlParameter("@clieCodPostal", SqlDbType.Int);
            if (this.txtCP.Text == "")
            {
                parametro.Value = DBNull.Value;

            }
            else
            {
                parametro.Value = Int32.Parse(this.txtCP.Text);
            }
            parametros.Add(parametro);
    
            parametro = new SqlParameter("@clieFechaNac", SqlDbType.Date);
            parametro.Value = this.dateNac.Text;
            parametros.Add(parametro);

            return parametros;
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

        private void button3_Click(object sender, EventArgs e)
        {
            Inicio inicio = new Inicio();
            inicio.Show();
            this.Close();
        }

        
       
    }
}
