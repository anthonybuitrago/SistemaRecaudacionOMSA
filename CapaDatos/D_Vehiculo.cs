using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos // Ajusta según tu namespace
{
    public class D_Vehiculo
    {
        private ConexionBD conexion = new ConexionBD();

        // Reemplaza el contenido de tu clase D_Vehiculo con esto:
        public DataTable Mostrar()
        {
            SqlCommand comando = new SqlCommand("SELECT * FROM Vehiculo", conexion.AbrirConexion());
            DataTable tabla = new DataTable();
            tabla.Load(comando.ExecuteReader());
            conexion.CerrarConexion();
            return tabla;
        }

        public void Insertar(string ficha, string placa, int capacidad)
        {
            SqlCommand comando = new SqlCommand("INSERT INTO Vehiculo (Ficha, Placa, Capacidad) VALUES (@ficha, @placa, @capacidad)", conexion.AbrirConexion());
            comando.Parameters.AddWithValue("@ficha", ficha);
            comando.Parameters.AddWithValue("@placa", placa);
            comando.Parameters.AddWithValue("@capacidad", capacidad);
            comando.ExecuteNonQuery();
            conexion.CerrarConexion();
        }

        public void Editar(int id, string ficha, string placa, int capacidad)
        {
            SqlCommand comando = new SqlCommand("UPDATE Vehiculo SET Ficha=@ficha, Placa=@placa, Capacidad=@capacidad WHERE ID_Vehiculo=@id", conexion.AbrirConexion());
            comando.Parameters.AddWithValue("@id", id);
            comando.Parameters.AddWithValue("@ficha", ficha);
            comando.Parameters.AddWithValue("@placa", placa);
            comando.Parameters.AddWithValue("@capacidad", capacidad);
            comando.ExecuteNonQuery();
            conexion.CerrarConexion();
        }

        public void Eliminar(int id)
        {
            SqlCommand comando = new SqlCommand("DELETE FROM Vehiculo WHERE ID_Vehiculo=@id", conexion.AbrirConexion());
            comando.Parameters.AddWithValue("@id", id);
            comando.ExecuteNonQuery();
            conexion.CerrarConexion();
        }
    }
}