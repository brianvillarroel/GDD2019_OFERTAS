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
using System.Configuration;
using System.Data.SqlClient;
using OfertasGD2019.CrearOferta;
using OfertasGD2019.Facturacion;
using OfertasGD2019.Abm_Proveedor;

namespace OfertasGD2019.AbmProveedor
{
    public partial class ListadoProveedor : Form
    {
        string menuText;
        int rolUsuario;
        public ListadoProveedor()
        {
            InitializeComponent();
        }

        public ListadoProveedor(string menu, int rolID)
        {
            InitializeComponent();
            rolUsuario = rolID;
            menuText = menu;
           
        }

        //Cuando carga el grid
        private void ListadoProveedor_Load(object sender, EventArgs e)
        {
       
            DataGridViewButtonColumn btnModificar = new DataGridViewButtonColumn();
            btnModificar.Name = "Seleccionar";
            btnModificar.Text = "Seleccionar";
            btnModificar.UseColumnTextForButtonValue = true;
            dataGridViewProv.Columns.Add(btnModificar);

            dataGridViewProv.DataSource = BaseDatos.ListarProveedores(txtRSoc.Text, numCuit.Text, txtMail.Text).Tables [0];
        
            ToolTip TP = new ToolTip();
            TP.ShowAlways = true;
            TP.SetToolTip(this.numCuit, "La busqueda por numero de CUIT es exacta.");

        }

        //Traer PROVEEDORES a la app
        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            //llenar el grid con los datos de los filtros
            dataGridViewProv.DataSource = BaseDatos.ListarProveedores(txtRSoc.Text, numCuit.Text, txtMail.Text).Tables [0];
            if (dataGridViewProv.Rows.Count > 0)
            {
                this.txtBusqueda.Visible = false;
                this.dataGridViewProv.Columns ["Seleccionar"].Visible = true;
            }
            else
            {
                dataGridViewProv.DataSource = null;
                this.txtBusqueda.Visible = true;
                this.dataGridViewProv.Columns ["Seleccionar"].Visible = false;
            }

            
        }

        
        //Colocar boton "Modificar" en la lista 
        private void dataGridViewProv_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && this.dataGridViewProv.Columns [e.ColumnIndex].Name == "Seleccionar" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                DataGridViewButtonCell celBoton = this.dataGridViewProv.Rows [e.RowIndex].Cells ["Seleccionar"] as DataGridViewButtonCell;
                Icon icoAtomico = new Icon(Environment.CurrentDirectory + @"\\pencil.ico");//
                e.Graphics.DrawIcon(icoAtomico, e.CellBounds.Left + 3, e.CellBounds.Top + 3);

                this.dataGridViewProv.Rows [e.RowIndex].Height = icoAtomico.Height + 8;
                this.dataGridViewProv.Columns [e.ColumnIndex].Width = icoAtomico.Width + 8;

                e.Handled = true;
            }
        }
        
        //Limpiar Filtros
        private void btnLimpiar_Click_1(object sender, EventArgs e)
        {
            this.txtRSoc.Text = "";
            this.numCuit.Text = "";
            this.txtMail.Text = "";
            dataGridViewProv.DataSource = null;
            this.txtBusqueda.Visible = true;
        }

        //Click en el boton del grid me lleva a la creacion de oferta o a la modificacion de datos.
        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Click en modificar me lleva a la pantalla de  modificacion del proveedor deseado.
            if (this.dataGridViewProv.Columns [e.ColumnIndex].Name == "Seleccionar")
            {
                //obtengo el valor del Proveedor ID de la fila seleccionada para modificar y abro la ventana de modificar con el valor del id.    
                int proveeID = Convert.ToInt32(dataGridViewProv.SelectedRows [0].Cells ["PROVEE_ID"].Value);

                switch (menuText)
                {
                    case "Crear Oferta":
                        CrearOfertas crearOferta = new CrearOfertas(proveeID);
                        crearOferta.ShowDialog();
                        this.Close();
                        break;

                    case "ABM Proveedor":
                        ModificarProveedor modificarProvee = new ModificarProveedor(proveeID, rolUsuario);
                        modificarProvee.ShowDialog();
                        this.Close();
                        break;

                    case "Entrega/Consumo Oferta":
                        ConsumoCupon consumoCupon = new ConsumoCupon(proveeID);
                        consumoCupon.ShowDialog();
                        this.Close();
                        break;

                    case "Facturar Proveedor":
                        Facturar facturar = new Facturar(proveeID);
                        facturar.ShowDialog();
                        this.Close();
                        break;

                    default:
                        break;
                }
            }
        }

        private void Nombre_Click(object sender, EventArgs e)
        {

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
