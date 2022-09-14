using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_01
{
    internal class Sucursal
    {
        private string codigo { get; set; }
        private string nombre { get; set; }

        public Sucursal(string codigo, string nombre)
        {
            this.codigo = codigo;
            this.nombre = nombre;
        }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string? ToString()
        {
            return base.ToString();
        }
    }
}
