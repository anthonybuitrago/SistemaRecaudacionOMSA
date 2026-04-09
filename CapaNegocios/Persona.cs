using System;

namespace CapaNegocios
{
    // TODO: [REQUISITO] - Abstracción (Uso de clase base abstracta)
    // Representa la estructura base para cualquier individuo registrado en el sistema
    public abstract class Persona
    {
        // TODO: [REQUISITO] - Encapsulamiento (Uso de propiedades con modificadores de acceso)
        public string Cedula { get; set; }
        public string NombreCompleto { get; set; }

        // Inicializa los atributos fundamentales de la persona
        public Persona(string cedula, string nombreCompleto)
        {
            Cedula = cedula;
            NombreCompleto = nombreCompleto;
        }

        // TODO: [REQUISITO] - Polimorfismo (Método virtual)
        // Retorna la información básica, permitiendo que las clases hijas expandan el comportamiento
        public virtual string ObtenerDetalles()
        {
            return $"Cédula: {Cedula} - Nombre: {NombreCompleto}";
        }

        // TODO: [REQUISITO] - Polimorfismo (Método abstracto)
        // Contrato que obliga a las clases derivadas a definir su rol específico en la empresa
        public abstract string ObtenerTipoEmpleado();
    }
}