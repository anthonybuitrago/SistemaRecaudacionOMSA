using System;
using System.Data;
using CapaDatos;

namespace CapaNegocios
{
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

        // Método para pedir la lista completa de viajes
        public DataTable MostrarViajes()
        {
            return objDatos.Mostrar();
        }

        // Método para enviar un nuevo viaje a guardar
        public void InsertarViaje(string idChofer, string idRuta, string idVehiculo, DateTime fecha, string estado)
        {
            // Convertimos los identificadores de texto a números enteros
            int choferId = Convert.ToInt32(idChofer);
            int rutaId = Convert.ToInt32(idRuta);
            int vehiculoId = Convert.ToInt32(idVehiculo);

            // Instanciamos el objeto Viaje
            Viaje nuevoViaje = new Viaje(0, choferId, rutaId, vehiculoId, fecha, estado);

            // Mandamos los datos a la Capa de Datos
            objDatos.Insertar(
                nuevoViaje.ID_Chofer,
                nuevoViaje.ID_Ruta,
                nuevoViaje.ID_Vehiculo,
                nuevoViaje.FechaViaje,
                nuevoViaje.Estado
            );
        }

        // Método para pedir los viajes disponibles y mostrarlos en selectores (ComboBox)
        public DataTable MostrarViajesCombo()
        {
            return objDatos.MostrarParaCombo();
        }

        // Puente para enviar la orden de cancelar un viaje a la Capa de Datos
        public void CancelarViaje(string idViaje)
        {
            objDatos.Cancelar(Convert.ToInt32(idViaje));
        }

        // Puente para enviar los datos editados a la Capa de Datos
        public void EditarViaje(string idViaje, string idChofer, string idRuta, string idVehiculo, DateTime fecha, string estado)
        {
            // Convertimos los identificadores de texto a números enteros
            int viajeId = Convert.ToInt32(idViaje);
            int choferId = Convert.ToInt32(idChofer);
            int rutaId = Convert.ToInt32(idRuta);
            int vehiculoId = Convert.ToInt32(idVehiculo);

            objDatos.Editar(viajeId, choferId, rutaId, vehiculoId, fecha, estado);
        }
    }
}