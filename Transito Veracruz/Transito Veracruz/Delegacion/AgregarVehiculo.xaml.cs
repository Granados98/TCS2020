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

namespace Transito_Veracruz.Delegacion
{
    /// <summary>
    /// Lógica de interacción para AgregarVehiculo.xaml
    /// </summary>
    public partial class AgregarVehiculo : Window
    {
        private Vehiculo vehiculo = new Vehiculo();
        public AgregarVehiculo()
        {
            InitializeComponent();
            cargarConductores();
        }

        public void cargarConductores()
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
            this.Close();
        }

        private void btn_AgregarVehiculo_Click(object sender, RoutedEventArgs e)
        {
            if (validarCampos())
            {
                this.vehiculo.NumeroLicencia = cb_Conductores.Text;
                this.vehiculo.NombreAseguradora = txt_Aseguradora.Text;
                this.vehiculo.Anio = txt_Año.Text;
                this.vehiculo.Color = txt_Color.Text;
                this.vehiculo.Marca = txt_Marca.Text;
                this.vehiculo.Modelo = txt_Modelo.Text;
                this.vehiculo.NumeroPlacas = txt_NumeroPlaca.Text;
                this.vehiculo.NumeroPolizaSeguro = txt_Poliza.Text;


                VehiculoDAO.guardaVehiculo(this.vehiculo);
                this.Close();
            }
            else
            {
                MessageBox.Show(this, "LLena todos los campos");
            }
        }

        public bool validarCampos()
        {
            if (this.vehiculo.NumeroLicencia == "" || this.vehiculo.Marca == "" || this.vehiculo.Modelo == "" || this.vehiculo.Anio == ""
                || this.vehiculo.Color == "" || this.vehiculo.NumeroPlacas == "" || this.vehiculo.NumeroPolizaSeguro == "" || this.vehiculo.NombreAseguradora == "")
            {
                return true;
            }
            return false;
        }
    }
}
