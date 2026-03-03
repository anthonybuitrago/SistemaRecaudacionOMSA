using System;
using System.Data;
using CapaDatos;

namespace CapaNegocios
{
    public class N_Chofer
    {
        private D_Chofer objDatos = new D_Chofer();
        public DataTable MostrarChoferes()
        {
            return objDatos.Mostrar();
        }
        public void InsertarChofer(string cedula, string nombreCompleto, string numeroLicencia)
        {
            objDatos.Insertar(cedula, nombreCompleto, numeroLicencia);
        }
    }
}