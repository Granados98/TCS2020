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
using DireccionGeneral.Model.securityDireccion;

namespace DireccionGeneral.VentanasDireccion
{
    /// <summary>
    /// Lógica de interacción para LoginDirGeneral.xaml
    /// </summary>
    public partial class LoginDirGeneral : Window
    {
        private String usuario;
        private String contraseñaIngresada;
        public LoginDirGeneral()
        {
            InitializeComponent();
        }

        private void btn_Ingresar_Click(object sender, RoutedEventArgs e)
        {

            contraseñaIngresada = Encriptacion.GetSHA256(txt_Contrasenia.Password);
            if (validacion())
            {
                usuario = txt_Usuario.Text;
                Personal personal = PersonalDAO.getLogin(usuario, contraseñaIngresada);
                if (personal != null && personal.IdPersonal > 0 && personal.Estado == "Desconectado")
                {
                    personal.Estado = "Conectado";
                    PersonalDAO.actualizarEstadoUsuario(personal);
                    MenuDirGeneral menuPrincpipal = new MenuDirGeneral(personal);
                    menuPrincpipal.Show();
                    this.Close();
                }
                else
                {

                    MessageBox.Show(this, "Usuario no registrado");
                    txt_Usuario.Text = "";
                    txt_Contrasenia.Password = "";
                    txt_Usuario.Focus();
                    Console.WriteLine("this is a test");
                }
            }
            /*
            if (string.IsNullOrEmpty(txtUsuario.Text) || string.IsNullOrEmpty(txtContrasenia.Password))
            {
                MessageBox.Show("Usuario y/o contraseña vacios, por favor introduzca sus datos.", "Error");
                txtUsuario.Focus();
                txtUsuario.Focus();
                return;
            }
            try
            {
                // IQueryable query;
                using (SistemaTransitoEntities1 db = new SistemaTransitoEntities1())
                {
                    var query = from U in db.Personal
                                where U.usuario == txtUsuario.Text && U.contrasena == txtContrasenia.Password
                                select (U.idPersonal);

                    if (query.Count() > 0)
                    {
                        int idUser = query.First();

                        MessageBox.Show(this, "Bienvenido: " + txtUsuario.Text, "Información");
                        MenuDirGeneral dirGeneral = new MenuDirGeneral();
                        dirGeneral.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Usuario y/o contraseña incorrectos, por favor introduzca sus datos.", "Error");
                    }
                }

            }
            catch
            {
                MessageBox.Show("Error");

            }*/
        }
        public bool validacion()
        {
            if (txt_Usuario.Text == null || txt_Usuario.Text.Length == 0)
            {
                return false;
            }
            if (txt_Contrasenia.Password == null || txt_Contrasenia.Password.Length == 0)
            {
                return false;
            }
            return true;
        }

    }
}
