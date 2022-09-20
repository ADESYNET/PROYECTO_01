using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_01
{ 
    //Autor: Kim Martinez
    //Fecha: 02/05/2014

    internal class cls_Parametros
    {
        // Atributos 
        private string m_Nombre;
        private object m_Valor;
        private string m_ValorS;

        // Atributos de registro 
        private SqlDbType m_TipoDato;
        private ParameterDirection m_Direccion;
        private int m_Tamaño;

        // Propiedades 
        public string Nombre
        {
            get { return m_Nombre; }
            set { m_Nombre = value; }
        }

        public object Valor
        {
            get { return m_Valor; }
            set { m_Valor = value; }
        }
        public SqlDbType TipoDato
        {
            get { return m_TipoDato; }
            set { m_TipoDato = value; }
        }
        public ParameterDirection Direccion
        {
            get { return m_Direccion; }
            set { m_Direccion = value; }
        }
        public int Tamaño
        {
            get { return m_Tamaño; }
            set { m_Tamaño = value; }
        }
        public string ValorS
        {
            get { return m_ValorS; }
            set { m_ValorS = value; }
        }

        //Constructor para los paramtros para crear XML
        /* public cls_Parametros(string ObjNombre, string ObjValorS)
         {
             m_Nombre = ObjNombre;
             m_ValorS = ObjValorS;
         }
        */

        //Constructor para los paramtros que no son de salida 
        public cls_Parametros(string ObjNombre, object ObjValor)
        {
            m_Nombre = ObjNombre;
            m_Valor = ObjValor;
            m_ValorS = ObjValor.ToString();
            m_Direccion = ParameterDirection.Input;
        }
        // Constructor  prara los parametros de salida 
        public cls_Parametros(string ObjNombre, object ObjValor, SqlDbType ObjTipoDato, ParameterDirection ObjDireccion, int ObjTamaño)
        {
            m_Nombre = ObjNombre;
            m_Valor = ObjValor;
            m_Direccion = ObjDireccion;
            m_TipoDato = ObjTipoDato;
            m_Tamaño = ObjTamaño;
        }
    }
}
