using System;
using System.Data;
using CapaDatos;

namespace CapaNegocios
{
    public class Vehiculo
    {
        // Propiedades del vehículo de transporte
        public int ID_Vehiculo { get; set; }
        public string Ficha { get; set; }
        public string Placa { get; set; }
        public int Capacidad { get; set; }

        // Constructor para inicializar los datos del vehículo
        public Vehiculo(int id, string ficha, string placa, int capacidad)
        {
            ID_Vehiculo = id;
            Ficha = ficha;
            Placa = placa;
            Capacidad = capacidad;
        }
    }

    public class N_Vehiculo
    {
        // Conexión con la Capa de Datos
        private D_Vehiculo objDatos = new D_Vehiculo();

        // Método para pedir la lista de vehículos registrados
        public DataTable MostrarVehiculos()
        {
            return objDatos.Mostrar();
        }

        // Método para procesar y guardar un nuevo vehículo
        public void InsertarVehiculo(string ficha, string placa, string capacidad)
        {
            // Convertimos la capacidad de texto a número entero
            int cap = Convert.ToInt32(capacidad);

            // Instanciamos el objeto Vehiculo para que el constructor sea utilizado
            Vehiculo nuevoVehiculo = new Vehiculo(0, ficha, placa, cap);

            // Mandamos los datos del objeto a la Capa de Datos
            objDatos.Insertar(nuevoVehiculo.Ficha, nuevoVehiculo.Placa, nuevoVehiculo.Capacidad);
        }

        // Puente para enviar los datos editados a la Capa de Datos
        public void EditarVehiculo(int id, string ficha, string placa, string capacidad)
        {
            objDatos.Editar(id, ficha, placa, Convert.ToInt32(capacidad));
        }

        // Puente para enviar la orden de eliminar a la Capa de Datos
        public void EliminarVehiculo(int id)
        {
            objDatos.Eliminar(id);
        }
    }
}