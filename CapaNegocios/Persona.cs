using System;

namespace CapaNegocios
{
    // TODO: Requisito - Abstracción (Uso de clase base abstracta)
    public abstract class Persona
    {
        // TODO: Requisito - Encapsulamiento (Uso de propiedades con get y set)
        public string Cedula { get; set; }
        public string NombreCompleto { get; set; }

        // Constructor para inicializar los datos de la persona
        public Persona(string cedula, string nombreCompleto)
        {
            Cedula = cedula;
            NombreCompleto = nombreCompleto;
        }

        // TODO: Requisito - Polimorfismo (Método virtual base listo para ser modificado)
        public virtual string ObtenerDetalles()
        {
            return $"Cédula: {Cedula} - Nombre: {NombreCompleto}";
        }

        // TODO: Requisito - Polimorfismo (Método abstracto obligatorio para las clases hijas)
        public abstract string ObtenerTipoEmpleado();
    }
}