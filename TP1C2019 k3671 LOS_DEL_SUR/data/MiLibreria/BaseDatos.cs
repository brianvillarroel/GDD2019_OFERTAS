using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace MiLibreria
{
    public class BaseDatos
    {

        public static string fechasistema = ConfigurationManager.AppSettings ["FechaSistema"];
        private static BaseDatos bdd = new BaseDatos();
        //Establecer conexion a la BD
        public SqlConnection ConectarBD()
        {
            SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["db_cn"].ConnectionString);

            if (conexion.State == ConnectionState.Open)
            {
                conexion.Close();
            }
            else
            {
                conexion.Open();
            }

            return conexion;
        }

        //OBTENER FECHA DE SISTEMA
        public static DateTime ObtenerFechaSistema()
        {
            try
            {
                DateTime fecha = DateTime.Parse(fechasistema.ToString());
                string fechaString = Convert.ToString(ConfigurationManager.AppSettings ["FechaSistema"]);
                fecha = Convert.ToDateTime(fechaString);
                return fecha;
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //OBTENER LOS IDS DEL USUARIO
        public static Object [] GetUsuario(string usuario)
        {
            BaseDatos bd = new BaseDatos();
            var cmd = new SqlCommand("SETEAR_USER", bd.ConectarBD());

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = usuario;

            SqlDataReader reader = cmd.ExecuteReader();
            //DataRow row = new DataRow();
            Object [] values = new Object [reader.FieldCount];
            // row = reader;
            if (reader.Read())
            {
                int fieldCount = reader.GetValues(values);
                fieldCount = reader.GetValues(values);
                for (int i = 0; i < fieldCount; i++)
                
                    return values;
            }

            return values;
        }

        //
        public static DataSet EjecutarEnBD(string cmd)
        {
            BaseDatos bd = new BaseDatos();
            DataSet ds = new DataSet();
            SqlDataAdapter dp = new SqlDataAdapter(cmd, bd.ConectarBD());

            dp.Fill(ds);

            return ds;
        
        }

        //Cargar los datos a la pantalla modificar cliente
        public static object[]  TraerUnCliente(int clieID)
        {
            BaseDatos bd = new BaseDatos();
            //Abrir conexión y el store procedure
            var cmd = new SqlCommand("BUSCAR_CLIENTE", bd.ConectarBD());

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@clieID", SqlDbType.Int).Value = clieID;

            SqlDataReader reader = cmd.ExecuteReader();
            //DataRow row = new DataRow();
            Object [] values = new Object [reader.FieldCount];
           // row = reader;
            if (reader.Read())
            {
                int fieldCount = reader.GetValues(values);
                fieldCount = reader.GetValues(values);
                for (int i = 0; i < fieldCount; i++)

                return values;
            }

            return values;
            
        }

        //Cargar los datos a la pantalla modificar Proveedor
        public static object [] TraerUnProveedor(int proveeID)
        {
            BaseDatos bd = new BaseDatos();
            //Abrir conexión y el store procedure
            var cmd = new SqlCommand("BUSCAR_PROVEEDOR", bd.ConectarBD());

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@proveeID", SqlDbType.Int).Value = proveeID;

            SqlDataReader reader = cmd.ExecuteReader();
            //DataRow row = new DataRow();
            Object [] values = new Object [reader.FieldCount];
            // row = reader;
            if (reader.Read())
            {
                int fieldCount = reader.GetValues(values);
                fieldCount = reader.GetValues(values);
                for (int i = 0; i < fieldCount; i++)

                return values;
            }

            return values;

        }

        //Guardar los datos modificados de un cliente

        public static void UpdateDatosCliente(List<SqlParameter> parametros)
        {
            BaseDatos bd = new BaseDatos();
            //Abrir conexión y el store procedure
            var cmd = new SqlCommand("UPDATE_CLIENTE", bd.ConectarBD());
            SqlCommand comando = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;

            foreach (SqlParameter p in parametros)
            {
                cmd.Parameters.Add(p);
            }
            


            //Ejecutar la consulta y recuperar el valor que retorna la consulta de selección

            try
            {
                
                cmd.ExecuteNonQuery();
                MessageBox.Show("Datos guardados correctamente.");
            }
            catch (SqlException)
            {
                MessageBox.Show("Failed", "DataError", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        //Guardar los datos modificados de un Proveedor

        public static void UpdatedatosProveedor(List<SqlParameter> parametros)
        {
            BaseDatos bd = new BaseDatos();
            //Abrir conexión y el store procedure
            var cmd = new SqlCommand("UPDATE_PROVEEDOR", bd.ConectarBD());
            SqlCommand comando = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;

            foreach (SqlParameter p in parametros)
            {
                cmd.Parameters.Add(p);
            }



            //Ejecutar la consulta y recuperar el valor que retorna la consulta de selección

            try
            {

                cmd.ExecuteNonQuery();
                MessageBox.Show("Datos guardados correctamente.");
            }
            catch (SqlException)
            {
                MessageBox.Show("Failed", "DataError", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }


        //Armar Listado de clientes en ABM CLIENTE
        public DataSet BuscarClientes(string tabla, string nombre, string apellido, string dni,string mail) 
        {
            DataSet ds;
            int cantFiltros = 0;

            //string query = "SELECT TOP 10 CLIE_ID, CLIE_NOMBRE, CLIE_APELLIDO, CLIE_DNI, CLIE_MAIL, CLIE_FECHA_NAC FROM LOS_DEL_SUR.CLIENTE ";
            string query = "SELECT  CLIE_ID, CLIE_NOMBRE, CLIE_APELLIDO, CLIE_DNI, CLIE_MAIL, CLIE_FECHA_NAC, USUARIO_Id, USUARIO_ESTADO  FROM LOS_DEL_SUR.CLIENTE  c join LOS_DEL_SUR.USUARIO u on c.CLIE_USUARIO = u.USUARIO_Id ";
            

            //Abrir conexión y el store procedure
            if (string.Equals(nombre, "") && string.Equals(apellido, "") && string.Equals(dni, "") && string.Equals(mail, ""))
            {
                ds = EjecutarEnBD(query);

                return ds;
            }

            if (!string.Equals(nombre, ""))
            {
                cantFiltros = cantFiltros +1;
                query = query + " WHERE CLIE_NOMBRE LIKE '%" + nombre + "%'";
            }

             if (!string.Equals(apellido, ""))
            {
                
                 if(cantFiltros > 0)
                 {
                     query = query + " AND ";
                 } else {
                    query = query + " WHERE ";
                 }
                 cantFiltros = cantFiltros + 1;

                 query = query + " CLIE_APELLIDO LIKE '%" + apellido + "%'";
            }

             if (!string.Equals(dni, ""))
            {
                int intDni = Convert.ToInt32(dni);

                  if(cantFiltros > 0)
                 {
                     query = query + " AND ";
                 } else {
                    query = query + " WHERE ";
                 }
                  cantFiltros = cantFiltros + 1;
                  query = query + " CLIE_DNI = " + intDni;
            }

             if (!string.Equals(mail, ""))
            {
                  if(cantFiltros > 0)
                 {
                     query = query + " AND ";
                 } else {
                    query = query + " WHERE ";
                 }

                cantFiltros = cantFiltros + 1;
                query = query + " CLIE_MAIL LIKE '%" + mail + "%'";
            }

            query = string.Format(query) ;

            
            ds = EjecutarEnBD(query);

            return ds;
        }

        public static DataSet ListarProveedores(string razonSocial,  string cuit, string mail)
        {
            DataSet listado = new DataSet();
            BaseDatos bd = new BaseDatos();
            //Abrir conexión y el store procedure
            var cmd = new SqlCommand("LISTAR_PROVEEDORES", bd.ConectarBD());
            cmd.CommandType = CommandType.StoredProcedure;
            
            //sETEAR PARAMETROS
            if (razonSocial.Trim() == "")
            {
                cmd.Parameters.Add("@proveeRazSoc", SqlDbType.NVarChar).Value = DBNull.Value;
            }
            else
            {
                cmd.Parameters.Add("@proveeRazSoc", SqlDbType.NVarChar).Value = razonSocial;
            }

            if (cuit.Trim() == "")
            {
                cmd.Parameters.Add("@proveeCuit", SqlDbType.NVarChar).Value = DBNull.Value;
            }
            else
            {
                cmd.Parameters.Add("@proveeCuit", SqlDbType.NVarChar).Value = cuit;
            }

            if (mail.Trim() == "")
            {
                cmd.Parameters.Add("@proveeMail", SqlDbType.NVarChar).Value = DBNull.Value;
            }
            else
            {
                cmd.Parameters.Add("@proveeMail", SqlDbType.NVarChar).Value = mail;
            }

            SqlDataAdapter dp = new SqlDataAdapter(cmd);


            dp.Fill(listado);


            return listado;
            //Ejecutar la consulta y recuperar el valor que retorna la consulta de selección


        }

        //OBTENER EL USERNAME DEL CLIETNE PARA IDENTIFICARLO EN LOS FORMS.
        public static string ObtenerUsernameCliente(string clienteID)
        {
            var cmd = new SqlCommand("OBTENER_USERNAME_CLIENTE", bdd.ConectarBD());
            SqlCommand comando = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@clieID", SqlDbType.Int).Value = Int32.Parse(clienteID);

            string result = cmd.ExecuteScalar().ToString();

            return result;
        }


        //OBTENER EL USERNAME DEL CLIETNE PARA IDENTIFICARLO EN LOS FORMS.
        public static string ObtenerUsernameProveedor(string proveeID)
        {
            var cmd = new SqlCommand("OBTENER_USERNAME_PROVEEDOR", bdd.ConectarBD());
            SqlCommand comando = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@proveeID", SqlDbType.Int).Value = Int32.Parse(proveeID);

            string result = cmd.ExecuteScalar().ToString();

            return result;
        }

        //Guardar la Carga de Credito

        public static void UpdateCargaCredito(List<SqlParameter> parametros)
        {
            //Abrir conexión y el store procedure
            var cmd = new SqlCommand("CARGAR_CREDITO", bdd.ConectarBD());
            SqlCommand comando = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;

            foreach (SqlParameter p in parametros)
            {
                cmd.Parameters.Add(p);
            }



            //Ejecutar la consulta y recuperar el valor que retorna la consulta de selección

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Carga exitosa.");
            }
            catch (SqlException)
            {
                MessageBox.Show("Failed", "DataError", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        public static void InsertOferta(List<SqlParameter> parametros)
        {
            //Abrir conexión y el store procedure
            var cmd = new SqlCommand("CREAR_OFERTA", bdd.ConectarBD());
            SqlCommand comando = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;

            foreach (SqlParameter p in parametros)
            {
                cmd.Parameters.Add(p);
            }
            //Ejecutar la consulta y recuperar el valor que retorna la consulta de selección

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("¡Oferta creada con éxito!");
            }
            catch (SqlException)
            {
                MessageBox.Show("Failed", "DataError", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
