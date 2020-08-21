using System;
using System.Collections.Generic;
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
using Transito_Veracruz.Model.security;

namespace Transito_Veracruz.Delegacion
{
    /// <summary>
    /// Lógica de interacción para Window1.xaml
    /// </summary>
    public partial class Login : Window
    {
        private String usuario;
        private String contraseñaIngresada;
        public Login()
        {
            InitializeComponent();

        }

        private void btn_Ingresar_Click(object sender, RoutedEventArgs e)
        {
            contraseñaIngresada = Encriptacion.Encriptar(txt_Contrasenia.Password);
            if (validacion())
            {
                usuario = txt_Usuario.Text;
                Personal personal = PersonalDAO.getLogin(usuario, contraseñaIngresada);
                if (personal!=null && personal.IdPersonal>0 && personal.Estado=="Desconectado" && personal.TipoPersonal=="Delegacion")
                {
                    personal.Estado="Conectado";
                    PersonalDAO.actualizarEstadoUsuario(personal);
                    MenuDelegacion menuPrincpipal = new MenuDelegacion(personal);
                    menuPrincpipal.Show();
                    this.Close();
                }
                else
                {

                    MessageBox.Show(this, "Error al iniciar sesion, intente de nuevo");
                    txt_Usuario.Text = "";
                    txt_Contrasenia.Password = "";
                    txt_Usuario.Focus();
                    Console.WriteLine("this is a test");
                }
            }
        }

        public bool validacion()
        {
            if (txt_Usuario.Text== null || txt_Usuario.Text.Length==0)
            {
                return false;
            }
            if (txt_Contrasenia.Password==null||txt_Contrasenia.Password.Length==0)
            {
                return false;
            }
            return true;
        }
    }
}
