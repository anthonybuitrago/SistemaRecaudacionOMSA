using System;

namespace CapaNegocios
{
    public abstract class Persona
    {
        public string Cedula { get; set; }
        public string NombreCompleto { get; set; }
        public Persona(string cedula, string nombreCompleto)
        {
            Cedula = cedula;
            NombreCompleto = nombreCompleto;
        }
        public virtual string ObtenerDetalles()
        {
            return $"Cédula: {Cedula} - Nombre: {NombreCompleto}";
        }
        public abstract string ObtenerTipoEmpleado();
    }
}