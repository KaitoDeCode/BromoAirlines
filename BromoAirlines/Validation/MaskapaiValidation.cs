using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BromoAirlines.Validation
{
    internal class MaskapaiValidation : BaseValidation
    {
        public bool store(
            String nama,
            String perusahaan,
            int jumlahKru,
            String deskripsi
        )
        {
            var error = isNullorEmpty(nama, perusahaan, jumlahKru, deskripsi);
            if (error)
            {
                return true;
            }

            if (jumlahKru < 1)
            {
                utils.message("error", "Jumlah kru minimal 1");
                return true;
            }

            return false;
        }
    }
}
