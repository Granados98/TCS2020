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

namespace Transito_Veracruz.Delegacion
{
    /// <summary>
    /// Lógica de interacción para Window2.xaml
    /// </summary>
    public partial class MenuDelegacion : Window
    {
        public MenuDelegacion()
        {
            InitializeComponent();
        }

        private void btn_AgregarConductor_Click(object sender, RoutedEventArgs e)
        {
            RegistroConductor conductor = new RegistroConductor();
            conductor.Show();
        }

        private void btn_AgregarVehiculo_Click(object sender, RoutedEventArgs e)
        {
            AgregarVehiculo vehiculo = new AgregarVehiculo();
            vehiculo.Show();
        }

        private void btn_AgregarReporte_Click(object sender, RoutedEventArgs e)
        {
            LevantaReporte reporte = new LevantaReporte();
            reporte.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
