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
    public partial class ModificarCliente : Form
    {
        public ModificarCliente()
        {
            InitializeComponent();
        }

        public ModificarCliente(int clieID)
        {
            InitializeComponent();
            LlenarCampos(clieID);
            
        }

        private Object [] LlenarCampos(int clieID)
        {
            Object [] datosCliente =  BaseDatos.TraerUnCliente(clieID);

            if (datosCliente.Length > 0)
            {
                this.txtNombre.Text = datosCliente [0].ToString();
                this.txtApellido.Text = datosCliente [1].ToString();
                this.numDNI.Text = datosCliente [2].ToString();
                this.txtMail.Text = datosCliente [3].ToString();
                this.numTelefono.Text = datosCliente [4].ToString();
                this.txtFechaNac.Text = (datosCliente [5].ToString()).Remove(10);
                this.txtCiudad.Text = datosCliente [6].ToString();
                this.txtCalle.Text = datosCliente [7].ToString();
                this.numPiso.Text = datosCliente [8].ToString();
                this.txtDepto.Text = datosCliente [9].ToString();
                this.txtCP.Text = datosCliente [10].ToString();
                this.txtUser.Text = datosCliente [11].ToString();
                this.txtPass.Text = datosCliente [12].ToString();
                this.numID.Text = clieID.ToString();

                if (datosCliente [13].ToString() == "True")
                {
                    this.checkHabil.Checked = true;
                }
                else
                {
                    this.checkHabil.Checked = false;
                }
            }

            return datosCliente;
        }

      

        private void button2_Click(object sender, EventArgs e)
        {
            
            List<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter parametro;


            parametro = new SqlParameter("@clieID", SqlDbType.Int);
            parametro.Value =  Int32.Parse(this.numID.Text);
            parametros.Add(parametro);

            parametro = new SqlParameter("@clieNombre", SqlDbType.NVarChar, 50);
            parametro.Value = this.txtNombre.Text;
            parametros.Add(parametro);

            parametro = new SqlParameter("@clieApellido", SqlDbType.NVarChar, 50);
            parametro.Value = this.txtApellido.Text;
            parametros.Add(parametro);

            parametro = new SqlParameter("@clieDni", SqlDbType.Int);
            if (this.numDNI.Text == "")
            {
                parametro.Value = DBNull.Value;

            }
            else
            {
                parametro.Value = Int32.Parse(this.numDNI.Text);
            }
            parametros.Add(parametro);

            parametro = new SqlParameter("@clieMail", SqlDbType.NVarChar, 50);
            parametro.Value = this.txtMail.Text;
            parametros.Add(parametro);

            parametro = new SqlParameter("@clieTelefono", SqlDbType.Int);
            if (this.numTelefono.Text == "")
            {
                parametro.Value = DBNull.Value;

            }
            else
            {
                parametro.Value = Int32.Parse(this.numTelefono.Text);
            }
            parametros.Add(parametro);
        
            parametro = new SqlParameter("@clieFechaNac", SqlDbType.NVarChar, 50);
            parametro.Value = this.txtFechaNac.Text;
            parametros.Add(parametro);
        
            parametro = new SqlParameter("@clieCiudad", SqlDbType.NVarChar, 225);
            parametro.Value = this.txtCiudad.Text;
            parametros.Add(parametro);

            parametro = new SqlParameter("@clieDireccion", SqlDbType.NVarChar, 225);
            parametro.Value = this.txtCalle.Text;
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

            parametro = new SqlParameter("@cliePassword", SqlDbType.NVarChar, 225);
            parametro.Value = this.txtPass.Text;
            parametros.Add(parametro);

            parametro = new SqlParameter("@clieHabilitado", SqlDbType.Bit);
            parametro.Value = this.checkHabil.Checked;
            parametros.Add(parametro);

            if (MiLibreria.Validaciones.ValidarTextBox(this, errorProvider2))
           {
              
               BaseDatos.UpdateDatosCliente(parametros);
           }
           else
           {
               MessageBox.Show("Algunos campos tienen errores. Por favor Verifiquelos"); 
           }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.txtNombre.Text = "";
            this.txtApellido.Text = "";
            this.numDNI.Text = "";
            this.numTelefono.Text = "";
            this.txtFechaNac.Text = "";
            this.txtMail.Text = "";
            this.txtCiudad.Text = "";
            this.txtCalle.Text = "";
            this.numPiso.Text = "";
            this.txtDepto.Text = "";
            this.txtCP.Text = "";
            this.txtPass.Text = "";
        }
    }
}
