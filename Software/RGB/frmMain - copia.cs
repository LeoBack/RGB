﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//
using System.IO.Ports;
using System.Configuration;

namespace RGB
{
    public partial class frmMain : Form
    {
        // Colores
        static int[] RGB = {0, 0, 0};
        static int R = 0;
        static int G = 1;
        static int B = 2;
        // Formulario
        private string Titulo = "RGB";
        private int TrackMax = 255;
        private int TrackMin = 0;
        // Puerto
        private string[] Port;
        private SerialPort sPort;
        private string Enviar;
        private bool Demo;
        //
        private StringBuilder BufferString;
        List<string> SetInstrucciones = new List<string>();
        //
        // Temporizadores
        private Timer Temp;

        #region Formulario

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            // Inicializacion Buffer 
            this.BufferString = new StringBuilder();
            // Inicializacion Formulario
            this.Text = Titulo;
            this.BackColor = System.Drawing.Color.Black;
            this.ForeColor = System.Drawing.Color.Lime;
            //
            this.lblRed.Text = "Red";
            this.lblGreen.Text = "Green";
            this.lblBlue.Text = "Blue";
            //
            this.btnCerrar.Text = "Cerrar";
            this.btnConfig.Text = "Conf.";
            this.btnDemo.Text = "Demo";
            //
            this.sPort = new SerialPort();
            this.sPort.Encoding = Encoding.ASCII;
            this.sPort.ParityReplace = 0;
            this.sPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(sPort_DataReceived);
            this.sPort.ErrorReceived += new System.IO.Ports.SerialErrorReceivedEventHandler(sPort_ErrorReceived);
            this.sPort.PinChanged += new System.IO.Ports.SerialPinChangedEventHandler(sPort_PinChanged);
            //
            this.Temp = new Timer();
            this.Temp.Tick += new EventHandler(Temp_Tick);
            //
            this.Demo = false;
            //
            foreach (Control crt in this.tlpPanel.Controls)
            {
                if (crt is ComboBox)
                {
                    ComboBox tc = (ComboBox)crt;
                    tc.DropDownStyle = ComboBoxStyle.DropDownList;
                    tc.BackColor = this.BackColor;
                    tc.ForeColor = this.ForeColor;
                }

                if (crt is TrackBar)
                {
                    TrackBar tr = (TrackBar)crt;
                    tr.Maximum = TrackMax;
                    tr.Minimum = TrackMin;
                    tr.BackColor = this.BackColor;
                    tr.Cursor = System.Windows.Forms.Cursors.Hand;
                    tr.TickFrequency = 255;
                    tr.LargeChange = 5;
                }

                if (crt is Label)
                {
                    Label tl = (Label)crt;
                    tl.BackColor = this.BackColor;
                    tl.ForeColor = this.ForeColor;
                }

                if (crt is TextBox)
                {
                    TextBox tx = (TextBox)crt;
                    tx.ReadOnly = true;
                    tx.BorderStyle = BorderStyle.FixedSingle;
                    tx.TextAlign = HorizontalAlignment.Center;
                    tx.BackColor = this.BackColor;
                    tx.ForeColor = this.ForeColor;
                    tx.Text = this.tkbRed.Value.ToString();
                }

                if (crt is Button)
                {
                    Button tb = (Button)crt;
                    tb.FlatStyle = FlatStyle.Flat;
                }
            }
            // SerialPort
            Port = SerialPort.GetPortNames();

            if (Port == null || Port.Length <= 0)
            {
                MessageBox.Show("No se detectaron Interfazes series.\nEl programa se cerrara.",
                    "RGB", MessageBoxButtons.OK);
                this.Close();
            }
            else
            {
                this.cmbPuerto.Items.AddRange(Port);
                this.cmbPuerto.SelectedIndex = 0;
                this.Text = Titulo + " - Puertos detectados: " + Port.Length.ToString();
                // Cargo configuracion del puerto.
                this.lblStatus.Text = "Leyendo configuracion.";
                this.LoadAppConfig();
                this.intentosCnx();
                this.loadCmsColor();
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (sPort != null)
            {
                //if (sPort.IsOpen)
                //{
                //    try
                //    {
                //        sPort.Close();
                //        //e.Cancel = false;
                //    }
                //    catch (InvalidOperationException ax)
                //    {
                //        MessageBox.Show(ax.ToString());
                //        e.Cancel = true;
                //    }
                //}
            }
        }

