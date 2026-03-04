using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class D_Vehiculo
    {
        private ConexionBD conexion = new ConexionBD();
        public DataTable Mostrar()
        {
            DataTable tabla = new DataTable();
            SqlCommand comando = new SqlCommand();
            SqlDataReader leer;
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "SELECT * FROM Vehiculo";
            comando.CommandType = CommandType.Text;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }

        public void Insertar(string ficha, string placa, int capacidad)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "INSERT INTO Vehiculo (Ficha, Placa, Capacidad) VALUES (@Ficha, @Placa, @Capacidad)";
            comando.CommandType = CommandType.Text;
            comando.Parameters.AddWithValue("@Ficha", ficha);
            comando.Parameters.AddWithValue("@Placa", placa); // Cambiado aquí también
            comando.Parameters.AddWithValue("@Capacidad", capacidad);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }
    }
}