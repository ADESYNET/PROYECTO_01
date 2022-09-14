namespace PROYECTO_01
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabPrincipal = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtRutaZip = new System.Windows.Forms.TextBox();
            this.lblRutaZip = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnGuardarDatosConexion = new System.Windows.Forms.Button();
            this.txtBaseDatos = new System.Windows.Forms.TextBox();
            this.txtContrasena = new System.Windows.Forms.TextBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtServidor = new System.Windows.Forms.TextBox();
            this.lblBaseDatos = new System.Windows.Forms.Label();
            this.lblContrasena = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblServidor = new System.Windows.Forms.Label();
            this.listSucursales = new System.Windows.Forms.ListBox();
            this.tabPrincipal.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPrincipal
            // 
            this.tabPrincipal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabPrincipal.Controls.Add(this.tabPage1);
            this.tabPrincipal.Controls.Add(this.tabPage2);
            this.tabPrincipal.Controls.Add(this.tabPage3);
            this.tabPrincipal.Location = new System.Drawing.Point(12, 12);
            this.tabPrincipal.Name = "tabPrincipal";
            this.tabPrincipal.SelectedIndex = 0;
            this.tabPrincipal.Size = new System.Drawing.Size(727, 391);
            this.tabPrincipal.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listSucursales);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(719, 363);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Sucursales";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 15);
            this.label1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtRutaZip);
            this.tabPage2.Controls.Add(this.lblRutaZip);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(719, 363);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "ZIP";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtRutaZip
            // 
            this.txtRutaZip.Location = new System.Drawing.Point(126, 12);
            this.txtRutaZip.Name = "txtRutaZip";
            this.txtRutaZip.Size = new System.Drawing.Size(321, 23);
            this.txtRutaZip.TabIndex = 1;
            // 
            // lblRutaZip
            // 
            this.lblRutaZip.AutoSize = true;
            this.lblRutaZip.Location = new System.Drawing.Point(6, 15);
            this.lblRutaZip.Name = "lblRutaZip";
            this.lblRutaZip.Size = new System.Drawing.Size(114, 15);
            this.lblRutaZip.TabIndex = 0;
            this.lblRutaZip.Text = "Ruta de archivos ZIP";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnGuardarDatosConexion);
            this.tabPage3.Controls.Add(this.txtBaseDatos);
            this.tabPage3.Controls.Add(this.txtContrasena);
            this.tabPage3.Controls.Add(this.txtUsuario);
            this.tabPage3.Controls.Add(this.txtServidor);
            this.tabPage3.Controls.Add(this.lblBaseDatos);
            this.tabPage3.Controls.Add(this.lblContrasena);
            this.tabPage3.Controls.Add(this.lblUsuario);
            this.tabPage3.Controls.Add(this.lblServidor);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(719, 363);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Conexión";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnGuardarDatosConexion
            // 
            this.btnGuardarDatosConexion.Location = new System.Drawing.Point(406, 18);
            this.btnGuardarDatosConexion.Name = "btnGuardarDatosConexion";
            this.btnGuardarDatosConexion.Size = new System.Drawing.Size(107, 49);
            this.btnGuardarDatosConexion.TabIndex = 8;
            this.btnGuardarDatosConexion.Text = "Guardar datos de conexión";
            this.btnGuardarDatosConexion.UseVisualStyleBackColor = true;
            this.btnGuardarDatosConexion.Click += new System.EventHandler(this.btnGuardarDatosConexion_Click);
            // 
            // txtBaseDatos
            // 
            this.txtBaseDatos.Location = new System.Drawing.Point(126, 129);
            this.txtBaseDatos.Name = "txtBaseDatos";
            this.txtBaseDatos.Size = new System.Drawing.Size(230, 23);
            this.txtBaseDatos.TabIndex = 7;
            // 
            // txtContrasena
            // 
            this.txtContrasena.Location = new System.Drawing.Point(126, 87);
            this.txtContrasena.Name = "txtContrasena";
            this.txtContrasena.Size = new System.Drawing.Size(230, 23);
            this.txtContrasena.TabIndex = 6;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(126, 49);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(230, 23);
            this.txtUsuario.TabIndex = 5;
            // 
            // txtServidor
            // 
            this.txtServidor.Location = new System.Drawing.Point(126, 15);
            this.txtServidor.Name = "txtServidor";
            this.txtServidor.Size = new System.Drawing.Size(230, 23);
            this.txtServidor.TabIndex = 4;
            // 
            // lblBaseDatos
            // 
            this.lblBaseDatos.AutoSize = true;
            this.lblBaseDatos.Location = new System.Drawing.Point(22, 132);
            this.lblBaseDatos.Name = "lblBaseDatos";
            this.lblBaseDatos.Size = new System.Drawing.Size(79, 15);
            this.lblBaseDatos.TabIndex = 3;
            this.lblBaseDatos.Text = "Base de datos";
            // 
            // lblContrasena
            // 
            this.lblContrasena.AutoSize = true;
            this.lblContrasena.Location = new System.Drawing.Point(22, 90);
            this.lblContrasena.Name = "lblContrasena";
            this.lblContrasena.Size = new System.Drawing.Size(67, 15);
            this.lblContrasena.TabIndex = 2;
            this.lblContrasena.Text = "Contraseña";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(22, 52);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(47, 15);
            this.lblUsuario.TabIndex = 1;
            this.lblUsuario.Text = "Usuario";
            // 
            // lblServidor
            // 
            this.lblServidor.AutoSize = true;
            this.lblServidor.Location = new System.Drawing.Point(22, 18);
            this.lblServidor.Name = "lblServidor";
            this.lblServidor.Size = new System.Drawing.Size(50, 15);
            this.lblServidor.TabIndex = 0;
            this.lblServidor.Text = "Servidor";
            this.lblServidor.Click += new System.EventHandler(this.label1_Click);
            // 
            // listSucursales
            // 
            this.listSucursales.FormattingEnabled = true;
            this.listSucursales.ItemHeight = 15;
            this.listSucursales.Location = new System.Drawing.Point(6, 6);
            this.listSucursales.Name = "listSucursales";
            this.listSucursales.Size = new System.Drawing.Size(221, 349);
            this.listSucursales.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 415);
            this.Controls.Add(this.tabPrincipal);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabPrincipal.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl tabPrincipal;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private Label lblServidor;
        private Button btnGuardarDatosConexion;
        private TextBox txtBaseDatos;
        private TextBox txtContrasena;
        private TextBox txtUsuario;
        private TextBox txtServidor;
        private Label lblBaseDatos;
        private Label lblContrasena;
        private Label lblUsuario;
        private Label label1;
        private TextBox txtRutaZip;
        private Label lblRutaZip;
        private ListBox listSucursales;
    }
}