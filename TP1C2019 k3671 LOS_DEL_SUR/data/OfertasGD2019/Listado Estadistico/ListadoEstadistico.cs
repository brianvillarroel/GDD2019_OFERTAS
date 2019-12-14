using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MiLibreria;

namespace OfertasGD2019.Listado_Estadistico
{
    public partial class ListadoEstadistico : Form
    {
        DateTime fechaActual = BaseDatos.ObtenerFechaSistema();
        int anioActual;

        public ListadoEstadistico()
        {
            InitializeComponent();
        }

        private void Listado_Load(object sender, EventArgs e)
        {
            comboBoxSemestre.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxListado.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSemestre.SelectedIndex = 0;
            comboBoxListado.SelectedIndex = 0;

            anioActual = fechaActual.Year;
            comboBoxAnio.Items.Add(anioActual.ToString());
            comboBoxAnio.Items.Add((anioActual - 1).ToString());
            comboBoxAnio.Items.Add((anioActual - 2).ToString());
            comboBoxAnio.SelectedIndex = 0;
            comboBoxAnio.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int anio = Convert.ToInt32(comboBoxAnio.SelectedItem.ToString());
            int semestre = Convert.ToInt32(comboBoxSemestre.SelectedItem.ToString());
            int mesActual = fechaActual.Month;
            
            //no permito que se listen periodos que aun no terminaron .
            if (anioActual == anio && (mesActual <= 6) || (mesActual > 6 && semestre == 2) )
            {
                MessageBox.Show("El semestre seleccionado aun no terminó. Elija otro periodo.");
                dataGridView1.DataSource = null;
                this.txtBusqueda.Visible = true;
            }
            else
            {
                string listado = comboBoxListado.SelectedItem.ToString();

                //Seteo los parametros para el store procedure

                List<SqlParameter> parametrosListado = new List<SqlParameter>();
                SqlParameter parametro;
                //Chequeo que el dni no este registrado
                parametro = new SqlParameter("@anio", SqlDbType.Int);
                parametro.Value = anio;
                parametrosListado.Add(parametro);

                parametro = new SqlParameter("@semestre", SqlDbType.Int);
                parametro.Value = semestre;
                parametrosListado.Add(parametro);

                if (comboBoxListado.SelectedIndex == 1)
                {
                    dataGridView1.DataSource = BaseDatos.ObtenerListadoProcentajeDescuento(parametrosListado).Tables [0];
                }
                else
                {
                    dataGridView1.DataSource = BaseDatos.ObtenerListadoMayorFacturacion(parametrosListado).Tables [0];
                }

                if (dataGridView1.Rows.Count > 0)
                {
                    this.txtBusqueda.Visible = false;
                }
                else
                {
                    dataGridView1.DataSource = null;
                    this.txtBusqueda.Visible = true;
                }
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            this.txtBusqueda.Visible = true;
        }
    }
}
