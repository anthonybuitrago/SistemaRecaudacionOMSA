using System;
using System.Data;
using System.Threading.Tasks; // Obligatorio para el asincronismo
using CapaDatos;

namespace CapaNegocios
{
    // TODO: Requisito - Creación de Entidad/Clase
    public class Viaje
    {
        // Propiedades que enlazan el viaje con su chofer, ruta y vehículo
        public int ID_Viaje { get; set; }
        public int ID_Chofer { get; set; }
        public int ID_Ruta { get; set; }
        public int ID_Vehiculo { get; set; }
        public DateTime FechaViaje { get; set; }
        public string Estado { get; set; }

        // Constructor
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

    public class N_Viaje
    {
        // Conexión con la Capa de Datos
        private D_Viaje objDatos = new D_Viaje();

        // --- MÉTODOS BÁSICOS ASÍNCRONOS (Solo para que compile el proyecto) ---
        // Nota: Faltan las validaciones y try/catch que hará tu compañero.

        // Método para pedir la lista completa de viajes
        public async Task<DataTable> MostrarViajesAsync()
        {
            return await objDatos.MostrarAsync();
        }

        // Método para enviar un nuevo viaje a guardar
        public async Task InsertarViajeAsync(string idChofer, string idRuta, string idVehiculo, DateTime fecha, string estado)
        {
            // Convertimos los identificadores de texto a números enteros
            int choferId = Convert.ToInt32(idChofer);
            int rutaId = Convert.ToInt32(idRuta);
            int vehiculoId = Convert.ToInt32(idVehiculo);

            // Instanciamos el objeto Viaje
            Viaje nuevoViaje = new Viaje(0, choferId, rutaId, vehiculoId, fecha, estado);

            // Mandamos los datos a la Capa de Datos de forma asíncrona
            await objDatos.InsertarAsync(
                nuevoViaje.ID_Chofer,
                nuevoViaje.ID_Ruta,
                nuevoViaje.ID_Vehiculo,
                nuevoViaje.FechaViaje,
                nuevoViaje.Estado
            );
        }

        // Método para pedir los viajes disponibles y mostrarlos en selectores (ComboBox)
        public async Task<DataTable> MostrarViajesComboAsync()
        {
            return await objDatos.MostrarParaComboAsync();
        }

        // Puente para enviar la orden de cancelar un viaje a la Capa de Datos
        public async Task CancelarViajeAsync(string idViaje)
        {
            await objDatos.CancelarAsync(Convert.ToInt32(idViaje));
        }

        // Puente para enviar los datos editados a la Capa de Datos
        public async Task EditarViajeAsync(string idViaje, string idChofer, string idRuta, string idVehiculo, DateTime fecha, string estado)
        {
            // Convertimos los identificadores de texto a números enteros
            int viajeId = Convert.ToInt32(idViaje);
            int choferId = Convert.ToInt32(idChofer);
            int rutaId = Convert.ToInt32(idRuta);
            int vehiculoId = Convert.ToInt32(idVehiculo);

            await objDatos.EditarAsync(viajeId, choferId, rutaId, vehiculoId, fecha, estado);
        }
    }
}