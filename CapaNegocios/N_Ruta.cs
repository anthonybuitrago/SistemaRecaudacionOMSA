using System;
using System.Data;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocios
{
    // Clase que define la entidad de negocio para una ruta de transporte
    public class Ruta
    {
        public int ID_Ruta { get; set; }
        public string NombreRuta { get; set; }
        public decimal Tarifa { get; set; }
        public int TiempoMinutos { get; set; }
        public decimal DistanciaKM { get; set; }

        // Constructor para la inicialización estructurada de la entidad
        public Ruta(int id, string nombre, decimal tarifa, int tiempo, decimal distancia)
        {
            ID_Ruta = id;
            NombreRuta = nombre;
            Tarifa = tarifa;
            TiempoMinutos = tiempo;
            DistanciaKM = distancia;
        }
    }

    // Reglas de negocio y orquestación de operaciones para el catálogo de rutas
    public class N_Ruta
    {
        // Enlace de comunicación con la capa de persistencia de datos
        private D_Ruta objDatos = new D_Ruta();

        // Recupera el listado completo de rutas activas
        public async Task<DataTable> MostrarRutasAsync()
        {
            return await objDatos.MostrarAsync();
        }

        // Valida y encapsula los datos en la entidad antes de su persistencia
        public async Task InsertarRutaAsync(string nombre, string tarifaText, string tiempoText, string distanciaText)
        {
            // Conversión de tipos para procesamiento numérico
            decimal tarifa = Convert.ToDecimal(tarifaText);
            int tiempo = Convert.ToInt32(tiempoText);
            decimal distancia = Convert.ToDecimal(distanciaText);

            Ruta nuevaRuta = new Ruta(0, nombre, tarifa, tiempo, distancia);

            await objDatos.InsertarAsync(
                nuevaRuta.NombreRuta,
                nuevaRuta.Tarifa,
                nuevaRuta.TiempoMinutos,
                nuevaRuta.DistanciaKM
            );
        }

        // Procesa y formatea la modificación de un registro existente
        public async Task EditarRutaAsync(int id, string nombre, string tarifaText, string tiempoText, string distanciaText)
        {
            decimal tarifa = Convert.ToDecimal(tarifaText);
            int tiempo = Convert.ToInt32(tiempoText);
            decimal distancia = Convert.ToDecimal(distanciaText);

            await objDatos.EditarAsync(id, nombre, tarifa, tiempo, distancia);
        }

        // Ejecuta la baja lógica o física de la ruta en el sistema
        public async Task EliminarRutaAsync(int id)
        {
            await objDatos.EliminarAsync(id);
        }

        // Verifica la unicidad del nombre de la ruta para evitar duplicados
        public async Task<bool> VerificarSiExiste(string nombreRuta)
        {
            return await objDatos.ExisteRutaAsync(nombreRuta);
        }
    }
}