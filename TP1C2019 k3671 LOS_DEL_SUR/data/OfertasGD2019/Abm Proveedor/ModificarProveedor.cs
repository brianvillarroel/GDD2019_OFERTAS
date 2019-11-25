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

namespace OfertasGD2019.AbmProveedor
{
    public partial class ModificarProveedor : Form
    {
        public ModificarProveedor()
        {
            InitializeComponent();
        }

        public ModificarProveedor(int proveeID)
        {
            InitializeComponent();
            LlenarCampos(proveeID);
            
        }

        private Object [] LlenarCampos(int proveeID)
        {
            Object [] datosProveedor = BaseDatos.TraerUnProveedor(proveeID);

            if (datosProveedor.Length > 0)
            {
                this.txtRSoc.Text = datosProveedor [0].ToString();
                this.txtCuit.Text = datosProveedor [1].ToString();
                this.txtContacto.Text = datosProveedor [2].ToString();
                this.txtMail.Text = datosProveedor [3].ToString();
                this.numID.Text = proveeID.ToString();
                this.numTelefono.Text = datosProveedor [4].ToString();
                this.txtRubro.Text = (datosProveedor [5].ToString());
                this.txtCiudad.Text = datosProveedor [6].ToString();
                this.txtCalle.Text = datosProveedor [7].ToString();
                this.numPiso.Text = datosProveedor [8].ToString();
                this.txtDepto.Text = datosProveedor [9].ToString();
                this.numCP.Text = datosProveedor [10].ToString();
                this.txtUser.Text = datosProveedor [11].ToString();
                this.txtPass.Text = datosProveedor [12].ToString();
                if (datosProveedor [13].ToString() == "True")
                {
                    this.checkHabil.Checked = true;
                }
                else
                {
                    this.checkHabil.Checked = false;
                }
                
            }

            return datosProveedor;
        }

      
        //Guardar en BD
        private void button2_Click(object sender, EventArgs e)
        {
            
            List<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter parametro;


            parametro = new SqlParameter("@proveeID", SqlDbType.Int);
            parametro.Value =  Int32.Parse(this.numID.Text);
            parametros.Add(parametro);

            parametro = new SqlParameter("@proveeRazSoc", SqlDbType.NVarChar, 50);
            parametro.Value = this.txtRSoc.Text;
            parametros.Add(parametro);

            parametro = new SqlParameter("@proveeCuit", SqlDbType.NVarChar, 50);
            parametro.Value = this.txtCuit.Text;
            parametros.Add(parametro);

            parametro = new SqlParameter("@proveeContacto", SqlDbType.NVarChar, 50);
            parametro.Value = this.txtContacto.Text;
            parametros.Add(parametro);

            parametro = new SqlParameter("@proveeMail", SqlDbType.NVarChar, 50);
            parametro.Value = this.txtMail.Text;
            parametros.Add(parametro);
            
            parametro = new SqlParameter("@proveeTelefono", SqlDbType.Int);
            if (this.numTelefono.Text == "")
            {
                parametro.Value = DBNull.Value;

            }
            else
            {
                parametro.Value = Int32.Parse(this.numTelefono.Text);
            }
            parametros.Add(parametro);

            parametro = new SqlParameter("@proveeRubro", SqlDbType.NVarChar, 50);
            parametro.Value = this.txtRubro.Text;
            parametros.Add(parametro);

            parametro = new SqlParameter("@proveeCiudad", SqlDbType.NVarChar, 225);
            parametro.Value = this.txtCiudad.Text;
            parametros.Add(parametro);
            
            parametro = new SqlParameter("@proveeCalle", SqlDbType.NVarChar, 225);
            parametro.Value = this.txtCalle.Text;
            parametros.Add(parametro);
            
            parametro = new SqlParameter("@proveePiso", SqlDbType.Int);
            if (this.numPiso.Text == "")
            {
                parametro.Value = DBNull.Value;

            }
            else
            {
                parametro.Value = Int32.Parse(this.numPiso.Text);
            }
            
            parametros.Add(parametro);

            parametro = new SqlParameter("@proveeDepto", SqlDbType.NVarChar, 225);
            parametro.Value = this.txtDepto.Text;
            parametros.Add(parametro);
            
            parametro = new SqlParameter("@proveeCP", SqlDbType.Int);
            if (this.numCP.Text == "")
            {
                parametro.Value = DBNull.Value;

            }
            else
            {
                parametro.Value = Int32.Parse(this.numCP.Text);
            }
            parametros.Add(parametro);

            
            parametro = new SqlParameter("@proveePassword", SqlDbType.NVarChar, 225);
            parametro.Value = this.txtPass.Text;
            parametros.Add(parametro);

            parametro = new SqlParameter("@proveeHabilitado", SqlDbType.Bit);
            parametro.Value = this.checkHabil.Checked;
            parametros.Add(parametro);
            
            if (MiLibreria.Validaciones.ValidarTextBox(this, errorProvider2))
           {
              
               BaseDatos.UpdatedatosProveedor(parametros);
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
            this.txtRSoc.Text = "";
            this.txtContacto.Text = "";
            this.txtCuit.Text = "";
            this.numTelefono.Text = "";
            this.txtRubro.Text = "";
            this.txtMail.Text = "";
            this.txtCiudad.Text = "";
            this.txtCalle.Text = "";
            this.numPiso.Text = "";
            this.txtDepto.Text = "";
            this.numCP.Text = "";
            this.txtPass.Text = "";
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
