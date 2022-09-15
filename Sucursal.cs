using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_01
{
    internal class Sucursal
    {
        private string codigo;
        private string nombre;

        public Sucursal(string codigo, string nombre)
        {
            this.codigo = codigo;
            this.nombre = nombre;
        }

        public string getCodigo()
        {
            return codigo;
        }

        public string getNombre()
        {
            return nombre;
        }

        public void setCodigo(string c)
        {
            this.codigo = c;
        }

        public void setNombre(string n)
        {
            this.nombre = n;
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
