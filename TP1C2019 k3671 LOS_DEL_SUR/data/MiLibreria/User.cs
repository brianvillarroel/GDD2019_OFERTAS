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


namespace MiLibreria
{
    public class User
    {

        /*
         POnerle atributos
         user_id
         rol id
         clie o provee id 
         
         */


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
    }
}
