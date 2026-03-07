using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class D_Ticket
    {
        private ConexionBD conexion = new ConexionBD();

        public void Insertar(int idViaje, DateTime horaEmision, decimal montoPagado)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion();

            comando.CommandText = "INSERT INTO Ticket (ID_Viaje, HoraEmision, MontoPagado) VALUES (@ID_Viaje, @HoraEmision, @MontoPagado)";
            comando.CommandType = CommandType.Text;

            comando.Parameters.AddWithValue("@ID_Viaje", idViaje);
            comando.Parameters.AddWithValue("@HoraEmision", horaEmision);
            comando.Parameters.AddWithValue("@MontoPagado", montoPagado);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

            conexion.CerrarConexion();
        }
    }
}