using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//
using System.IO.Ports;

namespace RGB
{
    public partial class frmSettings : Form
    {
        public SerialPort sPort { get; set;}

        int[] baudRate = { 75, 110, 130, 150, 300, 600, 1200, 1800, 2400, 4800, 
                              7200, 9600, 14400, 19200, 38400, 57600, 115200, 128000};

        int[] dataBits = { 5, 6, 7, 8 };

        public frmSettings()
        {
            InitializeComponent();
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            btnAplicar.DialogResult = DialogResult.OK;

            foreach (int br in baudRate)
                cmbBaudRate.Items.Add(br.ToString());

            foreach (string s in Enum.GetNames(typeof(Parity)))
                cmbParity.Items.Add(s);

            foreach (string s in Enum.GetNames(typeof(StopBits)))
                cmbStopBits.Items.Add(s);

            foreach (string s in Enum.GetNames(typeof(Handshake)))
                cmbHandshake.Items.Add(s);

            foreach (int db in dataBits)
                cmbDataBits.Items.Add(db.ToString());
            
            //foreach (string s in Enum.GetNames(typeof(Encoding)))
            //    cmbEncoding.Items.Add(s);

            this.Cargar();
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            try
            {
                sPort.BaudRate = Convert.ToInt32(cmbBaudRate.SelectedItem);
                sPort.Parity = (Parity)Enum.Parse(typeof(Parity), cmbParity.SelectedItem.ToString());
                sPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), cmbStopBits.SelectedItem.ToString());
                sPort.Handshake = (Handshake)Enum.Parse(typeof(Handshake), cmbHandshake.SelectedItem.ToString());
                sPort.DataBits = Convert.ToInt32(cmbDataBits.SelectedItem);
                //sPort.Encoding = (Encoding)Enum.Parse(typeof(Encoding), cmbEncoding.SelectedItem.ToString());
            }
            catch (System.IO.IOException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Cargar()
        {
            if (sPort == null)
            {
                sPort = new SerialPort();
                sPort.BaudRate = 9600;
                sPort.Parity = Parity.None;
                sPort.StopBits = StopBits.One;
                sPort.Handshake = Handshake.None;
                sPort.DataBits = 8;
                sPort.Encoding = Encoding.ASCII;

                sPort.ParityReplace = 0;
                
            }

            for (int p = 0; p < cmbBaudRate.Items.Count; p++)
            {
                if (Convert.ToInt32(cmbBaudRate.Items[p]) == sPort.BaudRate)
                    cmbBaudRate.SelectedIndex = p;
            }

            for (int p = 0; p < cmbParity.Items.Count; p++)
            {
                if ((Parity)Enum.Parse(typeof(Parity), cmbParity.Items[p].ToString()) == sPort.Parity)
                    cmbParity.SelectedIndex = p;
            }

            for (int p = 0; p < cmbStopBits.Items.Count; p++)
            {
                if ((StopBits)Enum.Parse(typeof(StopBits), cmbStopBits.Items[p].ToString()) == sPort.StopBits)
                    cmbStopBits.SelectedIndex = p;
            }

            for (int p = 0; p < cmbHandshake.Items.Count; p++)
            {
                if ((Handshake)Enum.Parse(typeof(Handshake), cmbHandshake.Items[p].ToString()) == sPort.Handshake)
                    cmbHandshake.SelectedIndex = p;
            }

            for (int p = 0; p < cmbDataBits.Items.Count; p++)
            {
                if (Convert.ToInt32(cmbDataBits.Items[p]) == sPort.DataBits)
                    cmbDataBits.SelectedIndex = p;
            }

            //for (int p = 0; p < cmbEncoding.Items.Count; p++)
            //{
            //    if ((Encoding)Enum.Parse(typeof(Encoding), cmbEncoding.Items[p].ToString()) == sPort.Encoding)
            //        cmbEncoding.SelectedIndex = p;
            //}
        }
    }
}
