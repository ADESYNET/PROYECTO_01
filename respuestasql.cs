using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace PROYECTO_01
{
    internal class respuestasql
    {
        public List<SqlDataReader> respuetassql = new List<SqlDataReader>();

        public SqlDataReader respuesta1;
        public SqlDataReader respuesta2;
        public SqlDataReader respuesta3;
        public SqlDataReader respuesta4;
        public SqlDataReader respuesta5;
        public SqlDataReader respuesta6;
        public SqlDataReader respuesta7;
        public SqlDataReader respuesta8;
        public SqlDataReader respuesta9;
        public SqlDataReader respuesta10;
        public SqlDataReader respuesta11;
        public SqlDataReader respuesta12;
        public SqlDataReader respuesta13;
        public SqlDataReader respuesta14;
        public SqlDataReader respuesta15;
        public SqlDataReader respuesta16;
        public SqlDataReader respuesta17;
        public SqlDataReader respuesta18;
        public SqlDataReader respuesta19;
        public SqlDataReader respuesta20;
        public SqlDataReader respuesta21;
        public SqlDataReader respuesta22;
        public SqlDataReader respuesta23;
        public SqlDataReader respuesta24;
        public SqlDataReader respuesta25;
        public SqlDataReader respuesta26;
        public SqlDataReader respuesta27;
        public SqlDataReader respuesta28;
        public SqlDataReader respuesta29;
        public SqlDataReader respuesta30;

        public SqlDataReader getRespuesta(SqlDataReader respuesta)
        {
            for (int i=0; i<respuetassql.Count(); i++)
            {
                if (respuetassql[i].IsClosed)
                {
                    respuetassql[i] = respuesta;
                    return respuetassql[i];
                }
            }

            return null;
        }

        public void _respuestas()
        {
            respuetassql.Add(respuesta1);
            respuetassql.Add(respuesta2);
            respuetassql.Add(respuesta3);
            respuetassql.Add(respuesta4);
            respuetassql.Add(respuesta5);
            respuetassql.Add(respuesta6);
            respuetassql.Add(respuesta7);
            respuetassql.Add(respuesta8);
            respuetassql.Add(respuesta9);
            respuetassql.Add(respuesta10);
            respuetassql.Add(respuesta11);
            respuetassql.Add(respuesta12);
            respuetassql.Add(respuesta13);
            respuetassql.Add(respuesta14);
            respuetassql.Add(respuesta15);
            respuetassql.Add(respuesta16);
            respuetassql.Add(respuesta17);
            respuetassql.Add(respuesta18);
            respuetassql.Add(respuesta19);
            respuetassql.Add(respuesta20);               
            respuetassql.Add(respuesta21);
            respuetassql.Add(respuesta22);
            respuetassql.Add(respuesta23);
            respuetassql.Add(respuesta24);
            respuetassql.Add(respuesta25);
            respuetassql.Add(respuesta26);
            respuetassql.Add(respuesta27);
            respuetassql.Add(respuesta28);
            respuetassql.Add(respuesta29);
            respuetassql.Add(respuesta30);
        }
    }    
}
