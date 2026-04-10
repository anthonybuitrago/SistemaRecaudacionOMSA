using System;

namespace CapaNegocios
{
    // Clase estática para la gestión global de la sesión del usuario activo
    public static class Sesion
    {
        // Propiedades de identificación y perfil
        public static int IdUsuario { get; set; }
        public static string NombreUsuario { get; set; }
        public static string Rol { get; set; }

        // Validaciones rápidas de nivel de acceso basado en roles (RBAC)
        public static bool EsAdministrador => Rol == "Administrador";
        public static bool EsOperador => Rol == "Operador";

        // Limpia los datos almacenados en memoria al finalizar la sesión
        public static void CerrarSesion()
        {
            IdUsuario = 0;
            NombreUsuario = null;
            Rol = null;
        }
    }
}