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
    public partial class ModificarRol : Form
    {
        int rol_estado;
        int rol_id;
        DataSet rolInfo;
        public ModificarRol()
        {
            InitializeComponent();
        }
        
        public ModificarRol(int rolID)
        {
            
            InitializeComponent();
            rol_id = rolID;
            //Seteo el nombre y el estado del Rol
            rolInfo = BaseDatos.ObtenerNombreYEstadoRol(rol_id);

            foreach (DataRow theRow in rolInfo.Tables [0].Rows)
            {
                this.txtNombreRol.Text = theRow ["ROL_NOMBRE"].ToString();
                rol_estado = Convert.ToInt32( theRow ["ROL_ESTADO"]);
            }



            //Seteo el list box
            DataSet funcionalidades = BaseDatos.ListarFuncionalidades();

            foreach (DataRow theRow in funcionalidades.Tables[0].Rows)
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

            DataSet funcionXRol = BaseDatos.ObtenerFuncionalidadesXRol(rol_id);

            foreach (DataRow theRow in funcionXRol.Tables [0].Rows)
            {

                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    if (checkedListBox1.Items [i].ToString() == theRow ["FUNCION_NOMBRE"].ToString())
                    {
                        checkedListBox1.SetItemCheckState(i, CheckState.Checked);
                    }
                }
            }

            //Si esta inhabilitado muestro el boton de habilitar, sino no.
            if (rol_estado == 0)
            {
                this.btnHabilitar.Visible = true;
            }
            else
            {
                this.btnHabilitar.Visible = false;
            }
        }

        //Click en Vovler cierra la pantalla.
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Click en guardar llama al store procedure para guardar los cambios;
        private void button3_Click(object sender, EventArgs e)
        {
            string funcHabilitadas = "";
            string funcNOhabilitadas = "";
            foreach (CheckListBoxItem item in checkedListBox1.Items)
            {
                if (checkedListBox1.CheckedItems.Contains(item))
                {
                    funcHabilitadas = funcHabilitadas + item.Tag.ToString() + ',';
                }
                else
                {
                    funcNOhabilitadas = funcNOhabilitadas + item.Tag.ToString() + ',';
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


            if (funcNOhabilitadas.Length > 0)
            {
                funcNOhabilitadas = funcNOhabilitadas.Remove(funcNOhabilitadas.Length - 1);
            }
            else
            {
                funcNOhabilitadas = " ";
            }

            List<SqlParameter> parametros = new List<SqlParameter>();
            SqlParameter parametro;

            //seteo los parametros
            parametro = new SqlParameter("@rolD", SqlDbType.Int);
            parametro.Value = rol_id;
            parametros.Add(parametro);

            parametro = new SqlParameter("@habilitar", SqlDbType.VarChar, 500);
            parametro.Value = funcHabilitadas;
            parametros.Add(parametro);

            parametro = new SqlParameter("@inhabilitar", SqlDbType.VarChar, 500);
            parametro.Value = funcNOhabilitadas;
            parametros.Add(parametro);


            BaseDatos.UpdateFuncionalidadesXRol(parametros);
           
        }

        //click en habilitar
        private void button2_Click(object sender, EventArgs e)
        {
            BaseDatos.HabilitarRol(rol_id);
        }
    }
}
