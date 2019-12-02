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

        public ModificarCliente(int clieID, int rolID)
        {
            InitializeComponent();
            LlenarCampos(clieID);
            MostrarCheckBoxHabilitar(rolID);
        }

        private Object [] LlenarCampos(int clieID)
        {
            Object [] datosCliente =  BaseDatos.TraerUnCliente(clieID);

            if (datosCliente.Length > 0)
            {
                this.numID.Text = datosCliente [0].ToString();
                this.txtNombre.Text = datosCliente [1].ToString();
                this.txtApellido.Text = datosCliente [2].ToString();
                this.numDNI.Text = datosCliente [3].ToString();
                this.txtMail.Text = datosCliente [4].ToString();
                this.numTelefono.Text = datosCliente [5].ToString();
                //Seteo bien el formato de lafecha en "dd/mm/yyyy"
                DateTime dateAndTime = Convert.ToDateTime (datosCliente [6]);
                string date = dateAndTime.ToString("dd/MM/yyyy");
                this.txtFechaNac.Text = date;
                this.txtCiudad.Text = datosCliente [7].ToString();
                this.txtCalle.Text = datosCliente [8].ToString();
                this.numPiso.Text = datosCliente [9].ToString();
                this.txtDepto.Text = datosCliente [10].ToString();
                this.txtCP.Text = datosCliente [11].ToString();
                this.txtUser.Text = datosCliente [12].ToString();
                this.txtPass.Text = datosCliente [13].ToString();

                if (datosCliente [14].ToString() == "True")
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

        //Si es admin muestro el chackbox para habilitar/Inhabilitar al proveedor, si no no lo muestro.
        private void MostrarCheckBoxHabilitar(int rolID)
        {
            if (rolID == 2)
            {
                this.checkHabil.Visible = true;
                this.label24.Visible = true;
            }

            else
            {
                this.checkHabil.Visible = false;
                this.label24.Visible = false;
            }
        }

        //Guardar los cambios en la BD
        private void button2_Click(object sender, EventArgs e)
        {

            if (MiLibreria.Validaciones.ValidarTextBox(this, errorProvider2))
           {

               List<SqlParameter> parametrosDNI = new List<SqlParameter>();
               SqlParameter parametro;

               //Seteo parametros para hacer el chequeo del dni y que no haya duplicados 
               parametro = new SqlParameter("@clieID", SqlDbType.Int);
               parametro.Value = Int32.Parse(this.numID.Text);
               parametrosDNI.Add(parametro);

               parametro = new SqlParameter("@clieDni", SqlDbType.Int);
               if (this.numDNI.Text == "")
               {
                   parametro.Value = DBNull.Value;

               }
               else
               {
                   parametro.Value = Int32.Parse(this.numDNI.Text);
               }
               parametrosDNI.Add(parametro);


                //La funcion devuelve 1 si esta ok el dni 0 si ya es de otro usuario
               if (1 == (BaseDatos.ChequearDniClientes(parametrosDNI)))
               {
                   List<SqlParameter> parametros = new List<SqlParameter>();

                   //Seteo parametros para hacer el update 
                   parametro = new SqlParameter("@clieID", SqlDbType.Int);
                   parametro.Value = Int32.Parse(this.numID.Text);
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

                   //LLamo a la funcion par ahacer el update 
                   BaseDatos.UpdateDatosCliente(parametros);

               }
               else
               {
                   errorProvider2.SetError(this.numDNI, "Ya existe otro usuario con este DNI");
               }
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
