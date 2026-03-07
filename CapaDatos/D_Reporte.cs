using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class D_Reporte
    {
        private ConexionBD conexion = new ConexionBD();

        public DataTable RecaudacionPorRuta()
        {
            DataTable tabla = new DataTable();
            SqlCommand comando = new SqlCommand();
            SqlDataReader leer;

            comando.Connection = conexion.AbrirConexion();

            comando.CommandText = @"
                SELECT 
                    R.NombreRuta AS [Nombre de la Ruta],
                    COUNT(T.ID_Ticket) AS [Total Pasajeros],
                    SUM(T.MontoPagado) AS [Ingresos Totales RD$]
                FROM Ticket T
                INNER JOIN Viaje V ON T.ID_Viaje = V.ID_Viaje
                INNER JOIN Ruta R ON V.ID_Ruta = R.ID_Ruta
                GROUP BY R.NombreRuta";

            comando.CommandType = CommandType.Text;

            leer = comando.ExecuteReader();
            tabla.Load(leer);

            conexion.CerrarConexion();
            return tabla;
        }
    }
}