        #endregion

        #region Configuracion

        /// <summary>
        /// Lee o crea el archivo de configuracion.
        /// OK - 12/04/14.
        /// </summary>
        private void LoadAppConfig()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            if (ConfigurationManager.AppSettings["BaudRate"] != null)
                this.sPort.BaudRate = Convert.ToInt32(ConfigurationManager.AppSettings["BaudRate"]);
            else
            {
                config.AppSettings.Settings.Add("BaudRate", "9600");
                config.Save(ConfigurationSaveMode.Modified);
            }

            if (ConfigurationManager.AppSettings["DataBits"] != null)
                this.sPort.DataBits = Convert.ToInt32(ConfigurationManager.AppSettings["DataBits"]);
            else
            {
                config.AppSettings.Settings.Add("DataBits", "8");
                config.Save(ConfigurationSaveMode.Modified);
            }

            if (ConfigurationManager.AppSettings["Handshake"] != null)
                this.sPort.Handshake = (Handshake)Enum.Parse(typeof(Handshake), ConfigurationManager.AppSettings["Handshake"].ToString());
            else
            {
                config.AppSettings.Settings.Add("Handshake", Handshake.None.ToString());
                config.Save(ConfigurationSaveMode.Modified);
            }

            if (ConfigurationManager.AppSettings["Parity"] != null)
                this.sPort.Parity = (Parity)Enum.Parse(typeof(Parity), ConfigurationManager.AppSettings["Parity"].ToString());
            else
            {
                config.AppSettings.Settings.Add("Parity", Parity.None.ToString());
                config.Save(ConfigurationSaveMode.Modified);
            }

