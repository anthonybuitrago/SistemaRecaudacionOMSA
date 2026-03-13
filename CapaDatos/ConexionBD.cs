using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CapaDatos
{
    public class ConexionBD
    {
        // Ruta de acceso extraída de las configuraciones del sistema (App.config)
        private readonly string cadenaConexion = ConfigurationManager.ConnectionStrings["ConexionOMSA"].ConnectionString;

        // Objeto que maneja la comunicación con SQL Server
        private SqlConnection conexion;

        // Constructor que prepara la conexión con el servidor
        public ConexionBD()
        {
            conexion = new SqlConnection(cadenaConexion);
        }

        // Método para abrir el canal de comunicación con la base de datos
        public SqlConnection AbrirConexion()
        {
            if (conexion.State == ConnectionState.Closed)
            {
                conexion.Open();
            }
            return conexion;
        }

        // Método para cerrar de forma segura la conexión con la base de datos
        public SqlConnection CerrarConexion()
        {
            if (conexion.State == ConnectionState.Open)
            {
                conexion.Close();
            }
            return conexion;
        }
    }
}