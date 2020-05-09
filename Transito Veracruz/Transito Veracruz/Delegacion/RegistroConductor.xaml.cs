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
    /// Lógica de interacción para RegistroConductor.xaml
    /// </summary>
    public partial class RegistroConductor : Window
    {
        private Conductor conductor;
        public RegistroConductor()
        {
            InitializeComponent();
        }
        public bool Resultado { get => Resultado; set => Resultado = value; }

        private void btn_Cancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Resultado = false;
            this.Close();
        }

        private void btn_AgregarConductor_Click(object sender, RoutedEventArgs e)
        {
            this.conductor.NumeroLicencia = txt_Licencia.Text;
            this.conductor.Apellidos = txt_Apellidos.Text;
            this.conductor.Nombre = txt_Nombre.Text;
            this.conductor.Telefono = txt_Telefono.Text;
            this.conductor.Usuario = txt_NombreUsuario.Text;
            this.conductor.Contrasenia = txt_Contrasena.Text;

            if (this.conductor.NumeroLicencia == "" || this.conductor.Apellidos == "" || this.conductor.Nombre == "" || this.conductor.Telefono == ""
                || this.conductor.Usuario == "" || this.conductor.Contrasenia == "")
            {
                MessageBox.Show("Los campos no estan completos");
            }
            else
            {
                this.Resultado = ConductorDAO.agregarConductor(this.conductor, true);
                this.Close();
            }

        }
    }
}
