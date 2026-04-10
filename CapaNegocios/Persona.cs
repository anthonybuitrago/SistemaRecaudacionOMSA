using System;

namespace CapaNegocios
{
    // TODO: [REQUISITO] - Clase Abstracta: Definición de una estructura base que no puede ser instanciada directamente.

    // Clase base abstracta para entidades físicas del sistema (Aplicación de Abstracción)
    public abstract class Persona
    {
        // Protección de datos mediante propiedades (Aplicación de Encapsulamiento)
        public string Cedula { get; set; }
        public string NombreCompleto { get; set; }

        // Constructor base para la inicialización de atributos fundamentales
        public Persona(string cedula, string nombreCompleto)
        {
            Cedula = cedula;
            NombreCompleto = nombreCompleto;
        }

        // TODO: [REQUISITO] - Método Virtual: Permite la sobreescritura (Polimorfismo) en clases derivadas.

        // Método base expandible por las clases derivadas (Aplicación de Polimorfismo Virtual)
        public virtual string ObtenerDetalles()
        {
            return $"Cédula: {Cedula} - Nombre: {NombreCompleto}";
        }

        // TODO: [REQUISITO] - Método Abstracto: Obliga a las clases hijas a definir su propio comportamiento.

        // Contrato estructural de implementación obligatoria para clases hijas (Polimorfismo Abstracto)
        public abstract string ObtenerTipoEmpleado();
    }
}