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

        public ModificarProveedor(int proveeID, int userRolID)
        {
            InitializeComponent();
            LlenarCampos(proveeID);
            MostrarCheckBoxHabilitar(userRolID);
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

        //Si es admin muestro el chackbox para habilitar/Inhabilitar al proveedor, si no no lo muestro.
        private void MostrarCheckBoxHabilitar(int rolID)
        {
            if (rolID == 2 || rolID == 4)
            {
                this.checkHabil.Visible = true;
                this.label24.Visible = true;
            }

            else {
                this.checkHabil.Visible = false;
                this.label24.Visible  = false;
            }
        }

        //CLick en boton "VOLVER"
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
            this.txtConfPass.Text = "";
            this.txtNuevaPass.Text = "";
            this.txtConfPass.Enabled = false;
            this.txtNuevaPass.Enabled = false;
            this.txtConfPass.Validar = false;
            this.txtNuevaPass.Validar = false;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }


        //Guardar en BD
        private void button2_Click(object sender, EventArgs e)
        {

            if (MiLibreria.Validaciones.ValidarTextBox(this, errorProvider2, this.numID.Text.ToString()))
           {
               List<SqlParameter> parametrosCuit = new List<SqlParameter>();

               List<SqlParameter> parametrosRazSoc = new List<SqlParameter>();
               SqlParameter parametro;

               parametro = new SqlParameter("@proveeID", SqlDbType.Int);
               parametro.Value = Int32.Parse(this.numID.Text);
               parametrosCuit.Add(parametro);
               parametrosRazSoc.Add(parametro);


               parametro = new SqlParameter("@RSProvee", SqlDbType.NVarChar, 50);
               parametro.Value = this.txtRSoc.Text;
               parametrosRazSoc.Add(parametro);

               parametro = new SqlParameter("@cuitProvee", SqlDbType.NVarChar, 50);
               parametro.Value = this.txtCuit.Text;
               parametrosCuit.Add(parametro);

                int cuitValidado = BaseDatos.ChequearCuitProveedor(parametrosCuit);
                int RazSocValidado = BaseDatos.ChequearRazSocProveedor(parametrosRazSoc);
                                
                //Devuelven 1 si esta ok
                 if (1 == cuitValidado && 1 == RazSocValidado)
               {
                     //Seteo los parametros para hcer el update de los datos 
                     List<SqlParameter> parametros = new List<SqlParameter>();

                     parametro = new SqlParameter("@proveeID", SqlDbType.Int);
                     parametro.Value = Int32.Parse(this.numID.Text);
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


                    if (this.txtNuevaPass.Text.ToString() == this.txtConfPass.Text.ToString() && !string.IsNullOrEmpty(this.txtNuevaPass.Text.Trim()))
                    {
                        parametro = new SqlParameter("@proveePassword", SqlDbType.NVarChar, 225);
                        parametro.Value = this.txtNuevaPass.Text;
                        parametros.Add(parametro);
                    }
                   

                    parametro = new SqlParameter("@proveeHabilitado", SqlDbType.Bit);
                    parametro.Value = this.checkHabil.Checked;
                    parametros.Add(parametro);

                       BaseDatos.UpdatedatosProveedor(parametros);
                   }
                     else 
                   {
                     
                       if (0 == cuitValidado && 1 == RazSocValidado)
                       {
                           MessageBox.Show("El cuit ya está registrado con otro usuario");
                           errorProvider2.SetError(this.txtCuit, "El cuit ya está registrado con otro usuario");  
                       }

                       if (1 == cuitValidado && 0 == RazSocValidado)
                       {
                           MessageBox.Show("La Razon Social ya está registrada con otro usuario");
                           errorProvider2.SetError(this.txtRSoc, "La Razon Social ya está registrada con otro usuario");  
                       }

                       if (0 == cuitValidado && 0 == RazSocValidado)
                       {
                           MessageBox.Show("El cuit y la Razon Social ya están registrados con otro usuario");
                           errorProvider2.SetError(this.txtCuit, "El cuit ya está registrado con otro usuario");  
                           errorProvider2.SetError(this.txtRSoc, "La Razon Social ya está registrada con otro usuario");  
                       }
               }
           }
           else
           {
               MessageBox.Show("Algunos campos tienen errores. Por favor Verifiquelos"); 
           }
        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        //Al escribir sobre la contraseña actual habilito los campos parala nueva contraseña

        private void txtPass_TextChanged(object sender, EventArgs e)
        {
            this.txtConfPass.Enabled = true;
            this.txtNuevaPass.Enabled = true;
            this.txtConfPass.Validar = true;
            this.txtNuevaPass.Validar = true;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

      
    }
}
