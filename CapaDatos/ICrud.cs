using System;
using System.Data;
using System.Threading.Tasks;

namespace CapaDatos
{
    // TODO: Requisito - Creación de Interfaz para estandarizar el CRUD asíncrono
    public interface ICrud
    {
        // Método para leer datos (Devuelve una tabla de forma asíncrona)
        Task<DataTable> MostrarAsync();

        // Utilizamos 'params object[]' para permitir que cada clase reciba la cantidad exacta de datos que necesita
        Task InsertarAsync(params object[] parametros);

        Task EditarAsync(params object[] parametros);

        Task EliminarAsync(int id);
    }
}