using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResolveMACList
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label_work.Location = new Point((Width / 2 - label_work.Width / 2), (Height / 2 - label_work.Height / 2));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label_work.Visible = true;
            Application.DoEvents();
            List<IPInfo> info = IPInfo.GetIPInfo();

            foreach (var item in textBox1.Lines)
            {
                if (IPInfo.Contains(info, item))
                {
                    IPInfo ip = IPInfo.GetIPInfo(info, item);
                    if (ip != null)
                    {
                        textBox2.AppendText((ip.HostName??"NO HOSTNAME") + "," + ip.IPAddress + "," + ip.MacAddress + Environment.NewLine);
                    }
                    else
                    {
                        textBox2.AppendText("Can't Resolve MAC " + item + Environment.NewLine);
                    }
                }
                else
                {
                    textBox2.AppendText("Can't Find MAC " + item + Environment.NewLine);
                }
            }
            label_work.Visible = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.ToLower();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label_work.Visible = true;
            Application.DoEvents();
            List<IPInfo> info = IPInfo.GetIPInfo();
            foreach (IPInfo item in info)
            {
                textBox2.AppendText((item.HostName ?? "NO HOSTNAME") + "," + item.IPAddress + "," + item.MacAddress + Environment.NewLine);
            }
            label_work.Visible = false;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            label_work.Location = new Point((Width / 2 - label_work.Width / 2), (Height / 2 - label_work.Height / 2));
        }
    }
}
