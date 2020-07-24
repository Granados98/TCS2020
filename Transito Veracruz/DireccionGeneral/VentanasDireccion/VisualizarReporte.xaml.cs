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
    /// Lógica de interacción para VisualizarReporte.xaml
    /// </summary>
    public partial class VisualizarReporte : Window
    {
        Reporte reporte;
        private List<int> listVehiculos;
        public VisualizarReporte(Reporte reporte)
        {
            this.reporte = reporte;
            InitializeComponent();
            int numeroReporte = reporte.NumeroReporte;

            consultarInvolucrados(numeroReporte);

            string numReporte = Convert.ToString(numeroReporte);
            txt_NumReporte.Text = numReporte;
            txt_Delegacion.Text = reporte.NombreDelegacion;
            txt_Direccion.Text = reporte.Direccion;

            cargarImagenes(numeroReporte);

        }
        /*
        public void verImagen(int id)
        {
            SqlConnection conexion = null;

            try
            {
                conexion = ConnectionUtils.getConnection();
                SqlCommand command;
                byte[] 
                if (conexion != null)
                {
                    String query = String.Format("SELECT dato FROM Imagen WHERE idImagen='" + id + "'");
                    command = new SqlCommand(query, conexion);
                    SqlDataReader dr = command.ExecuteReader();

                    while (dr.Read() == true)
                    {
                        =dr[0];
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                Console.WriteLine("No se encontro el Conductor");
            }

        }
        */
        public void cargarImagenes(int numeroReporte)
        {
            SqlConnection conexion = null;

            try
            {
                conexion = ConnectionUtils.getConnection();
                SqlCommand command;
                if (conexion != null)
                {
                    String query = String.Format("SELECT idImagen FROM Imagen WHERE numeroReporte='"+numeroReporte+"'");
                    command = new SqlCommand(query, conexion);
                    SqlDataReader dr = command.ExecuteReader();

                    while (dr.Read() == true)
                    {
                        cb_SelecImagen.Items.Add(dr[0]);
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                Console.WriteLine("No se encontro el Conductor");
            }
        }
        private void consultarInvolucrados(int numeroReporte)
        {
            List<string> matriculas = new List<string>();
            string cadena = "";
            listVehiculos = Reporte_VehiculoDAO.obtenerVehiculos(numeroReporte);

            foreach (var id in listVehiculos)
            {
                string matricula = VehiculoDAO.getMatricula(id);
                Console.WriteLine(matricula);
                matriculas.Add(matricula);
            }
            
            foreach (var matricula in matriculas)
            {
                Console.WriteLine(matricula);
                cadena += String.Concat(", ", matricula);
            }
            tb_Involucrados.Text = cadena;
        }

        private void btn_Salir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
