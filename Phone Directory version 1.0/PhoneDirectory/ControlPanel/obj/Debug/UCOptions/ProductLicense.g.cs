﻿#pragma checksum "..\..\..\UCOptions\ProductLicense.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "AF995A16B69256B5E512CBEACB812E1B"
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


namespace Wollundra.ControlPanel.UCOptions {
    
    
    /// <summary>
    /// ProductLicense
    /// </summary>
    public partial class ProductLicense : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 6 "..\..\..\UCOptions\ProductLicense.xaml"
        internal System.Windows.Controls.TextBlock textBlock2;
        
        #line default
        #line hidden
        
        
        #line 6 "..\..\..\UCOptions\ProductLicense.xaml"
        internal System.Windows.Controls.TextBox txtProductKey;
        
        #line default
        #line hidden
        
        
        #line 6 "..\..\..\UCOptions\ProductLicense.xaml"
        internal System.Windows.Controls.Button btnActivate;
        
        #line default
        #line hidden
        
        
        #line 6 "..\..\..\UCOptions\ProductLicense.xaml"
        internal System.Windows.Controls.TextBlock lbLicensingStatus;
        
        #line default
        #line hidden
        
        
        #line 6 "..\..\..\UCOptions\ProductLicense.xaml"
        internal System.Windows.Controls.TextBlock lbLicenseType;
        
        #line default
        #line hidden
        
        
        #line 6 "..\..\..\UCOptions\ProductLicense.xaml"
        internal System.Windows.Controls.TextBlock lbExpireDate;
        
        #line default
        #line hidden
        
        
        #line 6 "..\..\..\UCOptions\ProductLicense.xaml"
        internal System.Windows.Controls.Image imgFail;
        
        #line default
        #line hidden
        
        
        #line 6 "..\..\..\UCOptions\ProductLicense.xaml"
        internal System.Windows.Controls.Image imgValid;
        
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
            System.Uri resourceLocater = new System.Uri("/ControlPanel;component/ucoptions/productlicense.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UCOptions\ProductLicense.xaml"
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
            
            #line 4 "..\..\..\UCOptions\ProductLicense.xaml"
            ((Wollundra.ControlPanel.UCOptions.ProductLicense)(target)).Loaded += new System.Windows.RoutedEventHandler(this.UserControl_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.textBlock2 = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.txtProductKey = ((System.Windows.Controls.TextBox)(target));
            
            #line 6 "..\..\..\UCOptions\ProductLicense.xaml"
            this.txtProductKey.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txtProductKey_TextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnActivate = ((System.Windows.Controls.Button)(target));
            
            #line 6 "..\..\..\UCOptions\ProductLicense.xaml"
            this.btnActivate.Click += new System.Windows.RoutedEventHandler(this.btnActivate_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.lbLicensingStatus = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.lbLicenseType = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.lbExpireDate = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.imgFail = ((System.Windows.Controls.Image)(target));
            return;
            case 9:
            this.imgValid = ((System.Windows.Controls.Image)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
