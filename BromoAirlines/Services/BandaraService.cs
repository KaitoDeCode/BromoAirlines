using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BromoAirlines.Services
{
    internal class BandaraService: BaseServices
    {
        private BandaraValidation validation;
        public BandaraService() {
            validation = new BandaraValidation();
        }

        public void get(DataGridView table,ComboBox cmb)
        {
            table.Rows.Clear();
            table.Refresh();
            cmb.Controls.Clear();
            cmb.DataSource = null;
            List<Bandara> bandara = db.Bandaras.ToList();
            foreach (var item in bandara)
            {
                table.Rows.Add(item.Nama,item.KodeIATA,item.Kota,item.Negara.Nama,item.JumlahTerminal,item.Alamat);
            }
            cmb.DataSource = db.Negaras.ToList();
            cmb.DisplayMember = "Nama";
            cmb.ValueMember = "Id";
        }

        public void store(
            String name,
            String kodeIata,
            String kota,
            int negaraId,
            String jumlahTerminal,
            String alamat
        )
        {
            var error = validation.store(name,kodeIata,kota,negaraId,jumlahTerminal,alamat);
            if (!error)
            {

                try
                {
                    var negara = db.Negaras.FirstOrDefault(item => item.ID == negaraId);
                    Bandara bandara = new Bandara
                    {
                        Nama = name,
                        KodeIATA = kodeIata,
                        Kota = kota,
                        Negara = negara,
                        JumlahTerminal = int.Parse(jumlahTerminal),
                        Alamat = alamat,
                    };
                    db.Bandaras.InsertOnSubmit(bandara);
                    db.SubmitChanges();
                    utils.message("success", "Berhasil menambahkan bandara");
                }catch(Exception ex)
                {
                    utils.message("error", ex.Message);
                }
            }

           
        }
    }
}
