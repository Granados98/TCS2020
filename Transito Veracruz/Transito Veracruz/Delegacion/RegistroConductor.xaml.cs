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
using Transito_Veracruz.Model.interfaz;
using Transito_Veracruz.Model.pocos;
using Transito_Veracruz.Model.security;

namespace Transito_Veracruz.Delegacion
{
    /// <summary>
    /// Lógica de interacción para RegistroConductor.xaml
    /// </summary>
    public partial class RegistroConductor : Window
    {
        private bool resultado;
        private bool nuevo;
        private Conductor conductor;
        InterfaceMenu itActualizar;
        public RegistroConductor(InterfaceMenu itActualizar, Boolean nuevo, Conductor conductor)
        {
            this.conductor = conductor;
            this.nuevo = nuevo;
            this.itActualizar = itActualizar;
            InitializeComponent();

            //String.Format("{0:MM/dd/yyyy}", select_Date);
            if (!nuevo)
            {
                txt_Apellidos.Text = conductor.Apellidos;
                txt_Nombre.Text = conductor.Nombre;
                select_Date.SelectedDate = Convert.ToDateTime(conductor.FechaNacimiento);
                txt_Licencia.Text = conductor.NumeroLicencia;
                txt_Telefono.Text = conductor.Telefono;
                txt_NombreUsuario.Text = conductor.Usuario;

                string desencriptada = Encriptacion.DesEncriptar(conductor.Contrasenia);
                txt_Contrasena.Text = desencriptada;

            }
        }

        public bool Resultado { get => resultado; set => resultado = value; }
        private void btn_Cancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Resultado = false;
            this.Close();
        }

        private void btn_AgregarConductor_Click(object sender, RoutedEventArgs e)
        {
            String contraseñaEncriptada;
            string numeroLicencia = txt_Licencia.Text;
            string apellidos = txt_Apellidos.Text;
            string nombre = txt_Nombre.Text;
            string telefono = txt_Telefono.Text;
            string usuario = txt_NombreUsuario.Text;
            string contrasena = txt_Contrasena.Text;
            DateTime fechaNacimiento = select_Date.SelectedDate.Value;
            string fechaNacimientoAux = fechaNacimiento.ToString("dd/MM/yyyy");

            if (apellidos.Length>0 && nombre.Length>0 && numeroLicencia.Length>0 && telefono.Length>0 && usuario.Length>0 && contrasena.Length>0) { 
                this.conductor.NumeroLicencia = txt_Licencia.Text;
                this.conductor.Apellidos = txt_Apellidos.Text;
                this.conductor.FechaNacimiento = fechaNacimientoAux;
                this.conductor.Nombre = txt_Nombre.Text;
                this.conductor.Telefono = txt_Telefono.Text;
                this.conductor.Usuario = txt_NombreUsuario.Text;
                this.conductor.FechaRegistro = DateTime.Now;

                contraseñaEncriptada = Encriptacion.Encriptar(txt_Contrasena.Text);
                this.conductor.Contrasenia = contraseñaEncriptada;

                ConductorDAO.guardarConductor(this.nuevo,this.conductor);
                this.Resultado = true;
                if (nuevo)
                {
                    int idConductorAux = ConductorDAO.getIdConductor(numeroLicencia);
                    this.itActualizar.actualizar(numeroLicencia, apellidos, nombre, fechaNacimientoAux, telefono);
                }
                this.itActualizar.actualizar(numeroLicencia,apellidos,nombre,fechaNacimientoAux,telefono);
                this.Close();
                }
                else
                {
                MessageBox.Show(this, "LLena todos los campos");
                }
        }

        public bool validaFecha(DateTime fecha)
        {
            if (fecha.Date.ToString()=="")
            {
                return true;
            }
            return false;
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

        private void txt_Apellidos_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Validacion.soloLetras(e);
        }

        private void txt_Nombre_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Validacion.soloLetras(e);
        }
    }
}
