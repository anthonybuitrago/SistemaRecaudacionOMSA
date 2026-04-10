using System;
using System.Data;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocios
{
    // TODO: [REQUISITO] - Clases (Entidad de negocio)
    // Entidad que representa una ruta de transporte en el sistema
    public class Ruta
    {
        public int ID_Ruta { get; set; }
        public string NombreRuta { get; set; }
        public decimal Tarifa { get; set; }
        public int TiempoMinutos { get; set; }
        public decimal DistanciaKM { get; set; }

        public Ruta(int id, string nombre, decimal tarifa, int tiempo, decimal distancia)
        {
            ID_Ruta = id;
            NombreRuta = nombre;
            Tarifa = tarifa;
            TiempoMinutos = tiempo;
            DistanciaKM = distancia;
        }
    }

    // Gestiona la lógica de negocio y validaciones para las rutas
    public class N_Ruta
    {
        private D_Ruta objDatos = new D_Ruta();

        public async Task<DataTable> MostrarRutasAsync()
        {
            return await objDatos.MostrarAsync();
        }

        // Empaqueta los datos en el objeto Ruta y los envía a guardar
        public async Task InsertarRutaAsync(string nombre, string tarifaText, string tiempoText, string distanciaText)
        {
            decimal tarifa = Convert.ToDecimal(tarifaText);
            int tiempo = Convert.ToInt32(tiempoText);
            decimal distancia = Convert.ToDecimal(distanciaText);

            Ruta nuevaRuta = new Ruta(0, nombre, tarifa, tiempo, distancia);

            await objDatos.InsertarAsync(nuevaRuta.NombreRuta, nuevaRuta.Tarifa, nuevaRuta.TiempoMinutos, nuevaRuta.DistanciaKM);
        }

        // Modifica los datos de una ruta existente
        public async Task EditarRutaAsync(int id, string nombre, string tarifaText, string tiempoText, string distanciaText)
        {
            decimal tarifa = Convert.ToDecimal(tarifaText);
            int tiempo = Convert.ToInt32(tiempoText);
            decimal distancia = Convert.ToDecimal(distanciaText);

            await objDatos.EditarAsync(id, nombre, tarifa, tiempo, distancia);
        }

        public async Task EliminarRutaAsync(int id)
        {
            await objDatos.EliminarAsync(id);
        }

        // Valida en la base de datos si el nombre de la ruta ya existe
        public async Task<bool> VerificarSiExiste(string nombreRuta)
        {
            return await objDatos.ExisteRutaAsync(nombreRuta);
        }
    }
}