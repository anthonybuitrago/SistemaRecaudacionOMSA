using System;
using System.Data;
using System.Threading.Tasks; // Obligatorio para el asincronismo
using CapaDatos;

namespace CapaNegocios
{
    // TODO: Requisito - Creación de Entidad/Clase
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

        // --- MÉTODOS BÁSICOS ASÍNCRONOS (Solo para que compile el proyecto) ---
        // Nota: Faltan las validaciones y try/catch que hará tu compañero.

        // Método para pedir la lista de vehículos registrados
        public async Task<DataTable> MostrarVehiculosAsync()
        {
            return await objDatos.MostrarAsync();
        }

        // Método para procesar y guardar un nuevo vehículo
        public async Task InsertarVehiculoAsync(string ficha, string placa, string capacidad)
        {
            // Convertimos la capacidad de texto a número entero
            int cap = Convert.ToInt32(capacidad);

            // Instanciamos el objeto Vehiculo para que el constructor sea utilizado
            Vehiculo nuevoVehiculo = new Vehiculo(0, ficha, placa, cap);

            // Mandamos los datos del objeto a la Capa de Datos de forma asíncrona
            await objDatos.InsertarAsync(nuevoVehiculo.Ficha, nuevoVehiculo.Placa, nuevoVehiculo.Capacidad);
        }

        // Puente para enviar los datos editados a la Capa de Datos
        public async Task EditarVehiculoAsync(int id, string ficha, string placa, string capacidad)
        {
            await objDatos.EditarAsync(id, ficha, placa, Convert.ToInt32(capacidad));
        }

        // Puente para enviar la orden de eliminar a la Capa de Datos
        public async Task EliminarVehiculoAsync(int id)
        {
            await objDatos.EliminarAsync(id);
        }
    }
}