﻿#pragma checksum "..\..\..\VentanasDireccion\DictaminarReporte.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "1F7E349901433367E46DBB609437F8AC28E3E9A10E2E0FCBB3AAA05B31D71CE1"
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
    /// DictaminarReporte
    /// </summary>
    public partial class DictaminarReporte : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 34 "..\..\..\VentanasDireccion\DictaminarReporte.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_GuardarDictamen;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\VentanasDireccion\DictaminarReporte.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_NumeroReporte;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\VentanasDireccion\DictaminarReporte.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Cancelar;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\VentanasDireccion\DictaminarReporte.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_Descripcion;
        
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
            System.Uri resourceLocater = new System.Uri("/DireccionGeneral;component/ventanasdireccion/dictaminarreporte.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\VentanasDireccion\DictaminarReporte.xaml"
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
            this.btn_GuardarDictamen = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\..\VentanasDireccion\DictaminarReporte.xaml"
            this.btn_GuardarDictamen.Click += new System.Windows.RoutedEventHandler(this.btn_GuardarDictamen_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txt_NumeroReporte = ((System.Windows.Controls.TextBox)(target));
            
            #line 36 "..\..\..\VentanasDireccion\DictaminarReporte.xaml"
            this.txt_NumeroReporte.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.txt_Folio_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btn_Cancelar = ((System.Windows.Controls.Button)(target));
            
            #line 37 "..\..\..\VentanasDireccion\DictaminarReporte.xaml"
            this.btn_Cancelar.Click += new System.Windows.RoutedEventHandler(this.btn_Salir_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.tb_Descripcion = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

