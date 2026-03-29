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
                // Llamamos al método asíncrono de la capa de datos
                return await objDatos.MostrarAsync();
            }
            catch (Exception ex)
            {
                // TODO: Requisito - Manejo de excepciones (Try/Catch)
                throw new Exception("Error al intentar mostrar los tickets: " + ex.Message);
            }
        }

        // Método para procesar y guardar un nuevo ticket de forma asíncrona
        public async Task InsertarTicketAsync(string idViaje, string montoPagado)
        {
            try
            {
                // 1. Validaciones de negocio básicas (Que no envíen campos vacíos)
                if (string.IsNullOrWhiteSpace(idViaje) || string.IsNullOrWhiteSpace(montoPagado))
                {
                    throw new Exception("Debe seleccionar un viaje y especificar el monto pagado.");
                }

                // 2. Convertimos los textos recibidos a sus tipos de datos correctos
                int viajeId = Convert.ToInt32(idViaje);
                decimal monto = Convert.ToDecimal(montoPagado);

                // 3. Regla de negocio: El monto no puede ser negativo ni cero
                if (monto <= 0)
                {
                    throw new Exception("El monto pagado debe ser mayor a cero.");
                }

                DateTime fechaActual = DateTime.Now;

                // 4. Instanciamos el objeto Ticket usando la fecha y hora actuales
                Ticket nuevoTicket = new Ticket(0, viajeId, fechaActual, monto);

                // 5. Mandamos los datos a la Capa de Datos esperando (await) a que termine
                await objDatos.InsertarAsync(nuevoTicket.ID_Viaje, nuevoTicket.HoraEmision, nuevoTicket.MontoPagado);
            }
            catch (FormatException)
            {
                // Este catch específico atrapa el error si el usuario escribe letras en lugar de números
                throw new Exception("Por favor, ingrese valores numéricos válidos. No se permiten letras.");
            }
            catch (Exception ex)
            {
                // Este atrapa cualquier otro error general (como pérdida de conexión)
                throw new Exception("Error al guardar el ticket: " + ex.Message);
            }
        }
    }
}