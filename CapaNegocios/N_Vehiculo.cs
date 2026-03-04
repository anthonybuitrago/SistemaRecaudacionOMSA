using System;
using System.Data;
using CapaDatos;

namespace CapaNegocios
{
    public class N_Vehiculo
    {
        private D_Vehiculo objDatos = new D_Vehiculo();
        public DataTable MostrarVehiculos()
        {
            return objDatos.Mostrar();
        }
        public void InsertarVehiculo(string ficha, string placa, string capacidadTexto)
        {
            int capacidad = Convert.ToInt32(capacidadTexto);
            objDatos.Insertar(ficha, placa, capacidad);
        }
    }
}