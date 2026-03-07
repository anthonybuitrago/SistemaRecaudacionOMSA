using System;
using System.Data;
using CapaDatos;

namespace CapaNegocios
{
    public class N_Reporte
    {
        // Conexión con la Capa de Datos (Reportes)
        private D_Reporte objDatos = new D_Reporte();

        // Método para solicitar la suma de dinero por ruta
        public DataTable MostrarRecaudacionRuta()
        {
            return objDatos.RecaudacionPorRuta();
        }
    }
}