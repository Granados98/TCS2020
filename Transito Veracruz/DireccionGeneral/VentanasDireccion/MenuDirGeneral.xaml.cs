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
using DireccionGeneral.Model.InterfaceDireccion;
using DireccionGeneral.Model.pocosDireccion;

namespace DireccionGeneral.VentanasDireccion
{
    /// <summary>
    /// Lógica de interacción para MenuDirGeneral.xaml
    /// </summary>
    public partial class MenuDirGeneral : Window, InterfaceMenu
    {
        Personal personal { get; set; }

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
            listDelegacion = DelegacionDAO.getDelegaciones();
            dgDelegaciones.ItemsSource = listDelegacion;
        }

        private void btn_AgregarDelegacion_Click(object sender, RoutedEventArgs e)
        {
            Delegacion delegacion = new Delegacion();
            AgregarDelegacion ad = new AgregarDelegacion(this, true, delegacion);
            ad.Show();
        }

        private void btn_AgregarUsuario_Click(object sender, RoutedEventArgs e)
        {
            Personal personal = new Personal();
            RegistroUsuario nuevoUsuario = new RegistroUsuario(this,true,personal);
            nuevoUsuario.Show();
        }

        private void btn_AgregarDictamen_Click(object sender, RoutedEventArgs e)
        {
            int index = dgReportes.SelectedIndex;
            if (index>=0)
            {
                Reporte reporte = listReporte[index];

                DictaminarReporte nuevoDictamen = new DictaminarReporte(this,reporte,personal);
                nuevoDictamen.ShowDialog();
                bool resultado = nuevoDictamen.Resultado;
                if (resultado)
                {
                    CargaReportes();
                }
            }
        }

        private void btn_VerDetalle_Click(object sender, RoutedEventArgs e)
        {
            int index = dgReportes.SelectedIndex;
            if (index>=0)
            {
                Reporte reporte = listReporte[index];
                VisualizarReporte verReporte = new VisualizarReporte(reporte);
                verReporte.Show();
            }
            else
            {
                MessageBox.Show("Seleccione un reporte");
            }
        }

        

        private void btn_Salir_Click(object sender, RoutedEventArgs e)
        {
            this.personal.Estado = "Desconectado";
            PersonalDAO.actualizarEstadoUsuario(personal);
            this.Close();
        }
        private void btn_EditarDelegacion_Click(object sender, RoutedEventArgs e)
        {
            int index = dgDelegaciones.SelectedIndex;
            if (index >= 0)
            {
                Delegacion delegacion = listDelegacion[index];
                Boolean resultado = false;
                AgregarDelegacion ad = new AgregarDelegacion(this, false, delegacion);
                ad.ShowDialog();
                resultado = ad.Resultado;
                if (resultado)
                {
                    this.CargaDelegaciones();
                }
            }
            else
            {
                MessageBox.Show("Seleccione una delegacion");
            }

        }

        private void btn_EliminarDelegacion_Click(object sender, RoutedEventArgs e)
        {
            int index = dgDelegaciones.SelectedIndex;
            if (index>=0)
            {
                Delegacion delegacion = listDelegacion[index];
                if (MessageBox.Show("¿Desea eliminar el reporte con numero: " + delegacion.NumeroDelegacion + "?", "Eliminar reporte", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    DelegacionDAO.eliminarDelegacion(delegacion.IdDelegacion);
                    CargaDelegaciones();
                }


                }
            else
            {
                MessageBox.Show("Seleccione una delegacion");
            }
        }



        public void actualizar(int idPersonal, string numeroPersonal, string tipoPersonal, string apellidos, string nombre, string cargo, string usuario, string contrasena, string nombreDelegacion)
        {
            CargarUsuarios();
        }

        public void actualizar(int idDelegacion, int numeroDelegacion, string nombre, string colonia, string codigoPostal, string municipio, string telefono, string correo, string calle, string numeroDireccion)
        {
            CargaDelegaciones();
        }

        private void btn_EditarUsuario_Click(object sender, RoutedEventArgs e)
        {
            int index = dgPersonal.SelectedIndex;
            if (index >= 0)
            {
                Personal personal = listPersonal[index];
                Boolean resultado = false;
                RegistroUsuario ru = new RegistroUsuario(this, false, personal);
                ru.ShowDialog();
                resultado = ru.Resultado;
                if (resultado)
                {
                    this.CargaDelegaciones();
                }
            }
            else
            {
                MessageBox.Show("Seleccione una delegacion");
            }

        }

        private void btn_EliminarUsuario_Click(object sender, RoutedEventArgs e)
        {
            int index = dgPersonal.SelectedIndex;
            if (index >= 0)
            {
                Personal personal = listPersonal[index];
                if (MessageBox.Show("¿Desea eliminar el usuario: " + personal.Usuario + "?", "Eliminar reporte", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    PersonalDAO.eliminarPersonal(personal.IdPersonal);
                    CargarUsuarios();
                }


            }
            else
            {
                MessageBox.Show("Seleccione una delegacion");
            }
        }

        public void actualizar(int idReporte, int numeroReporte, string estatus, string nombreDelegacion, int folio, string direccion, DateTime fechaCreacion)
        {
            CargaReportes();
        }
    }
}
