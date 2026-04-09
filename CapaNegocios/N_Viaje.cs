using System;
using System.Data;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocios
{
    // Entidad que representa la programación de un viaje
    public class Viaje
    {
        public int ID_Viaje { get; set; }
        public int ID_Chofer { get; set; }
        public int ID_Ruta { get; set; }
        public int ID_Vehiculo { get; set; }
        public DateTime FechaViaje { get; set; }
        public string Estado { get; set; }

        public Viaje(int id, int chofer, int ruta, int vehiculo, DateTime fecha, string estado)
        {
            ID_Viaje = id;
            ID_Chofer = chofer;
            ID_Ruta = ruta;
            ID_Vehiculo = vehiculo;
            FechaViaje = fecha;
            Estado = estado;
        }
    }

    // Gestiona la lógica y reglas de negocio para la programación de viajes
    public class N_Viaje
    {
        private D_Viaje objDatos = new D_Viaje();

        public async Task<DataTable> MostrarViajesAsync()
        {
            return await objDatos.MostrarAsync();
        }

        // Obtiene la lista de viajes formateada para el selector de la pantalla de ventas
        public async Task<DataTable> MostrarViajesComboAsync()
        {
            return await objDatos.MostrarParaComboAsync();
        }

        // Valida las reglas de negocio y envía a guardar un nuevo viaje
        public async Task InsertarViajeAsync(string idChofer, string idRuta, string idVehiculo, DateTime fecha, string estado)
        {
            // Validaciones (Reglas de Negocio)
            if (string.IsNullOrWhiteSpace(idChofer) || string.IsNullOrWhiteSpace(idRuta) || string.IsNullOrWhiteSpace(idVehiculo))
            {
                throw new Exception("Debe seleccionar un chofer, una ruta y un vehículo para programar el viaje.");
            }

            if (fecha < DateTime.Now.Date)
            {
                throw new Exception("No se puede programar un viaje con una fecha anterior a la actual.");
            }

            int choferId = Convert.ToInt32(idChofer);
            int rutaId = Convert.ToInt32(idRuta);
            int vehiculoId = Convert.ToInt32(idVehiculo);

            Viaje nuevoViaje = new Viaje(0, choferId, rutaId, vehiculoId, fecha, estado);

            await objDatos.InsertarAsync(
                nuevoViaje.ID_Chofer,
                nuevoViaje.ID_Ruta,
                nuevoViaje.ID_Vehiculo,
                nuevoViaje.FechaViaje,
                nuevoViaje.Estado
            );
        }

        // Valida y envía la modificación de un viaje existente
        public async Task EditarViajeAsync(string idViaje, string idChofer, string idRuta, string idVehiculo, DateTime fecha, string estado)
        {
            if (string.IsNullOrWhiteSpace(idChofer) || string.IsNullOrWhiteSpace(idRuta) || string.IsNullOrWhiteSpace(idVehiculo))
            {
                throw new Exception("Los datos del viaje no pueden quedar vacíos.");
            }

            int viajeId = Convert.ToInt32(idViaje);
            int choferId = Convert.ToInt32(idChofer);
            int rutaId = Convert.ToInt32(idRuta);
            int vehiculoId = Convert.ToInt32(idVehiculo);

            await objDatos.EditarAsync(viajeId, choferId, rutaId, vehiculoId, fecha, estado);
        }

        // Cambia el estado del viaje a 'Cancelado'
        public async Task CancelarViajeAsync(string idViaje)
        {
            if (string.IsNullOrWhiteSpace(idViaje))
            {
                throw new Exception("ID de viaje inválido para cancelar.");
            }
            await objDatos.CancelarAsync(Convert.ToInt32(idViaje));
        }
    }
}