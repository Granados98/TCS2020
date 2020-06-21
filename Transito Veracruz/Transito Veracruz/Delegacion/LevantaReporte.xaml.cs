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
        private int identificadorConductor;
        private int idVehiculoSeleccionado;
        private String[] archivosImg;

        private List<Vehiculo> listVehiculos = new List<Vehiculo>();
        private Conductor informacionConductor;
        private Vehiculo vehiculoConductor;

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
            cb_VehiculosConductor.Items.Clear();
            if (cb_Conductor.SelectedItem != null)
            {
                string numeroLicencia = cb_Conductor.SelectedItem.ToString();
                informacionConductor = ConductorDAO.getInformacionSeleccionada(numeroLicencia);


                identificadorConductor = informacionConductor.IdConductor;
                consultarVehiculosDeConductor(identificadorConductor);
                   

            }
            else
            {
                MessageBox.Show("Seleccione un vehiculo");
            }

        }

        public bool verificaVehiculoRepetido(int idVehiculoSeleccionado)
        {
            foreach (var a in listVehiculos)
            {
                if (a.IdVehiculo==idVehiculoSeleccionado)
                {
                    return true;
                }
            }
            return false;
        }

        private void cb_VehiculosConductor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (cb_VehiculosConductor.SelectedItem != null)
            {
                string numeroPlacas = cb_VehiculosConductor.SelectedItem.ToString();
                vehiculoConductor = VehiculoDAO.getVehiculoConductor(numeroPlacas);
                idVehiculoSeleccionado = vehiculoConductor.IdVehiculo;
                Console.WriteLine(idVehiculoSeleccionado);
                
                if (!verificaVehiculoRepetido(idVehiculoSeleccionado))
                {
                    box_Implicados.Items.Add(informacionConductor.Apellidos + " " + informacionConductor.Nombre + " " + vehiculoConductor.NumeroPlacas + " " + vehiculoConductor.Marca + " " + vehiculoConductor.Modelo);
                    listVehiculos.Add(vehiculoConductor);
                }
                else
                {
                    MessageBox.Show("Vehiculo ya está agregado");
                }
            }
        }

        private void btn_AgregarImagenes_Click(object sender, RoutedEventArgs e)
        {
            String archivos="";
            OpenFileDialog op = new OpenFileDialog();
            op.Multiselect = true;
            op.Title = "Selecciona una imagen";
            op.Filter = "JPG,JPEG,PNG Files|*.png;*.jpg;*.jpeg";
            
            if (op.ShowDialog() == true)
            {
                archivosImg = op.FileNames;

                Console.WriteLine(archivosImg);
                foreach (var archivo in archivosImg)
                {
                    archivos = "" + archivo;
                    MessageBox.Show(archivos);
                }
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

        private void btn_AgregarReporte_Click(object sender, RoutedEventArgs e)
        {
            Reporte nuevoReporte = new Reporte();
            var random = new Random();
            int numeroReporte = random.Next(1,1000);
            Console.WriteLine(numeroReporte);

            try
            {
                nuevoReporte.NumeroReporte = numeroReporte;
                nuevoReporte.Estatus = "No revisado";
                int numeroReporteObtenido = nuevoReporte.NumeroReporte;
                ReporteDAO.guardaReporte(nuevoReporte);

                Reporte_Vehiculo reporte_Vehiculo = new Reporte_Vehiculo();
                foreach (var a in listVehiculos)
                {
                    if (a.IdVehiculo > 0)
                    {
                        int idVehiculoObtenido = a.IdVehiculo;
                        reporte_Vehiculo.IdVehiculo = idVehiculoObtenido;
                        reporte_Vehiculo.NumeroReporte = numeroReporteObtenido;
                        Reporte_VehiculoDAO.guardarReporteVehiculo(reporte_Vehiculo);
                    }
                }


                Imagen imagen = new Imagen();
                if (archivosImg.Length > 0)
                {
                    foreach (var archivo in archivosImg)
                    {
                        img = ConvierteImageToByteArray(archivo);
                        imagen.Dato = img;
                        imagen.NumeroReporte = numeroReporteObtenido;
                        ImagenDAO.guardarImagen(imagen);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
