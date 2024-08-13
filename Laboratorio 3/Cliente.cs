using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

   
namespace Laboratorio_3
{
    public class Clientes 
    {
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }


        public Clientes(string nombre, string correo, string direccion)
        {
            this.Nombre = nombre;
            this.Correo = correo;
            this.Direccion = direccion;
        }

        public override string ToString()
        {
            return $"Nombre: {Nombre}, Correo: {Correo}, Dirección: {Direccion}";
        }
    }

}
