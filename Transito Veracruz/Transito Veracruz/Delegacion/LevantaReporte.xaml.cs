using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
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
using Microsoft.Win32;
using Transito_Veracruz.Model.dao;
using Transito_Veracruz.Model.db;
using Transito_Veracruz.Model.pocos;

namespace Transito_Veracruz.Delegacion
{
    /// <summary>
    /// Lógica de interacción para LevantaReporte.xaml
    /// </summary>
    public partial class LevantaReporte : Window
    {
        private int contador = 0;
        private int conductorSeleccionado;
        private String VehiculoConductor;
        private String archivoImg = "";
        Conductor informacionConductor;
        private byte[] img;

        public LevantaReporte()
        {
            InitializeComponent();
            cargarConductores();
        }

        private void btn_Cancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void cargarConductores()
        {
            SqlConnection conexion = null;

            try
            {
                conexion = ConnectionUtils.getConnection();
                SqlCommand command;
                if (conexion != null)
                {
                    String query = String.Format("SELECT idConductor,numeroLicencia FROM Conductor");
                    command = new SqlCommand(query, conexion);
                    SqlDataReader dr = command.ExecuteReader();

                    while (dr.Read() == true)
                    {
                        cb_Conductor.Items.Add(dr[1]);
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                Console.WriteLine("No se encontro el Conductor");
            }
        }

        public void consultarVehiculosDeConductor(int idConductor)
        {
            SqlConnection conexion = null;

            try
            {
                conexion = ConnectionUtils.getConnection();
                SqlCommand command;
                if (conexion != null)
                {
                    String query = String.Format("SELECT idVehiculo,numeroPlacas FROM Vehiculo WHERE idConductor='" + idConductor + "'");
                    command = new SqlCommand(query, conexion);
                    SqlDataReader dr = command.ExecuteReader();

                    while (dr.Read() == true)
                    {
                        cb_VehiculosConductor.Items.Add(dr[1]);
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                Console.WriteLine("No se encontro vehiculos del conductor");
            }

        }

        private void cb_Conductor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cb_Conductor.SelectedItem != null)
            {
                string numeroLicencia = cb_Conductor.SelectedItem.ToString();
                informacionConductor = ConductorDAO.getInformacionSeleccionada(numeroLicencia);

                box_Implicados.Items.Add(informacionConductor.Apellidos + " " + informacionConductor.Nombre);

                int identificadorConductor = informacionConductor.IdConductor;

                consultarVehiculosDeConductor(identificadorConductor);
                   

            }
            else
            {
                MessageBox.Show("Seleccione un vehiculo");
            }
            contador = 0;
        }

        private void cb_VehiculosConductor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


            if (cb_VehiculosConductor.SelectedItem != null)
            {
                //box_Implicados.Items.Add();
            }
            else
            {
                MessageBox.Show("Seleccione un vehiculo");
            }
        }

        private void btn_AgregarImagenes_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Selecciona una imagen";
            op.Filter = "PNG Files|*.png";

            if (op.ShowDialog() == true)
            {
                archivoImg = op.FileName;
                label_1.Content = archivoImg;
            }

            if (archivoImg.Length > 0)
            {
                img = ConvierteImageToByteArray(archivoImg);
            }
        }

        private static byte[] ConvierteImageToByteArray(string rutaArchivo)
        {
            Uri uri = new Uri(rutaArchivo);
            var image = new BitmapImage(uri);
            byte[] data;
            BitmapEncoder encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(image));
            using (MemoryStream ms = new MemoryStream())
            {
                encoder.Save(ms);
                data = ms.ToArray();
            }

            return data;
        }
    }
}
