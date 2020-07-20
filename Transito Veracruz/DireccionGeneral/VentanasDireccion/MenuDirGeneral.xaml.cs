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
    /// Lógica de interacción para MenuDirGeneral.xaml
    /// </summary>
    public partial class MenuDirGeneral : Window
    {
        Personal personal { get; set; }
        Delegacion delegacion { get; set; }
        Reporte reportes { get; set; }

        private List<Personal> listPersonal = new List<Personal>();
        private List<Delegacion> listDelegacion = new List<Delegacion>();
        private List<Reporte> listReporte = new List<Reporte>();
        public MenuDirGeneral(Personal personal)        {
            this.personal = personal;
            InitializeComponent();
            CargaDelegaciones();
            CargarUsuarios();
            CargaReportes();
        }

        private void CargaReportes()
        {
            listReporte = ReporteDAO.getReportes();
            dgReportes.ItemsSource = listReporte;
        }
        private void CargarUsuarios()
        {
            listPersonal = PersonalDAO.getPersonal();
            dgPersonal.ItemsSource = listPersonal;
        }

        private void CargaDelegaciones()
        {
            listDelegacion = DelegacionDAO.getDelegacion();
            dgDelegaciones.ItemsSource = listDelegacion;
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

        

        private void btn_Salir_Click(object sender, RoutedEventArgs e)
        {
            this.personal.Estado = "Desconectado";
            PersonalDAO.actualizarEstadoUsuario(personal);
            this.Close();
        }
    }
}
