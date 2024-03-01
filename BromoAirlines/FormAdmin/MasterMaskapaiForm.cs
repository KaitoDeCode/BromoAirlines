using BromoAirlines.Utils;
using BromoAirlines.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BromoAirlines.FormAdmin
{
    public partial class MasterMaskapaiForm : Form
    {
        private DataClassesDataContext db;
        private Utilities utils;
        private MaskapaiValidation vdt;
        private int idSelected;

        public MasterMaskapaiForm()
        {
            InitializeComponent();
            this.db = new DataClassesDataContext();
            this.utils = new Utilities();
            this.idSelected = 0;
            this.vdt = new MaskapaiValidation();
            get();
        }

        private void get()
        {
            var maskapai = db.Maskapais.ToList();
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            foreach (var item in maskapai)
            {
                dataGridView1.Rows.Add(item.Nama,item.Perusahaan,item.JumlahKru,item.Deskripsi);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int jumlahKru = int.Parse(numericUpDown1.Value.ToString());
            if (this.idSelected == 0)
            {
                var error = vdt.store(textBox1.Text,textBox2.Text,jumlahKru,richTextBox1.Text);
                if (!error)
                {
                    Maskapai maskapai = new Maskapai
                    {
                        Nama = textBox1.Text,
                        Perusahaan = textBox2.Text,
                        JumlahKru = jumlahKru,
                        Deskripsi = richTextBox1.Text
                    };

                    db.Maskapais.InsertOnSubmit(maskapai);
                    db.SubmitChanges();
                    utils.message("success","Berhasil membuat maskapai");
                }
            }
            else
            {

            }
            get();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //var name = 
            //if ()
            //{

            //}
        }
    }
}
