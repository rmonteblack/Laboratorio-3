using System;

namespace Laboratorio_3
{
    internal class Pedidos
    {
  
        public int Numero { get; set; } 
        public int Fecha { get; set; } 

   
        public Clientes Cliente { get; set; }
        public Vehiculo Vehiculo { get; set; }

        
        public string Lista { get; set; }

        public Pedidos(int numero, int fecha, Clientes cliente, Vehiculo vehiculo, string lista)
        {
            Numero = numero;
            Fecha = fecha;
            Cliente = cliente;
            Vehiculo = vehiculo;
            Lista = lista;
        }

      
        public override string ToString()
        {
            return $"Número de Pedido: {Numero}, Fecha: {Fecha}, Cliente: {Cliente.Nombre}, " +
                   $"Vehículo: {Vehiculo.Matricula}, Lista: {Lista}";
        }
    }
}
