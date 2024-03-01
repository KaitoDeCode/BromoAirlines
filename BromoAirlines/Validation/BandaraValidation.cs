using BromoAirlines.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BromoAirlines.Services
{
    internal class BandaraValidation : BaseValidation
    {
        public bool store(
            String name,
            String kodeIata,
            String kota,
            int negara,
            String jumlahTerminal,
            String alamat
        )
        {
            var error = isNullorEmpty(
            name,
            kodeIata,
            kota,
            negara,
            jumlahTerminal,
            alamat
            );

            if (error)
            {
                return true;
            }

            var val1 = db.Bandaras.FirstOrDefault(item => item.Nama == name || item.KodeIATA == kodeIata);
            if ((val1 != null))
            {
                utils.message("error","Nama Bandara atau Kode IATA sudah digunakan");
                return true;
            }

            if (kodeIata.Length != 3)
            {
                utils.message("error", "Kode Iata harus berupa 3 karakter");
                return true;
            }

            if (int.Parse(jumlahTerminal) < 1)
            {
                utils.message("error", "Bandara harus memilki 1 atau lebih terminal");
                return true;
            }
            return false;
        }

        public bool update(
            int id,
            String name,
            String kodeIata,
            String kota,
            int negara,
            String jumlahTerminal,
            String alamat
        )
        {
            var error = isNullorEmpty(
            id,
            name,
            kodeIata,
            kota,
            negara,
            jumlahTerminal,
            alamat
            );

            if (error)
            {
                return true;
            }

            var val1 = db.Bandaras.FirstOrDefault(item => item.Nama == name || item.KodeIATA == kodeIata);
            if ((val1 != null))
            {
                if (val1.ID != id)
                {
                    utils.message("error", "Nama Bandara atau Kode IATA sudah digunakan");
                    return true;
                }
            }
            if (kodeIata.Length != 3)
            {
                utils.message("error", "Kode Iata harus berupa 3 karakter");
                return true;
            }

            if (int.Parse(jumlahTerminal) < 1)
            {
                utils.message("error", "Bandara harus memilki 1 atau lebih terminal");
                return true;
            }
            return false;
        }

    }
}
