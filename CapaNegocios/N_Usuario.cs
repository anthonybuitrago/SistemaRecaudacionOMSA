using CapaDatos;

namespace CapaNegocios
{
    // Gestiona la lógica de seguridad y validación de acceso al sistema
    public class N_Usuario
    {
        private D_Usuario datos = new D_Usuario();

        // Puente que solicita la validación de credenciales a la capa de datos
        public bool ValidarUsuario(string usuario, string clave)
        {
            return datos.ValidarUsuario(usuario, clave);
        }
    }
}