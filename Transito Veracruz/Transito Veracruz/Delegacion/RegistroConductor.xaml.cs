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
using Transito_Veracruz.Model.security;

namespace Transito_Veracruz.Delegacion
{
    /// <summary>
    /// Lógica de interacción para RegistroConductor.xaml
    /// </summary>
    public partial class RegistroConductor : Window
    {
        private Conductor conductor = new Conductor();
        public RegistroConductor()
        {
            InitializeComponent();
        }

        private void btn_Cancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_AgregarConductor_Click(object sender, RoutedEventArgs e)
        {
            String contraseñaEncriptada;
            if (validarCampos()) { 
                this.conductor.NumeroLicencia = txt_Licencia.Text;
                this.conductor.Apellidos = txt_Apellidos.Text;
                this.conductor.FechaNacimiento = select_Date.SelectedDate.Value;
                this.conductor.Nombre = txt_Nombre.Text;
                this.conductor.Telefono = txt_Telefono.Text;
                this.conductor.Usuario = txt_NombreUsuario.Text;

                contraseñaEncriptada = Encriptacion.GetSHA256(txt_Contrasena.Text);
                this.conductor.Contrasenia = contraseñaEncriptada;

                ConductorDAO.agregarConductor(this.conductor);
                this.Close();
                }
                else
                {
                MessageBox.Show(this, "LLena todos los campos");
                }
        }

        
        public bool validarCampos()
        {
            if (this.conductor.NumeroLicencia == "" || this.conductor.Apellidos == "" || this.conductor.Nombre == "" || this.conductor.Telefono == ""
                || this.conductor.Usuario == "" || this.conductor.Contrasenia == "")
            {
                return true;
            }
            return false;
        }

        private void txt_Licencia_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Validacion.soloNumeros(e);
        }

        private void txt_Telefono_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Validacion.soloNumeros(e);
        }
    }
}
