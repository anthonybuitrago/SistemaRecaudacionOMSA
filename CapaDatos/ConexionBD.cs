using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CapaDatos
{
    // TODO: [REQUISITO] - Conexión a base de datos
    // Clase para gestionar el enlace con SQL Server
    public class ConexionBD
    {
        private readonly string cadenaConexion = ConfigurationManager.ConnectionStrings["ConexionOMSA"].ConnectionString;
        private SqlConnection conexion;

        public ConexionBD()
        {
            conexion = new SqlConnection(cadenaConexion);
        }

        // Abre el canal de datos
        public SqlConnection AbrirConexion()
        {
            if (conexion.State == ConnectionState.Closed)
            {
                conexion.Open();
            }
            return conexion;
        }

        // Cierra el canal de datos
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