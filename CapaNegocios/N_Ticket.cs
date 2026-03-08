using System;
using System.Data;
using CapaDatos;

namespace CapaNegocios
{
    public class N_Ticket
    {
        // Conexión con la Capa de Datos (Tickets)
        private D_Ticket objDatos = new D_Ticket();

        // Método que llama a la Capa de Datos
        public DataTable MostrarTickets()
        {
            return objDatos.Mostrar();
        }

        // Método para procesar y guardar un ticket
        public void InsertarTicket(string idViaje, string montoPagado)
        {
            // 1. Preparar datos
            int viajeId = Convert.ToInt32(idViaje);
            decimal monto = Convert.ToDecimal(montoPagado);
            DateTime fechaActual = DateTime.Now;

            // 2. Crear el objeto Ticket (Referencia +1)
            Ticket nuevoTicket = new Ticket(0, viajeId, fechaActual, monto);

            // 3. Usar el objeto para enviar a la base de datos
            objDatos.Insertar(nuevoTicket.ID_Viaje, nuevoTicket.HoraEmision, nuevoTicket.MontoPagado);
        }
    }
}