using System;
using System.Data;
using CapaDatos;

namespace CapaNegocios
{
    public class Ruta
    {
        // Propiedades de la ruta
        public int ID_Ruta { get; set; }
        public string NombreRuta { get; set; }
        public decimal TarifaPasaje { get; set; }

        // Constructor
        public Ruta(int id, string nombre, decimal tarifa)
        {
            ID_Ruta = id;
            NombreRuta = nombre;
            TarifaPasaje = tarifa;
        }
    }

    public class N_Ruta
    {
        // Conexión con la Capa de Datos
        private D_Ruta objDatos = new D_Ruta();

        // Método para pedir la lista de rutas
        public DataTable MostrarRutas()
        {
            return objDatos.Mostrar();
        }

        // Método para enviar una nueva ruta a guardar
        public void InsertarRuta(string nombreRuta, string tarifaPasaje)
        {
            // Convertimos el texto a decimal para la tarifa
            decimal tarifa = Convert.ToDecimal(tarifaPasaje);

            // Instanciamos el objeto Ruta
            Ruta nuevaRuta = new Ruta(0, nombreRuta, tarifa);

            // Mandamos los datos del objeto a la Capa de Datos
            objDatos.Insertar(nuevaRuta.NombreRuta, nuevaRuta.TarifaPasaje.ToString());
        }

        // Puente para enviar la orden de eliminar a la Capa de Datos
        public void EliminarRuta(int id)
        {
            objDatos.Eliminar(id);
        }

        // Puente para enviar los datos editados a la Capa de Datos
        public void EditarRuta(int id, string nombreRuta, string tarifaPasaje)
        {
            decimal tarifa = Convert.ToDecimal(tarifaPasaje);
            objDatos.Editar(id, nombreRuta, tarifa);
        }
    }
}