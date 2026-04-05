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
        public string Modelo { get; set; } // <-- NUEVO: Para completar la simetría 2x2
        public int Capacidad { get; set; }

        // Constructor para inicializar los datos del vehículo
        // Se añade el parámetro 'modelo'
        public Vehiculo(int id, string ficha, string placa, string modelo, int capacidad)
        {
            ID_Vehiculo = id;
            Ficha = ficha;
            Placa = placa;
            Modelo = modelo;
            Capacidad = capacidad;
        }
    }

    public class N_Vehiculo
    {
        // Conexión con la Capa de Datos
        private D_Vehiculo objDatos = new D_Vehiculo();

        // --- MÉTODOS BÁSICOS ASÍNCRONOS ---

        // Método para pedir la lista de vehículos registrados
        public async Task<DataTable> MostrarVehiculosAsync()
        {
            return await objDatos.MostrarAsync();
        }

        // Método para procesar y guardar un nuevo vehículo (Ahora recibe 4 parámetros de texto)
        public async Task InsertarVehiculoAsync(string ficha, string placa, string modelo, string capacidad)
        {
            // Convertimos la capacidad de texto a número entero
            int cap = Convert.ToInt32(capacidad);

            // Instanciamos el objeto Vehiculo con el nuevo campo Modelo
            Vehiculo nuevoVehiculo = new Vehiculo(0, ficha, placa, modelo, cap);

            // Mandamos los 4 datos a la Capa de Datos (D_Vehiculo ahora espera 4 parámetros)
            await objDatos.InsertarAsync(nuevoVehiculo.Ficha, nuevoVehiculo.Placa, nuevoVehiculo.Modelo, nuevoVehiculo.Capacidad);
        }

        // Puente para enviar los datos editados incluyendo el Modelo (Recibe 5 parámetros)
        public async Task EditarVehiculoAsync(int id, string ficha, string placa, string modelo, string capacidad)
        {
            int cap = Convert.ToInt32(capacidad);
            await objDatos.EditarAsync(id, ficha, placa, modelo, cap);
        }

        // Puente para enviar la orden de eliminar (Borrado Lógico) a la Capa de Datos
        public async Task EliminarVehiculoAsync(int id)
        {
            await objDatos.EliminarAsync(id);
        }

        // MÉTODO EXTRA: Puente para verificar si la ficha ya existe antes de guardar
        public async Task<bool> VerificarFichaExiste(string ficha)
        {
            return await objDatos.ExisteFichaAsync(ficha);
        }
    }
}