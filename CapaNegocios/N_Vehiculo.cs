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

        public void InsertarVehiculo(string ficha, string placa, string capacidad)
        {
            // Convertimos la capacidad a entero antes de mandarlo a la Capa D
            objDatos.Insertar(ficha, placa, Convert.ToInt32(capacidad));
        }

        public void EditarVehiculo(int id, string ficha, string placa, string capacidad)
        {
            objDatos.Editar(id, ficha, placa, Convert.ToInt32(capacidad));
        }

        // Asegúrate de que este sea el nombre exacto en N_Vehiculo.cs
        public void EliminarVehiculo(int id)
        {
            objDatos.Eliminar(id); // Llama al método de la Capa de Datos
        }
    }
}