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
using Transito_Veracruz.Model.pocos;

namespace Transito_Veracruz.Delegacion
{
    /// <summary>
    /// Lógica de interacción para Window2.xaml
    /// </summary>
    public partial class MenuDelegacion : Window
    {
        private Personal usuarioIniciado { get; set; }


        private delegate void DAddItem(String s);

        private void AddItem(String s)
        {
            block_Chat.Items.Add(s);
        }

        public MenuDelegacion(Personal personal)
        {
            InitializeComponent();
            this.usuarioIniciado = personal;

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

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btn_EnviarMensaje_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
