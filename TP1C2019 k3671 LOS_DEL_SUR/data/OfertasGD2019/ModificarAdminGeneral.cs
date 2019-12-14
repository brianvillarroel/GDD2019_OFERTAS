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
    public partial class ModificarAdminGeneral : Form
    {
        public ModificarAdminGeneral()
        {
            InitializeComponent();
        }

        public ModificarAdminGeneral(int adminGralID, int rolID)
        {
            InitializeComponent();
            LlenarCampos(adminGralID);
        }

        private Object [] LlenarCampos(int adminGralID)
        {
            Object [] datosAdministrativo = BaseDatos.TraerAdminGeneral(adminGralID);

            if (datosAdministrativo.Length > 0)
            {
                this.numID.Text = adminGralID.ToString();
                this.txtUser.Text = datosAdministrativo [0].ToString();
            }

            return datosAdministrativo;
        }

        //Guardar los cambios en la BD
        private void button2_Click(object sender, EventArgs e)
        {

            if (MiLibreria.Validaciones.ValidarTextBox(this, errorProvider2, this.numID.Text.ToString()))
           {

               if (this.txtNuevaPass.Text.ToString() == this.txtConfPass.Text.ToString() && !string.IsNullOrEmpty(this.txtNuevaPass.Text.Trim()))
               {
                   List<SqlParameter> parametros = new List<SqlParameter>();
                   SqlParameter parametro;

                   parametro = new SqlParameter("@adminGralID", SqlDbType.Int);
                   parametro.Value = Int32.Parse(this.numID.Text);
                   parametros.Add(parametro);

                   parametro = new SqlParameter("@adminGralPassword", SqlDbType.NVarChar, 255);
                   parametro.Value = this.txtNuevaPass.Text.ToString();
                   parametros.Add(parametro);

                   //LLamo a la funcion par ahacer el update 
                   BaseDatos.UpdateDatosAdminGeneral(parametros);
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
