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
    public partial class RegistroProveedor : Form
    {
        string menuText;
        public RegistroProveedor()
        {
            InitializeComponent();
        }

        public RegistroProveedor(string menu)
        {
            InitializeComponent();
            menuText = menu;
        }
      
        public  void Guardar(object sender, EventArgs e)
        {
            if (Validaciones.ValidarRegistroProveedor(this, errorProvider1))
            {
                
                
                List<SqlParameter> parametrosCuit = new List<SqlParameter>();
                List<SqlParameter> parametrosRazSoc = new List<SqlParameter>();
                List<SqlParameter> parametrosUsername = new List<SqlParameter>();
                SqlParameter parametro;

                //Chequeo que el CUIT no este registrado
                parametro = new SqlParameter("@cuit", SqlDbType.NVarChar, 255);
                parametro.Value = this.txtContacto.Text;
                parametrosCuit.Add(parametro);

                int cuitValidado = BaseDatos.ValidarCuitDisponible(parametrosCuit);

                //chequeo que la Razon Social no este registrada
                parametro = new SqlParameter("@razonsocial", SqlDbType.NVarChar, 255);
                parametro.Value = this.txtUser.Text;
                parametrosRazSoc.Add(parametro);

                int razSocValidado = BaseDatos.ValidarRazSocDisponible(parametrosRazSoc);

                //chequeo que el username no este registrado
                parametro = new SqlParameter("@USERNAME", SqlDbType.NVarChar, 255);
                parametro.Value = this.txtUser.Text;
                parametrosUsername.Add(parametro);

                int usernameValidado = BaseDatos.ValidarUsernameDisponible(parametrosUsername);

                //Si esta todo ok hago el store procedure para registrar el proveedor
                if (1 == cuitValidado && 1 == razSocValidado && 1 == usernameValidado)
                {
                    List<SqlParameter> parametros = new List<SqlParameter>();

                    BaseDatos.RegistrarProveedor(SetearParametros());

                    if (menuText == "Registrar Proveedor")
                    {
                        Inicio inicio = new Inicio();
                        inicio.Show();
                        this.Close();
                    }
           
                    this.Close();
                }
                else
                {
                    if (0 == razSocValidado)
                    {
                        errorProvider1.SetError(this.txtRazonSoc, "La Razon Social ya está registrada con otro usuario");
                    }

                    if ( 0 == usernameValidado)
                    {
                        errorProvider1.SetError(this.txtUser, "El usuario ya está registrado con otro usuario");
                    }

                    if (0 == cuitValidado)
                    {
                        errorProvider1.SetError(this.txtCuit, "El CUIT ya está registrado con otro usuario");
                    }
                }
            }
        }

        //Click en boton limpiar
        private void Limpiar(object sender, EventArgs e)
        {
            this.txtUser.Text = "";
            this.txtPass.Text = "";
            this.txtConfPass.Text = "";
            this.txtRazonSoc.Text = "";
            this.txtCuit.Text = "";
            this.txtContacto.Text = "";
            this.txtMail.Text = "";
            this.numTel.Text = "";
            this.txtCiudad.Text = "";
            this.txtDir.Text = "";
            this.numPiso.Text = "";
            this.txtDepto.Text = "";
            this.txtCP.Text = "";
            this.txtRubro.Text = "";
        }

        public  List<SqlParameter> SetearParametros()
        {
           
            List<SqlParameter> parametros = new List<SqlParameter>();
            
           SqlParameter parametro;
           //Chequeo que el dni no este registrado
           parametro = new SqlParameter("@username", SqlDbType.NVarChar, 225);
           parametro.Value = this.txtUser.Text;
           parametros.Add(parametro);

           parametro = new SqlParameter("@Password", SqlDbType.NVarChar, 225);
           parametro.Value = this.txtPass.Text;
           parametros.Add(parametro);

           parametro = new SqlParameter("@razonsocial", SqlDbType.NVarChar, 225);
           parametro.Value = this.txtRazonSoc.Text;
           parametros.Add(parametro);

           parametro = new SqlParameter("@cuit", SqlDbType.NVarChar, 225);
           parametro.Value = this.txtCuit.Text;
           parametros.Add(parametro);

           parametro = new SqlParameter("@contacto", SqlDbType.NVarChar, 225);
           parametro.Value = this.txtContacto.Text;
           parametros.Add(parametro);

           parametro = new SqlParameter("@Mail", SqlDbType.NVarChar, 225);
           parametro.Value = this.txtMail.Text;
           parametros.Add(parametro);

           parametro = new SqlParameter("@Telefono", SqlDbType.Int);
           parametro.Value = Int32.Parse(this.numTel.Text);
           parametros.Add(parametro);

           parametro = new SqlParameter("@Ciudad", SqlDbType.NVarChar, 225);
           parametro.Value = this.txtCiudad.Text;
           parametros.Add(parametro);

           parametro = new SqlParameter("@Direccion", SqlDbType.NVarChar, 225);
           parametro.Value = this.txtDir.Text;
           parametros.Add(parametro);

           parametro = new SqlParameter("@Piso", SqlDbType.Int);
           if (this.numPiso.Text == "")
           {
               parametro.Value = DBNull.Value;

           }
           else
           {
               parametro.Value = Int32.Parse(this.numPiso.Text);
           }
           parametros.Add(parametro);

           parametro = new SqlParameter("@Depto", SqlDbType.NVarChar, 225);
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

           parametro = new SqlParameter("@CodPostal", SqlDbType.Int);
           if (this.txtCP.Text == "")
           {
               parametro.Value = DBNull.Value;

           }
           else
           {
               parametro.Value = Int32.Parse(this.txtCP.Text);
           }
           parametros.Add(parametro);

           parametro = new SqlParameter("@rubro", SqlDbType.NVarChar, 225);
           parametro.Value = this.txtRubro.Text;
           parametros.Add(parametro);
            return parametros;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (menuText == "Registrar Proveedor")
            {
                Inicio inicio = new Inicio();
                inicio.Show();
                this.Close();
            }
            this.Close();
        }
    }
}
