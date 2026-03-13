using System;
using System.Data;
using CapaDatos;

namespace CapaNegocios
{
    public class N_Reporte
    {
        // Conexión con la Capa de Datos
        private D_Reporte objDatos = new D_Reporte();

        // Método para pedir el reporte de ingresos y pasajeros a la base de datos
        public DataTable MostrarRecaudacionRuta()
        {
            return objDatos.RecaudacionPorRuta();
        }
    }
}