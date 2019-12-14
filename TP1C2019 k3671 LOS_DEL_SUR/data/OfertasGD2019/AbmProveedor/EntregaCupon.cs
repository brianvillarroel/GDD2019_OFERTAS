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
    public partial class EntregaCupon : Form
    {
        private string cupon_Codigo;
        private string cuponID;
        private int clienteID;
        public EntregaCupon()
        {
            InitializeComponent();
        }

        public EntregaCupon(int clieID, string cuponid, string cuponCodigo)
        {
            //Seteo estos valores para tenerlos para llamar al store procedure del registro de la entrega
            cuponID = cuponid;
            cupon_Codigo = cuponCodigo;
            clienteID = clieID;

            InitializeComponent();
            //Cargar las ofertas disponibles para la fecha del sistema.

            Object [] datosCliente = BaseDatos.TraerUnCliente(clieID);

            if (datosCliente.Length > 0)
            {
                this.label3.Text = datosCliente [1].ToString();
                this.label3.Text = this.label3.Text + " " + datosCliente [2].ToString();
                this.label3.Text = this.label3.Text + ", DNI: " + datosCliente [3].ToString();
            }

            DataGridViewButtonColumn btnElegir = new DataGridViewButtonColumn();
            btnElegir.Name = "Elegir";
            btnElegir.Text = "Elegir";
            btnElegir.UseColumnTextForButtonValue = true;
            dataGVEntrega.Columns.Add(btnElegir);
            btnElegir.Visible = true;
        }


        private void dataGVEntrega_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (this.dataGVEntrega.Columns [e.ColumnIndex].Name == "Elegir")
            {
                List<SqlParameter> parametros = new List<SqlParameter>();
                SqlParameter parametro;

                parametro = new SqlParameter("@fecha", SqlDbType.Date);
                parametro.Value = BaseDatos.ObtenerFechaSistema();
                parametros.Add(parametro);

                parametro = new SqlParameter("@clienteID", SqlDbType.Int);
                parametro.Value = clienteID;
                parametros.Add(parametro);

                parametro = new SqlParameter("@cuponID", SqlDbType.Int);
                parametro.Value = Convert.ToInt64(cuponID);
                parametros.Add(parametro);

                parametro = new SqlParameter("@cuponCodigo", SqlDbType.NVarChar, 255);
                parametro.Value = cupon_Codigo;
                parametros.Add(parametro);

                // Funcino de base de datos que haga el store procedure de registrar la entrega
                
                BaseDatos.RegistrarEntrega(parametros);
                this.Close();
                
            }
        }

        private void Mail_Click(object sender, EventArgs e)
        {

        }

        //Click en boton limpiar
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.txtNombre.Text = "";
            this.txtApellido.Text = "";
            this.txtMail.Text = "";
            this.numDni.Text = "";
            dataGVEntrega.DataSource = null;
            this.dataGVEntrega.Columns ["Elegir"].Visible = false;
        }

        //Click en boton buscar
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string nombre = this.txtNombre.Text.ToString();
            string apellido = this.txtApellido.Text.ToString();
            string dni = this.numDni.Text.ToString();
            string mail = this.txtMail.Text.ToString(); 
            //llenar el grid con los datos de los filtros
            dataGVEntrega.DataSource = BaseDatos.ListarClientesEntrega(nombre, apellido, mail, dni).Tables [0];
            this.dataGVEntrega.Columns ["Elegir"].Visible = true;

            dataGVEntrega.Columns [5].Visible = false;
            dataGVEntrega.Columns [6].Visible = false;
            dataGVEntrega.Columns [7].Visible = false;
            dataGVEntrega.Columns [8].Visible = false;

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
