using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BromoAirlines.FormUser
{
    public partial class BeliTIketForm : Form
    {
        public BeliTIketForm()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BeliTIketForm_Load(object sender, EventArgs e)
        {
            for(int i = 1; i < 5; i++)
            {
                UserControl1 uc = new UserControl1();
                uc.NamePenumpang = i.ToString();

                flowLayoutPanel1.Controls.Add(uc);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}