            if (ConfigurationManager.AppSettings["StopBits"] != null)
                this.sPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), ConfigurationManager.AppSettings["StopBits"].ToString());
            else
            {
                config.AppSettings.Settings.Add("StopBits", StopBits.One.ToString());
                config.Save(ConfigurationSaveMode.Modified);
            }
        }

        /// <summary>
        /// Actualiza el archivo de configuracion
        /// OK - 12/04/14.
        /// </summary>
        private void RefreshAppConfig()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["BaudRate"].Value = this.sPort.BaudRate.ToString();
            config.AppSettings.Settings["DataBits"].Value = this.sPort.DataBits.ToString();
            config.AppSettings.Settings["Handshake"].Value = this.sPort.Handshake.ToString();
            config.AppSettings.Settings["Parity"].Value = this.sPort.Parity.ToString();
            config.AppSettings.Settings["StopBits"].Value = this.sPort.StopBits.ToString();
            config.Save(ConfigurationSaveMode.Modified);
        }

        #endregion

        #region Controles en el Formulario

        private void cmbPuerto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sPort.IsOpen)
                sPort.Close();

            if (!sPort.IsOpen)
            {
                this.sPort.PortName = cmbPuerto.SelectedItem.ToString();
                this.intentosCnx();
            }
        }

        private void tkbRed_Scroll(object sender, EventArgs e)
        {
            RGB[R] = this.tkbRed.Value;
            this.RefreshForm();
            this.Invoke(new EventHandler(sPort_SendRang));
        }

        private void tkbGreen_Scroll(object sender, EventArgs e)
        {
            RGB[B] = this.tkbGreen.Value;
            this.RefreshForm();
            this.Invoke(new EventHandler(sPort_SendRang));
        }

        private void tkbBlue_Scroll(object sender, EventArgs e)
        {
            RGB[G] = this.tkbBlue.Value;
            this.RefreshForm();
            this.Invoke(new EventHandler(sPort_SendRang));
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSetings_Click(object sender, EventArgs e)
        {
            frmSettings frms = new frmSettings();
            frms.sPort = this.sPort;

            if (frms.ShowDialog() == DialogResult.OK)
            {
                this.sPort = frms.sPort;
                RefreshAppConfig();
            }
        }

        private void btnDemo_Click(object sender, EventArgs e)
        {
            this.Demo = true;
            RGB[R] = 0;
            RGB[B] = 0;
            RGB[G] = 0;
            this.RefreshForm();
            this.Invoke(new EventHandler(sPort_SendRang));
        }

        private void cmsColor_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            System.Drawing.Color Cr = System.Drawing.Color.FromName(e.ClickedItem.Text);

            RGB[R] = Convert.ToInt32(Cr.R);
            RGB[B] = Convert.ToInt32(Cr.G);
            RGB[G] = Convert.ToInt32(Cr.B);

            this.RefreshForm();

            this.Invoke(new EventHandler(sPort_SendRang));
        }

        private void pic_Click(object sender, EventArgs e)
        {
            ColorDialog fColor = new ColorDialog();
            fColor.Color = System.Drawing.Color.FromArgb(RGB[R], RGB[B], RGB[G]);

            if (fColor.ShowDialog() == DialogResult.OK)
            {
                RGB[R] = fColor.Color.R;
                RGB[B] = fColor.Color.G;
                RGB[G] = fColor.Color.B;

                this.pic.BackColor = fColor.Color;
                this.RefreshForm();
            }
        }

        #endregion

        #region Metodos de Interfaz Serie

        /// <summary>
        /// Envia por COMX
        /// OK - 12/04/14.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sPort_SendRang(object sender, EventArgs e)
        {
            this.Codificar();

            if (this.intentosCnx())
            {
                try
                {
                    byte[] mBuffer = new byte[this.Enviar.Length];
                    int p = 0;

                    foreach (char chr in this.Enviar)
                        mBuffer[p++] = Convert.ToByte(chr);

                    this.sPort.Write(mBuffer, 0, mBuffer.Length);
                }
                catch (System.IO.IOException ax)
                {
                    MessageBox.Show(ax.ToString());
                }
                catch (System.ArgumentNullException ax)
                {
                    MessageBox.Show(ax.ToString());
                }
                catch (System.InvalidOperationException ax)
                {
                    MessageBox.Show(ax.ToString());
                }
                catch (System.ArgumentOutOfRangeException ax)
                {
                    MessageBox.Show(ax.ToString());
                }
                catch (System.ArgumentException ax)
                {
                    MessageBox.Show(ax.ToString());
                }
            }
        }

        /// <summary>
        /// Recive por COMX
        /// OK - 12/04/14.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            this.BufferString.Append(this.sPort.ReadExisting());// + "/DataReceived");
            //
            this.Invoke(new EventHandler(Decodificar));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sPort_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            //this.BufferString.AppendLine(this.sPort.ReadExisting() + "/ErrorReceived");
            ////
            //this.Invoke(new EventHandler(Decodificar));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sPort_PinChanged(object sender, SerialPinChangedEventArgs e)
        {
            // http://www.euskalnet.net/shizuka/rs232.htm
            //this.BufferString.AppendLine(this.sPort.ReadExisting() + "/PinChanged");
            ////
            //this.Invoke(new EventHandler(Decodificar));
        }

        private void Temp_Tick(object sender, EventArgs e)
        {

        }

        #endregion

        #region Codificacion y Decodificacion

        /// <summary>
        /// Decodificar
        /// </summary>
        /// <param name="s"></param>
        /// <param name="e"></param>
        private void Decodificar(object s, EventArgs e)
        {
            /*
             * 1 - Recorto parametros.
             * 2 - Recorto nombre y valor.
             * 3 - Aplicar cambios.
             * 
             * Valore que decodifica:
             * r=100|g=50|b=255| 
             * r=255
             */

            //----------------------------------------------------
            
            string Buffer = BufferString.ToString();

            // Si no coincida Agrega caracter final de insttruccion.
            if (Buffer.LastIndexOf('|') != (BufferString.Length - 1)) 
                Buffer += "|";

            this.BufferString.Clear();
            //----------------------------------------------------
            string PreInstruccion = string.Empty;

            foreach (char ch in Buffer)
            {
                if (!char.Equals('|', ch))
                {
                    PreInstruccion += ch.ToString();
                    Buffer.Remove(0, 1);
                }
                else
                {
                    this.SetInstrucciones.Add(PreInstruccion);
                    PreInstruccion = string.Empty;
                }
            }

            this.lblStatus.Text = "Cantidad de instruciones: " + this.SetInstrucciones.Count.ToString();
            //----------------------------------------------------
            string Nombre = string.Empty;
            string Valor = string.Empty;

            foreach (string Instruccion in this.SetInstrucciones)
            {
                if (Instruccion.Contains("="))
                {
                    Nombre = Instruccion.Substring(0, Instruccion.IndexOf('='));
                    Valor = Instruccion.Substring((Instruccion.IndexOf('=') + 1), Instruccion.Length - (Instruccion.IndexOf('=') + 1));
                    this.GoInstruccion(Nombre, Valor);
                    this.SetInstrucciones.Remove(Instruccion);
                }
                else
                    this.lblStatus.Text = "Instruccion Invalida: " + Instruccion;
            }
        }

        private void GoInstruccion(string Nombre, string Valor) //vie 19-17:30-yp.hyr
        {
            //Colores
            if ((Nombre == "T") || (Nombre == "t"))
            {
                int n = 0;
                if (Int32.TryParse(Valor, out n))
                {
                    int Val = Convert.ToInt32(Valor);
                    Temp.Interval = Val;
                }
            }

            if ((Nombre == "R") || (Nombre == "r"))
            {
                int n = 0;
                if (Int32.TryParse(Valor, out n))
                {
                    int Val = Convert.ToInt32(Valor);

                    if (Val <= TrackMax & Val >= TrackMin)
                    {
                        RGB[R] = Val;
                        this.RefreshForm();
                    }
                }
            }

            if ((Nombre == "G") || (Nombre == "g"))
            {
                int n = 0;
                if (Int32.TryParse(Valor, out n))
                {
                    int Val = Convert.ToInt32(Valor);

                    if (Val <= TrackMax & Val >= TrackMin)
                    {
                        RGB[B] = Val;
                        this.RefreshForm();
                    }
                }
            }

            if ((Nombre == "B") || (Nombre == "b"))
            {
                int n = 0;
                if (Int32.TryParse(Valor, out n))
                {
                    int Val = Convert.ToInt32(Valor);

                    if (Val <= TrackMax & Val >= TrackMin)
                    {
                        RGB[G] = Val;
                        this.RefreshForm();
                    }
                }
            }
        }
        //-------------------------------------------------------
        
        /// <summary>
        /// Codifica
        /// </summary>
        private void Codificar()
        {
            if (this.Demo)
            {
                this.Enviar = "D";
                this.Demo = false;
            }
            else
            {
                this.Enviar =
                    "R" + RGB[R].ToString() +
                    "G" + RGB[B].ToString() +
                    "B" + RGB[G].ToString() +
                    "\n\r";
            }
        }

        #endregion

        #region metodos

        /// <summary>
        /// Actualiza el Formulario.
        /// OK - 12/04/14.
        /// </summary>
        private void RefreshForm()
        {
            this.tkbRed.Value = RGB[R];
            this.tkbGreen.Value = RGB[B];
            this.tkbBlue.Value = RGB[G];
            //
            this.txtRed.Text = RGB[R].ToString();
            this.txtGreen.Text = RGB[B].ToString();
            this.txtBlue.Text = RGB[G].ToString();
            //
            this.pic.BackColor = System.Drawing.Color.FromArgb(
                RGB[R], RGB[B], RGB[G]);
        }

        /// <summary>
        /// Realiza Intentos de conexion.
        /// OK - 12/04/14.
        /// </summary>
        /// <returns></returns>
        private bool intentosCnx()
        {
            try
            {
                int Intentos = 5;
                // Abro Puerto
                this.lblStatus.Text = "Conectando Intento: " + Intentos.ToString();
                
                while (!this.sPort.IsOpen)
                {
                    this.sPort.Open();

                    if (0 <= Intentos)
                    {
                        Intentos--;
                        this.lblStatus.Text = "Conectando Intento: " + Intentos.ToString();
                    }
                    else
                    {
                        this.lblStatus.Text = "ERROR.\nSe Superaron los  intentos de conexion.";
                        return false;
                    }
                }
                this.lblStatus.Text = "Conectado";
            }
            catch (UnauthorizedAccessException ax)
            {
                MessageBox.Show(ax.ToString());
                return false;
            }
            return true;
        }

        /// <summary>
        /// Carga MenuEmergente con colores.
        /// OK - 12/04/14.
        /// </summary>
        private void loadCmsColor()
        {
            string sCr;

            foreach (Color Cr in new ColorConverter().GetStandardValues())
            {
                sCr = Cr.ToString();

                if (sCr.Contains("Color ["))
                {
                    sCr = sCr.Remove(0, 7);                     //Remueve "Color ["
                    sCr = sCr.Remove(sCr.LastIndexOf(']'), 1);  //Remueve "]"
                }

                cmsColor.Items.Add(sCr);
            }
        }

        #endregion
    }
}
