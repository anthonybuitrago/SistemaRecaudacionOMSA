using System;
using System.Data.SqlClient;

namespace CapaDatos
{
    // TODO: [REQUISITO] - Login para el acceso de la aplicación con conexión a base de datos
    // Gestiona la validación de credenciales de los usuarios en el sistema
    public class D_Usuario
    {
        // Verifica si el usuario y la contraseña coinciden con los registros activos
        public bool ValidarUsuario(string usuario, string clave)
        {
            bool acceso = false;
            ConexionBD bd = new ConexionBD();

            try
            {
                SqlConnection cn = bd.AbrirConexion();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cn;
                    cmd.CommandText = "SELECT COUNT(*) FROM Usuario WHERE NombreUsuario = @usuario AND Contrasena = @clave";

                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    cmd.Parameters.AddWithValue("@clave", clave);

                    int resultado = Convert.ToInt32(cmd.ExecuteScalar());
                    acceso = resultado > 0;
                }
            }
            finally
            {
                bd.CerrarConexion();
            }

            return acceso;
        }
    }
}