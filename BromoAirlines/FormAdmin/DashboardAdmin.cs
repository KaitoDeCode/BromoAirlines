using BromoAirlines.Utils;
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
    public partial class DashboardAdmin : Form
    {
        private Utilities utils;
        public DashboardAdmin()
        {
            this.utils = new Utilities();
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MasterBandaraForm form = new MasterBandaraForm();
            this.utils.Link(form,panel3);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MasterMaskapaiForm form = new MasterMaskapaiForm();
            this.utils.Link(form, panel3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MasterJadwalPenerbangan form = new MasterJadwalPenerbangan();
            this.utils.Link(form, panel3);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MasterKodePromo form = new MasterKodePromo();
            this.utils.Link(form, panel3);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            UbahStatusPenerbangan form = new UbahStatusPenerbangan();
            this.utils.Link(form, panel3);
        }
    }
}
