using BromoAirlines.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BromoAirlines
{
    public partial class Form2 : Form
    {
        private AuthServices authServices;
        public Form2()
        {
            InitializeComponent();
            this.authServices = new AuthServices();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 login = new Form1();
            login.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.authServices.register(
               textBox1.Text,
               textBox2.Text,
               dateTimePicker1.Value,
               textBox3.Text,
               textBox4.Text
            );
        }
    }
}
