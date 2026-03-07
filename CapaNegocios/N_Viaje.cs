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
            int chofer = Convert.ToInt32(idChofer);
            int ruta = Convert.ToInt32(idRuta);
            int vehiculo = Convert.ToInt32(idVehiculo);

            objDatos.Insertar(chofer, ruta, vehiculo, fecha, estado);
        }
    }
}