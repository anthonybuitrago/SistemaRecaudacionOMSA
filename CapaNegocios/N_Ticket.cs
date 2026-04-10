using System;
using System.Data;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocios
{
    // Entidad de dominio que representa un boleto emitido a un pasajero
    public class Ticket
    {
        public int ID_Ticket { get; set; }
        public int ID_Viaje { get; set; }
        public DateTime HoraEmision { get; set; }
        public decimal MontoPagado { get; set; }

        // Constructor para la inicialización estructurada de la entidad transaccional
        public Ticket(int id, int viaje, DateTime hora, decimal monto)
        {
            ID_Ticket = id;
            ID_Viaje = viaje;
            HoraEmision = hora;
            MontoPagado = monto;
        }
    }

    // TODO: [REQUISITO] - Arquitectura en Capas: Separación de la lógica de negocio de la persistencia de datos.

    // Reglas de negocio y orquestación para la emisión y venta de boletos
    public class N_Ticket
    {
        // Enlace de comunicación con la capa de persistencia de datos
        private D_Ticket objDatos = new D_Ticket();

        // ==========================================================
        // CONSULTAS DE DATOS
        // ==========================================================

        // Recupera el registro histórico de operaciones de venta
        public async Task<DataTable> MostrarTicketsAsync()
        {
            try
            {
                return await objDatos.MostrarAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar el historial de ventas: " + ex.Message);
            }
        }

        // Recupera la cartelera de viajes disponibles para asignación
        public async Task<DataTable> MostrarViajesActivosAsync()
        {
            try
            {
                return await objDatos.MostrarViajesActivosParaVentaAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cargar la cartelera de viajes: " + ex.Message);
            }
        }

        // ==========================================================
        // TRANSACCIONES FINANCIERAS
        // ==========================================================

        // Procesa la transacción financiera y emite los boletos solicitados
        public async Task VenderTicketsAsync(string idViaje, string tarifaPorTicket, string cantidadTickets)
        {
            try
            {
                // Validación de integridad de los datos de entrada
                if (string.IsNullOrWhiteSpace(idViaje) || string.IsNullOrWhiteSpace(tarifaPorTicket) || string.IsNullOrWhiteSpace(cantidadTickets))
                {
                    throw new Exception("Debe seleccionar un viaje e indicar la cantidad a vender.");
                }

                // Conversión de tipos para procesamiento numérico
                int viajeId = Convert.ToInt32(idViaje);
                decimal tarifa = Convert.ToDecimal(tarifaPorTicket);
                int cantidad = Convert.ToInt32(cantidadTickets);

                // Reglas de negocio financieras
                if (tarifa <= 0)
                {
                    throw new Exception("La tarifa del pasaje debe ser mayor a cero.");
                }

                if (cantidad <= 0)
                {
                    throw new Exception("Debe vender al menos 1 ticket.");
                }

                DateTime fechaActual = DateTime.Now;

                // Generación de un registro de base de datos individual por cada ticket solicitado
                for (int i = 0; i < cantidad; i++)
                {
                    Ticket nuevoTicket = new Ticket(0, viajeId, fechaActual, tarifa);
                    await objDatos.InsertarAsync(nuevoTicket.ID_Viaje, nuevoTicket.HoraEmision, nuevoTicket.MontoPagado);
                }
            }
            catch (FormatException)
            {
                throw new Exception("Error de formato: Asegúrese de que la tarifa y cantidad sean números válidos.");
            }
            catch (Exception ex)
            {
                throw new Exception("Error al registrar la transacción de venta: " + ex.Message);
            }
        }
    }
}