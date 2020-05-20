using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using Transito_Veracruz.Model.db;
using Transito_Veracruz.Model.pocos;

namespace Transito_Veracruz.Delegacion
{
    /// <summary>
    /// Lógica de interacción para Window2.xaml
    /// </summary>
    public partial class MenuDelegacion : Window
    {
        private List<Conductor> listConductores { get; set; }
        private Personal usuarioIniciado { get; set; }
        public MenuDelegacion(Personal personal)
        {
            InitializeComponent();
            this.usuarioIniciado = personal;
        }
        /*
        private void cargarConductores()
        {
            listConductores = ConductorDAO.getConductores();
            dg_Conductores.ItemsSource = listConductores;

        }*/

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

        private void btn_EnviarMensaje_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_CargarConductores_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection conexion = null;

            try
            {
                conexion = ConnectionUtils.getConnection();
                SqlCommand command;
                if (conexion != null)
                {
                    String query = String.Format("SELECT * FROM Conductor");
                    command = new SqlCommand(query, conexion);
                    command.ExecuteNonQuery();

                    SqlDataAdapter dataAdp = new SqlDataAdapter(command);
                    DataTable dt = new DataTable("Conductor");
                    dataAdp.Fill(dt);
                    dg_Conductores.ItemsSource = dt.DefaultView;
                    dataAdp.Update(dt);

                    command.Dispose();
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("No se encontro el Conductor");
            }
        }
    }
}
