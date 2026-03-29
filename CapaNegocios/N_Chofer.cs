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

        // Constructor que inicializa datos base y específicos
        public Chofer(int idChofer, string cedula, string nombreCompleto, string numeroLicencia)
            : base(cedula, nombreCompleto)
        {
            ID_Chofer = idChofer;
            NumeroLicencia = numeroLicencia;
        }

        // TODO: Requisito - Polimorfismo (Sobreescritura de método virtual)
        // Sobreescritura para mostrar detalles personalizados
        public override string ObtenerDetalles()
        {
            return base.ObtenerDetalles() + $" - Licencia: {NumeroLicencia}";
        }

        // Sobreescritura para identificar el rol del empleado
        public override string ObtenerTipoEmpleado()
        {
            return "Chofer de Ruta OMSA";
        }
    }

    public class N_Chofer
    {
        // Conexión con la Capa de Datos
        private D_Chofer objDatos = new D_Chofer();

        // --- MÉTODOS BÁSICOS ASÍNCRONOS (Solo para que compile el proyecto) ---
        // Nota: Faltan las validaciones y try/catch que hará Luis Eduardo.

        public async Task<DataTable> MostrarChoferesAsync()
        {
            return await objDatos.MostrarAsync();
        }

        public async Task InsertarChoferAsync(string cedula, string nombreCompleto, string numeroLicencia)
        {
            // Instanciamos el objeto Chofer
            Chofer nuevoChofer = new Chofer(0, cedula, nombreCompleto, numeroLicencia);

            // Mandamos los datos a la Capa de Datos de forma asíncrona
            await objDatos.InsertarAsync(nuevoChofer.Cedula, nuevoChofer.NombreCompleto, nuevoChofer.NumeroLicencia);
        }

        public async Task EditarChoferAsync(int id, string cedula, string nombre, string licencia)
        {
            await objDatos.EditarAsync(id, cedula, nombre, licencia);
        }

        public async Task EliminarChoferAsync(int id)
        {
            await objDatos.EliminarAsync(id);
        }
    }
}