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
        private int numeroReporte;
        private string nombreDelegacion;
        private string estatus="Asignado";
        private string direccion;
        private DateTime fechaCreacion;
        private int folio = 0;
        
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
            numeroReporte = reporte.NumeroReporte;
            nombreDelegacion = reporte.NombreDelegacion;
            direccion = reporte.Direccion;
            fechaCreacion = reporte.FechaCreacion;
            idPersonal = personal.IdPersonal;
        }
        public bool Resultado { get => resultado; set => resultado = value; }

        private void btn_Salir_Click(object sender, RoutedEventArgs e)
        {
            this.Resultado = false;
            this.Close();
        }

        private void btn_GuardarDictamen_Click(object sender, RoutedEventArgs e)
        {
            folio = Convert.ToInt32(txt_Folio.Text);
            string descripcion = tb_Descripcion.Text;

            if (folio>0 && descripcion.Length>0)
            {
                Dictamen dictamen = new Dictamen();
                dictamen.Folio = folio;
                dictamen.Descripcion = descripcion;
                dictamen.FechaDictamen = DateTime.Now;
                dictamen.IdPersonal = idPersonal;

                reporte.FolioDictamen = folio;
                int folioAux = DictamenDAO.verificaDictamen(folio);
                if (folioAux==0)
                {
                    reporte.Estatus = estatus;
                    DictamenDAO.guardarDictamen(dictamen);
                    ReporteDAO.asociarDictamen(this.reporte);

                    this.Resultado = true;
                    this.itActualizar.actualizar(idReporteAsig,numeroReporte,estatus,nombreDelegacion,folio,direccion,fechaCreacion);
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
