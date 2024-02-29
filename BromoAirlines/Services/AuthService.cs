using BromoAirlines.FormAdmin;
using BromoAirlines.FormUser;
using BromoAirlines.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BromoAirlines.Services
{
    internal class AuthServices : BaseServices
    {
        private AuthValidation validation;
        public AuthServices() {
            validation = new AuthValidation();
        }

        public void register(
            String username,
            String nama,
            DateTime tanggalLahir,
            String nomorTelp,
            String password
        )
        {
               var error =  validation.registerValidation(
                    username,
                    nama,
                    tanggalLahir,
                    nomorTelp,
                    password
                );
            if (!error)
            {
                try
                {


                    Akun akun = new Akun
                    {
                        Username = username,
                        Nama = nama,
                        TanggalLahir = tanggalLahir,
                        NomorTelepon = nomorTelp,
                        Password = password
                    };

                    db.Akuns.InsertOnSubmit(akun);
                    db.SubmitChanges();
                    utils.message("success", "Berhasil registrasi");
                }
                catch (Exception ex)
                {
                    utils.message("error", ex.Message);
                }
            }
           
        }

        public bool login(
            String username,
            String password
        )
        {
            var error = this.validation.loginValidation(username, password);
            if (!error)
            {
                try
                {
                    var user = db.Akuns.FirstOrDefault(
                       item => item.Username == username && item.Password == password
                       );
                    if (user is null)
                    {
                        utils.message("error", "Terdapat kesalahan diantara username atau password");
                        return false;
                    }

                    if (user.MerupakanAdmin)
                    {
                        DashboardAdmin dash = new DashboardAdmin();
                        dash.Show();
                    }
                    else
                    {
                        DashboadUser dash = new DashboadUser();
                        dash.Show();
                    }
                    

                    utils.message("success","Berhasil Login");
                    return true;
                   
                }
                catch (Exception ex)
                {
                    utils.message("success", ex.Message);
                }
            }
            return false;

        }

    }
}
