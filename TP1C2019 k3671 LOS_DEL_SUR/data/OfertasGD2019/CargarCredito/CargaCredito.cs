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

namespace OfertasGD2019.CargarCredito
{
    public partial class CargaCredito : Form
    {
        public CargaCredito()
        {
            InitializeComponent();

        }

        public CargaCredito(int clienteID)
        {
            InitializeComponent();

            //Seteo el dropdown
            comboPago.DropDownStyle = ComboBoxStyle.DropDownList;
            comboPago.SelectedIndex = 0;

            //Obtengo el nombre del usuario para dientificar a quien realizo la carga
            this.numId.Text = clienteID.ToString();
            this.txtUsuario.Text = BaseDatos.ObtenerUsernameCliente(clienteID.ToString());
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void errorTxtBox1_TextChanged(object sender, EventArgs e)
        {

        }

        //Validar y realizar la carga
        private void button1_Click(object sender, EventArgs e)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter parametro;

            if (MiLibreria.Validaciones.ValidarCargaCredito(this, errorProvider1))
           {
               parametro = new SqlParameter("@clieID", SqlDbType.Int);
               parametro.Value = Int32.Parse(this.numId.Text);
               parametros.Add(parametro);

               parametro = new SqlParameter("@tipoPago", SqlDbType.NVarChar, 255);
               parametro.Value = this.comboPago.SelectedItem.ToString();
               parametros.Add(parametro);

               parametro = new SqlParameter("@monto", SqlDbType.Int);
               parametro.Value = Int32.Parse(this.numMonto.Text); 
               parametros.Add(parametro);

               parametro = new SqlParameter("@tarjetaNum", SqlDbType.BigInt);
               parametro.Value = Int64.Parse(this.numTarjeta.Text);
               parametros.Add(parametro);

               parametro = new SqlParameter("@tarjetaVenc", SqlDbType.NVarChar, 255);
               parametro.Value = "01/" + this.dateVenc.Text;
               parametros.Add(parametro);

               parametro = new SqlParameter("@tarjetaNombre", SqlDbType.NVarChar, 255);
               parametro.Value = this.txtNombTarj.Text;
               parametros.Add(parametro);

               parametro = new SqlParameter("@fecha", SqlDbType.NVarChar, 255);
               parametro.Value = BaseDatos.ObtenerFechaSistema();
               parametros.Add(parametro);


               BaseDatos.UpdateCargaCredito(parametros);
               this.Close();
           }
           else
           {
               MessageBox.Show("Algunos campos tienen errores. Por favor Verifiquelos"); 
           }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        //Click en limpiar
        private void button2_Click(object sender, EventArgs e)
        {
            this.txtNombTarj.Text = "";
            this.numMonto.Text = "";
            this.numTarjeta.Text = "";
            this.dateVenc.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
