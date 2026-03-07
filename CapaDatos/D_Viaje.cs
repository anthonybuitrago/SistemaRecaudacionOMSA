using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class D_Viaje
    {
        private ConexionBD conexion = new ConexionBD();
        public DataTable Mostrar()
        {
            DataTable tabla = new DataTable();
            SqlCommand comando = new SqlCommand();
            SqlDataReader leer;
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "SELECT * FROM Viaje";
            comando.CommandType = CommandType.Text;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }
        public void Insertar(int idChofer, int idRuta, int idVehiculo, DateTime fecha, string estado)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion();

            comando.CommandText = "INSERT INTO Viaje (ID_Chofer, ID_Ruta, ID_Vehiculo, FechaViaje, Estado) VALUES (@ID_Chofer, @ID_Ruta, @ID_Vehiculo, @Fecha, @Estado)";
            comando.CommandType = CommandType.Text;

            comando.Parameters.AddWithValue("@ID_Chofer", idChofer);
            comando.Parameters.AddWithValue("@ID_Ruta", idRuta);
            comando.Parameters.AddWithValue("@ID_Vehiculo", idVehiculo);
            comando.Parameters.AddWithValue("@Fecha", fecha);
            comando.Parameters.AddWithValue("@Estado", estado);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

            conexion.CerrarConexion();
        }
    }
}