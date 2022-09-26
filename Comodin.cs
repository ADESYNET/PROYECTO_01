//using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace PROYECTO_01
{
    internal class Comodin
    {
        public string rutaDescomprimir;
        public SqlConnection conexion;
        public string cdlocal;
        public string rutaZip;
        public Comodin(string rutaDescomprimir, SqlConnection conexion, string cdlocal, string rutaZip)
        {
            this.rutaDescomprimir = rutaDescomprimir;
            this.conexion = conexion;
            this.cdlocal = cdlocal;
            this.rutaZip = rutaZip;
        }
    }
}
