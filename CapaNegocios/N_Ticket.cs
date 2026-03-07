using System;
using CapaDatos;

namespace CapaNegocios
{
    public class N_Ticket
    {
        private D_Ticket objDatos = new D_Ticket();

        public void InsertarTicket(string idViaje, string montoPagado)
        {
            int viaje = Convert.ToInt32(idViaje);
            decimal monto = Convert.ToDecimal(montoPagado);

            DateTime horaActual = DateTime.Now;

            objDatos.Insertar(viaje, horaActual, monto);
        }
    }
}