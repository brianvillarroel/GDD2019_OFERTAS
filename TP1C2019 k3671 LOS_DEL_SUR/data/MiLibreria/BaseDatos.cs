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

        //cHEQUEO EL DNI NO EXISTA ANTES DE GUARDAR LSO DATOS DE UN CLIENTE
        public static int ChequearDniClientes(List<SqlParameter> parametros)
        {
            BaseDatos bd = new BaseDatos();
            //Abrir conexión y el store procedure
            var cmd = new SqlCommand("CHEQUEAR_DNI_CLIENTE", bd.ConectarBD());
            SqlCommand comando = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;

            foreach (SqlParameter p in parametros)
            {
                cmd.Parameters.Add(p);
            }


            //Ejecutar la consulta y recuperar el valor que retorna la consulta de selección
            int result = Convert.ToInt32(cmd.ExecuteScalar());

            
            return result;
        }

        //Guardar los datos modificados de un cliente

        public static void UpdateDatosCliente(List<SqlParameter> parametros)
        {
            //Abrir conexión y el store procedure
            var cmd = new SqlCommand("UPDATE_CLIENTE", bdd.ConectarBD());
            SqlCommand comando = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
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


        //cHEQUEO EL CUIT NO EXISTA ANTES DE GUARDAR LSO DATOS DE UN CLIENTE
        public static int ChequearCuitProveedor(List<SqlParameter> parametros)
        {
            BaseDatos bd = new BaseDatos();
            //Abrir conexión y el store procedure
            var cmd = new SqlCommand("CHEQUEAR_CUIT_PROVEE", bd.ConectarBD());
            SqlCommand comando = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter p in parametros)
            {
                cmd.Parameters.Add(p);
            }


            //Ejecutar la consulta y recuperar el valor que retorna la consulta de selección
            int result = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Parameters.Clear();

            return result;
        }

        //cHEQUEO QUE LA Razon Social NO EXISTA ANTES DE GUARDAR LSO DATOS DE UN CLIENTE
        public static int ChequearRazSocProveedor(List<SqlParameter> parametros)
        {
            BaseDatos bd = new BaseDatos();
            //Abrir conexión y el store procedure
            var cmd = new SqlCommand("CHEQUEAR_RS_PROVEE", bd.ConectarBD());
            SqlCommand comando = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
           
            foreach (SqlParameter p in parametros)
            {
                cmd.Parameters.Add(p);
            }


            //Ejecutar la consulta y recuperar el valor que retorna la consulta de selección
            int result = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Parameters.Clear();

            return result;
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
        public static DataSet ListarClientes(string nombre, string apellido, string dni, string mail) 
        {
            DataSet listadoClientes = new DataSet();
            //Abrir conexión y el store procedure
            var cmd = new SqlCommand("LISTAR_CLIENTES", bdd.ConectarBD());
            cmd.CommandType = CommandType.StoredProcedure;

            //sETEAR PARAMETROS
            if (nombre.Trim() == "")
            {
                cmd.Parameters.Add("@NOMBRE", SqlDbType.NVarChar).Value = DBNull.Value;
            }
            else
            {
                cmd.Parameters.Add("@NOMBRE", SqlDbType.NVarChar).Value = nombre;
            }

            if (apellido.Trim() == "")
            {
                cmd.Parameters.Add("@apellido", SqlDbType.NVarChar).Value = DBNull.Value;
            }
            else
            {
                cmd.Parameters.Add("@apellido", SqlDbType.NVarChar).Value = apellido;
            }

            if (mail.Trim() == "")
            {
                cmd.Parameters.Add("@mail", SqlDbType.NVarChar).Value = DBNull.Value;
            }
            else
            {
                cmd.Parameters.Add("@mail", SqlDbType.NVarChar).Value = mail;
            }

            if (dni.Trim() == "")
            {
                cmd.Parameters.Add("@dni", SqlDbType.NVarChar).Value = DBNull.Value;
            }
            else
            {
                cmd.Parameters.Add("@dni", SqlDbType.NVarChar).Value = Convert.ToInt32(dni);
            }

            SqlDataAdapter dp = new SqlDataAdapter(cmd);


            dp.Fill(listadoClientes);


            return listadoClientes;
        }

        /// <summary>
        /// Llamar al store procedure para obtener los proveedores
        /// </summary>
        /// <param name="razonSocial"></param>
        /// <param name="cuit"></param>
        /// <param name="mail"></param>
        /// <returns></returns>
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

       

         //OBTENER EL SALDO DEL CLIETNE PARA QUE SEA VISIBLE EN LA PANTALLA DE COMPRAR OFERTAS.
        public static string ObtenerSaldoCliente(string clienteID)
        {
            var cmd = new SqlCommand("OBTENER_SALDO_CLIENTE", bdd.ConectarBD());
            SqlCommand comando = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@clieID", SqlDbType.Int).Value = Int32.Parse(clienteID);

            string result = cmd.ExecuteScalar().ToString();

            return result;
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
        public static string ObtenerUsernameProveedor(int proveeID)
        {
            var cmd = new SqlCommand("OBTENER_USERNAME_PROVEEDOR", bdd.ConectarBD());
            SqlCommand comando = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@proveeID", SqlDbType.Int).Value = proveeID;

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

        public static DataSet ListarOfertas()
        {

            DataSet listadoOfertas = new DataSet();
            //Abrir conexión y el store procedure
            var cmd = new SqlCommand("LISTAR_OFERTAS", bdd.ConectarBD());
            cmd.CommandType = CommandType.StoredProcedure;

            //sETEAR PARAMETROS
            cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = BaseDatos.ObtenerFechaSistema();

            SqlDataAdapter dp = new SqlDataAdapter(cmd);


            dp.Fill(listadoOfertas);


            return listadoOfertas;
        }

        //vALIDAR SI EL CLIENTE SUPERA EL LIMITE DE COMPRAS DE UNA OFERTA
        public static Boolean ValidarLimiteDeCompra(int clienteID, int ofertaID, int limiteCompra, int cantidad)
        {
            bool validado = false;
            int cantidadYaComprada;
            var cmd = new SqlCommand("VALIDAR_LIMITE_COMPRA", bdd.ConectarBD());
            SqlCommand comando = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@clienteID", SqlDbType.Int).Value = clienteID;
            cmd.Parameters.Add("@ofertaID", SqlDbType.Int).Value = ofertaID;

            if (cmd.ExecuteScalar() == DBNull.Value)
            {
            cantidadYaComprada = 0;
            }
            else
            {
                cantidadYaComprada = (Convert.ToInt32(cmd.ExecuteScalar()));
            }
            validado = ((cantidadYaComprada + cantidad) <= limiteCompra);

            return validado;
        }

        //Registar la compra y crear el cupon correspondiente a la compra
        public static void RegistrarCompraOferta(List<SqlParameter> parametros)
        {
            //Abrir conexión y el store procedure
            var cmd = new SqlCommand("REGISTRAR_COMPRA_Y_CUPON", bdd.ConectarBD());
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
                MessageBox.Show("¡La compra se realizó con éxito!");
            }
            catch (SqlException)
            {
                MessageBox.Show("Failed", "DataError", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Listar cupones para la view de consumo cupon
        public static DataSet ListarCupones(int proveeID)
        {

            DataSet listadoCupones = new DataSet();
            //Abrir conexión y el store procedure
            var cmd = new SqlCommand("LISTAR_CUPONES_PROVEEDOR", bdd.ConectarBD());
            cmd.CommandType = CommandType.StoredProcedure;

            //sETEAR PARAMETROS
            cmd.Parameters.Add("@proveedorID", SqlDbType.Int).Value = proveeID;
            cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = BaseDatos.ObtenerFechaSistema();

            SqlDataAdapter dp = new SqlDataAdapter(cmd);


            dp.Fill(listadoCupones);


            return listadoCupones;
        }

        //Listar clientes para seleccionar a quien se lo entrega el cupon
        public static DataSet ListarClientesEntrega(string nombre, string apellido, string mail, string dni)
        {

            DataSet listadoEntregaClientes = new DataSet();
            //Abrir conexión y el store procedure
            var cmd = new SqlCommand("LISTAR_CLIENTES", bdd.ConectarBD());
            cmd.CommandType = CommandType.StoredProcedure;

            //sETEAR PARAMETROS
            if (nombre.Trim() == "")
            {
                cmd.Parameters.Add("@NOMBRE", SqlDbType.NVarChar).Value = DBNull.Value;
            }
            else
            {
                cmd.Parameters.Add("@NOMBRE", SqlDbType.NVarChar).Value = nombre;
            }

            if (apellido.Trim() == "")
            {
                cmd.Parameters.Add("@apellido", SqlDbType.NVarChar).Value = DBNull.Value;
            }
            else
            {
                cmd.Parameters.Add("@apellido", SqlDbType.NVarChar).Value = apellido;
            }

            if (mail.Trim() == "")
            {
                cmd.Parameters.Add("@mail", SqlDbType.NVarChar).Value = DBNull.Value;
            }
            else
            {
                cmd.Parameters.Add("@mail", SqlDbType.NVarChar).Value = mail;
            }

            if (dni.Trim() == "")
            {
                cmd.Parameters.Add("@dni", SqlDbType.NVarChar).Value = DBNull.Value;
            }
            else
            {
                cmd.Parameters.Add("@dni", SqlDbType.NVarChar).Value = Convert.ToInt32(dni);
            }

            SqlDataAdapter dp = new SqlDataAdapter(cmd);


            dp.Fill(listadoEntregaClientes);


            return listadoEntregaClientes;
        }

        public static void RegistrarEntrega(List<SqlParameter> parametros)
        {
            //Abrir conexión y el store procedure
            var cmd = new SqlCommand("REGISTRAR_ENTREGA_Y_DAR_DE_BAJA_CUPON", bdd.ConectarBD());
            SqlCommand comando = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;

            foreach (SqlParameter p in parametros)
            {
                cmd.Parameters.Add(p);
                Console.WriteLine(p.Value);
            }
            //Ejecutar la consulta y recuperar el valor que retorna la consulta de selección

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("¡Se dio de baja el cupon de forma exitosa!");
            }
            catch (SqlException)
            {
                MessageBox.Show("Failed", "DataError", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Validar que el dni no este registrado para el registro de un cliente
        public static int ValidarDniDisponible(List<SqlParameter> parametros)
        {
            //Abrir conexión y el store procedure
            var cmd = new SqlCommand("VALIDAR_DNI_BASEDATOS", bdd.ConectarBD());
            SqlCommand comando = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter p in parametros)
            {
                cmd.Parameters.Add(p);
            }


            //Ejecutar la consulta y recuperar el valor que retorna la consulta de selección
            int resultado = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Parameters.Clear();


            return resultado;
        }

        //Validar que el username no este registrado 
        public static int ValidarUsernameDisponible(List<SqlParameter> parametros)
        {
            //Abrir conexión y el store procedure
            var cmd = new SqlCommand("VALIDAR_USERNAME_BASEDATOS", bdd.ConectarBD());
            SqlCommand comando = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter p in parametros)
            {
                cmd.Parameters.Add(p);
            }


            //Ejecutar la consulta y recuperar el valor que retorna la consulta de selección
            int resultado = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Parameters.Clear();


            return resultado;
        }

        //Registrar en la BD la creacion de un nuevo cliente
        public static void RegistrarCliente(List<SqlParameter> parametros)
        {
            //Abrir conexión y el store procedure
            var cmd = new SqlCommand("REGISTRAR_CLIENTE", bdd.ConectarBD());
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
                MessageBox.Show("¡Registro realizado con exito!");
                cmd.Parameters.Clear();
            }
            catch (SqlException)
            {
                MessageBox.Show("Failed", "DataError", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmd.Parameters.Clear();
            }
        }

        //Validar que el cuit no este registrado para el registro de un proveedor
        public static int ValidarCuitDisponible(List<SqlParameter> parametros)
        {
            //Abrir conexión y el store procedure
            var cmd = new SqlCommand("VALIDAR_CUIT_REGISTRO", bdd.ConectarBD());
            SqlCommand comando = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter p in parametros)
            {
                cmd.Parameters.Add(p);
            }


            //Ejecutar la consulta y recuperar el valor que retorna la consulta de selección
            int resultado = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Parameters.Clear();


            return resultado;
        }

        //Validar que la razon social no este registrado para el registro de un proveedor
        public static int ValidarRazSocDisponible(List<SqlParameter> parametros)
        {
            //Abrir conexión y el store procedure
            var cmd = new SqlCommand("VALIDAR_RAZON_SOC_REGISTRO", bdd.ConectarBD());
            SqlCommand comando = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter p in parametros)
            {
                cmd.Parameters.Add(p);
            }


            //Ejecutar la consulta y recuperar el valor que retorna la consulta de selección
            int resultado = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Parameters.Clear();


            return resultado;
        }
    }
}
