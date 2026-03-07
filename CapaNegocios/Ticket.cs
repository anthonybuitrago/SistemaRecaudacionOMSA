using System;

namespace CapaNegocios
{
    public class Ticket
    {
        // Propiedades del boleto
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
}