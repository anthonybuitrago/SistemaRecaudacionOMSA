using System;
using System.Data;
using System.Threading.Tasks; // Obligatorio para el asincronismo
using CapaDatos;

namespace CapaNegocios
{
    // TODO: Requisito - Creación de Entidad/Clase
    public class Ticket
    {
        // Propiedades del boleto vendido
        public int ID_Ticket { get; set; }
        public int ID_Viaje { get; set; }
        public DateTime HoraEmision { get; set; }
        public decimal MontoPagado { get; set; }

        // Constructor
        public Ticket(int id, int viaje, DateTime hora, decimal monto)
        {
            ID_Ticket = id;
            ID_Viaje = viaje;
            HoraEmision = hora;
            MontoPagado = monto;
        }
    }

    public class N_Ticket
    {
        // Conexión con la Capa de Datos
        private D_Ticket objDatos = new D_Ticket();

        // TODO: Requisito - Llamada Asíncrona (Async/Await) en Capa de Negocios
        // Método para pedir la lista de tickets vendidos de forma asíncrona
        public async Task<DataTable> MostrarTicketsAsync()
        {
            try
            {
                return await objDatos.MostrarAsync();
            }
            catch (Exception ex)
            {
                // TODO: Requisito - Manejo de excepciones (Try/Catch)
                throw new Exception("Error al intentar mostrar los tickets: " + ex.Message);
            }
        }

        // NUEVO MÉTODO: Para llenar el ComboBox inteligente con solo viajes "Activos"
        public async Task<DataTable> MostrarViajesActivosAsync()
        {
            try
            {
                return await objDatos.MostrarViajesActivosParaVentaAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cargar los viajes disponibles: " + ex.Message);
            }
        }

        // MODIFICADO: Procesa la venta basada en CANTIDAD
        public async Task VenderTicketsAsync(string idViaje, string tarifaPorTicket, string cantidadTickets)
        {
            try
            {
                // 1. Validaciones básicas
                if (string.IsNullOrWhiteSpace(idViaje) || string.IsNullOrWhiteSpace(tarifaPorTicket) || string.IsNullOrWhiteSpace(cantidadTickets))
                {
                    throw new Exception("Debe seleccionar un viaje, tarifa y cantidad de tickets.");
                }

                // 2. Conversiones
                int viajeId = Convert.ToInt32(idViaje);
                decimal tarifa = Convert.ToDecimal(tarifaPorTicket);
                int cantidad = Convert.ToInt32(cantidadTickets);

                // 3. Reglas de negocio restrictivas
                if (tarifa <= 0) throw new Exception("La tarifa del pasaje debe ser mayor a cero.");
                if (cantidad <= 0) throw new Exception("Debe vender al menos 1 ticket.");

                DateTime fechaActual = DateTime.Now;

                // 4. El Ciclo de Venta (El "Truco" del Punto de Venta)
                // Si el cliente pide 4 tickets, guardamos 4 registros individuales para que la auditoría cuadre
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
                throw new Exception("Error al registrar la venta: " + ex.Message);
            }
        }
    }
}