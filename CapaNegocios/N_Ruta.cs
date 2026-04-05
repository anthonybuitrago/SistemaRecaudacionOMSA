using System;
using System.Data;
using System.Threading.Tasks; // Obligatorio para el asincronismo
using CapaDatos;

namespace CapaNegocios
{
    // TODO: Requisito - Creación de Entidad/Clase con el diseño 2x2
    public class Ruta
    {
        // Propiedades de la ruta
        public int ID_Ruta { get; set; }
        public string NombreRuta { get; set; }
        public decimal Tarifa { get; set; }
        public string Origen { get; set; }  // <-- NUEVO
        public string Destino { get; set; } // <-- NUEVO

        // Constructor actualizado
        public Ruta(int id, string nombre, decimal tarifa, string origen, string destino)
        {
            ID_Ruta = id;
            NombreRuta = nombre;
            Tarifa = tarifa;
            Origen = origen;
            Destino = destino;
        }
    }

    public class N_Ruta
    {
        // Conexión con la Capa de Datos
        private D_Ruta objDatos = new D_Ruta();

        // --- MÉTODOS ASÍNCRONOS ---

        // Pedir la lista de rutas activas
        public async Task<DataTable> MostrarRutasAsync()
        {
            return await objDatos.MostrarAsync();
        }

        // Insertar procesando los 4 campos
        public async Task InsertarRutaAsync(string nombre, string tarifaText, string origen, string destino)
        {
            // Convertimos la tarifa (viene de un MaskedTextBox como string)
            decimal tarifa = Convert.ToDecimal(tarifaText);

            // Instanciamos el objeto con la nueva estructura
            Ruta nuevaRuta = new Ruta(0, nombre, tarifa, origen, destino);

            // Mandamos los 4 datos a la Capa de Datos
            await objDatos.InsertarAsync(nuevaRuta.NombreRuta, nuevaRuta.Tarifa, nuevaRuta.Origen, nuevaRuta.Destino);
        }

        // Editar procesando ID + los 4 campos
        public async Task EditarRutaAsync(int id, string nombre, string tarifaText, string origen, string destino)
        {
            decimal tarifa = Convert.ToDecimal(tarifaText);
            await objDatos.EditarAsync(id, nombre, tarifa, origen, destino);
        }

        // Eliminar (Borrado Lógico)
        public async Task EliminarRutaAsync(int id)
        {
            await objDatos.EliminarAsync(id);
        }

        // MÉTODO EXTRA: Para que el formulario pueda validar duplicados antes de guardar
        public async Task<bool> VerificarSiExiste(string nombreRuta)
        {
            return await objDatos.ExisteRutaAsync(nombreRuta);
        }
    }
}