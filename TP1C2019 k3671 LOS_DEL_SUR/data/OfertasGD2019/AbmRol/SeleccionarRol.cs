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

namespace OfertasGD2019.AbmRol
{
    public partial class SeleccionarRol : Form
    {
        Dictionary<string, string> comboSourceRol;
        string valueRol;

        public SeleccionarRol()
        {
            InitializeComponent();
        }

        private void SeleccionarRol_Load(object sender, EventArgs e)
        {
            DataSet roles =  BaseDatos.ListarRoles();
            comboSourceRol = new Dictionary<string, string>();

            foreach (DataRow theRow in roles.Tables [0].Rows)
            {
                string id = theRow ["ROL_ID"].ToString();
                string nombre = theRow ["ROL_NOMBRE"].ToString();

                comboSourceRol.Add(nombre, id);
            }




            foreach (string item in comboSourceRol.Keys)
            {
                comboBoxRol.Items.Add(item.ToString());
            }
            comboBoxRol.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxRol.SelectedIndex = 0;

        }

        private void comboBoxRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            //get the selected item in a variable
            string keyRol = comboBoxRol.SelectedItem.ToString();
            valueRol = "";
            //try to fetch the value for the same 
            bool isValid = comboSourceRol.TryGetValue(keyRol, out valueRol);
            //display it in message box or use it as u want
        }

        //click en volver
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //click en habilitar
        private void button3_Click(object sender, EventArgs e)
        {
            BaseDatos.InhabilitarRol(Convert.ToInt32(valueRol));
        }

        //Click en modificar
        private void button1_Click(object sender, EventArgs e)
        {
            ModificarRol modificarRol = new ModificarRol(Convert.ToInt32(valueRol));
            modificarRol.ShowDialog();
        }

        private void btnHabilitar_Click(object sender, EventArgs e)
        {
            BaseDatos.InhabilitarRol(Convert.ToInt32(valueRol));
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            
            CrearRol crearRol = new CrearRol();
            crearRol.Show();
            this.Close();
        }
    }
}
