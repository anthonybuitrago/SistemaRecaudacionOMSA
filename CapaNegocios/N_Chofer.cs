using System;
using System.Data;
using CapaDatos;

namespace CapaNegocios
{
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
    }
}