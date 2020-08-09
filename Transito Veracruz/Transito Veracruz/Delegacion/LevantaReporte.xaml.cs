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
using Transito_Veracruz.Model.interfaz;
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

        private string delegacionSeleccionada;

        private byte[] img;

        InterfaceMenu itActualizar;

        public LevantaReporte(InterfaceMenu itActualizar)
        {
            this.itActualizar = itActualizar;
            InitializeComponent();
            cargarConductores();
            cargarDelegaciones();
        }

        private void btn_Cancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cargarConductores()
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

        private void consultarVehiculosDeConductor(int idConductor)
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

        private bool verificaVehiculoRepetido(int idVehiculoSeleccionado)
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
                if (op.FileNames.Length>=3 && op.FileNames.Length<=8)
                {
                    archivosImg = op.FileNames;

                    Console.WriteLine(archivosImg);
                    foreach (var archivo in archivosImg)
                    {
                        archivos = "" + archivo;
                        box_Imagenes.Items.Add(archivos);
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione de 3 a 8 imagenes");
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

        private void cargarDelegaciones()
        {
            SqlConnection conexion = null;

            try
            {
                conexion = ConnectionUtils.getConnection();
                SqlCommand command;
                if (conexion != null)
                {
                    String query = String.Format("SELECT idDelegacion,nombre FROM Delegacion");
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

        private void btn_AgregarReporte_Click(object sender, RoutedEventArgs e)
        {
            Reporte nuevoReporte = new Reporte();

            var dateAux = DateTime.Now;

            string estatus = "No revisado";
            string direccion = txt_Direccion.Text;
            string delegacion = delegacionSeleccionada;

            try
            {
                nuevoReporte.Estatus = "No revisado";
                nuevoReporte.Direccion = txt_Direccion.Text;
                nuevoReporte.NombreDelegacion=delegacionSeleccionada;
                nuevoReporte.FechaCreacion = dateAux;

                ReporteDAO.guardaReporte(nuevoReporte);
                int idReporteAux=ReporteDAO.consultaReporteNuevo(dateAux);

                Reporte_Vehiculo reporte_Vehiculo = new Reporte_Vehiculo();
                foreach (var a in listVehiculos)
                {
                    if (a.IdVehiculo > 0)
                    {
                        int idVehiculoObtenido = a.IdVehiculo;
                        reporte_Vehiculo.IdVehiculo = idVehiculoObtenido;
                        reporte_Vehiculo.IdReporte = idReporteAux;
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
                        imagen.IdReporte = idReporteAux;
                        ImagenDAO.guardarImagen(imagen);
                    }
                }

                this.Close();
                this.itActualizar.actualizar(idReporteAux, estatus, delegacion, direccion);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void cb_Delegacion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cb_Conductor.SelectedItem != null)
            {
                delegacionSeleccionada = cb_Conductor.SelectedItem.ToString();
            }
            else
            {
                MessageBox.Show("Seleccione un vehiculo");
            }
        }

        private void btn_EliminarImagen_Click(object sender, RoutedEventArgs e)
        {
            int index = box_Imagenes.SelectedIndex;
            if(index >= 0)
            {
                string imagenSeleccionada = archivosImg[index];

                if (box_Imagenes.SelectedItem!=null)
                {
                    foreach(var img in archivosImg)
                    {
                        if (img != imagenSeleccionada)
                        {
                            box_Imagenes.Items.Add(img);
                        }
                    }

                }
            }
        }
    }
}
