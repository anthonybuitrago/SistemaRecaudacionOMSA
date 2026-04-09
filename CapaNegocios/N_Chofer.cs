using System;
using System.Data;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocios
{
    // TODO: [REQUISITO] - Herencia (Chofer hereda de la clase base Persona)
    // Entidad que representa a un conductor del sistema
    public class Chofer : Persona
    {
        public int ID_Chofer { get; set; }
        public string NumeroLicencia { get; set; }
        public string Telefono { get; set; }

        // Constructor que inicializa datos base (padre) y específicos (hijo)
        public Chofer(int idChofer, string cedula, string nombreCompleto, string numeroLicencia, string telefono)
            : base(cedula, nombreCompleto)
        {
            ID_Chofer = idChofer;
            NumeroLicencia = numeroLicencia;
            Telefono = telefono;
        }

        // TODO: [REQUISITO] - Métodos virtuales (Sobreescritura por polimorfismo)
        // Personaliza el método de la clase padre para incluir datos específicos del chofer
        public override string ObtenerDetalles()
        {
            return base.ObtenerDetalles() + $" - Licencia: {NumeroLicencia} - Tel: {Telefono}";
        }

        // Implementación obligatoria del método abstracto de la clase base
        public override string ObtenerTipoEmpleado()
        {
            return "Chofer de Ruta OMSA";
        }
    }

    // Gestiona la lógica de negocio y validaciones para los choferes
    public class N_Chofer
    {
        private D_Chofer objDatos = new D_Chofer();

        public async Task<DataTable> MostrarChoferesAsync()
        {
            return await objDatos.MostrarAsync();
        }

        // Empaqueta los datos en un objeto y los envía a la capa de datos
        public async Task InsertarChoferAsync(string cedula, string nombreCompleto, string numeroLicencia, string telefono)
        {
            Chofer nuevoChofer = new Chofer(0, cedula, nombreCompleto, numeroLicencia, telefono);
            await objDatos.InsertarAsync(nuevoChofer.Cedula, nuevoChofer.NombreCompleto, nuevoChofer.NumeroLicencia, nuevoChofer.Telefono);
        }

        public async Task EditarChoferAsync(int id, string cedula, string nombre, string licencia, string telefono)
        {
            await objDatos.EditarAsync(id, cedula, nombre, licencia, telefono);
        }

        public async Task EliminarChoferAsync(int id)
        {
            await objDatos.EliminarAsync(id);
        }

        // Valida en la base de datos si la cédula ingresada ya existe
        public async Task<bool> VerificarSiExisteCedula(string cedula)
        {
            return await objDatos.ExisteCedulaAsync(cedula);
        }
    }
}