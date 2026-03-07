using System;
using System.Data;
using CapaDatos;

namespace CapaNegocios
{
    public class N_Reporte
    {
        private D_Reporte objDatos = new D_Reporte();

        public DataTable MostrarRecaudacionRuta()
        {
            return objDatos.RecaudacionPorRuta();
        }
    }
}