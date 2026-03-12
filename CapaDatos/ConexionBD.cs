using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CapaDatos
{
    public class ConexionBD
    {
        // Obtiene la cadena de conexión desde el archivo App.config
        private readonly string cadenaConexion = ConfigurationManager.ConnectionStrings["ConexionOMSA"].ConnectionString;

        private SqlConnection conexion;

        // Constructor para inicializar el objeto de conexión
        public ConexionBD()
        {
            conexion = new SqlConnection(cadenaConexion);
        }

        // Abre la conexión si se encuentra cerrada
        public SqlConnection AbrirConexion()
        {
            if (conexion.State == ConnectionState.Closed)
            {
                conexion.Open();
            }
            return conexion;
        }

        // Cierra la conexión si se encuentra abierta
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