using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace CapaDatos
{
    // TODO: [REQUISITO] - Comentarios correspondientes para interpretar el código
    // Se encarga de extraer y consolidar los datos para el módulo de reportes
    public class D_Reporte
    {
        private ConexionBD conexion = new ConexionBD();

        // Genera el reporte de ingresos cruzando ventas, rutas, choferes y vehículos
        public async Task<DataTable> RecaudacionPorRutaAsync()
        {
            DataTable tabla = new DataTable();

            try
            {
                using (SqlCommand comando = new SqlCommand())
                {
                    comando.Connection = conexion.AbrirConexion();

                    // Cruce relacional para agrupar la cantidad de pasajeros y sumar el dinero recaudado por ruta
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

                    using (SqlDataReader leer = await comando.ExecuteReaderAsync())
                    {
                        tabla.Load(leer);
                    }
                }
            }
            finally
            {
                conexion.CerrarConexion();
            }

            return tabla;
        }
    }
}