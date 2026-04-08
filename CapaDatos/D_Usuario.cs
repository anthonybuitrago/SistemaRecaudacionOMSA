using System.Data.SqlClient;

namespace CapaDatos
{
    public class D_Usuario
    {
        // TODO: ESTO ES PARA VALIDAR USUARIO Y CONTRASEÑA
      
        public bool ValidarUsuario(string usuario, string clave)
        {
            bool acceso = false;
            ConexionBD bd = new ConexionBD();

            try
            {
                SqlConnection cn = bd.AbrirConexion();

                string query = "SELECT COUNT(*) FROM Usuario " +
                 "WHERE NombreUsuario = @usuario AND Contrasena = @clave";


                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@clave", clave);

                int resultado = (int)cmd.ExecuteScalar();
                acceso = resultado > 0;
            }
            finally
            {
                bd.CerrarConexion(); 
            }

            return acceso;
        }
    }
}