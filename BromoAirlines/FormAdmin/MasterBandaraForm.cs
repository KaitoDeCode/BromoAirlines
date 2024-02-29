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

namespace BromoAirlines.FormAdmin
{
    public partial class MasterBandaraForm : Form
    {
        private BandaraService bandaraService;
        public MasterBandaraForm()
        {
            bandaraService = new BandaraService();
            InitializeComponent();
            bandaraService.get(dataGridView1,comboBox1);
        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            bandaraService.store(
                textBox1.Text,
                textBox2.Text,
                textBox3.Text,
                int.Parse(comboBox1.SelectedValue.ToString()),
                numericUpDown1.Value.ToString(),
                richTextBox1.Text
            );
            bandaraService.get(dataGridView1,comboBox1);
        }
    }
}
