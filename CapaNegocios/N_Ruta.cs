using System;
using System.Data;
using System.Threading.Tasks; // Obligatorio para el asincronismo
using CapaDatos;

namespace CapaNegocios
{
    // TODO: Requisito - Creación de Entidad/Clase
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

        // --- MÉTODOS BÁSICOS ASÍNCRONOS (Solo para que compile el proyecto) ---
        // Nota: Faltan las validaciones y try/catch que hará tu compañero.

        // Método para pedir la lista de rutas
        public async Task<DataTable> MostrarRutasAsync()
        {
            return await objDatos.MostrarAsync();
        }

        // Método para enviar una nueva ruta a guardar
        public async Task InsertarRutaAsync(string nombreRuta, string tarifaPasaje)
        {
            // Convertimos el texto a decimal para la tarifa
            decimal tarifa = Convert.ToDecimal(tarifaPasaje);

            // Instanciamos el objeto Ruta
            Ruta nuevaRuta = new Ruta(0, nombreRuta, tarifa);

            // Mandamos los datos del objeto a la Capa de Datos asíncronamente
            await objDatos.InsertarAsync(nuevaRuta.NombreRuta, nuevaRuta.TarifaPasaje.ToString());
        }

        // Puente para enviar la orden de eliminar a la Capa de Datos
        public async Task EliminarRutaAsync(int id)
        {
            await objDatos.EliminarAsync(id);
        }

        // Puente para enviar los datos editados a la Capa de Datos
        public async Task EditarRutaAsync(int id, string nombreRuta, string tarifaPasaje)
        {
            decimal tarifa = Convert.ToDecimal(tarifaPasaje);
            await objDatos.EditarAsync(id, nombreRuta, tarifa);
        }
    }
}