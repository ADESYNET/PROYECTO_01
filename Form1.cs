using Microsoft.VisualBasic.ApplicationServices;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Text.Json.Serialization;

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

               
                List<Sucursal> mislocales  = getSucursales(cnx);
                foreach(Sucursal sucursal in mislocales)
                {
                    this.listSucursales.Items.Add(sucursal.ToString);
                }

                //this.listSucursales.DataSource = mislocales;
                //this.listSucursales.DisplayMember = "codigo";
                //this.listSucursales.ValueMember = "nombre";
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
            SqlDataReader respuesta2 = qry.ExecuteReader();

            while (respuesta2.Read())
            {
                sucursales.Add(
                    new Sucursal(
                        (string)respuesta2.GetSqlString(0),
                        $"{(string)respuesta2.GetSqlString(0)}- {(string)respuesta2.GetSqlString(1)}"
                    )
                );
            }

            respuesta2.Close();

            return sucursales;
        }
    }
}