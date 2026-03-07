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
            // 1. Conversión de datos
            int capacidad = Convert.ToInt32(capacidadTexto);

            // 2. Creación del objeto de negocio (Genera la referencia)
            Vehiculo nuevoVehiculo = new Vehiculo(0, ficha, placa, capacidad);

            // 3. Envío de las propiedades del objeto a la Capa de Datos
            objDatos.Insertar(nuevoVehiculo.Ficha, nuevoVehiculo.Placa, nuevoVehiculo.Capacidad);
        }
    }
}