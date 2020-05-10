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
            if (validarCampos())
            {
                this.conductor.NumeroLicencia = txt_Licencia.Text;
                this.conductor.Apellidos = txt_Apellidos.Text;
                this.conductor.Nombre = txt_Nombre.Text;
                this.conductor.Telefono = txt_Telefono.Text;
                this.conductor.Usuario = txt_NombreUsuario.Text;
                this.conductor.Contrasenia = txt_Contrasena.Text;

                this.Resultado = ConductorDAO.agregarConductor(this.conductor, true);
                this.Close();
            }
            else
            {
                MessageBox.Show(this, "LLena todos los campos");
            }
        }


        public bool validarCampos()
        {
            if (txt_Licencia.Text.Length!=0 || txt_Apellidos.Text.Length!=0 || txt_Nombre.Text.Length!=0|| txt_Contrasena.Text.Length!=0 
                || txt_NombreUsuario.Text.Length!=0 || txt_Telefono.Text.Length!=0)
            {
                return true;
            }
            return false;
        }
    }
}
