using System;
using System.Data;
using CapaDatos;

namespace CapaNegocios
{
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

        // Método para pedir la lista de tickets vendidos
        public DataTable MostrarTickets()
        {
            return objDatos.Mostrar();
        }

        // Método para procesar y guardar un nuevo ticket
        public void InsertarTicket(string idViaje, string montoPagado)
        {
            // Convertimos los textos recibidos a sus tipos de datos correctos
            int viajeId = Convert.ToInt32(idViaje);
            decimal monto = Convert.ToDecimal(montoPagado);
            DateTime fechaActual = DateTime.Now;

            // Instanciamos el objeto Ticket usando la fecha y hora actuales
            Ticket nuevoTicket = new Ticket(0, viajeId, fechaActual, monto);

            // Mandamos los datos a la Capa de Datos
            objDatos.Insertar(nuevoTicket.ID_Viaje, nuevoTicket.HoraEmision, nuevoTicket.MontoPagado);
        }
    }
}