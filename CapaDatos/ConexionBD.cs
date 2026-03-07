using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class ConexionBD
    {
        // Ruta de acceso a SQL Server
        private readonly string cadenaConexion = "Server=.;Database=OMSA_Recaudacion;Integrated Security=True;";
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