using System;

namespace CapaNegocios
{
    // Clase que hereda de Persona (Aplicando Herencia)
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
}