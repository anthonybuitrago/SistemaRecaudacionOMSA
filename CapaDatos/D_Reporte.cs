using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class D_Reporte
    {
        // Instancia para establecer la comunicación con el servidor SQL
        private ConexionBD conexion = new ConexionBD();

        // Método para generar el reporte de ingresos cruzando múltiples tablas
        public DataTable RecaudacionPorRuta()
        {
            DataTable tabla = new DataTable();
            SqlCommand comando = new SqlCommand();
            SqlDataReader leer;

            // Abrimos el canal de comunicación con la base de datos
            comando.Connection = conexion.AbrirConexion();

            // Consulta relacional: Cruza las ventas con rutas, choferes y vehículos para agrupar totales y mostrar nombres reales en lugar de números (IDs)
            comando.CommandText = @"
    SELECT 
        R.NombreRuta AS [Ruta],
        C.NombreCompleto AS [Chofer],
        Ve.Ficha AS [Vehículo],
        COUNT(T.ID_Ticket) AS [Pasajeros],
        SUM(T.MontoPagado) AS [Total Recaudado RD$]
    FROM Ticket T
    INNER JOIN Viaje V ON T.ID_Viaje = V.ID_Viaje
    INNER JOIN Ruta R ON V.ID_Ruta = R.ID_Ruta
    INNER JOIN Chofer C ON V.ID_Chofer = C.ID_Chofer
    INNER JOIN Vehiculo Ve ON V.ID_Vehiculo = Ve.ID_Vehiculo
    GROUP BY R.NombreRuta, C.NombreCompleto, Ve.Ficha";

            comando.CommandType = CommandType.Text;

            // Ejecutamos la consulta en el servidor y volcamos los resultados estructurados en la tabla
            leer = comando.ExecuteReader();
            tabla.Load(leer);

            // Cerramos la comunicación de forma segura
            conexion.CerrarConexion();
            return tabla;
        }
    }
}