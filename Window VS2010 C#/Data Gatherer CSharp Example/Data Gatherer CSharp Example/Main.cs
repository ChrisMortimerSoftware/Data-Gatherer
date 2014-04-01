using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;

namespace Data_Gatherer_CSharp_Example
{
    public partial class Main : Form
    {
        SerialPort serialport;
        StringBuilder output = new StringBuilder();
        byte[] delimiter = new byte[1] {13};

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            serialport = new SerialPort();
            serialport.BaudRate = 115200;
            serialport.ReadBufferSize = 5242880;
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
            output.Append(serialport.ReadExisting());
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

            while ((output.Length == 0 ? true : (output.ToString().Substring(0, 1) == "0")))
            {
                output.Clear();
                writeserialport("HTTPSTAT");
                Application.DoEvents();
                System.Threading.Thread.Sleep(1000);
            }

            output.Clear();

            writeserialport("HTTPRESP");

            while (output.Length == 0)
            {
                Application.DoEvents();
                System.Threading.Thread.Sleep(100);
            }

            SerialOutPut.Text +=  output.ToString() + "\n";

            output.Clear();
        }

        private void capture_Click(object sender, EventArgs e)
        {
            writeserialport("CAPTURE:" + capname.Text);
        }

        private void getimage_Click(object sender, EventArgs e)
        {
            writeserialport("GETIMAGE:" + getname.Text); //Send Command to capture image and name to use.

            string count = "";

            while (!output.ToString().Contains("\r")) //Wait for size of image data to be returned
            {}

            count = output.ToString().Substring(0, output.ToString().IndexOf("\r")); //Get image data size

            while ((count.Length + 1 + output.Length) < int.Parse(count)) //Waiting while receiving data
            {
                System.Threading.Thread.Sleep(500);
                this.Text = (count.Length + 1 + output.Length).ToString() + " of " + count;
                Application.DoEvents();
            }

            output = output.Remove(0, count.Length + 1); //trim length information from start of string
            output = output.Remove(output.Length - 1, 1); //trim delimiting charactor

            byte[] imageBytes = Convert.FromBase64String(output.ToString());
            MemoryStream ms = new MemoryStream(imageBytes, 0,imageBytes.Length); //convert base64 string to memory stream

            ms.Write(imageBytes, 0, imageBytes.Length); //convert memory stream to image
            Captured.Image = Image.FromStream(ms, true);

            output.Clear(); //reset for next image
        }

        static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }
    }
}
