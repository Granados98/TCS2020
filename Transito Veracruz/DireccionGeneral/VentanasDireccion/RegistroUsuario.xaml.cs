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
using DireccionGeneral.Model.daoDireccion;
using DireccionGeneral.Model.dbDireccion;
using DireccionGeneral.Model.pocosDireccion;

namespace DireccionGeneral.VentanasDireccion
{
    /// <summary>
    /// Lógica de interacción para RegistroUsuario.xaml
    /// </summary>
    public partial class RegistroUsuario : Window
    {
        Personal personal;
        public RegistroUsuario()
        {
            InitializeComponent();
            cargarDelegaciones();
        }

        private void cargarDelegaciones()
        {
            SqlConnection conexion = null;

            try
            {
                conexion = ConnectionUtils.getConnection();
                SqlCommand command;
                if (conexion != null)
                {
                    String query = String.Format("SELECT idDelegacion,numeroDelegacion,nombre FROM Delegacion");
                    command = new SqlCommand(query, conexion);
                    SqlDataReader dr = command.ExecuteReader();

                    while (dr.Read() == true)
                    {
                        cb_Delegacion.Items.Add(dr[2]);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void btn_Cancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_AgregarUsuario_Click(object sender, RoutedEventArgs e)
        {
            var random = new Random();
            int numeroPersonal = random.Next(1, 1000);
            string numero=Convert.ToString(numeroPersonal);

            personal = new Personal();
            personal.NumeroPersonal = numero;
            personal.NombreDelegacion = cb_Delegacion.Text;
            personal.Cargo = cb_Cargo.Text;
            personal.TipoPersonal = cb_Personal.Text;
            personal.Nombre = txt_Nombre.Text;
            personal.Apellidos = txt_Apellidos.Text;
            personal.Usuario = txt_Usuario.Text;
            personal.Contrasenia = txt_Contraseña.Text;
            personal.Estado = "Desconectado";
            
            PersonalDAO.guardarUsuario(personal);
        }
    }
}
