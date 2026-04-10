namespace CapaNegocios
{
    public static class Sesion
    {
        public static int IdUsuario { get; set; }
        public static string NombreUsuario { get; set; } // Asegúrate de usar este nombre en FrmPrincipal
        public static string Rol { get; set; }

        public static bool EsAdministrador => Rol == "Administrador";
        public static bool EsOperador => Rol == "Operador";

        public static void CerrarSesion()
        {
            IdUsuario = 0;
            NombreUsuario = null;
            Rol = null;
        }
    }
}