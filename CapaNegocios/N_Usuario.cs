using CapaDatos;

namespace CapaNegocios
{
    // Reglas de negocio y orquestación para la seguridad y control de acceso
    public class N_Usuario
    {
        // Valida credenciales contra la base de datos e inicializa la sesión global
        public bool ValidarUsuario(string nombreUsuario, string contrasena)
        {
            D_Usuario u = D_Usuario.Validar(nombreUsuario, contrasena);

            if (u != null)
            {
                // Autenticación exitosa: se registra el perfil en memoria
                Sesion.IdUsuario = u.IdUsuario;
                Sesion.NombreUsuario = u.NombreUsuario;
                Sesion.Rol = u.Rol;

                return true;
            }

            // Autenticación fallida por credenciales incorrectas o usuario inexistente
            return false;
        }

        // Procesa la creación de un nuevo perfil de acceso en el sistema
        public void CrearUsuario(string nombreUsuario, string contrasena, string rol)
        {
            D_Usuario.Insertar(nombreUsuario, contrasena, rol);
        }
    }
}