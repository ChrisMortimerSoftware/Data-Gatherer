using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

namespace Data_Gatherer_CSharp_Example
{
    public partial class Main : Form
    {
        SerialPort serialport;
        string output = "";
        byte[] delimiter = new byte[1] {13};

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            serialport = new SerialPort();
            serialport.BaudRate = 115200;
            serialport.DataReceived += serialport_DataReceived;
        }

        private void connect_Click(object sender, EventArgs e)
        {
            try
            {
                serialport.PortName = port.Text;
                serialport.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to connect: " + ex.Message);
            }
        }

        private void serialport_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            output += serialport.ReadExisting();
        }

        private void writeserialport(string data)
        {
            serialport.Write(data);
            serialport.Write(delimiter, 0, 1);
            SerialOutPut.Text += data + "\n";
        }

        private void light_Click(object sender, EventArgs e)
        {
            if (light.Text == "Light On")
            {
                light.Text = "Light Off";
                writeserialport("LIGHT:1");
            }
            else
            {
                light.Text = "Light On";
                writeserialport("LIGHT:0");
            }
        }

        private void vibrate_Click(object sender, EventArgs e)
        {
            writeserialport("VIBRATE:" + time.Value.ToString());
        }

        private void go_Click(object sender, EventArgs e)
        {
            writeserialport("GETHTTP:" + address.Text);

            while ((output.Length == 0 ? true : (output.Substring(0, 1) == "0")))
            {
                output = "";
                writeserialport("HTTPSTAT");
                Application.DoEvents();
                System.Threading.Thread.Sleep(1000);
            }

            output = "";

            writeserialport("HTTPRESP");

            while (output.Length == 0)
            {
                Application.DoEvents();
                System.Threading.Thread.Sleep(100);
            }

            SerialOutPut.Text +=  output + "\n";

            output = "";
        }
    }
}
