using System;

namespace CapaNegocios
{
    // Clase base abstracta para los empleados del sistema
    public abstract class Persona
    {
        // Propiedades básicas de identificación
        public string Cedula { get; set; }
        public string NombreCompleto { get; set; }

        // Constructor para inicializar los datos de la persona
        public Persona(string cedula, string nombreCompleto)
        {
            Cedula = cedula;
            NombreCompleto = nombreCompleto;
        }

        // Método base que permite ser modificado por las clases hijas
        public virtual string ObtenerDetalles()
        {
            return $"Cédula: {Cedula} - Nombre: {NombreCompleto}";
        }

        // Método obligatorio para que las clases hijas definan su rol
        public abstract string ObtenerTipoEmpleado();
    }
}