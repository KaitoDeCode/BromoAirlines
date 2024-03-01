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
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        private string _namePenumpang;

        public string NamePenumpang
        {
            get{ return _namePenumpang; }
            set { _namePenumpang = value; }
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            label1.Text = "Penumpang " + _namePenumpang.ToString();
        }
    }
}
