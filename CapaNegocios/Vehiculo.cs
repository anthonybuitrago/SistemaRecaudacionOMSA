using System;

namespace CapaNegocios
{
    public class Vehiculo
    {
        // Propiedades del objeto
        public int ID_Vehiculo { get; set; }
        public string Ficha { get; set; }
        public string Placa { get; set; }
        public int Capacidad { get; set; }

        // Constructor
        public Vehiculo(int id, string ficha, string placa, int capacidad)
        {
            ID_Vehiculo = id;
            Ficha = ficha;
            Placa = placa;
            Capacidad = capacidad;
        }
    }
}