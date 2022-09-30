using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_01
{
    internal class logProceso
    {
        private string cdlocal;
        private string zip;
        private string xml;
        private string mensaje;

        public logProceso(string cdlocal, string zip, string xml, string mensaje)
        {
            this.cdlocal = cdlocal;
            this.zip = zip;
            this.xml = xml;
            this.mensaje = mensaje;

        }

        
    }
}
