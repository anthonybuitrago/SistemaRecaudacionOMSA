using System;

namespace CapaNegocios
{
    // Clase abstracta (No se pueden crear objetos "Persona" directamente)
    public abstract class Persona
    {
        // Propiedades básicas de cualquier persona
        public string Cedula { get; set; }
        public string NombreCompleto { get; set; }

        // Constructor para inicializar los datos
        public Persona(string cedula, string nombreCompleto)
        {
            Cedula = cedula;
            NombreCompleto = nombreCompleto;
        }

        // Método que los hijos pueden modificar (Polimorfismo)
        public virtual string ObtenerDetalles()
        {
            return $"Cédula: {Cedula} - Nombre: {NombreCompleto}";
        }

        // Método obligatorio para los hijos (Cada hijo debe decir qué es)
        public abstract string ObtenerTipoEmpleado();
    }
}