using System;
using System.Data;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocios
{
    // TODO: [REQUISITO] - Herencia: La clase Chofer extiende las funcionalidades de la clase base Persona.

    // Entidad que representa a un conductor operativo (Aplicación de Herencia desde Persona)
    public class Chofer : Persona
    {
        public int ID_Chofer { get; set; }
        public string NumeroLicencia { get; set; }
        public string Telefono { get; set; }

        // Constructor que inicializa atributos de la clase base (padre) y locales (hijo)
        public Chofer(int idChofer, string cedula, string nombreCompleto, string numeroLicencia, string telefono)
            : base(cedula, nombreCompleto)
        {
            ID_Chofer = idChofer;
            NumeroLicencia = numeroLicencia;
            Telefono = telefono;
        }

        // Extensión del método de la clase base para incluir datos del hijo (Polimorfismo / Override)
        public override string ObtenerDetalles()
        {
            return base.ObtenerDetalles() + $" - Licencia: {NumeroLicencia} - Tel: {Telefono}";
        }

        // Implementación del contrato establecido por la clase base (Polimorfismo Abstracto)
        public override string ObtenerTipoEmpleado()
        {
            return "Chofer de Ruta OMSA";
        }
    }

    // Reglas de negocio y orquestación de operaciones para la gestión de choferes
    public class N_Chofer
    {
        // Enlace de comunicación con la capa de persistencia de datos
        private D_Chofer objDatos = new D_Chofer();

        // Recupera el listado completo de conductores activos
        public async Task<DataTable> MostrarChoferesAsync()
        {
            return await objDatos.MostrarAsync();
        }

        // Valida y encapsula los datos en la entidad antes de su persistencia
        public async Task InsertarChoferAsync(string cedula, string nombreCompleto, string numeroLicencia, string telefono)
        {
            Chofer nuevoChofer = new Chofer(0, cedula, nombreCompleto, numeroLicencia, telefono);

            await objDatos.InsertarAsync(
                nuevoChofer.Cedula,
                nuevoChofer.NombreCompleto,
                nuevoChofer.NumeroLicencia,
                nuevoChofer.Telefono
            );
        }

        // Procesa y formatea la modificación de un registro existente
        public async Task EditarChoferAsync(int id, string cedula, string nombre, string licencia, string telefono)
        {
            await objDatos.EditarAsync(id, cedula, nombre, licencia, telefono);
        }

        // Ejecuta la baja lógica o física del conductor en el sistema
        public async Task EliminarChoferAsync(int id)
        {
            await objDatos.EliminarAsync(id);
        }

        // Verifica la unicidad de la cédula de identidad para evitar duplicidades
        public async Task<bool> VerificarSiExisteCedula(string cedula)
        {
            return await objDatos.ExisteCedulaAsync(cedula);
        }
    }
}