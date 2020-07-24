using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DireccionGeneral.Model.securityDireccion
{
    class Validacion
    {
        public static void soloNumeros(TextCompositionEventArgs e)
        {
            int caracter = Convert.ToInt32(Convert.ToChar(e.Text));
            if (caracter >= 48 && caracter <= 57)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        public static void soloLetras(TextCompositionEventArgs e)
        {
            var regex = new Regex(@"[^a-zA-Z\s]");
            if (regex.IsMatch(e.Text.ToString()))
            {
                e.Handled = true;
            }
        }
    }
}
