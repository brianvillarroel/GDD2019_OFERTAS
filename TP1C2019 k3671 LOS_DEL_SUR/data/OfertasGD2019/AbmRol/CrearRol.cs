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

namespace OfertasGD2019.AbmRol
{
    public partial class CrearRol : Form
    {

        public CrearRol()
        {
            InitializeComponent();

            //Armo la lista de funcionalidades
            DataSet funcionalidades = BaseDatos.ListarFuncionalidades();

            foreach (DataRow theRow in funcionalidades.Tables [0].Rows)
            {
                string id = theRow ["FUNCION_ID"].ToString();
                string nombre = theRow ["FUNCION_NOMBRE"].ToString();

                checkedListBox1.Items.Add(new CheckListBoxItem()
                {
                    Tag = id,
                    Text = nombre
                });
            }
        }

        //Obtengo las funcionalidades ya existentes para el rol y las selecciono.
        private void ModificarRol_Load(object sender, EventArgs e)
        {
        }

        //Click en Vovler cierra la pantalla.
        private void button1_Click(object sender, EventArgs e)
        {
            SeleccionarRol seleccionarRol = new SeleccionarRol();
            seleccionarRol.Show();
            this.Close();
        }

        //Click en guardar llama al store procedure para guardar los cambios;
        private void button3_Click(object sender, EventArgs e)
        {
            string funcHabilitadas = "";
            foreach (CheckListBoxItem item in checkedListBox1.Items)
            {
                if (checkedListBox1.CheckedItems.Contains(item))
                {
                funcHabilitadas = funcHabilitadas + item.Tag.ToString() + ',';
                }
            }

            if (funcHabilitadas.Length > 0)
            {
                funcHabilitadas = funcHabilitadas.Remove(funcHabilitadas.Length - 1);
            }
            else
            {
                funcHabilitadas = " ";
            }

            //Seteo los valores para crear el Rol
            List<SqlParameter> parametros = new List<SqlParameter>();
            SqlParameter parametro;

            parametro = new SqlParameter("@rolNombre", SqlDbType.VarChar, 50);
            parametro.Value = this.txtNombreRol.Text.ToString();
            parametros.Add(parametro);

            parametro = new SqlParameter("@funHabilitadas", SqlDbType.VarChar, 500);
            parametro.Value = funcHabilitadas;
            parametros.Add(parametro);


            BaseDatos.RegistrarRol(parametros);
           
        }
    }
}
