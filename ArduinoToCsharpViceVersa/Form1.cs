using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArduinoToCsharpViceVersa
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SerialPort port = new SerialPort();

        private void timer1_Tick(object sender, EventArgs e)
        {
            string ss = port.ReadLine();

            //MessageBox.Show(ss);

            listBox1.Items.Add(ss);

            //port.BaudRate = 9600;
            //port.PortName = "COM11";
            //port.Open();

            //while (true)
            //{
            //    string ss = port.ReadLine();

            //    MessageBox.Show(ss);
            //}
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (port.IsOpen)
                port.PortName = "COM11";// + nudPort.Value.ToString();

            try
            {
                port.Close();

                port.PortName = "COM11";// + nudPort.Value.ToString();

                port.BaudRate = 9600;

                port.Parity = Parity.None;

                port.DataBits = 8;

                port.StopBits = StopBits.One;

                port.ReceivedBytesThreshold = 1;
                
                port.DtrEnable = true;

                port.RtsEnable = true;

                port.Open();

                //timer1.Interval = 500;

                timer1.Enabled = true;
            }
            catch
            {
                MessageBox.Show("Serial port " + port.PortName +
                " cannot be opened!", "Arduino tester", MessageBoxButtons.OK
                , MessageBoxIcon.Warning);
            }
        }
    }
}
