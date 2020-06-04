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
using DireccionGeneral.Modelo;

namespace DireccionGeneral.VentanasDireccion
{
    /// <summary>
    /// Lógica de interacción para LoginDirGeneral.xaml
    /// </summary>
    public partial class LoginDirGeneral : Window
    {
        public LoginDirGeneral()
        {
            InitializeComponent();
        }

        private void btn_Ingresar_Click(object sender, RoutedEventArgs e)
        {

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
                        MenuDirGeneral dirGeneral = new MenuDirGeneral(idUser);
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

            }
        }
    
    }
}
