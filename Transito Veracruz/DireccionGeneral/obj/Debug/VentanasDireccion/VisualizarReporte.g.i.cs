﻿#pragma checksum "..\..\..\VentanasDireccion\VisualizarReporte.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "62ADEBC676623ACFFFE59938434749AFE17567686CF10908DD7839447C34415C"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using DireccionGeneral.VentanasDireccion;
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


namespace DireccionGeneral.VentanasDireccion {
    
    
    /// <summary>
    /// VisualizarReporte
    /// </summary>
    public partial class VisualizarReporte : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 29 "..\..\..\VentanasDireccion\VisualizarReporte.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Salir;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\VentanasDireccion\VisualizarReporte.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tb_Involucrados;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\VentanasDireccion\VisualizarReporte.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txt_Direccion;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\VentanasDireccion\VisualizarReporte.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txt_NumReporte;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\VentanasDireccion\VisualizarReporte.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txt_Delegacion;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\VentanasDireccion\VisualizarReporte.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox box_Imagenes;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/DireccionGeneral;component/ventanasdireccion/visualizarreporte.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\VentanasDireccion\VisualizarReporte.xaml"
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
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.btn_Salir = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\..\VentanasDireccion\VisualizarReporte.xaml"
            this.btn_Salir.Click += new System.Windows.RoutedEventHandler(this.btn_Salir_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.tb_Involucrados = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.txt_Direccion = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.txt_NumReporte = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.txt_Delegacion = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.box_Imagenes = ((System.Windows.Controls.ListBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

