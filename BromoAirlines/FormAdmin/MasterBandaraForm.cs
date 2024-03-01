using BromoAirlines.Services;
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
    public partial class MasterBandaraForm : Form
    {
        private BandaraService bandaraService;
        private Utilities utils;
        private int idSelected;
        private DataClassesDataContext db;
        public MasterBandaraForm()
        {
            bandaraService = new BandaraService();
            InitializeComponent();
            bandaraService.get(dataGridView1,comboBox1);
            this.utils = new Utilities();
            this.idSelected = 0;
            this.db = new DataClassesDataContext();
        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.idSelected == 0)
            {
               bandaraService.store(
               textBox1.Text,
               textBox2.Text.ToUpper(),
               textBox3.Text,
               int.Parse(comboBox1.SelectedValue.ToString()),
               numericUpDown1.Value.ToString(),
               richTextBox1.Text
           );
            }
            else
            {
                bandaraService.update(
                    this.idSelected,
                    textBox1.Text,
                    textBox2.Text.ToUpper(),
                    textBox3.Text,
                    int.Parse(comboBox1.SelectedValue.ToString()),
                    numericUpDown1.Value.ToString(),
                    richTextBox1.Text
                );
                this.idSelected = 0;
            }
            this.utils.clearText(textBox1, textBox2, textBox3);
            numericUpDown1.Value = 0;
            richTextBox1.Clear();
            bandaraService.get(dataGridView1, comboBox1);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = dataGridView1;

            string name = dgv.Columns[e.ColumnIndex].Name;
            var kode = dgv.Rows[e.RowIndex].Cells[1].Value;

            Bandara bandara = this.db.Bandaras.FirstOrDefault(item => item.KodeIATA == kode.ToString());

            if (bandara is null)
            {
                utils.message("error",kode.ToString());
            }

            if (name == "Column7")
            {
                this.idSelected = bandara.ID;
                textBox1.Text = bandara.Nama;
                textBox2.Text = bandara.KodeIATA;
                textBox3.Text = bandara.Kota;
                comboBox1.SelectedValue = bandara.NegaraID;
                numericUpDown1.Value = bandara.JumlahTerminal;
                richTextBox1.Text = bandara.Alamat;
            }
            if (name == "Column8")
            {
                DialogResult dlg = utils.confirm("Apakah kamu yakin ingin menghapus bandara");
                if (dlg == DialogResult.Yes)
                {
                    db.Bandaras.DeleteOnSubmit(bandara);
                    db.SubmitChanges();
                    utils.message("success","Berhasil menghapus bandara");
                    this.utils.clearText(textBox1, textBox2, textBox3);
                    numericUpDown1.Value = 0;
                    richTextBox1.Clear();
                    bandaraService.get(dataGridView1, comboBox1);
                }
            }
        }
    }
}
