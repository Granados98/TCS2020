using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DireccionGeneral.Model.daoDireccion;
using DireccionGeneral.Model.pocosDireccion;

namespace DireccionGeneral.VentanasDireccion
{
    /// <summary>
    /// Lógica de interacción para DictaminarReporte.xaml
    /// </summary>
    public partial class DictaminarReporte : Window
    {
        public DictaminarReporte()
        {
            InitializeComponent();
        }

        private void btn_Salir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_GuardarDictamen_Click(object sender, RoutedEventArgs e)
        {
            int folio = 0;
            folio = Convert.ToInt32(txt_Folio.Text);
            string nombre = txt_Nombre.Text;
            string descripcion = tb_Descripcion.Text;

            if (folio==0 && nombre.Length>0 && descripcion.Length>0)
            {
                Dictamen dictamen = new Dictamen();
                dictamen.Folio = folio;
                dictamen.Descripcion = descripcion;
                dictamen.FechaDictamen = DateTime.Now;

                if (DictamenDAO.verificaDictamen(folio)>0)
                {
                    DictamenDAO.guardarDictamen(dictamen);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Dictamen ya registrado");
                }

            }
            else
            {
                MessageBox.Show("Llene todos los campos");
            }
        }
    }
}
