using BromoAirlines.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BromoAirlines.Services
{
    internal class BaseServices
    {
        public Utilities utils;
        public DataClassesDataContext db;
       

        public BaseServices()
        {
            utils = new Utilities();
            db = new DataClassesDataContext();
        }
    }
}
