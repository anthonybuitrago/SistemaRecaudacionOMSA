using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CapaDatos
{
    // TODO: [REQUISITO] - Conexión a base de datos SQL Server mediante cadena de conexión.

    // Clase maestra para la gestión del ciclo de vida de la conexión con SQL Server
    public class ConexionBD
    {
        // Recuperación de la cadena de conexión desde el archivo de configuración (App.config/Web.config)
        private readonly string cadenaConexion = ConfigurationManager.ConnectionStrings["ConexionOMSA"].ConnectionString;
        private SqlConnection conexion;

        // Constructor: Inicializa la instancia del cliente SQL
        public ConexionBD()
        {
            conexion = new SqlConnection(cadenaConexion);
        }

        // ==========================================================
        // MÉTODOS DE CONTROL DE FLUJO DE DATOS
        // ==========================================================

        // Valida el estado actual y abre el canal de comunicación con el servidor
        public SqlConnection AbrirConexion()
        {
            if (conexion.State == ConnectionState.Closed)
            {
                conexion.Open();
            }
            return conexion;
        }

        // Valida el estado actual y libera el recurso de conexión de forma segura
        public SqlConnection CerrarConexion()
        {
            if (conexion.State == ConnectionState.Open)
            {
                conexion.Close();
            }
            return conexion;
        }
    }
}