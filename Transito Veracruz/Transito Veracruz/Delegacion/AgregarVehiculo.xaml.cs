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
using Transito_Veracruz.Model.interfaz;
using Transito_Veracruz.Model.pocos;
using Transito_Veracruz.Model.security;

namespace Transito_Veracruz.Delegacion
{
    /// <summary>
    /// Lógica de interacción para AgregarVehiculo.xaml
    /// </summary>
    public partial class AgregarVehiculo : Window
    {
        private int idVehiculo;
        private int idConductorSeleccionado;
        private Vehiculo vehiculo;
        private bool nuevo;
        private bool resultado;

        InterfaceMenu itActualizar;
        public AgregarVehiculo(InterfaceMenu itActualizar, Boolean nuevo, Vehiculo vehiculo)
        {
            this.vehiculo = vehiculo;
            this.nuevo = nuevo;
            this.itActualizar = itActualizar;
            InitializeComponent();
            cargarConductores();

            if (!nuevo)
            {
                txt_Marca.Text = vehiculo.Marca;
                txt_Modelo.Text = vehiculo.Modelo;
                txt_Año.Text = vehiculo.Anio;
                txt_Color.Text = vehiculo.Color;
                txt_NumeroPlaca.Text = vehiculo.NumeroPlacas;
                txt_Aseguradora.Text = vehiculo.NombreAseguradora;
                txt_Poliza.Text = vehiculo.NumeroPolizaSeguro;

                int idConductorEditar = vehiculo.IdConductor;

                cargarLicenciaConductor(idConductorEditar);
                cb_Conductores.IsEnabled=false;
            }
        }
        public bool Resultado { get => resultado; set => resultado = value; }

        private void cargarLicenciaConductor(int idConductor)
        {
            cb_Conductores.Text = ConductorDAO.getLicenciaConductor(idConductor);
        }

        private void cargarConductores()
        {
            SqlConnection conexion = null;

            try
            {
                conexion = ConnectionUtils.getConnection();
                SqlCommand command;
                if (conexion!=null)
                {
                    String query = String.Format("SELECT numeroLicencia FROM Conductor");
                    command = new SqlCommand(query, conexion);
                    SqlDataReader dr = command.ExecuteReader();

                    while (dr.Read() == true)
                    {
                        cb_Conductores.Items.Add(dr[0]);
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                Console.WriteLine("No se encontro el Conductor");
            }
        }

        private void btn_Cancelar(object sender, RoutedEventArgs e)
        {
            this.Resultado = false;
            this.Close();
        }

        private void btn_AgregarVehiculo_Click(object sender, RoutedEventArgs e)
        {
            string numeroPlacas = txt_NumeroPlaca.Text;
            string marca = txt_Marca.Text;
            string modelo = txt_Modelo.Text;
            string anio = txt_Año.Text;
            string color = txt_Color.Text;
            string nombreAseguradora = txt_Aseguradora.Text;
            string numeroPoliza = txt_Poliza.Text;

            if (cb_Conductores.SelectedItem == null || marca.Length>0 || modelo.Length>0 || anio.Length>0 || color.Length>0 || numeroPlacas.Length>0 || nombreAseguradora.Length>0 || numeroPoliza.Length> 0)
            {
                this.vehiculo.IdConductor = idConductorSeleccionado;
                this.vehiculo.NombreAseguradora = txt_Aseguradora.Text;
                this.vehiculo.Anio = txt_Año.Text;
                this.vehiculo.Color = txt_Color.Text;
                this.vehiculo.Marca = txt_Marca.Text;
                this.vehiculo.Modelo = txt_Modelo.Text;
                this.vehiculo.NumeroPlacas = txt_NumeroPlaca.Text;
                this.vehiculo.NumeroPolizaSeguro = txt_Poliza.Text;
                this.vehiculo.FechaCreacion = DateTime.Now;

                VehiculoDAO.guardaVehiculo(this.vehiculo, this.nuevo);
                this.Resultado = true;
                if (nuevo)
                {
                    int idVehiculoAux = VehiculoDAO.getIdVehiculo(numeroPlacas);
                    this.itActualizar.actualizar(numeroPlacas, marca, modelo, anio, color, nombreAseguradora, numeroPoliza);
                }
                else
                {
                    this.itActualizar.actualizar(numeroPlacas, marca, modelo, anio, color, nombreAseguradora, numeroPoliza);
                }
                this.Close();
            }
            else
            {
                MessageBox.Show(this, "LLena todos los campos");
            }
        }

        private bool validarCampos()
        {
            if (this.vehiculo.NumeroPlacas== "" || this.vehiculo.Marca == "" || this.vehiculo.Modelo == "" || this.vehiculo.Anio == ""
                || this.vehiculo.Color == "" || this.vehiculo.NumeroPlacas == "" || this.vehiculo.NumeroPolizaSeguro == "" || this.vehiculo.NombreAseguradora == "")
            {
                return true;
            }
            return false;
        }

        private void txt_Marca_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Validacion.soloLetras(e);
        }

        private void txt_Modelo_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Validacion.soloLetras(e);
        }

        private void txt_Año_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Validacion.soloNumeros(e);
        }

        private void txt_Color_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Validacion.soloLetras(e);
        }

        private void txt_NumeroPlaca_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
        }

        private void txt_Aseguradora_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Validacion.soloLetras(e);
        }

        private void txt_Poliza_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Validacion.soloNumeros(e);
        }

        private void cb_Conductores_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cb_Conductores.SelectedItem!=null)
            {
                String numeroLicencia= cb_Conductores.SelectedItem.ToString();
                Console.WriteLine(numeroLicencia);
                Conductor conductorSeleccionado = ConductorDAO.getInformacionSeleccionada(numeroLicencia);
                idConductorSeleccionado=conductorSeleccionado.IdConductor;
                
                MessageBox.Show("Numero de Licencia: "+ conductorSeleccionado.NumeroLicencia + " Apellidos: "+ conductorSeleccionado.Apellidos + " Nombre: " + conductorSeleccionado.Nombre + " Fecha de Nacimiento: "+conductorSeleccionado.FechaNacimiento +
                    " Telefono: "+ conductorSeleccionado.Telefono+" Usuario: "+ conductorSeleccionado.Usuario);
            }
            else
            {
                MessageBox.Show("Seleccione un conductor");
            }
        }

    }
}
