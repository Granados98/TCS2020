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
            int idReporte = reporte.IdReporte;

            consultarInvolucrados(idReporte);
            consultarImagenes(idReporte);
            string idReporteAux = Convert.ToString(idReporte);
            txt_NumReporte.Text = idReporteAux;
            txt_Delegacion.Text = reporte.NombreDelegacion;
            txt_Direccion.Text = reporte.Direccion;


        }
        private void consultarImagenes(int idReporte)
        {
            List<string> imagenes = new List<string>();

            imagenes = ImagenDAO.getImagenes(idReporte);

            foreach (var img in imagenes)
            {
                box_Imagenes.Items.Add(img);
            }
        }
        private void consultarInvolucrados(int idReporte)
        {
            List<string> matriculas = new List<string>();
            string cadena = "";
            listVehiculos = Reporte_VehiculoDAO.obtenerVehiculos(idReporte);

            foreach (var id in listVehiculos)
            {
                string matricula = VehiculoDAO.getMatricula(id);
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
