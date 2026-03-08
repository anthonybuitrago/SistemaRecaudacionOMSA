using System;
using System.Data;
using CapaDatos;

namespace CapaNegocios
{
    public class N_Ruta
    {
        // Conexión con la Capa de Datos (Rutas)
        private D_Ruta objDatos = new D_Ruta();

        // Método para solicitar la lista de rutas
        public DataTable MostrarRutas()
        {
            return objDatos.Mostrar();
        }

        // Método para enviar una nueva ruta a guardar
        public void InsertarRuta(string nombreRuta, string tarifaPasaje)
        {
            // Convertimos la tarifa a decimal antes de crear el objeto
            decimal tarifa = Convert.ToDecimal(tarifaPasaje);

            // Creamos el objeto Ruta
            Ruta nuevaRuta = new Ruta(0, nombreRuta, tarifa);

            // Mandamos los datos del objeto a la capa de datos
            objDatos.Insertar(nuevaRuta.NombreRuta, nuevaRuta.TarifaPasaje.ToString());
        }

        // Puente para eliminar la ruta llamando a la Capa de Datos
        public void EliminarRuta(int id)
        {
            objDatos.Eliminar(id);
        }

        // Método para enviar los datos editados a la Capa de Datos
        public void EditarRuta(int id, string nombreRuta, string tarifaPasaje)
        {
            decimal tarifa = Convert.ToDecimal(tarifaPasaje);
            objDatos.Editar(id, nombreRuta, tarifa);
        }
    }
}