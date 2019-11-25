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

namespace OfertasGD2019.AbmProveedor
{
    public partial class ListadoProveedor : Form
    {
        public ListadoProveedor()
        {
            InitializeComponent();
        }

        //Cuando carga el grid
        private void ListadoProveedor_Load(object sender, EventArgs e)
        {
            //Creo la columna para tener el boton de modificar
            DataGridViewButtonColumn btnModificar = new DataGridViewButtonColumn();
            btnModificar.Name = "Modificar";
            btnModificar.Text = "Modificar";
            btnModificar.UseColumnTextForButtonValue = true;
            dataGridViewProv.Columns.Add(btnModificar);
            //btnModificar.Visible = false;
         
            ToolTip TP = new ToolTip();
            TP.ShowAlways = true;
            TP.SetToolTip(this.numCuit, "La busqueda por numero de CUIT es exacta.");

        }

        //Traer PROVEEDORES a la app
        private void btnBuscar_Click_1(object sender, EventArgs e)
        {

            //llenar el grid con los datos de los filtros
            dataGridViewProv.DataSource = BaseDatos.ListarProveedores(txtRSoc.Text, numCuit.Text, txtMail.Text).Tables [0];

            this.dataGridViewProv.Columns ["Modificar"].Visible = true;
        }


        //Colocar boton "Modificar" en la lista 
        private void dataGridViewProv_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && this.dataGridViewProv.Columns [e.ColumnIndex].Name == "Modificar" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                DataGridViewButtonCell celBoton = this.dataGridViewProv.Rows [e.RowIndex].Cells ["Modificar"] as DataGridViewButtonCell;
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
        }

        //Click en modificar me lleva a la pantalla de  modificacion del proveedor deseado.
        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dataGridViewProv.Columns [e.ColumnIndex].Name == "Modificar")
            {
                //obtengo el valor del Proveedor ID de la fila seleccionada para modificar y abro la ventana de modificar con el valor del id.    
                int proveeID = Convert.ToInt32(dataGridViewProv.SelectedRows [0].Cells ["PROVEE_ID"].Value);
                ModificarProveedor modificar = new ModificarProveedor(proveeID);
                //this.Hide();
                modificar.Show();

            }
        }
        
        
        private void Nombre_Click(object sender, EventArgs e)
        {

        }
    }
}
