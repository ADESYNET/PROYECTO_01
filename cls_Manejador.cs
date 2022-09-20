using Microsoft.Data.SqlClient;
using Microsoft.SqlServer.Management.Smo;
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

    internal class cls_Manejador
    {
        private static string CadenaConexion;
        private SqlConnection nConexion = new SqlConnection(CadenaConexion);

        public void setCadenaConexion(string c)
        {
            CadenaConexion = c;
        }

        public string getCadenaConexion()
        {
            return CadenaConexion;
        }

        //Crear la funcion de conectar y desconectar 
        public static bool conectar(SqlConnection cnx)
        {
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        //Crear la funcion de conectar y desconectar 
        public static bool Desconectar(SqlConnection cnx)
        {
            try
            {
                if (cnx.State == ConnectionState.Open)
                    cnx.Close();
                
                return true;
            }
            catch
            {
                return false;
            }
        }
        // Función para crear para ejecutar procedimientos de consultas y retornar un dataset de sql
        public DataTable EjecutaSQL(string NombreSP, List<cls_Parametros> lst)
        {
            DataTable dt = new DataTable(); // creamos el data table 
            SqlDataAdapter da; // Creaos el adaptador 
            try
            {
                conectar(this.nConexion);
                da = new SqlDataAdapter(NombreSP, nConexion);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                if (lst != null)
                {
                    // recorremos la lista generica 
                    for (int i = 0; i < lst.Count; i++)
                    {
                        // Pasamos cada uno de los parametros 
                        da.SelectCommand.Parameters.AddWithValue(lst[i].Nombre, lst[i].Valor);
                    }
                }
                da.Fill(dt);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            Desconectar(this.nConexion);
            return dt;
        }

        // Funcion para guardar informacion en la base de datos SQL  
        public void EjecutarSP(SqlConnection cnx, string NombreSP, ref List<cls_Parametros> lst)
        {
            // Declarar una variable de tipo comando 
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand(NombreSP, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                //Verificar si la lista generica de parametros no esta vacia 
                if (lst != null)
                {
                    // Recorrer la lista 
                    for (int i = 0; i < lst.Count; i++)
                    {
                        // Verificar si los parametros son de entrada 
                        if (lst[i].Direccion == ParameterDirection.Input)
                            cmd.Parameters.AddWithValue(lst[i].Nombre, lst[i].Valor);
                        // Verificar si los parametros son de salida 
                        if (lst[i].Direccion == ParameterDirection.Output)
                            cmd.Parameters.Add(lst[i].Nombre, lst[i].TipoDato, lst[i].Tamaño).Direction = ParameterDirection.Output;
                    }
                    // Ejecutar la sentencia 
                    cmd.ExecuteNonQuery();
                    // Recuperamos los datos de salida 
                    for (int i = 0; i < lst.Count; i++)
                    {
                        if (cmd.Parameters[i].Direction == ParameterDirection.Output)
                            lst[i].Valor = cmd.Parameters[i].Value;
                    }
                }
            }
            catch (Exception ex)
            {
                // return false;
                throw ex;
            }
        }
    }
}
