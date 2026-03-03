using System;
using System.Data;
using CapaDatos;

namespace CapaNegocios
{
    public class N_Ruta
    {
        private D_Ruta objDatos = new D_Ruta();
        public DataTable MostrarRutas()
        {
            return objDatos.Mostrar();
        }
        public void InsertarRuta(string nombreRuta, string tarifaPasaje)
        {
            objDatos.Insertar(nombreRuta, tarifaPasaje);
        }
    }
}