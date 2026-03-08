using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class D_Ruta
    {
        // Conexión a la base de datos
        private ConexionBD conexion = new ConexionBD();

        // Método para leer las rutas
        public DataTable Mostrar()
        {
            DataTable tabla = new DataTable();
            SqlCommand comando = new SqlCommand();
            SqlDataReader leer;

            // Abrir conexión y configurar comando
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "SELECT * FROM Ruta";
            comando.CommandType = CommandType.Text;

            // Leer datos y cargar la tabla
            leer = comando.ExecuteReader();
            tabla.Load(leer);

            // Cerrar conexión
            conexion.CerrarConexion();
            return tabla;
        }

        // Método para guardar una ruta nueva
        public void Insertar(string nombreRuta, string tarifaPasaje)
        {
            SqlCommand comando = new SqlCommand();

            // Abrir conexión y preparar el INSERT
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "INSERT INTO Ruta (NombreRuta, TarifaPasaje) VALUES (@NombreRuta, @TarifaPasaje)";
            comando.CommandType = CommandType.Text;

            // Asignar los valores a los parámetros
            comando.Parameters.AddWithValue("@NombreRuta", nombreRuta);
            comando.Parameters.AddWithValue("@TarifaPasaje", tarifaPasaje);

            // Ejecutar en SQL y limpiar
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

            // Cerrar conexión
            conexion.CerrarConexion();
        }

        // Método para eliminar una ruta físicamente de la tabla
        public void Eliminar(int id)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "DELETE FROM Ruta WHERE ID_Ruta = @id";
            comando.CommandType = CommandType.Text;

            comando.Parameters.AddWithValue("@id", id);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        // Método para actualizar una ruta existente
        public void Editar(int id, string nombreRuta, decimal tarifaPasaje)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion();

            // El query de actualización
            comando.CommandText = "UPDATE Ruta SET NombreRuta = @nombre, TarifaPasaje = @tarifa WHERE ID_Ruta = @id";
            comando.CommandType = CommandType.Text;

            // Pasamos los parámetros de forma segura
            comando.Parameters.AddWithValue("@nombre", nombreRuta);
            comando.Parameters.AddWithValue("@tarifa", tarifaPasaje);
            comando.Parameters.AddWithValue("@id", id);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }
    }
}