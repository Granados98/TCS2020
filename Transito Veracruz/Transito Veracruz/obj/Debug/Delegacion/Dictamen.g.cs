﻿#pragma checksum "..\..\..\Delegacion\Dictamen.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "165D9B5CBF41A3E1EAC540549F08B81F5A396001F119E80BB578A0801CBAC1E8"
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


namespace Transito_Veracruz.Delegacion {
    
    
    /// <summary>
    /// Dictamen
    /// </summary>
    public partial class Dictamen : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 34 "..\..\..\Delegacion\Dictamen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Aceptar;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\Delegacion\Dictamen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_Folio;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\Delegacion\Dictamen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_NombrePerito;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\Delegacion\Dictamen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txt_Descripcion;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\Delegacion\Dictamen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Cancelar;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\Delegacion\Dictamen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_FechaRegistro;
        
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
            System.Uri resourceLocater = new System.Uri("/Transito Veracruz;component/delegacion/dictamen.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Delegacion\Dictamen.xaml"
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
            this.btn_Aceptar = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\..\Delegacion\Dictamen.xaml"
            this.btn_Aceptar.Click += new System.Windows.RoutedEventHandler(this.btn_Aceptar_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txt_Folio = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txt_NombrePerito = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.txt_Descripcion = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.btn_Cancelar = ((System.Windows.Controls.Button)(target));
            
            #line 39 "..\..\..\Delegacion\Dictamen.xaml"
            this.btn_Cancelar.Click += new System.Windows.RoutedEventHandler(this.btn_Cancelar_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.txt_FechaRegistro = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

