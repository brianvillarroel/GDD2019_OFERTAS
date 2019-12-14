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

namespace OfertasGD2019.ComprarOferta
{
    public partial class ComprarOfertas : Form
    {
        int cliente_ID;
        public User cliente;
        public ComprarOfertas()
        {
            InitializeComponent();
            //Cargar las ofertas disponibles para la fecha del sistema.
            dataGVOfertas.DataSource = BaseDatos.ListarOfertas().Tables [0];
        } 
        
        public ComprarOfertas(int clienteID)
        {
            cliente_ID = clienteID;
            InitializeComponent();
            //Cargar las ofertas disponibles para la fecha del sistema.
            dataGVOfertas.DataSource = BaseDatos.ListarOfertas().Tables [0];
            this.txtUsername.Text = BaseDatos.ObtenerUsernameCliente(cliente_ID.ToString());
            this.txtSaldo.Text = BaseDatos.ObtenerSaldoCliente(cliente_ID.ToString());

           
        }


        //Cuando carga el grid
        private void ComprarOfertas_Load(object sender, EventArgs e)
        {
            //Creo la columna para tener el boton de Compra
            DataGridViewButtonColumn btnComprar = new DataGridViewButtonColumn();
            btnComprar.Name = "Comprar";
            btnComprar.Text = "Comprar";
            btnComprar.UseColumnTextForButtonValue = true;
            dataGVOfertas.Columns.Add(btnComprar);
            btnComprar.Visible = true;

            if (dataGVOfertas.Rows.Count > 0)
            {
                this.dataGVOfertas.Columns ["Comprar"].Visible = true;
                this.txtBusqueda.Visible = false;
            }
            else
            {
                dataGVOfertas.DataSource = null;
                this.dataGVOfertas.Columns ["Comprar"].Visible = false;
                this.txtBusqueda.Visible = true;
            }

        }


        private void dataGVOfertas_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && this.dataGVOfertas.Columns [e.ColumnIndex].Name == "Comprar" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                DataGridViewButtonCell celBoton = this.dataGVOfertas.Rows [e.RowIndex].Cells ["Comprar"] as DataGridViewButtonCell;
                Icon icoAtomico = new Icon(Environment.CurrentDirectory + @"\\pencil.ico");//
                e.Graphics.DrawIcon(icoAtomico, e.CellBounds.Left + 3, e.CellBounds.Top + 3);

                this.dataGVOfertas.Rows [e.RowIndex].Height = icoAtomico.Height + 8;
                this.dataGVOfertas.Columns [e.ColumnIndex].Width = icoAtomico.Width + 8;

                e.Handled = true;
            }
        }


        //Click en "comprar" me lleva a la pantalla de confirmar la compra.

        private void dataGVOfertas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dataGVOfertas.Columns [e.ColumnIndex].Name == "Comprar")
            {
                //obtengo el valor del cliente ID de la fila seleccionada para modificar y abro la ventana de modificar con el valor del id.   
                string descripcion = dataGVOfertas.SelectedRows [0].Cells ["DESCRIPCION"].Value.ToString();
                string precio = dataGVOfertas.SelectedRows [0].Cells ["PRECIO"].Value.ToString();
                string precioLista = dataGVOfertas.SelectedRows [0].Cells ["PRECIO_LISTA"].Value.ToString();
                string stock = dataGVOfertas.SelectedRows [0].Cells ["STOCK"].Value.ToString();
                string limiteCompra = dataGVOfertas.SelectedRows [0].Cells ["LIMITE_COMPRA"].Value.ToString();
                string saldoCliente = this.txtSaldo.Text.ToString();
                string ofertaID = dataGVOfertas.SelectedRows [0].Cells ["ID"].Value.ToString();
               
                //obtengo el valor del cliente ID de la fila seleccionada para modificar y abro la ventana de modificar con el valor del id.    

                ConfirmarCompra confirmarCompra = new ConfirmarCompra(descripcion, precio, stock, limiteCompra, saldoCliente, ofertaID, precioLista, cliente_ID);
                confirmarCompra.ShowDialog();
                this.Close();
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
