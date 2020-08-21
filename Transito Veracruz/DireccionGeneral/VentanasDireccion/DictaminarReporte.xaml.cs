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
using DireccionGeneral.Model.daoDireccion;
using DireccionGeneral.Model.InterfaceDireccion;
using DireccionGeneral.Model.pocosDireccion;
using DireccionGeneral.Model.securityDireccion;

namespace DireccionGeneral.VentanasDireccion
{
    /// <summary>
    /// Lógica de interacción para DictaminarReporte.xaml
    /// </summary>
    public partial class DictaminarReporte : Window
    {
        Reporte reporte;
        private int idReporteAsig;
        private string nombreDelegacion;
        private string direccion;
        private string fechaCreacion;


        InterfaceMenu itActualizar;
        Personal personal;
        private bool resultado;
        private int idPersonal;
        public DictaminarReporte(InterfaceMenu itActualizar, Reporte reporte, Personal personal)
        {
            this.personal = personal;
            this.itActualizar = itActualizar;
            this.reporte = reporte;
            InitializeComponent();
            idReporteAsig = reporte.IdReporte;
            nombreDelegacion = reporte.NombreDelegacion;
            direccion = reporte.Direccion;
            fechaCreacion = reporte.FechaCreacion;
            idPersonal = personal.IdPersonal;

            int idAux = reporte.IdReporte;
            txt_NumeroReporte.Text = Convert.ToString(idAux);
        }
        public bool Resultado { get => resultado; set => resultado = value; }

        private void btn_Salir_Click(object sender, RoutedEventArgs e)
        {
            this.Resultado = false;
            this.Close();
        }

        private void btn_GuardarDictamen_Click(object sender, RoutedEventArgs e)
        {
            string descripcion = tb_Descripcion.Text;
            DateTime fechaDictamen = DateTime.Now;
            string fechaString = Convert.ToString(fechaDictamen);

            if (descripcion.Length>0)
            {
                Dictamen dictamen = new Dictamen();
                dictamen.Descripcion = descripcion;
                dictamen.FechaDictamen = fechaString;
                dictamen.IdPersonal = idPersonal;


                int idDictamen = DictamenDAO.verificaDictamen(fechaString);
                if (idDictamen == 0)
                {
                    string estatus = "Asignado";
                    DictamenDAO.guardarDictamen(dictamen);
                    int idDictamenRegistrado = DictamenDAO.verificaDictamen(fechaString);

                    Console.WriteLine(idDictamenRegistrado+reporte.IdReporte);
                    reporte.Estatus = estatus;
                    reporte.FolioDictamen = idDictamenRegistrado;
                    ReporteDAO.asociarDictamen(this.reporte);

                    this.Resultado = true;
                    this.itActualizar.actualizar(idReporteAsig,estatus,nombreDelegacion,direccion,fechaCreacion,idDictamenRegistrado);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Dictamen ya registrado");
                }

            }
            else
            {
                MessageBox.Show("Llene todos los campos");
            }
        }

        private void txt_Folio_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Validacion.soloNumeros(e);
        }

        private void txt_Nombre_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Validacion.soloLetras(e);
        }
    }
}
