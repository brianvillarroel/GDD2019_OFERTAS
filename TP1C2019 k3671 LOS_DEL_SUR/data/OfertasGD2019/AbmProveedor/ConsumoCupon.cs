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
using OfertasGD2019.AbmProveedor;

namespace OfertasGD2019.Abm_Proveedor
{
    public partial class ConsumoCupon : Form
    {
        public ConsumoCupon()
        {
            InitializeComponent();
            dataGVCupones.DataSource = BaseDatos.ListarOfertas().Tables [0];
        }

        public ConsumoCupon(int proveedorID)
        {
            
            InitializeComponent();
            //Cargar las ofertas disponibles para la fecha del sistema.
            dataGVCupones.DataSource = BaseDatos.ListarCupones(proveedorID).Tables [0];
            DataGridViewButtonColumn btnEntregar = new DataGridViewButtonColumn();
            btnEntregar.Name = "Entregar";
            btnEntregar.Text = "Entregar";
            btnEntregar.UseColumnTextForButtonValue = true;
            dataGVCupones.Columns.Add(btnEntregar);
            btnEntregar.Visible = true;
        }


        //Cuando carga el grid
        private void ConsumoCupon_Load(object sender, EventArgs e)
        {
            //Creo la columna para tener el boton de Compra
            DataGridViewButtonColumn btnEntregar = new DataGridViewButtonColumn();
            btnEntregar.Name = "Entregar";
            btnEntregar.Text = "Entregar";
            btnEntregar.UseColumnTextForButtonValue = true;
            dataGVCupones.Columns.Add(btnEntregar);
            btnEntregar.Visible = true;

        }

       

        private void dataGVCupones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dataGVCupones.Columns [e.ColumnIndex].Name == "Entregar")
            {
                string cuponID = "";
                int clieID = 0;
                string cuponCodigo = "";
                foreach (DataGridViewRow row in dataGVCupones.SelectedRows)
                {
                    cuponID = row.Cells [1].Value.ToString();
                    cuponCodigo = row.Cells [2].Value.ToString();
                    clieID = Convert.ToInt32( row.Cells [4].Value.ToString());
                }
                EntregaCupon entregaCupon = new EntregaCupon(clieID, cuponID, cuponCodigo);
                this.Close();
                entregaCupon.Show();

            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            ListadoProveedor listado = new ListadoProveedor();
            this.Close();
            listado.Show();
        }
    }
}
