using System;
using System.Data;
using CapaDatos;

namespace CapaNegocios
{

    public class Chofer : Persona
    {
        // Propiedades únicas del chofer
        public int ID_Chofer { get; set; }
        public string NumeroLicencia { get; set; }

        // Constructor que envía datos al padre (Persona)
        public Chofer(int idChofer, string cedula, string nombreCompleto, string numeroLicencia)
            : base(cedula, nombreCompleto)
        {
            ID_Chofer = idChofer;
            NumeroLicencia = numeroLicencia;
        }

        // Método para mostrar detalles personalizados
        public override string ObtenerDetalles()
        {
            return base.ObtenerDetalles() + $" - Licencia: {NumeroLicencia}";
        }

        // Método para identificar el rol del empleado
        public override string ObtenerTipoEmpleado()
        {
            return "Chofer de Ruta OMSA";
        }
    }

    public class N_Chofer
    {
        // Conexión con la Capa de Datos
        private D_Chofer objDatos = new D_Chofer();

        // Método para pedir la lista de choferes
        public DataTable MostrarChoferes()
        {
            return objDatos.Mostrar();
        }

        // Método para enviar un nuevo chofer a guardar
        public void InsertarChofer(string cedula, string nombreCompleto, string numeroLicencia)
        {
            // 1. Creamos el objeto (Aquí nace la referencia)
            Chofer nuevoChofer = new Chofer(0, cedula, nombreCompleto, numeroLicencia);

            // 2. Pasamos las propiedades del objeto a la Capa de Datos
            objDatos.Insertar(nuevoChofer.Cedula, nuevoChofer.NombreCompleto, nuevoChofer.NumeroLicencia);
        }

        // Puente para enviar los datos editados a la Capa de Datos
        public void EditarChofer(int id, string cedula, string nombre, string licencia)
        {
            objDatos.Editar(id, cedula, nombre, licencia);
        }

        // Puente para enviar la orden de eliminar a la Capa de Datos
        public void EliminarChofer(int id)
        {
            objDatos.Eliminar(id);
        }
    }
}