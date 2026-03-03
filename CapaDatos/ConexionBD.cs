using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class ConexionBD
    {
        private readonly string cadenaConexion = "Server=.;Database=OMSA_Recaudacion;Integrated Security=True;";
        private SqlConnection conexion;
        public ConexionBD()
        {
            conexion = new SqlConnection(cadenaConexion);
        }
        public SqlConnection AbrirConexion()
        {
            if (conexion.State == ConnectionState.Closed)
            {
                conexion.Open();
            }
            return conexion;
        }
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