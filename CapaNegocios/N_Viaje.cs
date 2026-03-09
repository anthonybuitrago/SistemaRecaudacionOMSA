using System;
using System.Data;
using CapaDatos;

namespace CapaNegocios
{
    public class N_Viaje
    {
        private D_Viaje objDatos = new D_Viaje();

        public DataTable MostrarViajes()
        {
            return objDatos.Mostrar();
        }

        public void InsertarViaje(string idChofer, string idRuta, string idVehiculo, DateTime fecha, string estado)
        {
            // 1. Conversión de IDs a enteros
            int choferId = Convert.ToInt32(idChofer);
            int rutaId = Convert.ToInt32(idRuta);
            int vehiculoId = Convert.ToInt32(idVehiculo);

            // 2. Creación del objeto Viaje (Genera la referencia)
            Viaje nuevoViaje = new Viaje(0, choferId, rutaId, vehiculoId, fecha, estado);

            // 3. Envío de datos estructurados a la Capa de Datos
            objDatos.Insertar(
                nuevoViaje.ID_Chofer,
                nuevoViaje.ID_Ruta,
                nuevoViaje.ID_Vehiculo,
                nuevoViaje.FechaViaje,
                nuevoViaje.Estado
            );
        }

        public DataTable MostrarViajesCombo()
        {
            return objDatos.MostrarParaCombo();
        }
    }
}