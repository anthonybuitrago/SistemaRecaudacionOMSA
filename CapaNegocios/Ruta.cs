using System;

namespace CapaNegocios
{
    public class Ruta
    {
        // Propiedades del objeto
        public int ID_Ruta { get; set; }
        public string NombreRuta { get; set; }
        public decimal TarifaPasaje { get; set; }

        // Constructor para crear la ruta con datos
        public Ruta(int id, string nombre, decimal tarifa)
        {
            ID_Ruta = id;
            NombreRuta = nombre;
            TarifaPasaje = tarifa;
        }
    }
}