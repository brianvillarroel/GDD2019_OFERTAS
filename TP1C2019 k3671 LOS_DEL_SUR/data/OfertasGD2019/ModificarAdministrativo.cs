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

namespace OfertasGD2019
{
    public partial class ModificarAdministrativo : Form
    {
        public ModificarAdministrativo()
        {
            InitializeComponent();
        }

        public ModificarAdministrativo(int adminID, int rolID)
        {
            InitializeComponent();
            LlenarCampos(adminID);
        }

        private Object [] LlenarCampos(int adminID)
        {
            Object [] datosAdministrativo = BaseDatos.TraerUnAdministrativo(adminID);

            if (datosAdministrativo.Length > 0)
            {
                this.numID.Text = adminID.ToString();
                this.txtNombre.Text = datosAdministrativo [0].ToString();
                this.txtApellido.Text = datosAdministrativo [1].ToString();
                this.txtUser.Text = datosAdministrativo [2].ToString();
            }

            return datosAdministrativo;
        }

        //Guardar los cambios en la BD
        private void button2_Click(object sender, EventArgs e)
        {

            if (MiLibreria.Validaciones.ValidarTextBox(this, errorProvider2, this.numID.Text.ToString()))
           {

               List<SqlParameter> parametros = new List<SqlParameter>();
               SqlParameter parametro;

               //Seteo parametros 
               parametro = new SqlParameter("@adminID", SqlDbType.Int);
               parametro.Value = Int32.Parse(this.numID.Text);
               parametros.Add(parametro);

               parametro = new SqlParameter("@adminNombre", SqlDbType.NVarChar, 255);
               parametro.Value = this.txtNombre.Text.ToString();
               parametros.Add(parametro);

               parametro = new SqlParameter("@adminApellido", SqlDbType.NVarChar, 255);
               parametro.Value = this.txtApellido.Text.ToString();
               parametros.Add(parametro);

               if (this.txtNuevaPass.Text.ToString() == this.txtConfPass.Text.ToString() && !string.IsNullOrEmpty(this.txtNuevaPass.Text.Trim()))
               {
                   parametro = new SqlParameter("@adminPassword", SqlDbType.NVarChar, 255);
                   parametro.Value = this.txtNuevaPass.Text.ToString();
                   parametros.Add(parametro);
               }

               //LLamo a la funcion par ahacer el update 
               BaseDatos.UpdateDatosAdministrativo(parametros);

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
            this.txtPass.Text = "";
            this.txtConfPass.Text = "";
            this.txtNuevaPass.Text = "";
            this.txtConfPass.Enabled = false;
            this.txtNuevaPass.Enabled = false;
            this.txtConfPass.Validar = false;
            this.txtNuevaPass.Validar = false;
        }

        //Al escribir la contraseña actual habilito los otros campos
        private void txtPass_TextChanged(object sender, EventArgs e)
        {
            this.txtConfPass.Enabled = true;
            this.txtNuevaPass.Enabled = true;
            this.txtConfPass.Validar = true;
            this.txtNuevaPass.Validar = true;
        }
    }
}
