using System;
using System.Data;
using System.Threading.Tasks;

namespace CapaDatos
{
    // TODO: [REQUISITO] - Interfaces
    // Contrato base para estandarizar las operaciones CRUD en todas las clases de datos
    public interface ICrud
    {
        // Obtiene un conjunto de datos estructurado
        Task<DataTable> MostrarAsync();

        // Inserta un nuevo registro utilizando un arreglo dinámico de parámetros
        Task InsertarAsync(params object[] parametros);

        // Modifica un registro existente
        Task EditarAsync(params object[] parametros);

        // Elimina física o lógicamente un registro según el identificador
        Task EliminarAsync(int id);
    }
}