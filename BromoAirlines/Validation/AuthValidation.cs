using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BromoAirlines.Validation
{
    internal class AuthValidation : BaseValidation
    {
        public bool registerValidation(
            String username,
            String nama,
            DateTime tanggalLahir,
            String nomorTelp,
            String password
        )
        {
            bool error;
           error = isNullorEmpty(
            username,
            nama,
            nomorTelp,
            password
            );

            var val1 = this.db.Akuns.FirstOrDefault(i => i.Username == username);
            if (val1 != null && !error)
            {
                utils.message("error", "Username sudah digunakan");
                return true;
            }
            long parsedNomorTelp = 0;
            if (!(long.TryParse(nomorTelp, out parsedNomorTelp)) && !error)
            {
                utils.message("error", "Nomor telepon harus berupa angka");
                return true;
            }

            if (nomorTelp.Length < 10 || nomorTelp.Length > 13) utils.message("error", "Nomor telp harus lebih 10 karakter dan kurang atau sama dengan 13 karakter");
            if (password.Length < 8) utils.message("error", "Password harus lebih atau sama dengan 8 karakter");

            return error;
        }

        public bool loginValidation(String username, String password)
        {
            var error = isNullorEmpty(username, password);
            var val1 = db.Akuns.FirstOrDefault(
            item=> item.Username == username && item.Password == password
            );

            if (val1 is null)
            {
                utils.message("error", "Terdapat kesalahan diantara username atau password");
                return true;
            }
            return error;
        }
    }

     
}
