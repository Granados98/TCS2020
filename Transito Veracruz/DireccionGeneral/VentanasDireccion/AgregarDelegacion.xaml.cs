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
    /// Lógica de interacción para AgregarDelegacion.xaml
    /// </summary>
    public partial class AgregarDelegacion : Window
    {
        Delegacion delegacion;
        public AgregarDelegacion()
        {
            InitializeComponent();
        }

        private void btn_Cancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_AgregarDelegacion_Click(object sender, RoutedEventArgs e)
        {

            var random = new Random();
            int numeroDelegacion = random.Next(1, 1000);

            delegacion = new Delegacion();
            delegacion.NumeroDelegacion = numeroDelegacion;
            delegacion.Calle = txt_Calle.Text;
            delegacion.CodigoPostal = txt_CodigoPostal.Text;
            delegacion.Colonia = txt_Colonia.Text;
            delegacion.CorreoElectronico = txt_Correo.Text;
            delegacion.Nombre = txt_Nombre.Text;
            delegacion.NumeroDireccion = txt_NumeroCalle.Text;
            delegacion.Telefono = txt_Telefono.Text;
            delegacion.Municipio = txt_Municipio.Text;

            DelegacionDAO.guardaDelegacion(delegacion);

            this.Close();
        }
    }
}
