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

namespace DireccionGeneral.VentanasDireccion
{
    /// <summary>
    /// Lógica de interacción para MenuDirGeneral.xaml
    /// </summary>
    public partial class MenuDirGeneral : Window
    {
        public MenuDirGeneral()
        {
            InitializeComponent();
            CargaDelegacionesDB();
            CargaPersonalDB();
        }

        private void CargaPersonalDB()
        {
            Modelo.SistemaTransitoEntities1 db = new Modelo.SistemaTransitoEntities1();
            dgPersonal.ItemsSource = db.Personal.ToList();
        }

        private void CargaDelegacionesDB()
        {
            Modelo.SistemaTransitoEntities1 db = new Modelo.SistemaTransitoEntities1();
            dgDelegaciones.ItemsSource = db.Delegacion.ToList();
        }

        private void btn_AgregarDelegacion_Click(object sender, RoutedEventArgs e)
        {
            AgregarDelegacion delegacion = new AgregarDelegacion();
            delegacion.Show();
        }

        private void btn_AgregarUsuario_Click(object sender, RoutedEventArgs e)
        {
            RegistroUsuario nuevoUsuario = new RegistroUsuario();
            nuevoUsuario.Show();
        }

        private void btn_AgregarDictamen_Click(object sender, RoutedEventArgs e)
        {
            DictaminarReporte nuevoDictamen = new DictaminarReporte();
            nuevoDictamen.Show();
        }

        private void btn_VerDetalle_Click(object sender, RoutedEventArgs e)
        {
            VisualizarReporte verReporte = new VisualizarReporte();
            verReporte.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
