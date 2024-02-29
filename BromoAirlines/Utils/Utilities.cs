using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BromoAirlines.Utils
{
    internal class Utilities
    {
        public void message(String status,String message)
        {
            if (status is "success") MessageBox.Show(message, status, MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (status is "error") MessageBox.Show(message, status, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void redirect(Form form, Form currentForm)
        {
            form.Show();
            currentForm.Hide();
        }
    }
}
