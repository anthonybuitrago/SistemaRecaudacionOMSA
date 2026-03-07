using System;

namespace CapaNegocios
{
    public class Viaje
    {
        // Propiedades que conectan con Chofer, Ruta y Vehículo
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
}