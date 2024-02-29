using BromoAirlines.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BromoAirlines.Validation
{
    internal class BaseValidation
    {
        public DataClassesDataContext db;
        public Utilities utils;
        public BaseValidation() {
            utils = new Utilities();
            db = new DataClassesDataContext();
        }

        public bool isNullorEmpty(params object[] values)
        {
            foreach (var value in values)
            {
                if (
                    (value == null) ||
                    (value == "") ||
                    (value.ToString() == "0")
                   )
                {
                    utils.message("error","Kolom tidak boleh ada yang kosong");
                    break;
                    return true;
                }
            }
            return false;
        }
    }
}
