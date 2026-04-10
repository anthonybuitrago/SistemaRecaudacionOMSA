using System;
using System.Data.SqlClient;

namespace CapaDatos
{
    // Gestión de autenticación y persistencia de usuarios
    public class D_Usuario
    {
        // Propiedades de la entidad de usuario
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasena { get; set; }
        public string Rol { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool Activo { get; set; }

        // TODO: [REQUISITO] - Login: Validación de acceso al sistema consultando la tabla Usuario.

        // Valida las credenciales y retorna el perfil si el usuario está activo
        public static D_Usuario Validar(string nombreUsuario, string contrasena)
        {
            try
            {
                ConexionBD bd = new ConexionBD();
                SqlConnection con = bd.AbrirConexion();

                // Consulta con parámetros para prevenir Inyección SQL
                SqlCommand cmd = new SqlCommand(@"
                    SELECT ID_Usuario, NombreUsuario, Rol
                    FROM Usuario
                    WHERE NombreUsuario = @nombre
                      AND Contrasena = @contrasena
                      AND Activo = 1", con);

                cmd.Parameters.AddWithValue("@nombre", nombreUsuario);
                cmd.Parameters.AddWithValue("@contrasena", contrasena);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    D_Usuario u = new D_Usuario
                    {
                        IdUsuario = Convert.ToInt32(dr["ID_Usuario"]),
                        NombreUsuario = dr["NombreUsuario"].ToString(),
                        Rol = dr["Rol"].ToString()
                    };
                    dr.Close();
                    bd.CerrarConexion();
                    return u;
                }

                dr.Close();
                bd.CerrarConexion();
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al validar usuario en base de datos: " + ex.Message);
            }
        }

        // Registra un nuevo acceso de usuario en el sistema
        public static void Insertar(string nombreUsuario, string contrasena, string rol)
        {
            try
            {
                ConexionBD bd = new ConexionBD();
                SqlConnection con = bd.AbrirConexion();

                SqlCommand cmd = new SqlCommand(@"
                    INSERT INTO Usuario (NombreUsuario, Contrasena, Rol)
                    VALUES (@nombre, @contrasena, @rol)", con);

                cmd.Parameters.AddWithValue("@nombre", nombreUsuario);
                cmd.Parameters.AddWithValue("@contrasena", contrasena);
                cmd.Parameters.AddWithValue("@rol", rol);

                cmd.ExecuteNonQuery();
                bd.CerrarConexion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar usuario en base de datos: " + ex.Message);
            }
        }
    }
}