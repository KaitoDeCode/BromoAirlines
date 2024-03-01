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
    public partial class UbahStatusPenerbangan : Form
    {
        private DataClassesDataContext db;
        private Utilities utils;
        private int idSelected;
        public UbahStatusPenerbangan()
        {
            this.db = new DataClassesDataContext();
            this.utils = new Utilities();
            this.idSelected = 0;
            InitializeComponent();
            get();
            panel2.Hide();
        }

        private void get()
        {
            var jadwal = db.JadwalPenerbangans.OrderBy(item=> item.Maskapai.Nama).ToList();
            dataGridView1.Rows.Clear();
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
            var status = this.db.StatusPenerbangans.ToList();
            comboBox1.Controls.Clear();
            comboBox1.DataSource = null;
            comboBox1.DataSource = status;
            comboBox1.DisplayMember = "Nama";
            comboBox1.ValueMember = "ID";
            foreach (var item in jadwal)
            {
                var nameStatus = "";
                var statusPerubahan = "";
                if(item.PerubahanStatusJadwalPenerbangans.Count() > 0)
                {
                    var statusTerbaru = item.PerubahanStatusJadwalPenerbangans.OrderByDescending(i => i.WaktuPerubahanTerjadi).Single();
                    nameStatus = statusTerbaru.StatusPenerbangan.Nama ?? "";
                    statusPerubahan = statusTerbaru.WaktuPerubahanTerjadi.ToString() ?? "";
                }
                
                dataGridView1.Rows.Add(item.KodePenerbangan, item.Maskapai.Nama,item.Bandara.Nama,item.Bandara1.Nama,item.TanggalWaktuKeberangkatan.Date,item.TanggalWaktuKeberangkatan.TimeOfDay,item.DurasiPenerbangan,nameStatus,statusPerubahan);
            }
        }

        private void UbahStatusPenerbangan_Load(object sender, EventArgs e)
        {
          
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = dataGridView1;
            var kode = "";
            string name = dgv.Columns[e.ColumnIndex].Name;
            if (e.RowIndex > 0)
            {
                kode = dgv.Rows[e.RowIndex].Cells[0].Value.ToString();

            }

            var jadwal = db.JadwalPenerbangans.FirstOrDefault(item => item.KodePenerbangan == kode.ToString());

            if (jadwal is null)
            {
                utils.message("error", "Jadwal tidak ditemukan");
            }

            if (name == "Column10")
            {
                panel2.Show();
                this.idSelected = jadwal.ID;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel2.Hide();
            
            this.idSelected = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var status = comboBox1.Text;
            var statusId = comboBox1.SelectedValue.ToString();
            int countDuration = 0;


            if (idSelected == 0)
            {
                this.utils.message("error", "Tidak ada jadwal yang dipilih");
                return;
            }

            if (status == "")
            {
                this.utils.message("success", "Status tidak boleh kosong");
                return;
            }

            if (status == "Delay")
            {
                if (!maskedTextBox1.MaskFull)
                {
                    utils.message("error", "Kolom perkiraan durasi delay harus diisi ");
                    return;
                }


                String[] durasiDelay = maskedTextBox1.Text.Split(' ');
                int statusDelay = 0;
                var durasi = durasiDelay.Where(item => int.TryParse(item, out statusDelay)).ToList();

                if (durasi.Count() > 1)
                {
                    countDuration += int.Parse(durasi[0].ToString()) * 60;
                    countDuration += int.Parse(durasi[1].ToString());
                }
            }

            PerubahanStatusJadwalPenerbangan perubahan = new PerubahanStatusJadwalPenerbangan
            {
                JadwalPenerbanganID = idSelected,
                PerkiraanDurasiDelay = countDuration,
                StatusPenerbanganID = int.Parse(statusId),
                WaktuPerubahanTerjadi = DateTime.Now,
            };

            db.PerubahanStatusJadwalPenerbangans.InsertOnSubmit(perubahan);
            db.SubmitChanges();
            utils.message("success", "Berhasil membuat perubahaan status penerbangan");
            get();
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
