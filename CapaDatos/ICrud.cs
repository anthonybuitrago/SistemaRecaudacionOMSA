using System;
using System.Data;
using System.Threading.Tasks;

namespace CapaDatos
{
    // TODO: [REQUISITO] - Interfaces: Contrato para estandarizar el comportamiento de las clases de datos.

    // Contrato base que estandariza las operaciones transaccionales (Implementación de Interfaces)
    public interface ICrud
    {
        // Recupera un conjunto de datos estructurado desde la base de datos
        Task<DataTable> MostrarAsync();

        // Inserta un nuevo registro utilizando un arreglo dinámico de parámetros
        Task InsertarAsync(params object[] parametros);

        // Modifica la información de un registro existente en el sistema
        Task EditarAsync(params object[] parametros);

        // Ejecuta la eliminación (física o lógica) de un registro mediante su identificador
        Task EliminarAsync(int id);
    }
}