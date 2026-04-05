using System;
using System.Data;
using System.Threading.Tasks; // Obligatorio para el asincronismo
using CapaDatos;

namespace CapaNegocios
{
    // TODO: Requisito - Herencia (Chofer hereda de la clase abstracta Persona)
    public class Chofer : Persona
    {
        // Propiedades específicas del chofer
        public int ID_Chofer { get; set; }
        public string NumeroLicencia { get; set; }

        // --- CAMBIO 1: Agregamos la propiedad Teléfono ---
        public string Telefono { get; set; }

        // Constructor que inicializa datos base y específicos
        // --- CAMBIO 2: El constructor ahora recibe el teléfono ---
        public Chofer(int idChofer, string cedula, string nombreCompleto, string numeroLicencia, string telefono)
            : base(cedula, nombreCompleto)
        {
            ID_Chofer = idChofer;
            NumeroLicencia = numeroLicencia;
            Telefono = telefono; // Asignamos el nuevo dato
        }

        // TODO: Requisito - Polimorfismo (Sobreescritura de método virtual)
        public override string ObtenerDetalles()
        {
            // Opcional: También podemos agregar el teléfono al detalle para aprovechar el polimorfismo
            return base.ObtenerDetalles() + $" - Licencia: {NumeroLicencia} - Tel: {Telefono}";
        }

        public override string ObtenerTipoEmpleado()
        {
            return "Chofer de Ruta OMSA";
        }
    }

    public class N_Chofer
    {
        // Conexión con la Capa de Datos
        private D_Chofer objDatos = new D_Chofer();

        // --- MÉTODOS BÁSICOS ASÍNCRONOS ---

        public async Task<DataTable> MostrarChoferesAsync()
        {
            return await objDatos.MostrarAsync();
        }

        // --- CAMBIO 3: Agregamos string telefono al método Insertar ---
        public async Task InsertarChoferAsync(string cedula, string nombreCompleto, string numeroLicencia, string telefono)
        {
            // Instanciamos el objeto Chofer con el nuevo parámetro
            Chofer nuevoChofer = new Chofer(0, cedula, nombreCompleto, numeroLicencia, telefono);

            // Mandamos los datos a la Capa de Datos en el orden exacto (4 parámetros)
            await objDatos.InsertarAsync(nuevoChofer.Cedula, nuevoChofer.NombreCompleto, nuevoChofer.NumeroLicencia, nuevoChofer.Telefono);
        }

        // --- CAMBIO 4: Agregamos string telefono al método Editar ---
        public async Task EditarChoferAsync(int id, string cedula, string nombre, string licencia, string telefono)
        {
            // Mandamos los datos a la Capa de Datos en el orden exacto (5 parámetros)
            await objDatos.EditarAsync(id, cedula, nombre, licencia, telefono);
        }

        public async Task EliminarChoferAsync(int id)
        {
            await objDatos.EliminarAsync(id);
        }
        public async Task<bool> VerificarSiExisteCedula(string cedula)
        {
            // Esto simplemente le pregunta a la Capa de Datos si ya conoce esa cédula
            return await objDatos.ExisteCedulaAsync(cedula);
        }
    }
}