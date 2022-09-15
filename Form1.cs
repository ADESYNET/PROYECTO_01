using Microsoft.SqlServer.Management.Sdk.Sfc;
using Microsoft.VisualBasic.ApplicationServices;
using Newtonsoft.Json;
using System.CodeDom.Compiler;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO.Compression;
using System.Text.Json.Serialization;
using System.Xml;

namespace PROYECTO_01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardarDatosConexion_Click(object sender, EventArgs e)
        {
            //capturar datos
            string servidor, usuario, contrasena, bbdd;

            servidor    = txtServidor.Text;
            usuario     = txtUsuario.Text;
            contrasena  = txtContrasena.Text;
            bbdd        = txtBaseDatos.Text;

            //Convertir los datos en un Json
            var DatosConexion = new
            {
                Servidor    = servidor,
                Usuario     = usuario,
                Contrasena  = contrasena,
                BaseDatos   = bbdd
            };

            var miJson = JsonConvert.SerializeObject(DatosConexion);

            try
            {
                //Guardar el Json en un archivo
                File.WriteAllText("DatosConexion.json", miJson);
                MessageBox.Show("Se guardó la conexión..");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection cnx = null;

            //Recuperar los datos de conexión a la base de datos en caso ya exista una.
            if (File.Exists("DatosConexion.json"))
            {
                string DatosConexion        = File.ReadAllText("DatosConexion.json");
                dynamic jsonDatosConexion   = JsonConvert.DeserializeObject(DatosConexion);

                this.txtBaseDatos.Text  = jsonDatosConexion.BaseDatos;
                this.txtContrasena.Text = jsonDatosConexion.Contrasena;
                this.txtServidor.Text   = jsonDatosConexion.Servidor;
                this.txtUsuario.Text    = jsonDatosConexion.Usuario;

                cnx = AbrirConexion(this.txtUsuario.Text, this.txtContrasena.Text, this.txtBaseDatos.Text, this.txtServidor.Text);

                this.txtRutaZip.Text = getRutaZip(cnx);

               //Cargar sucursales
                List<Sucursal> mislocales  = getSucursales(cnx);
                foreach(Sucursal sucursal in mislocales)
                {
                    this.listSucursales.Items.Add(sucursal.getNombre());
                }

                //limipiar lista sucursales de selecionados
                this.listSeleccion.Items.Clear();
                

            }
        }

        public  SqlConnection AbrirConexion(string pUser, string pContrasena, string pBaseDatos, string pServidor)
        {
            string CadenaConexion = $"Persist Security Info=False;User ID={pUser};Password={pContrasena};Initial Catalog={pBaseDatos};Server={pServidor}";
            SqlConnection conexion = null;
            conexion = new SqlConnection(CadenaConexion);

            conexion.Open();

            return conexion;

        }

        static string getRutaZip(SqlConnection c)
        {
            SqlCommand qry = new SqlCommand("select ruta_env from r_Actu", c);
            SqlDataReader respuesta = qry.ExecuteReader();

            if (respuesta.Read())
            {
                string ruta = (string)respuesta.GetSqlString(0);
                respuesta.Close();
                return ruta;
            }
            else
            {
                respuesta.Close();
                return "";
            }
            
        }

        static List<Sucursal> getSucursales(SqlConnection c)
        {
            List<Sucursal> sucursales = new List<Sucursal>();

            SqlCommand qry = new SqlCommand("SELECT cdlocal,nombre From Locales Where cdLocal<>'00' and flgborrado=0 AND flgcierreoperaciones=0 order by cdlocal", c);
            SqlDataReader respuesta = qry.ExecuteReader();

            while (respuesta.Read())
            {
                //MessageBox.Show($"{(string)respuesta[0]}- {(string)respuesta[1]}");

                sucursales.Add(
                    new Sucursal(
                        (string)respuesta[0],
                        $"{(string)respuesta[0]}- {(string)respuesta[1]}"
                    )
                );
                //(string)respuesta.GetSqlString(0),
                //$"{(string)respuesta.GetSqlString(0)}- {(string)respuesta.GetSqlString(1)}"
            }

            respuesta.Close();

            return sucursales;
        }

        private void btnDerecha_Click(object sender, EventArgs e)
        {
            //el seleccionado en la lista de la izquierda pasa a la derecha
            if (this.listSucursales.SelectedItem != null)
            {
                this.listSeleccion.Items.Add(this.listSucursales.SelectedItem);
                this.listSucursales.Items.Remove(this.listSucursales.SelectedItem);
            }
        }

        private void btnDerechaTodo_Click(object sender, EventArgs e)
        {
            this.listSeleccion.Items.AddRange(this.listSucursales.Items);
            this.listSucursales.Items.Clear();
        }

        private void btnIzquierda_Click(object sender, EventArgs e)
        {
            if (this.listSeleccion.SelectedItem != null)
            {
                this.listSucursales.Items.Add(this.listSeleccion.SelectedItem);
                this.listSeleccion.Items.Remove(this.listSeleccion.SelectedItem);
            }
        }

        private void btnIzquierdaTodo_Click(object sender, EventArgs e)
        {
            this.listSucursales.Items.AddRange(this.listSeleccion.Items);
            this.listSeleccion.Items.Clear();
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            //recorrer las sucursales
            if (this.listSeleccion.Items.Count == 0)
                return;

            foreach (var item in this.listSeleccion.Items)
            {
                //Ejecutar la recepción de la información
                ThreadPool.QueueUserWorkItem(RecuperarInformacionAsync,);
                
            }

        }

        static void RecuperarInformacion(string pRutaXML, SqlConnection cnx, string nombreSP, string pCdlocal, string pRutaZip )
        {
            //Crear la carpeta para descomprimir el zip del local
            if (pRutaXML.Substring(pRutaXML.Length - 1, 1) == "\\")
            {
                Directory.CreateDirectory($"{pRutaXML}{pCdlocal}");
            }
            else
            {
                Directory.CreateDirectory($"{pRutaXML}\\{pCdlocal}");
            }

            //descomprimir el zip
            try
            {
                ZipFile.ExtractToDirectory(pRutadelZIP, pRutaDondeSeVaDescomprimir);
                Console.WriteLine("Descompresión exitosa..");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            SqlXml miXML = new SqlXml(new XmlTextReader(pRutaXML));

            string qry = $"exec {nombreSP} @xmlParameter";

            SqlCommand consulta = new SqlCommand(qry, cnx);
            
            consulta.Parameters.AddWithValue("@xmlParameter", miXML);

            try
            {
                consulta.ExecuteNonQuery();
                Console.WriteLine("Proceso terminado");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            
        }

        /*******POOL DE HILOS - EJEMPLO
        ProbandoPoolHilos ProbandoPoolHilosObject = new ProbandoPoolHilos();
        //ProbandoPoolHilosObject.EjecutarProceso();

        for (int i = 0; i < 100; i++) 
        {
            //Thread t = new Thread(ejecutar);
            //t.Start();

            ThreadPool.QueueUserWorkItem(ejecutar,i);
        }

        Console.ReadLine();

        void ejecutar(Object stateInfo)
        {
            int nTarea = (int)stateInfo;

            ProbandoPoolHilosObject.EjecutarProceso(nTarea);
        }
        *************/
    }
}