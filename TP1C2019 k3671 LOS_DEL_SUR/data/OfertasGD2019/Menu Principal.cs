using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using MiLibreria;
using OfertasGD2019.AbmCliente;
using OfertasGD2019.AbmProveedor;
using OfertasGD2019.CargarCredito;
using OfertasGD2019.ComprarOferta;
using OfertasGD2019.CrearOferta;
using OfertasGD2019.Facturacion;
using OfertasGD2019.AbmRol;
using OfertasGD2019.Abm_Proveedor;
using OfertasGD2019.Listado_Estadistico;

namespace OfertasGD2019
{
    public partial class Menu_Principal : Form
    {
        User usuario = new User();
        public Menu_Principal()
        {
            InitializeComponent();
        }

        public Menu_Principal(User usuarioActivo)
        {
            usuario = usuarioActivo;
            InitializeComponent();
        }

       
        //Cargar solo los menu
        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            setearMenu();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        //////////////Registro ////////////////////
        //Registro clientes

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistroCliente registroCliente = new RegistroCliente();
            registroCliente.ShowDialog();
        }

        //Registro proveedores
        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistroProveedor registroProveedor = new RegistroProveedor();
            registroProveedor.ShowDialog();
        }

        ////////// ABMs /////////////////
        //ABM Rol
        private void aBMRolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SeleccionarRol abmRol = new SeleccionarRol();
            abmRol.ShowDialog();
        }

        //ABM Cliente
        private void aBMClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string menuText = this.aBMClienteToolStripMenuItem.Text.ToString();
            ListadoCliente listadoCliente = new ListadoCliente(usuario.Rol, menuText);
            listadoCliente.ShowDialog();
        }

        //ABM Proveedor
        private void aBMProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string menuText =  this.aBMProveedorToolStripMenuItem.Text.ToString();
            ListadoProveedor listadoProveedor = new ListadoProveedor(menuText, usuario.Rol);
            listadoProveedor.ShowDialog();
        }

        ///////// ACCIONES //////////////

        //Crear Oferta
        private void crearOfertaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //si son administrativo o administrador general muestro la lsita para elegir
            if (usuario.Rol == 2 || usuario.Rol == 4)
            {
                string menuText = this.crearOfertaToolStripMenuItem.Text.ToString();
                ListadoProveedor listadoProveedor = new ListadoProveedor(menuText, usuario.Rol);
                listadoProveedor.ShowDialog();
            }
            
            //si es un proveedor lo envio directamente a la creacion de oferta
            if (usuario.Rol == 3)
            {
                CrearOfertas crearOferta = new CrearOfertas(usuario.ProveeId);
                crearOferta.Show();
            }
                
        }


        //Comprar  Oferta
        private void comprarOfertaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //si son administrativo o administrador general muestro la lsita para elegir
            if (usuario.Rol == 2 || usuario.Rol == 4)
            {
                string menuText = this.comprarOfertaToolStripMenuItem.Text.ToString();
                ListadoCliente listadoCliente = new ListadoCliente(usuario.Rol, menuText);
                listadoCliente.ShowDialog();
            }

            //si es un cliente lo envio directamente a la carga de credito
            if (usuario.Rol == 1)
            {
                ComprarOfertas comprarOferta = new ComprarOfertas(usuario.ClienteId);
                comprarOferta.Show();
            }
        }

        //Entrega/Consumo cupon
        private void entregaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //si son administrativo o administrador general muestro la lsita para elegir
            if (usuario.Rol == 2 || usuario.Rol == 4)
            {
                string menuText = this.entregaToolStripMenuItem.Text.ToString();
                ListadoProveedor listadoProveedor = new ListadoProveedor(menuText, usuario.Rol);
                listadoProveedor.ShowDialog();
            }

             //si es un proveedor lo envio directamente a la pantalla de consumo de cupon
            if (usuario.Rol == 3)
            {
                ConsumoCupon consumoCupon = new ConsumoCupon(usuario.ProveeId);
                consumoCupon.ShowDialog();
            }
        }

        //Facturar proveedor
        private void facturarProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string menuText = this.facturarProveedorToolStripMenuItem.Text.ToString();
            ListadoProveedor listadoProveedor = new ListadoProveedor(menuText, usuario.Rol);
            listadoProveedor.ShowDialog();
        }


        //Cargar Credito
        private void cargarCreditoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //si son administrativo o administrador general muestro la lsita para elegir
            if (usuario.Rol == 2 || usuario.Rol == 4)
            {
                 string menuText = this.cargarCreditoToolStripMenuItem.Text.ToString();
            ListadoCliente listadoCliente = new ListadoCliente(usuario.Rol, menuText);
            listadoCliente.ShowDialog();
            }
           
            //si es un cliente lo envio directamente a la carga de credito
            if (usuario.Rol == 1)
            {
             CargaCredito cargaCredito = new CargaCredito(usuario.ClienteId);
             cargaCredito.ShowDialog();
            }
           
        }

        private void MenuItemListado_Click(object sender, EventArgs e)
        {
            ListadoEstadistico listado = new ListadoEstadistico();
            listado.ShowDialog();
        }



        private void setearMenu()
        {
            //ABM ROL
            if (!usuario.Funcionalidades.Contains(1))
            {
                this.aBMRolToolStripMenuItem.Visible = false;
            }

            //ABM CLIENTE
            if (!usuario.Funcionalidades.Contains(2))
            {
                this.aBMClienteToolStripMenuItem.Visible = false;
                this.clientesToolStripMenuItem.Visible = false;
            }

            //ABM PROVEEDOR
            if (!usuario.Funcionalidades.Contains(3))
            {
                this.aBMProveedorToolStripMenuItem.Visible = false;
                this.proveedoresToolStripMenuItem.Visible = false;
            }

            //CARGAR CREDITO
            if (!usuario.Funcionalidades.Contains(4))
            {
                this.cargarCreditoToolStripMenuItem.Visible = false;
            }

            //CREAR OFERTA
            if (!usuario.Funcionalidades.Contains(5))
            {
                this.crearOfertaToolStripMenuItem.Visible = false;
            }

            //COMPRAR OFERTA
            if (!usuario.Funcionalidades.Contains(6))
            {
                this.comprarOfertaToolStripMenuItem.Visible = false;
            }

            //ENTRAGA/CONSUMO OFERTA      
            if (!usuario.Funcionalidades.Contains(7))
            {
                this.entregaToolStripMenuItem.Visible = false;
            }

            //FACTURAR PROVEEDOR
            if (!usuario.Funcionalidades.Contains(8))
            {
                this.facturarProveedorToolStripMenuItem.Visible = false;
            }

            //LISTADO ESTADISTICO
            if (!usuario.Funcionalidades.Contains(9))
            {
                this.MenuItemListado.Visible = false;
            }
        }

        private void modificarDatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (usuario.Rol == 1)
            {
                ModificarCliente modificarCliente = new ModificarCliente(usuario.ClienteId, usuario.Rol);
                modificarCliente.Show();
            }

            if (usuario.Rol == 2)
            {
                ModificarAdministrativo modificarAdminsitrativo = new ModificarAdministrativo(usuario.AdminId, usuario.Rol);
                modificarAdminsitrativo.Show();
            }

            if (usuario.Rol == 3)
            {
                ModificarProveedor modificarProveedor = new ModificarProveedor(usuario.ProveeId , usuario.Rol);
                modificarProveedor.Show();
            }

            if (usuario.Rol == 4)
            {
                ModificarAdminGeneral modificaAdminGeneral = new ModificarAdminGeneral(usuario.Id, usuario.Rol);
                modificaAdminGeneral.Show();
            }
        }

        
        
    }
}
