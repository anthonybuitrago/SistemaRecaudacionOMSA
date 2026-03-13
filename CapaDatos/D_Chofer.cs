using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class D_Chofer
    {
        // Instancia para establecer la comunicación con el servidor SQL
        private ConexionBD conexion = new ConexionBD();

        // Método para extraer y listar todos los choferes registrados en la tabla
        public DataTable Mostrar()
        {
            DataTable tabla = new DataTable();
            SqlCommand comando = new SqlCommand();
            SqlDataReader leer;

            // Abrimos el canal y preparamos la orden de consulta
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "SELECT * FROM Chofer";
            comando.CommandType = CommandType.Text;

            // Ejecutamos la consulta y volcamos los resultados en la tabla
            leer = comando.ExecuteReader();
            tabla.Load(leer);

            // Cerramos la comunicación de forma segura
            conexion.CerrarConexion();
            return tabla;
        }

        // Método para registrar un nuevo chofer en la base de datos
        public void Insertar(string cedula, string nombreCompleto, string numeroLicencia)
        {
            SqlCommand comando = new SqlCommand();

            // Abrimos el canal y preparamos la orden de inserción
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "INSERT INTO Chofer (Cedula, NombreCompleto, NumeroLicencia) VALUES (@Cedula, @Nombre, @Licencia)";
            comando.CommandType = CommandType.Text;

            // Empaquetamos los datos de forma segura para evitar hackeos (Inyección SQL)
            comando.Parameters.AddWithValue("@Cedula", cedula);
            comando.Parameters.AddWithValue("@Nombre", nombreCompleto);
            comando.Parameters.AddWithValue("@Licencia", numeroLicencia);

            // Ejecutamos la acción en el servidor y limpiamos el empaque
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

            conexion.CerrarConexion();
        }

        // Método para modificar los datos de un chofer ya existente usando su ID
        public void Editar(int id, string cedula, string nombre, string licencia)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion();

            // Preparamos la orden SQL de actualización
            comando.CommandText = "UPDATE Chofer SET Cedula = @cedula, NombreCompleto = @nombre, NumeroLicencia = @licencia WHERE ID_Chofer = @id";
            comando.CommandType = CommandType.Text;

            // Asignamos los nuevos valores de forma segura
            comando.Parameters.AddWithValue("@cedula", cedula);
            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@licencia", licencia);
            comando.Parameters.AddWithValue("@id", id);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        // Método para borrar permanentemente el registro de un chofer
        public void Eliminar(int id)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion();

            // Preparamos la orden SQL de eliminación
            comando.CommandText = "DELETE FROM Chofer WHERE ID_Chofer = @id";
            comando.CommandType = CommandType.Text;

            comando.Parameters.AddWithValue("@id", id);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }
    }
}