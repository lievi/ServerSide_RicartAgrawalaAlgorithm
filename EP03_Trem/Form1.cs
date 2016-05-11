using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibUDP;

namespace EP03_Trem
{
    public partial class Form1 : Form
    {
        UDPSocket socket;
        public Form1()
        {
            InitializeComponent();
            socket = new UDPSocket(MensagemRecebida,7200);
            timer1.Interval = 10;
        }

        private void MensagemRecebida(byte[] buffer, int size, string ip, int port)
        {
            switch (buffer[0])
            {
                case 0: 
                    timer1.Start();
                    break;
                case 1:
                    timer1.Stop();
                    break;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Location = new Point(label1.Location.X + 2, label1.Location.Y);

            if (label1.Location.X > this.Width)
            {
                label1.Location = new Point(0 - label1.Width, label1.Location.Y);
            }
        }
    }
}
