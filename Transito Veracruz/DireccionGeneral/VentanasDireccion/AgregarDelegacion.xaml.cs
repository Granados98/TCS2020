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
using DireccionGeneral.Model.securityDireccion;

namespace DireccionGeneral.VentanasDireccion
{
    /// <summary>
    /// Lógica de interacción para AgregarDelegacion.xaml
    /// </summary>
    public partial class AgregarDelegacion : Window
    {
        private bool nuevo;
        private bool resultado;
        private InterfaceMenu itActualizar;
        private Delegacion delegacion;
        private int idDelegacionEditar;
        public AgregarDelegacion(InterfaceMenu itActualizar,Boolean nuevo,Delegacion delegacion)
        {
            this.delegacion = delegacion;
            this.nuevo = nuevo;
            this.itActualizar = itActualizar;
            InitializeComponent();
            if (!nuevo)
            {
                txt_Nombre.Text = delegacion.Nombre;
                txt_Calle.Text = delegacion.Calle;
                txt_NumeroCalle.Text = delegacion.NumeroDireccion;
                txt_Colonia.Text = delegacion.Colonia;
                txt_CodigoPostal.Text = delegacion.CodigoPostal;
                txt_Telefono.Text = delegacion.Telefono;
                txt_Municipio.Text = delegacion.Municipio;
                txt_Correo.Text = delegacion.CorreoElectronico;

                idDelegacionEditar = delegacion.IdDelegacion;
            }
        }

        public bool Resultado { get => resultado; set => resultado = value; }

        private void btn_Cancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Resultado = false;
            this.Close();
        }

        private void btn_AgregarDelegacion_Click(object sender, RoutedEventArgs e)
        {
            string calle = txt_Calle.Text;
            string codigoPostal = txt_CodigoPostal.Text;
            string colonia = txt_Colonia.Text;
            string correo = txt_Correo.Text;
            string nombre = txt_Nombre.Text;
            string numeroDireccion = txt_NumeroCalle.Text;
            string telefono = txt_Telefono.Text;
            string municipio = cb_Municipio.Text;

            if (calle.Length > 0 && codigoPostal.Length > 0 && colonia.Length > 0 && correo.Length > 0 && nombre.Length > 0 && numeroDireccion.Length > 0 && telefono.Length > 0 && municipio.Length > 0)
            {

                delegacion.Calle = txt_Calle.Text;
                delegacion.CodigoPostal = txt_CodigoPostal.Text;
                delegacion.Colonia = txt_Colonia.Text;
                delegacion.CorreoElectronico = txt_Correo.Text;
                delegacion.Nombre = txt_Nombre.Text;
                delegacion.NumeroDireccion = txt_NumeroCalle.Text;
                delegacion.Telefono = txt_Telefono.Text;
                delegacion.Municipio = txt_Municipio.Text;

                DelegacionDAO.guardaDelegacion(this.delegacion, this.nuevo);

                this.Close();
                this.Resultado = true;
                if (nuevo)
                {
                    int idDelegacionAux = DelegacionDAO.getIdDelegacion(nombre);
                    this.itActualizar.actualizar(idDelegacionAux, nombre, colonia, codigoPostal, municipio, telefono, correo, calle, numeroDireccion);
                }
                this.itActualizar.actualizar(idDelegacionEditar, nombre, colonia, codigoPostal, municipio, telefono, correo, calle, numeroDireccion);
                this.Close();
            }
            else
            {
                MessageBox.Show(this, "LLena todos los campos");
            }
        }

        private void txt_Nombre_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Validacion.soloLetras(e);
        }

        private void txt_Calle_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Validacion.soloLetras(e);
        }

        private void txt_NumeroCalle_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Validacion.soloNumeros(e);
        }

        private void txt_Colonia_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Validacion.soloLetras(e);
        }

        private void txt_CodigoPostal_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Validacion.soloNumeros(e);
        }

        private void txt_Telefono_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Validacion.soloNumeros(e);
        }
    } 

}



