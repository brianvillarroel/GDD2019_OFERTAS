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
using MiLibreria;

namespace OfertasGD2019
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent(); 
        }

        public void RestaurarCampos()
        {
            this.txtUsuario.Text = "";
            this.txtPass.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
                

                string user = txtUsuario.Text.Trim();
                string pass = txtPass.Text.Trim();

                int resultado = User.Autenticar(user, pass);

                switch (resultado)
                {

                    case 0: MessageBox.Show("Usuario Inexistente");
                        RestaurarCampos();
                        txtUsuario.Focus();
                        break;

                    case 1: MessageBox.Show("Usuario Bloqueado. Por favor contáctese con el Administrador");
                        this.Close();
                        break;

                    case 2: MessageBox.Show("Login Incorrecto");
                        
                        RestaurarCampos();
                        txtUsuario.Focus();
                        break;

                    case 3: ; 
                        User usuarioActivo = new User();
                        User.SetearAtributosUsuario(user, usuarioActivo);
                        if (usuarioActivo.Id == 1)
                        {
                            MenuCliente menu = new MenuCliente(usuarioActivo);
                            this.Hide();
                            menu.Show();
                            break;
                        }
                        if (usuarioActivo.Rol == 2)
                        {
                            MenuAdmin menu = new MenuAdmin();
                            this.Hide();
                            menu.Show();
                            break;
                        }
                        if (usuarioActivo.Rol == 3)
                        {
                            MenuProveedor menu = new MenuProveedor();
                            this.Hide();
                            menu.Show();
                            break;
                        }
                        break;

                    default: break;
                }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RestaurarCampos();
        }
    }
}
