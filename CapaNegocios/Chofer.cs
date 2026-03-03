using System;

namespace CapaNegocios
{
    public class Chofer : Persona
    {
        public int ID_Chofer { get; set; }
        public string NumeroLicencia { get; set; }
        public Chofer(int idChofer, string cedula, string nombreCompleto, string numeroLicencia)
            : base(cedula, nombreCompleto)
        {
            ID_Chofer = idChofer;
            NumeroLicencia = numeroLicencia;
        }
        public override string ObtenerDetalles()
        {
            return base.ObtenerDetalles() + $" - Licencia: {NumeroLicencia}";
        }
        public override string ObtenerTipoEmpleado()
        {
            return "Chofer de Ruta OMSA";
        }
    }
}