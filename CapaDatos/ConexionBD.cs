using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CapaDatos
{
    public class ConexionBD
    {
        // Ahora lee la ruta dinámicamente desde el App.config
        private readonly string cadenaConexion = ConfigurationManager.ConnectionStrings["ConexionOMSA"].ConnectionString;

        private SqlConnection conexion;

        // Constructor para inicializar la conexión
        public ConexionBD()
        {
            conexion = new SqlConnection(cadenaConexion);
        }

        // Método para abrir la conexión
        public SqlConnection AbrirConexion()
        {
            if (conexion.State == ConnectionState.Closed)
            {
                conexion.Open();
            }
            return conexion;
        }

        // Método para cerrar la conexión
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