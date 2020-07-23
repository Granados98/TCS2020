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
using DireccionGeneral.Model.InterfaceDireccion;
using DireccionGeneral.Model.pocosDireccion;
using DireccionGeneral.Model.securityDireccion;

namespace DireccionGeneral.VentanasDireccion
{
    /// <summary>
    /// Lógica de interacción para RegistroUsuario.xaml
    /// </summary>
    public partial class RegistroUsuario : Window
    {
        private Personal personal;
        private InterfaceMenu itActualizar;
        private bool nuevo;
        private bool resultado;
        private int idPersonalObtenido;
        public RegistroUsuario(InterfaceMenu itActualizar, Boolean nuevo, Personal personal)
        {
            this.itActualizar = itActualizar;
            this.nuevo = nuevo;
            this.personal = personal;
            InitializeComponent();
            cargarDelegaciones();

            if (!nuevo)
            {
                cb_Delegacion.Text = personal.NombreDelegacion;
                cb_Personal.Text= personal.TipoPersonal;
                cb_Cargo.Text = personal.Cargo;
                txt_Apellidos.Text = personal.Apellidos;
                txt_Nombre.Text = personal.Nombre;
                txt_Usuario.Text = personal.Usuario;

                idPersonalObtenido = personal.IdPersonal;
                Console.WriteLine(idPersonalObtenido);

            }
        }
        public bool Resultado { get => resultado; set => resultado = value; }
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
            this.Resultado = false;
            this.Close();
        }

        private void btn_AgregarUsuario_Click(object sender, RoutedEventArgs e)
        {
            var random = new Random();
            int numeroPersonal = random.Next(1, 1000);
            string numeroPersonalAux=Convert.ToString(numeroPersonal);

            string nombre = txt_Nombre.Text;
            string apellidos = txt_Apellidos.Text;
            string nombreUsuario = txt_Usuario.Text;
            string contrasenia = txt_Contraseña.Text;
            string cargo = cb_Cargo.Text;
            string tipoPersonal = cb_Personal.Text;
            string nombreDelefacion = cb_Delegacion.Text;

            if (cb_Delegacion.SelectedItem == null || cb_Cargo.SelectedItem == null || cb_Personal.SelectedItem == null || nombre.Length > 0 || apellidos.Length > 0 || nombreUsuario.Length > 0 || contrasenia.Length > 0)
            {
                this.personal.NumeroPersonal = numeroPersonalAux;
                this.personal.NombreDelegacion = cb_Delegacion.Text;
                this.personal.Cargo = cb_Cargo.Text;
                this.personal.TipoPersonal = cb_Personal.Text;
                this.personal.Nombre = txt_Nombre.Text;
                this.personal.Apellidos = txt_Apellidos.Text;
                this.personal.Usuario = txt_Usuario.Text;
                this.personal.Contrasenia = txt_Contraseña.Text;
                this.personal.Estado = "Desconectado";

                PersonalDAO.guardarUsuario(this.personal, this.nuevo);
                this.Resultado = true;
                if (nuevo)
                {
                    int idPersonalAux = PersonalDAO.getIdPersonal(numeroPersonalAux);
                    this.itActualizar.actualizar(idPersonalAux, numeroPersonalAux, tipoPersonal, apellidos, nombre, cargo,nombreUsuario,contrasenia,nombreDelefacion);
                }
                else
                {
                    this.itActualizar.actualizar(idPersonalObtenido, numeroPersonalAux, tipoPersonal, apellidos, nombre, cargo, nombreUsuario, contrasenia, nombreDelefacion);
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Llena todos los campos");
            }
        }
    }
}
