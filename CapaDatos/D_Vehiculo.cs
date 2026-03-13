using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class D_Vehiculo
    {
        // Instancia para establecer la comunicación con el servidor SQL
        private ConexionBD conexion = new ConexionBD();

        // Método para extraer y listar todos los vehículos registrados en la tabla
        public DataTable Mostrar()
        {
            // Abrimos el canal y preparamos la orden de consulta
            SqlCommand comando = new SqlCommand("SELECT * FROM Vehiculo", conexion.AbrirConexion());
            DataTable tabla = new DataTable();

            // Ejecutamos la consulta y volcamos los resultados en la tabla
            tabla.Load(comando.ExecuteReader());

            // Cerramos la comunicación de forma segura
            conexion.CerrarConexion();
            return tabla;
        }

        // Método para registrar un nuevo vehículo en la base de datos
        public void Insertar(string ficha, string placa, int capacidad)
        {
            // Abrimos el canal y preparamos la orden de inserción
            SqlCommand comando = new SqlCommand("INSERT INTO Vehiculo (Ficha, Placa, Capacidad) VALUES (@ficha, @placa, @capacidad)", conexion.AbrirConexion());

            // Empaquetamos los datos de forma segura para evitar hackeos (Inyección SQL)
            comando.Parameters.AddWithValue("@ficha", ficha);
            comando.Parameters.AddWithValue("@placa", placa);
            comando.Parameters.AddWithValue("@capacidad", capacidad);

            // Ejecutamos la acción en el servidor y cerramos la comunicación
            comando.ExecuteNonQuery();
            conexion.CerrarConexion();
        }

        // Método para modificar los datos de un vehículo ya existente usando su ID
        public void Editar(int id, string ficha, string placa, int capacidad)
        {
            // Abrimos el canal y preparamos la orden SQL de actualización
            SqlCommand comando = new SqlCommand("UPDATE Vehiculo SET Ficha=@ficha, Placa=@placa, Capacidad=@capacidad WHERE ID_Vehiculo=@id", conexion.AbrirConexion());

            // Asignamos los nuevos valores de forma segura
            comando.Parameters.AddWithValue("@id", id);
            comando.Parameters.AddWithValue("@ficha", ficha);
            comando.Parameters.AddWithValue("@placa", placa);
            comando.Parameters.AddWithValue("@capacidad", capacidad);

            // Ejecutamos la acción en el servidor y cerramos la comunicación
            comando.ExecuteNonQuery();
            conexion.CerrarConexion();
        }

        // Método para borrar permanentemente el registro de un vehículo
        public void Eliminar(int id)
        {
            // Abrimos el canal y preparamos la orden SQL de eliminación
            SqlCommand comando = new SqlCommand("DELETE FROM Vehiculo WHERE ID_Vehiculo=@id", conexion.AbrirConexion());

            // Empaquetamos el ID de forma segura
            comando.Parameters.AddWithValue("@id", id);

            // Ejecutamos la acción en el servidor y cerramos la comunicación
            comando.ExecuteNonQuery();
            conexion.CerrarConexion();
        }
    }
}