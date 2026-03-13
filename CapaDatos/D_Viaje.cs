using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class D_Viaje
    {
        // Instancia para establecer la comunicación con el servidor SQL
        private ConexionBD conexion = new ConexionBD();

        // Método para extraer y listar los viajes cruzando tablas para mostrar nombres reales (INNER JOIN)
        public DataTable Mostrar()
        {
            DataTable tabla = new DataTable();
            SqlCommand comando = new SqlCommand();
            SqlDataReader leer;

            // Abrimos el canal de comunicación
            comando.Connection = conexion.AbrirConexion();

            // Consulta relacional para reemplazar los números de ID por los nombres legibles
            comando.CommandText = @"
        SELECT 
            v.ID_Viaje AS 'ID',
            c.NombreCompleto AS 'Chofer',
            r.NombreRuta AS 'Ruta',
            ve.Ficha AS 'Ficha del Vehículo',
            v.FechaViaje AS 'Fecha y Hora',
            v.Estado AS 'Estado'
        FROM Viaje v
        INNER JOIN Chofer c ON v.ID_Chofer = c.ID_Chofer
        INNER JOIN Ruta r ON v.ID_Ruta = r.ID_Ruta
        INNER JOIN Vehiculo ve ON v.ID_Vehiculo = ve.ID_Vehiculo";

            comando.CommandType = CommandType.Text;

            // Ejecutamos la consulta y volcamos los resultados en la tabla
            leer = comando.ExecuteReader();
            tabla.Load(leer);

            // Cerramos la comunicación de forma segura
            conexion.CerrarConexion();

            return tabla;
        }

        // Método exclusivo para cargar selectores (ComboBox) combinando datos en un solo texto legible
        public DataTable MostrarParaCombo()
        {
            DataTable tabla = new DataTable();
            SqlCommand comando = new SqlCommand();
            SqlDataReader leer;

            // Abrimos el canal de comunicación
            comando.Connection = conexion.AbrirConexion();

            // Generamos una cadena descriptiva (Ej: Corredor 27 - Ficha: 19-045 (Juan Perez))
            comando.CommandText = @"
        SELECT 
            v.ID_Viaje,
            r.NombreRuta + ' - Ficha: ' + ve.Ficha + ' (' + c.NombreCompleto + ')' AS DescripcionViaje
        FROM Viaje v
        INNER JOIN Ruta r ON v.ID_Ruta = r.ID_Ruta
        INNER JOIN Vehiculo ve ON v.ID_Vehiculo = ve.ID_Vehiculo
        INNER JOIN Chofer c ON v.ID_Chofer = c.ID_Chofer
        WHERE v.Estado = 'Activo'";

            comando.CommandType = CommandType.Text;

            // Ejecutamos la consulta y volcamos los resultados
            leer = comando.ExecuteReader();
            tabla.Load(leer);

            conexion.CerrarConexion();

            return tabla;
        }

        // Método para registrar un nuevo viaje en la base de datos
        public void Insertar(int idChofer, int idRuta, int idVehiculo, DateTime fecha, string estado)
        {
            SqlCommand comando = new SqlCommand();

            // Abrimos el canal y preparamos la orden de inserción
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "INSERT INTO Viaje (ID_Chofer, ID_Ruta, ID_Vehiculo, FechaViaje, Estado) VALUES (@ID_Chofer, @ID_Ruta, @ID_Vehiculo, @Fecha, @Estado)";
            comando.CommandType = CommandType.Text;

            // Empaquetamos los datos de forma segura para evitar hackeos (Inyección SQL)
            comando.Parameters.AddWithValue("@ID_Chofer", idChofer);
            comando.Parameters.AddWithValue("@ID_Ruta", idRuta);
            comando.Parameters.AddWithValue("@ID_Vehiculo", idVehiculo);
            comando.Parameters.AddWithValue("@Fecha", fecha);
            comando.Parameters.AddWithValue("@Estado", estado);

            // Ejecutamos la acción en el servidor y limpiamos el empaque
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

            // Cerramos la comunicación de forma segura
            conexion.CerrarConexion();
        }

        // Método para realizar un "borrado lógico" cambiando el estado a cancelado en lugar de borrarlo físicamente
        public void Cancelar(int idViaje)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion();

            // Preparamos la orden SQL de actualización de estado
            comando.CommandText = "UPDATE Viaje SET Estado = 'Cancelado' WHERE ID_Viaje = @ID_Viaje";
            comando.CommandType = CommandType.Text;
            comando.Parameters.AddWithValue("@ID_Viaje", idViaje);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        // Método para modificar los datos de un viaje ya existente usando su ID
        public void Editar(int idViaje, int idChofer, int idRuta, int idVehiculo, DateTime fecha, string estado)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion();

            // Preparamos la orden SQL de actualización
            comando.CommandText = "UPDATE Viaje SET ID_Chofer = @ID_Chofer, ID_Ruta = @ID_Ruta, ID_Vehiculo = @ID_Vehiculo, FechaViaje = @Fecha, Estado = @Estado WHERE ID_Viaje = @ID_Viaje";
            comando.CommandType = CommandType.Text;

            // Asignamos los nuevos valores de forma segura
            comando.Parameters.AddWithValue("@ID_Viaje", idViaje);
            comando.Parameters.AddWithValue("@ID_Chofer", idChofer);
            comando.Parameters.AddWithValue("@ID_Ruta", idRuta);
            comando.Parameters.AddWithValue("@ID_Vehiculo", idVehiculo);
            comando.Parameters.AddWithValue("@Fecha", fecha);
            comando.Parameters.AddWithValue("@Estado", estado);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }
    }
}