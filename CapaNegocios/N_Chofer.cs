using System;
using System.Data;
using CapaDatos;

namespace CapaNegocios
{
    // Clase que hereda de Persona
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

        // Método para pedir la lista de choferes
        public DataTable MostrarChoferes()
        {
            return objDatos.Mostrar();
        }

        // Método para enviar un nuevo chofer a guardar
        public void InsertarChofer(string cedula, string nombreCompleto, string numeroLicencia)
        {
            // Instanciamos el objeto Chofer
            Chofer nuevoChofer = new Chofer(0, cedula, nombreCompleto, numeroLicencia);

            // Mandamos los datos a la Capa de Datos
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