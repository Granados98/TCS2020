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
        private bool nuevo;
        private bool resultado;
        public AgregarDelegacion()
        {
            InitializeComponent();
        }

        private void btn_Cancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Resultado = false;
            this.Close();
        }

        public bool Resultado { get => resultado; set => resultado = value; }

        private void btn_AgregarDelegacion_Click(object sender, RoutedEventArgs e)
        {
            /* string calle = txt_Calle.Text;
            string codigoPostal = txt_CodigoPostal.Text;
            string colonia = txt_Colonia.Text;
            string correo = txt_Correo.Text;
            string nombre = txt_Nombre.Text;
            string numeroDireccion = txt_NumeroCalle.Text;
            string telefono = txt_Telefono.Text;
            string municipio = txt_Municipio.Text; */

            var random = new Random();
            int numeroDelegacion = random.Next(1, 1000);

            /* if (calle.Length > 0 && codigoPostal.Length > 0 && colonia.Length > 0 && correo.Length > 0 && nombre.Length > 0 && numeroDireccion.Length > 0 && telefono.Length > 0 && municipio.Length > 0)
            { */

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

            DelegacionDAO.guardaDelegacion(delegacion, nuevo);

            this.Close();
            /* this.Resultado = true;
            if (nuevo)
            {
                int idDelegacionAux = DelegacionDAO.getIDelegacion(numeroDelegacion);
                this.itActualizar.actualizar(idConductorAux, numeroLicencia, apellidos, nombre, fechaNacimiento, telefono);
            }
            this.itActualizar.actualizar(idConductorA, numeroLicencia, apellidos, nombre, fechaNacimiento, telefono);
            this.Close();
            else
            {
                MessageBox.Show(this, "LLena todos los campos");
            } */
        }
    } 

}


