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


        public int Id { get; private set; }
        public int Rol { get; private set; }

        //public User usuarioActivo = new User();
        //Verificar datos de acceso del login
        public static int Autenticar(string usuario, string password)
        {

            BaseDatos bd = new BaseDatos();
            //Abrir conexión y el store procedure
            var cmd = new SqlCommand("BUSCAR_USER", bd.ConectarBD());

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = usuario;
            cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = password;

            //Ejecutar la consulta y recuperar el valor que retorna la consulta de selección
            int result = Convert.ToInt32(cmd.ExecuteScalar());


            return result;
            
        }

        public static object [] SetearAtributosUsuario(string usuario, User usuarioActivo)
        {

            
            Object [] datosUsuario = BaseDatos.GetUsuario(usuario);
             if (datosUsuario.Length > 0)
            {
                usuarioActivo.Id = Convert.ToInt32(datosUsuario [0].ToString());
                usuarioActivo.Rol = Convert.ToInt32(datosUsuario [1].ToString());
            }

             return datosUsuario;
        }
    }
}
