using MaterialSkin;
using MaterialSkin.Controls;
using Microsoft.SqlServer.Management.Sdk.Sfc;
using Microsoft.VisualBasic.ApplicationServices;
using Newtonsoft.Json;
using System.CodeDom.Compiler;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO.Compression;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using System.Windows.Forms;
using System.Xml;
using System.Linq;

namespace PROYECTO_01
{
    public partial class Form1 : MaterialForm
    {
        public Form1()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(getColor(44, 77, 121), getColor(44, 77, 121), Primary.BlueGrey800, Accent.LightBlue700, TextShade.WHITE);
        }

        private static MaterialSkin.Primary getColor(int R, int G, int B)
        {
            return (MaterialSkin.Primary)(R * 65536 + G * 256 + B);
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
            SqlConnection cnx = new SqlConnection();

            //Recuperar los datos de conexión base de datos en caso ya exista una.
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
                this.txtRutaDescomprimir.Text = getRutaDescomprimir();

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
            SqlConnection conexion = new SqlConnection(CadenaConexion);

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
                ruta = ruta.Trim();

                respuesta.Close();
                return ruta;
            }
            else
            {
                respuesta.Close();

                //Si no la encuentras en la base de datos tomar en cuenta que puede estar en el archivo.
                if (!File.Exists("EntornoZIP.json"))
                    return "";

                string EntornoZip = File.ReadAllText("EntornoZIP.json");
                dynamic jsonEntornoZIP = JsonConvert.DeserializeObject(EntornoZip);

                return jsonEntornoZIP.RutaZip;

            }
            
        }

        static string getRutaDescomprimir()
        {
            if (!File.Exists("EntornoZIP.json"))
                return "";

            string EntornoZip = File.ReadAllText("EntornoZIP.json");
            dynamic jsonEntornoZIP = JsonConvert.DeserializeObject(EntornoZip);

            return jsonEntornoZIP.RutaDescomprimir;
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

            Console.WriteLine("hola mundus");

            foreach (var item in this.listSeleccion.Items)
            {
                //Ejecutar la recepción de la información
                //ThreadPool.QueueUserWorkItem(RecuperarInformacionAsync,);
                
            }

        }

        static bool zip_ya_fue_procesado(string UltimoArchivoProcesado,string ZipProcesar)
        {
            return UltimoArchivoProcesado.ToUpper().Equals(ZipProcesar.Trim().ToUpper());
            
        }

        static string getUltimoArchivoProcesado(string pCdlocal, SqlConnection c)
        {
            SqlCommand qry = new SqlCommand($"select max(archivo) as archivo from datalocales where cdlocalOrigen='{pCdlocal}'", c);
            SqlDataReader respuesta = qry.ExecuteReader();
            string ultimoArchivoCargado = "";

            if (respuesta.Read())
            {
                ultimoArchivoCargado = (string)respuesta.GetSqlString(0);
                ultimoArchivoCargado = ultimoArchivoCargado.Trim();

                respuesta.Close();
            }

            return ultimoArchivoCargado;
        }

        static FileInfo[] getArchivosRecepcionados(string pCdlocal,string pRutaZIP, string UltimoArchivoProcesado)
        {
            //accediento a la carpeta con los zip
            DirectoryInfo Metadata_de_la_carpeta = new DirectoryInfo(pRutaZIP);
            FileInfo[] misArchivos = null;
            
            //recorremos los archivos ordenados por fecha de creación
            foreach (FileInfo Archivo in Metadata_de_la_carpeta.GetFiles().OrderBy(p => p.CreationTime))
            {
                //Si el archivo corresponde a la sucursal y aún no ha sido Procesado, se agrega al arreglo de archivos recepcionados
                if (Archivo.Name.ToUpper().Contains($"ENVIO_{pCdlocal}") && 
                    !zip_ya_fue_procesado(UltimoArchivoProcesado.ToUpper(), Archivo.Name.ToUpper())) 
                {
                    misArchivos.Append(Archivo);

                    //Este break es para evitar que siga buscando archivos si ya llegó al último procesado..
                    if (zip_ya_fue_procesado(UltimoArchivoProcesado.ToUpper(), Archivo.Name.ToUpper()))
                        break;
                }
            }

            return misArchivos;
        }

        private static bool ruta_termina_en_back_slash(string path)
        {
            return (path.Substring(path.Length - 1, 1) == "\\");
        }

        static void RecuperarInformacion(string pRutaDescoprimir, SqlConnection cnx, string nombreSP, string pCdlocal, string pRutaZip )
        {
            /*Procesar el archivo que nos ha enviado la sucursal.
             *Buscar todos los zip que ha enviado ese local (pueden ser varios).
             *
             */
            string UltimoProcesado      = getUltimoArchivoProcesado(pCdlocal, cnx);
            FileInfo[] misArchivosZip   = getArchivosRecepcionados(pCdlocal, pRutaZip, UltimoProcesado);

            if (misArchivosZip == null) //No hay archivos -> terminamos el proceso
                return;

            //por cada zip
            foreach (FileInfo Zip in misArchivosZip)
            {
                //crear una carpeta para descompimirlo
                //si la carpeta existe... se elimina sin asco
                string miCarpeta = ruta_termina_en_back_slash(pRutaDescoprimir) ? $"{pRutaDescoprimir}{pCdlocal}" : $"{pRutaDescoprimir}\\{pCdlocal}";

                try
                {
                    if (Directory.Exists(miCarpeta))
                        Directory.Delete(miCarpeta,true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }

                //se vuelve a crear..
                Directory.CreateDirectory(miCarpeta);

                //descomprimir el zip
                try
                {
                    string miZip = ruta_termina_en_back_slash(pRutaZip) ? $"{pRutaZip}{Zip}" : $"{pRutaZip}\\{Zip}";

                    ZipFile.ExtractToDirectory(miZip, miCarpeta);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }

                //con el zip descomprimido.. ahora tenemos todos los xml desparramados listos parar procesarlos en sql.

                
            }


            SqlXml miXML = new SqlXml(new XmlTextReader(pRutaDescoprimir));

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


        private void btnRutasZip_Click(object sender, EventArgs e)
        {
            //capturar datos
            string RutaZip, RutaDescomprimir;

            RutaZip = txtRutaZip.Text;
            RutaDescomprimir = txtRutaDescomprimir.Text;
            
            //Convertir los datos en un Json
            var EntornoZIP = new
            {
                RutaZip = RutaZip,
                RutaDescomprimir = RutaDescomprimir
            };

            var miJson = JsonConvert.SerializeObject(EntornoZIP);

            try
            {
                //Guardar el Json en un archivo
                File.WriteAllText("EntornoZIP.json", miJson);
                MessageBox.Show("Se guardaron los datos de zipeado..");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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