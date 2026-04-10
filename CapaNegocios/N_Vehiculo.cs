using System;
using System.Data;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocios
{
    // Entidad que representa una unidad de transporte
    public class Vehiculo
    {
        public int ID_Vehiculo { get; set; }
        public string Ficha { get; set; }
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public int Capacidad { get; set; }

        public Vehiculo(int id, string ficha, string placa, string modelo, int capacidad)
        {
            ID_Vehiculo = id;
            Ficha = ficha;
            Placa = placa;
            Modelo = modelo;
            Capacidad = capacidad;
        }
    }

    // Gestiona la lógica de negocio y validaciones para los vehículos
    public class N_Vehiculo
    {
        private D_Vehiculo objDatos = new D_Vehiculo();

        public async Task<DataTable> MostrarVehiculosAsync()
        {
            return await objDatos.MostrarAsync();
        }

        // Empaqueta los datos en un objeto Vehiculo y los envía a la capa de datos
        public async Task InsertarVehiculoAsync(string ficha, string placa, string modelo, string capacidad)
        {
            int cap = Convert.ToInt32(capacidad);
            Vehiculo nuevoVehiculo = new Vehiculo(0, ficha, placa, modelo, cap);

            await objDatos.InsertarAsync(nuevoVehiculo.Ficha, nuevoVehiculo.Placa, nuevoVehiculo.Modelo, nuevoVehiculo.Capacidad);
        }

        public async Task EditarVehiculoAsync(int id, string ficha, string placa, string modelo, string capacidad)
        {
            int cap = Convert.ToInt32(capacidad);
            await objDatos.EditarAsync(id, ficha, placa, modelo, cap);
        }

        public async Task EliminarVehiculoAsync(int id)
        {
            await objDatos.EliminarAsync(id);
        }

        // Valida en la base de datos si la ficha ingresada ya existe
        public async Task<bool> VerificarFichaExiste(string ficha)
        {
            return await objDatos.ExisteFichaAsync(ficha);
        }
    }
}