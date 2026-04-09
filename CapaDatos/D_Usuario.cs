using System;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class D_Usuario
    {
        // Propiedades
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasena { get; set; }
        public string Rol { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool Activo { get; set; }

        // Validar login - devuelve el usuario si existe o null si no
        public static D_Usuario Validar(string nombreUsuario, string contrasena)
        {
            try
            {
                ConexionBD bd = new ConexionBD();
                SqlConnection con = bd.AbrirConexion();

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
                throw new Exception("Error al validar usuario: " + ex.Message);
            }
        }

        // Insertar usuario nuevo
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
                throw new Exception("Error al insertar usuario: " + ex.Message);
            }
        }
    }
}