using CapaDatos;

namespace CapaNegocios
{
    // Gestiona la lógica de seguridad y validación de acceso al sistema
    public class N_Usuario
    {
        public bool ValidarUsuario(string nombreUsuario, string contrasena)
        {
            D_Usuario u = D_Usuario.Validar(nombreUsuario, contrasena);

            if (u != null)
            {
                Sesion.IdUsuario = u.IdUsuario;
                Sesion.NombreUsuario = u.NombreUsuario;
                Sesion.Rol = u.Rol;
                return true;
            }

            return false;
        }

        public void CrearUsuario(string nombreUsuario, string contrasena, string rol)
        {
            D_Usuario.Insertar(nombreUsuario, contrasena, rol);
        }
    }
}