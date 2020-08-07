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
using Transito_Veracruz.Model.dao;
using Transito_Veracruz.Model.pocos;

namespace Transito_Veracruz.Delegacion
{
    /// <summary>
    /// Lógica de interacción para Dictamen.xaml
    /// </summary>
    public partial class Dictamen : Window
    {
        DictamenC dictamenSeleccionado;
        Personal encargadoDictamen;
        public Dictamen(int idDictamen)
        {
            InitializeComponent();
            dictamenSeleccionado = DictamenDAO.getInformacionDictamen(idDictamen);
            int idPersonal = dictamenSeleccionado.IdPersonal;
            encargadoDictamen = PersonalDAO.getInformacionPersonal(idPersonal);

            txt_NombrePerito.Text = encargadoDictamen.Apellidos + " " + encargadoDictamen.Nombre;
            txt_FechaRegistro.Text = dictamenSeleccionado.FechaDictamen.ToString();
            txt_Descripcion.Text = dictamenSeleccionado.Descripcion;
        }

        private void btn_Cancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_Aceptar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
