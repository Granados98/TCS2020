#pragma checksum "..\..\..\Delegacion\MenuDelegacion.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "5F706A70E86ABE454A549CFD467A0711D19823E0E6ACF200BD094F15C66FA082"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Transitions;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using Transito_Veracruz.Delegacion;


namespace Transito_Veracruz.Delegacion
{


    /// <summary>
    /// MenuDelegacion
    /// </summary>
    public partial class MenuDelegacion : System.Windows.Window, System.Windows.Markup.IComponentConnector
    {


#line 21 "..\..\..\Delegacion\MenuDelegacion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel BarraTitulo;

#line default
#line hidden


#line 24 "..\..\..\Delegacion\MenuDelegacion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel MenuVertical;

#line default
#line hidden


#line 40 "..\..\..\Delegacion\MenuDelegacion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_AgregarConductor;

#line default
#line hidden


#line 58 "..\..\..\Delegacion\MenuDelegacion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_AgregarVehiculo;

#line default
#line hidden


#line 75 "..\..\..\Delegacion\MenuDelegacion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_AgregarReporte;

#line default
#line hidden


#line 81 "..\..\..\Delegacion\MenuDelegacion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_Mensaje;

#line default
#line hidden


#line 82 "..\..\..\Delegacion\MenuDelegacion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_EnviarMensaje;

#line default
#line hidden


#line 83 "..\..\..\Delegacion\MenuDelegacion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox block_Chat;

#line default
#line hidden

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Transito Veracruz;component/delegacion/menudelegacion.xaml", System.UriKind.Relative);

#line 1 "..\..\..\Delegacion\MenuDelegacion.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);

#line default
#line hidden
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:
                    this.BarraTitulo = ((System.Windows.Controls.StackPanel)(target));
                    return;
                case 2:
                    this.MenuVertical = ((System.Windows.Controls.StackPanel)(target));
                    return;
                case 3:

#line 31 "..\..\..\Delegacion\MenuDelegacion.xaml"
                    ((System.Windows.Controls.DataGrid)(target)).SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.DataGrid_SelectionChanged);

#line default
#line hidden
                    return;
                case 4:
                    this.btn_AgregarConductor = ((System.Windows.Controls.Button)(target));

#line 40 "..\..\..\Delegacion\MenuDelegacion.xaml"
                    this.btn_AgregarConductor.Click += new System.Windows.RoutedEventHandler(this.btn_AgregarConductor_Click);

#line default
#line hidden
                    return;
                case 5:

#line 44 "..\..\..\Delegacion\MenuDelegacion.xaml"
                    ((System.Windows.Controls.TabItem)(target)).GotFocus += new System.Windows.RoutedEventHandler(this.ClicItemVehiculos);

#line default
#line hidden
                    return;
                case 6:
                    this.btn_AgregarVehiculo = ((System.Windows.Controls.Button)(target));

#line 58 "..\..\..\Delegacion\MenuDelegacion.xaml"
                    this.btn_AgregarVehiculo.Click += new System.Windows.RoutedEventHandler(this.btn_AgregarVehiculo_Click);

#line default
#line hidden
                    return;
                case 7:
                    this.btn_AgregarReporte = ((System.Windows.Controls.Button)(target));

#line 75 "..\..\..\Delegacion\MenuDelegacion.xaml"
                    this.btn_AgregarReporte.Click += new System.Windows.RoutedEventHandler(this.btn_AgregarReporte_Click);

#line default
#line hidden
                    return;
                case 8:
                    this.txt_Mensaje = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 9:
                    this.btn_EnviarMensaje = ((System.Windows.Controls.Button)(target));

#line 82 "..\..\..\Delegacion\MenuDelegacion.xaml"
                    this.btn_EnviarMensaje.Click += new System.Windows.RoutedEventHandler(this.btn_EnviarMensaje_Click);

#line default
#line hidden
                    return;
                case 10:
                    this.block_Chat = ((System.Windows.Controls.ListBox)(target));
                    return;
                case 11:

#line 87 "..\..\..\Delegacion\MenuDelegacion.xaml"
                    ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);

#line default
#line hidden
                    return;
            }
            this._contentLoaded = true;
        }

        internal System.Windows.Controls.DataGridTextColumn columnPropietario;
        internal System.Windows.Controls.DataGridTextColumn columnApellidos;
        internal System.Windows.Controls.DataGridTextColumn columnNombre;
        internal System.Windows.Controls.DataGridTextColumn columnfecha;
        internal System.Windows.Controls.DataGridTextColumn columnLicencia;
        internal System.Windows.Controls.DataGridTextColumn columnTeleg;
    }
}

