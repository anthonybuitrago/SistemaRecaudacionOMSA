using CapaDatos;


namespace OMSA_Recaudacion.CapaNegocio
{
    public class N_Usuario
    {
        D_Usuario datos = new D_Usuario();

        // TODO: Es para Llamar a la capa de datos para validar credenciales
        public bool ValidarUsuario(string usuario, string clave)
        {
            return datos.ValidarUsuario(usuario, clave);
        }
    }
}