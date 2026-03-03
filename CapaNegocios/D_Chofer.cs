using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class D_Chofer
    {
        private ConexionBD conexion = new ConexionBD();
        public DataTable Mostrar()
        {
            DataTable tabla = new DataTable();
            SqlCommand comando = new SqlCommand();
            SqlDataReader leer;

            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "SELECT * FROM Chofer";
            comando.CommandType = CommandType.Text;

            leer = comando.ExecuteReader();
            tabla.Load(leer);

            conexion.CerrarConexion();
            return tabla;
        }
        public void Insertar(string cedula, string nombreCompleto, string numeroLicencia)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion();

            comando.CommandText = "INSERT INTO Chofer (Cedula, NombreCompleto, NumeroLicencia) VALUES (@Cedula, @Nombre, @Licencia)";
            comando.CommandType = CommandType.Text;

            comando.Parameters.AddWithValue("@Cedula", cedula);
            comando.Parameters.AddWithValue("@Nombre", nombreCompleto);
            comando.Parameters.AddWithValue("@Licencia", numeroLicencia);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

            conexion.CerrarConexion();
        }
    }
}