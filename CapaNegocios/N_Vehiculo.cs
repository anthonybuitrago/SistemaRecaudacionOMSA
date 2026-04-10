using System;
using System.Data;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocios
{
    // Entidad de dominio que representa una unidad de transporte operativo
    public class Vehiculo
    {
        public int ID_Vehiculo { get; set; }
        public string Ficha { get; set; }
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public int Capacidad { get; set; }

        // Constructor para la inicialización estructurada de la entidad
        public Vehiculo(int id, string ficha, string placa, string modelo, int capacidad)
        {
            ID_Vehiculo = id;
            Ficha = ficha;
            Placa = placa;
            Modelo = modelo;
            Capacidad = capacidad;
        }
    }

    // Reglas de negocio y orquestación de operaciones para el inventario de vehículos
    public class N_Vehiculo
    {
        // Enlace de comunicación con la capa de persistencia de datos
        private D_Vehiculo objDatos = new D_Vehiculo();

        // Recupera el catálogo completo de vehículos registrados
        public async Task<DataTable> MostrarVehiculosAsync()
        {
            return await objDatos.MostrarAsync();
        }

        // Valida y encapsula los datos en la entidad antes de su persistencia
        public async Task InsertarVehiculoAsync(string ficha, string placa, string modelo, string capacidad)
        {
            int cap = Convert.ToInt32(capacidad);
            Vehiculo nuevoVehiculo = new Vehiculo(0, ficha, placa, modelo, cap);

            await objDatos.InsertarAsync(
                nuevoVehiculo.Ficha,
                nuevoVehiculo.Placa,
                nuevoVehiculo.Modelo,
                nuevoVehiculo.Capacidad
            );
        }

        // Procesa y formatea la modificación de un registro existente
        public async Task EditarVehiculoAsync(int id, string ficha, string placa, string modelo, string capacidad)
        {
            int cap = Convert.ToInt32(capacidad);

            await objDatos.EditarAsync(id, ficha, placa, modelo, cap);
        }

        // Ejecuta la baja del vehículo en el sistema
        public async Task EliminarVehiculoAsync(int id)
        {
            await objDatos.EliminarAsync(id);
        }

        // Verifica la unicidad de la ficha operativa para evitar registros duplicados
        public async Task<bool> VerificarFichaExiste(string ficha)
        {
            return await objDatos.ExisteFichaAsync(ficha);
        }
    }
}