using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class D_Reporte
    {
        // Conexión a la base de datos
        private ConexionBD conexion = new ConexionBD();

        // Método para obtener el dinero ganado por ruta
        public DataTable RecaudacionPorRuta()
        {
            DataTable tabla = new DataTable();
            SqlCommand comando = new SqlCommand();
            SqlDataReader leer;

            // Abrir la conexión
            comando.Connection = conexion.AbrirConexion();

            // Consulta SQL para sumar tickets y contar pasajeros
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

            // Ejecutar la consulta y cargar los datos
            leer = comando.ExecuteReader();
            tabla.Load(leer);

            // Cerrar conexión y devolver resultados
            conexion.CerrarConexion();
            return tabla;
        }
    }
}