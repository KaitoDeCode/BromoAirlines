using BromoAirlines.Services;
using BromoAirlines.Validation;
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
    public partial class Form1 : Form
    {
        private AuthServices authServices;
        public Form1()
        {
            InitializeComponent();
            this.authServices = new AuthServices();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form2 register = new Form2();
            register.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var login = this.authServices.login(textBox1.Text,textBox2.Text);
            if (login)
            {
                this.Hide();
            }
            
        }
    }
}
