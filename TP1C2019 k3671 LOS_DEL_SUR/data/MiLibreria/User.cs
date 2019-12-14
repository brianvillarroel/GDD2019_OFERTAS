using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using MiLibreria;
using System.Security;


namespace MiLibreria
{
    public class User
    {
        private int adminId = 0;
        private int clienteId = 0;
        private int proveeId = 0;

        public int Id { get; private set; }
        public int Rol { get; private set; }
        public int AdminId { get {return adminId;}  set { adminId = value; } }
        public int ClienteId { get{return clienteId;}  set { clienteId = value; } }
        public int ProveeId { get{return proveeId;}  set { proveeId = value; } }
        public List<int> Funcionalidades { get; set; }


        //public User usuarioActivo = new User();
        //Verificar datos de acceso del login
        public static int Autenticar(string usuario, string password)
        {

            BaseDatos bd = new BaseDatos();
            //Abrir conexión y el store procedure
            var cmd = new SqlCommand("LOS_DEL_SUR.BUSCAR_USER", bd.ConectarBD());

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = usuario;
            cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = password;

            //Ejecutar la consulta y recuperar el valor que retorna la consulta de selección
            int result = Convert.ToInt32(cmd.ExecuteScalar());


            return result;
            
        }

        public static object [] SetearAtributosUsuario(string usuario, User usuarioActivo)
        {

            usuarioActivo.Funcionalidades = new List<int>();
            Object [] datosUsuario = BaseDatos.GetUsuario(usuario);
            if (datosUsuario.Length > 0)
            {
                usuarioActivo.Id = Convert.ToInt32(datosUsuario [0].ToString());
                usuarioActivo.Rol = Convert.ToInt32(datosUsuario [1].ToString());

               
           DataSet rolFuncionalidades = BaseDatos.GetFuncionalidadesUsuario(usuarioActivo.Rol);

            foreach (DataRow theRow in rolFuncionalidades.Tables [0].Rows)
            {
                int funcionalidad = Convert.ToInt32(theRow ["FUNCION_ID"].ToString());
                usuarioActivo.Funcionalidades.Add(funcionalidad);
            }

                switch (usuarioActivo.Rol)
                {
                    case 1:
                        usuarioActivo.ClienteId = Convert.ToInt32(datosUsuario [2].ToString());
                        break;
                    case 2:
                        usuarioActivo.AdminId = Convert.ToInt32(datosUsuario [2].ToString());
                        break;
                     case 3:
                        usuarioActivo.ProveeId = Convert.ToInt32(datosUsuario [2].ToString());
                        break;
                    default:
                        break;
                }

            }
             return datosUsuario;
        }
    }
}
