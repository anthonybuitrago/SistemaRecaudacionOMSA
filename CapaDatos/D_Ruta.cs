using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class D_Ruta
    {
        private ConexionBD conexion = new ConexionBD();
        public DataTable Mostrar()
        {
            DataTable tabla = new DataTable();
            SqlCommand comando = new SqlCommand();
            SqlDataReader leer;

            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "SELECT * FROM Ruta";
            comando.CommandType = CommandType.Text;

            leer = comando.ExecuteReader();
            tabla.Load(leer);

            conexion.CerrarConexion();
            return tabla;
        }
        public void Insertar(string nombreRuta, string tarifaPasaje)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "INSERT INTO Ruta (NombreRuta, TarifaPasaje) VALUES (@NombreRuta, @TarifaPasaje)";
            comando.CommandType = CommandType.Text;
            comando.Parameters.AddWithValue("@NombreRuta", nombreRuta);
            comando.Parameters.AddWithValue("@TarifaPasaje", tarifaPasaje);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }
    }
}