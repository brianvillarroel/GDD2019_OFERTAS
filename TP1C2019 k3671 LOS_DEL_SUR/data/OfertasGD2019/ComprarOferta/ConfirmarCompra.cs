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

namespace OfertasGD2019.ComprarOferta
{
    public partial class ConfirmarCompra : Form
    {
        int cliente_ID;
        private string oferta_ID;
        private string precio_lista;
        private static Random random = new Random();

        public ConfirmarCompra()
        {
            InitializeComponent();
        }

        public ConfirmarCompra(string descripcion, string precio, string stock, string limiteCompra, string saldo, string ofertaID, string precioLista, int clienteID)
        {
            InitializeComponent();
            //cliente = usuario;
            cliente_ID = clienteID;
            this.txtDescripcion.Text = descripcion;
            this.numPrecio.Text = precio;
            this.txtStock.Text = stock;
            this.txtLimite.Text = limiteCompra;
            this.txtSaldo.Text = saldo;
            oferta_ID = ofertaID;
            precio_lista = precioLista;

            this.button3.Enabled = false;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void numCantidad_TextChanged(object sender, EventArgs e)
        {
            this.button3.Enabled = true;
        }

        private void errorTxtBox1_TextChanged(object sender, EventArgs e)
        {

        }

        //Click en CALCULAR TOTAL
        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.numCantidad.Text.Trim()))
            {
                errorProvider1.SetError(this.numCantidad, "Este campo es obligatorio");

            }
            else
            {
                errorProvider1.SetError(this.numCantidad, "");
                calcularTotalCompra();
            }
        }

        //Click en Volver
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Click en ACEPTAR
        private void button3_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty (this.numCantidad.Text.ToString()))
            {
                MessageBox.Show("Debe poner la cantidad que desea comprar");
            }
            else
            {
            calcularTotalCompra();
            List<SqlParameter> parametros = new List<SqlParameter>();
            SqlParameter parametro;

            if (MiLibreria.Validaciones.ValidarComprarOferta(this, errorProvider1, cliente_ID, Int32.Parse(oferta_ID)))
            { 
                parametro = new SqlParameter("@fecha", SqlDbType.Date);
                parametro.Value = BaseDatos.ObtenerFechaSistema();
                parametros.Add(parametro);

                parametro = new SqlParameter("@clienteID", SqlDbType.Int);
                parametro.Value = cliente_ID;
                parametros.Add(parametro);

                parametro = new SqlParameter("@ofertaID", SqlDbType.Int);
                parametro.Value = Int32.Parse(oferta_ID);
                parametros.Add(parametro);

                parametro = new SqlParameter("@cuponCodigo", SqlDbType.NVarChar, 255);
                parametro.Value = RandomString(10);
                parametros.Add(parametro);

                parametro = new SqlParameter("@precio", SqlDbType.Int);
                parametro.Value = Convert.ToDecimal(this.numPrecio.Text.ToString());
                parametros.Add(parametro);

                parametro = new SqlParameter("@precioLista", SqlDbType.Int);
                parametro.Value = Convert.ToDecimal(precio_lista);
                parametros.Add(parametro);

                parametro = new SqlParameter("@cantidad", SqlDbType.Int);
                parametro.Value = Int32.Parse(this.numCantidad.Text);
                parametros.Add(parametro);

                parametro = new SqlParameter("@fechaVencimiento ", SqlDbType.Date);
                parametro.Value = BaseDatos.ObtenerFechaSistema().AddMonths(1);
                parametros.Add(parametro);

                try
                {
                    BaseDatos.RegistrarCompraOferta(parametros);
                    this.Close();
                    ComprarOfertas comprarOferta = new ComprarOfertas(cliente_ID);
                    comprarOferta.Show();
                }
                catch
                { 
                }

            }
            }
        }

        public void calcularTotalCompra()
        {
            float cantidad = float.Parse(this.numCantidad.Text.ToString());
            float precio = float.Parse(this.numPrecio.Text);
            this.numTotal.Text = (cantidad * precio).ToString("N2");
        }

        // Funcion para crear codigos de cupon random.
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s [random.Next(s.Length)]).ToArray());
        }

        //Limpiar
        private void button4_Click(object sender, EventArgs e)
        {
            this.numCantidad.Text = "";
            this.numTotal.Text = "";
        }
    }
}
