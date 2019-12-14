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

namespace OfertasGD2019.Facturacion
{
    public partial class Facturar : Form
    {
        Dictionary<string, string> comboSourceMes;
        int proveeIdFact;
        string valueMes;

        public Facturar()
        {
            InitializeComponent();

            //Seteo el dropdown
        }

        public Facturar(int proveedorID)
        {
            InitializeComponent();
            proveeIdFact = proveedorID;
            //Seteo el dropdown
        }

        //Cargo los combobox al cargar la pantalla
        private void Facturar_Load(object sender, EventArgs e)
        {
            comboSourceMes = new Dictionary<string, string>();
            comboSourceMes.Add("Enero", "01");
            comboSourceMes.Add("Febrero", "02");
            comboSourceMes.Add("Marzo", "03");
            comboSourceMes.Add("Abril", "04");
            comboSourceMes.Add("Mayo", "05");
            comboSourceMes.Add("Junio", "06");
            comboSourceMes.Add("Julio", "07");
            comboSourceMes.Add("Agosto", "08");
            comboSourceMes.Add("Septiembre", "09");
            comboSourceMes.Add("Octubre", "10");
            comboSourceMes.Add("Noviembre", "11");
            comboSourceMes.Add("Diciembre", "12");

            foreach (string item in comboSourceMes.Keys)
            {
                comboBoxMes.Items.Add(item.ToString());
            }
            DateTime fechaActual = BaseDatos.ObtenerFechaSistema();
            int anio = fechaActual.Year;
            comboBoxMes.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxMes.SelectedIndex = 0;

          
           
            comboBoxAnio.Items.Add(anio.ToString());
            comboBoxAnio.Items.Add((anio - 1).ToString());
            comboBoxAnio.Items.Add((anio - 2).ToString());

            comboBoxAnio.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxAnio.SelectedIndex = 0;





            object [] datosProveedor = BaseDatos.TraerUnProveedor(proveeIdFact);

            this.txtRS.Text = datosProveedor [0].ToString();
            this.txtCUIT.Text = datosProveedor[1].ToString();
            this.btnFacturar.Enabled = false;
        }

        //Seteo el valor cuando selecciono el combobox del mes
        private void comboBoxMes_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            //get the selected item in a variable
            string keyMes = comboBoxMes.SelectedItem.ToString();
            valueMes = "";
            //try to fetch the value for the same 
            bool isValid = comboSourceMes.TryGetValue(keyMes, out valueMes);
            //display it in message box or use it as u want
        }

        //Click en buscar trae todas las compras de ofertas del proveedor en el periodo seleccionado
        private void button1_Click(object sender, System.EventArgs e)
        {
            List<SqlParameter> facturacion = SetearParametros();
            dataGVFacturacion.DataSource = BaseDatos.ObtenerOfertasAFacturar(facturacion).Tables [0];



            if (dataGVFacturacion.Rows.Count > 0)
            {
                double suma = dataGVFacturacion.Rows.OfType<DataGridViewRow>().
                        Sum(x => (Convert.ToDouble(x.Cells ["Precio"].Value)) * (Convert.ToDouble(x.Cells ["Cantidad"].Value)));

                dataGVFacturacion.Columns ["Factura"].Visible = false;
                this.txtTotal.Text = string.Format("{0:N2}", suma);

                this.txtFactura.Text = dataGVFacturacion.Rows [0].Cells ["Factura"].Value.ToString();
                this.txtBusqueda.Visible = false;
                this.btnFacturar.Enabled = true;
            }
            else 
            {
                dataGVFacturacion.DataSource = null;
                this.txtBusqueda.Visible = true;
                this.btnFacturar.Enabled = false;
            }

           
        }

        //Seteo los parametros par alos store procedures
        public List<SqlParameter> SetearParametros()
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter parametro;
            //Chequeo que el dni no este registrado
            parametro = new SqlParameter("@proveedorID", SqlDbType.Int);
            parametro.Value = proveeIdFact;
            parametros.Add(parametro);

            parametro = new SqlParameter("@mes", SqlDbType.Int);
            parametro.Value = Convert.ToInt32(valueMes);
            parametros.Add(parametro);

            parametro = new SqlParameter("@anio", SqlDbType.Int);
            parametro.Value = Convert.ToInt32(this.comboBoxAnio.SelectedItem.ToString());
            parametros.Add(parametro);

            return parametros;
        }

        //Click en Facturar
        private void button3_Click(object sender, EventArgs e)
        {
            List<SqlParameter> parametrosFactura = new List<SqlParameter>();
            SqlParameter parametro;
            //Chequeo que el dni no este registrado
            parametro = new SqlParameter("@proveedorID", SqlDbType.Int);
            parametro.Value = proveeIdFact;
            parametrosFactura.Add(parametro);

            parametro = new SqlParameter("@mes", SqlDbType.Int);
            parametro.Value = Convert.ToInt32(valueMes);
            parametrosFactura.Add(parametro);

            parametro = new SqlParameter("@anio", SqlDbType.Int);
            parametro.Value = Convert.ToInt32(this.comboBoxAnio.SelectedItem.ToString());
            parametrosFactura.Add(parametro);

            parametro = new SqlParameter("@fecha", SqlDbType.DateTime);
            parametro.Value = BaseDatos.ObtenerFechaSistema();
            parametrosFactura.Add(parametro);

            parametro = new SqlParameter("@total", SqlDbType.Int);
            parametro.Value = Convert.ToDecimal(this.txtTotal.Text.ToString());
            parametrosFactura.Add(parametro);

            BaseDatos.FacturarPeriodoProveedor(parametrosFactura);
            
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}