﻿#pragma checksum "..\..\..\Parameters\ExportParameters.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "CCF1CAC085318415DCE3EC9F927040B2"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3603
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace Wollundra.ControlPanel.Parameters {
    
    
    /// <summary>
    /// ExportParameters
    /// </summary>
    public partial class ExportParameters : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 6 "..\..\..\Parameters\ExportParameters.xaml"
        internal System.Windows.Controls.TextBlock textBlock1;
        
        #line default
        #line hidden
        
        
        #line 6 "..\..\..\Parameters\ExportParameters.xaml"
        internal System.Windows.Controls.TextBox txtServerName;
        
        #line default
        #line hidden
        
        
        #line 6 "..\..\..\Parameters\ExportParameters.xaml"
        internal System.Windows.Controls.TextBlock lbFilePath;
        
        #line default
        #line hidden
        
        
        #line 6 "..\..\..\Parameters\ExportParameters.xaml"
        internal System.Windows.Controls.TextBox txtFilePath;
        
        #line default
        #line hidden
        
        
        #line 6 "..\..\..\Parameters\ExportParameters.xaml"
        internal System.Windows.Controls.Button btnBrowse;
        
        #line default
        #line hidden
        
        
        #line 6 "..\..\..\Parameters\ExportParameters.xaml"
        internal System.Windows.Controls.Button btnOK;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ControlPanel;component/parameters/exportparameters.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Parameters\ExportParameters.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.textBlock1 = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.txtServerName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.lbFilePath = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.txtFilePath = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.btnBrowse = ((System.Windows.Controls.Button)(target));
            
            #line 6 "..\..\..\Parameters\ExportParameters.xaml"
            this.btnBrowse.Click += new System.Windows.RoutedEventHandler(this.btnBrowse_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnOK = ((System.Windows.Controls.Button)(target));
            
            #line 6 "..\..\..\Parameters\ExportParameters.xaml"
            this.btnOK.Click += new System.Windows.RoutedEventHandler(this.btnOK_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
