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
using Transito_Veracruz.Model.dao;
using Transito_Veracruz.Model.pocos;

namespace Transito_Veracruz.Delegacion
{
    /// <summary>
    /// Lógica de interacción para AgregarVehiculo.xaml
    /// </summary>
    public partial class AgregarVehiculo : Window
    {
        private List<Conductor> listaConductores { get; set; }
        public AgregarVehiculo()
        {
            InitializeComponent();
            cargarConductores();
        }

        public void cargarConductores()
        {
            listaConductores = ConductorDAO.getConductores();
            cb_Conductores.ItemsSource = listaConductores;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_AgregarVehiculo_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
