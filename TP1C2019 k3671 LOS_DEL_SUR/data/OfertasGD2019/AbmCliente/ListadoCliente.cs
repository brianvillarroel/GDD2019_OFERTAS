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
using OfertasGD2019.CargarCredito;
using OfertasGD2019.ComprarOferta;

namespace OfertasGD2019.AbmCliente
{
    public partial class ListadoCliente : Form
    {
        string menuText;
        int rolUsuario;
        public ListadoCliente()
        {
            InitializeComponent();
        }

        public ListadoCliente(int rolID, string menu)
        {
            InitializeComponent();
            rolUsuario = rolID;
            menuText = menu;
           
        }

        //Cuando carga el grid
        private void ListadoCliente_Load(object sender, EventArgs e)
        {
            //Creo la columna para tener el boton de modificar
            DataGridViewButtonColumn btnModificar = new DataGridViewButtonColumn();
            btnModificar.Name = "Seleccionar";
            btnModificar.Text = "Seleccionar";
            btnModificar.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(btnModificar);
            dataGridView1.DataSource = BaseDatos.ListarClientes(txtNombre.Text, txtApellido.Text, numDni.Text, txtMail.Text).Tables [0];
         
            ToolTip TP = new ToolTip();
            TP.ShowAlways = true;
            TP.SetToolTip(this.numDni, "La busqueda por numero de DNI es exacta.");

        }

        //Traer clientes a la app cuando se hace click en "Buscar"
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //BaseDatos bd = new BaseDatos();
            //string tabla = "CLIENTE";

            //llenar el grid con los datos de los filtros
            dataGridView1.DataSource = BaseDatos.ListarClientes(txtNombre.Text, txtApellido.Text, numDni.Text, txtMail.Text).Tables [0];
            if ( dataGridView1.Rows.Count > 0)
            {
                this.dataGridView1.Columns ["Seleccionar"].Visible = true;
                 this.txtBusqueda.Visible = false;
            }
            else
            {
                 dataGridView1.DataSource = null;
                 this.dataGridView1.Columns ["Seleccionar"].Visible = false;
                this.txtBusqueda.Visible = true;
            }
           
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && this.dataGridView1.Columns [e.ColumnIndex].Name == "Seleccionar" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                DataGridViewButtonCell celBoton = this.dataGridView1.Rows [e.RowIndex].Cells ["Seleccionar"] as DataGridViewButtonCell;
                Icon icoAtomico = new Icon(Environment.CurrentDirectory + @"\\pencil.ico");//
                e.Graphics.DrawIcon(icoAtomico, e.CellBounds.Left + 3, e.CellBounds.Top + 3);

                this.dataGridView1.Rows [e.RowIndex].Height = icoAtomico.Height + 8;
                this.dataGridView1.Columns [e.ColumnIndex].Width = icoAtomico.Width + 8;

                e.Handled = true;
            }
        }

        //Limpiar Filtros
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.txtNombre.Text = "";
            this.txtApellido.Text = "";
            this.numDni.Text = "";
            this.txtMail.Text = "";
            dataGridView1.DataSource = null;
            this.txtBusqueda.Visible = true;
        }

        //Click en seleccionar me lleva a la pantalla de  modificacion del cliente deseado.
        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
             //obtengo el valor del cliente ID de la fila seleccionada para modificar y abro la ventana de modificar con el valor del id.    
            int clieID = Convert.ToInt32(dataGridView1.SelectedRows [0].Cells ["CLIE_ID"].Value);

            if (this.dataGridView1.Columns [e.ColumnIndex].Name == "Seleccionar")
            {

                switch (menuText)
                {
                    case "Comprar Oferta":
                        ComprarOfertas comprarOferta = new ComprarOfertas(clieID);
                        this.Close();
                        comprarOferta.Show();
                        break;

                    case "ABM Cliente":
                        ModificarCliente modificar = new ModificarCliente(clieID, rolUsuario);
                        this.Close();
                        modificar.Show();
                        break;

                    case "Cargar Crédito":
                        CargaCredito cargarCredito = new CargaCredito(clieID);
                        this.Close();
                        cargarCredito.Show();
                        break;
                }
                
            }


        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
