using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_3
{
    internal class Vehiculo
    {
        public int Matricula {  get; set; }
        public int Modelo { get; set; }
        public string Combustible { get; set; }

        public Vehiculo (int matricula, int modelo, string combustible)
        {
            Matricula = matricula;
            Modelo = modelo;
            Combustible = combustible;
        }
        public override string ToString()
        {
            return $"Matrícula: {Matricula}, Modelo: {Modelo}, Combustible: {Combustible}";
        }
    }
}
