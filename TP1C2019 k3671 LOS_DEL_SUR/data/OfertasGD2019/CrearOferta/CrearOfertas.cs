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

namespace OfertasGD2019.CrearOferta
{
    public partial class CrearOfertas : Form
    {
        //Para la creacion random del codigo de oferta
        private static Random random = new Random();
        int proveedorID;
        public CrearOfertas()
        {
            InitializeComponent();
        }

        public CrearOfertas(int proveeID)
        {
            InitializeComponent();
            proveedorID = proveeID;
            //Obtengo el nombre del usuario para dientificar a quien realizo la carga
            this.txtUsername.Text = BaseDatos.ObtenerUsernameProveedor(proveedorID);
        }

        private void CrearOfertas_Load(object sender, EventArgs e)
        {
            //Seteo que el dia minimo para poder publicar la oferta sea el dia de la configuracion de la app
            this.dateInicio.MinDate = BaseDatos.ObtenerFechaSistema();
            this.dateInicio.Value = BaseDatos.ObtenerFechaSistema();
            // Y que el dia minimo para el vencimiento sea un dia despues.
            this.dateVencimiento.MinDate = BaseDatos.ObtenerFechaSistema().AddDays(1);
            this.dateVencimiento.Value = BaseDatos.ObtenerFechaSistema().AddDays(1);
        }


        //VALIDAR Y GUARDAR LA OFERTA EN LA BD SI ESTÁ TODO OK
        private void button3_Click(object sender, EventArgs e)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            SqlParameter parametro;

            if (MiLibreria.Validaciones.ValidarCrearOferta(this, errorProvider1))
            {
                parametro = new SqlParameter("@proveeID", SqlDbType.Int);
                parametro.Value = proveedorID;
                parametros.Add(parametro);

                parametro = new SqlParameter("@descripcion", SqlDbType.NVarChar, 255);
                parametro.Value = this.txtDescr.Text.ToString();
                parametros.Add(parametro);

                parametro = new SqlParameter("@fechaInicio", SqlDbType.Date);
                parametro.Value = Convert.ToDateTime(this.dateInicio.Text);
                parametros.Add(parametro);

                parametro = new SqlParameter("@fechaVencimiento", SqlDbType.Date);
                parametro.Value = Convert.ToDateTime(this.dateVencimiento.Text);
                parametros.Add(parametro);

                parametro = new SqlParameter("@precioOferta", SqlDbType.Int);
                parametro.Value =  this.numPreOferta.Text;
                parametros.Add(parametro);

                parametro = new SqlParameter("@precioLista", SqlDbType.Int);
                parametro.Value = this.numPrecLista.Text;
                parametros.Add(parametro);

                parametro = new SqlParameter("@stock", SqlDbType.Int);
                parametro.Value = this.numStock.Text;
                parametros.Add(parametro);

                parametro = new SqlParameter("@limiteCompra", SqlDbType.Int);
                parametro.Value = this.numLimite.Text;
                parametros.Add(parametro);

                parametro = new SqlParameter("@codigo", SqlDbType.NVarChar, 50);
                parametro.Value = RandomString(12);
                parametros.Add(parametro);


                BaseDatos.InsertOferta(parametros);
                this.Close();
            }
            else
            {
                MessageBox.Show("Algunos campos tienen errores. Por favor Verifiquelos");
            }
        }

        // Funcion para crear codigos de oferta random.
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s [random.Next(s.Length)]).ToArray());
        }

        /// <summary>
        /// Click en "Volver" cierra la ventana
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        /// <summary>
        /// Limpiar blanquea los txtbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            this.txtDescr.Text  = "";
            this.numPrecLista.Text  = "";
            this.numPreOferta.Text  = "";
            this.numStock.Text  = "";
            this.numLimite.Text  = "";
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
