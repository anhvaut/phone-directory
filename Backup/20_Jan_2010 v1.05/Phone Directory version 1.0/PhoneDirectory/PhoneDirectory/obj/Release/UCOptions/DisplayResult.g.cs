﻿#pragma checksum "..\..\..\UCOptions\DisplayResult.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "6FF7CC6CD6049CD2670B482CD989D875"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3082
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


namespace PhoneDirectory.UCOptions {
    
    
    /// <summary>
    /// DisplayResult
    /// </summary>
    public partial class DisplayResult : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 6 "..\..\..\UCOptions\DisplayResult.xaml"
        internal System.Windows.Controls.TextBlock textBlock1;
        
        #line default
        #line hidden
        
        
        #line 6 "..\..\..\UCOptions\DisplayResult.xaml"
        internal System.Windows.Controls.CheckBox ckHomePhone;
        
        #line default
        #line hidden
        
        
        #line 6 "..\..\..\UCOptions\DisplayResult.xaml"
        internal System.Windows.Controls.CheckBox ckMobilePhone;
        
        #line default
        #line hidden
        
        
        #line 6 "..\..\..\UCOptions\DisplayResult.xaml"
        internal System.Windows.Controls.CheckBox ckBusinessPhone;
        
        #line default
        #line hidden
        
        
        #line 6 "..\..\..\UCOptions\DisplayResult.xaml"
        internal System.Windows.Controls.CheckBox ckBusinessFax;
        
        #line default
        #line hidden
        
        
        #line 6 "..\..\..\UCOptions\DisplayResult.xaml"
        internal System.Windows.Controls.CheckBox ckEmail;
        
        #line default
        #line hidden
        
        
        #line 6 "..\..\..\UCOptions\DisplayResult.xaml"
        internal System.Windows.Controls.CheckBox ckAddress;
        
        #line default
        #line hidden
        
        
        #line 6 "..\..\..\UCOptions\DisplayResult.xaml"
        internal System.Windows.Controls.Button btnSave;
        
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
            System.Uri resourceLocater = new System.Uri("/PhoneDirectory;component/ucoptions/displayresult.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UCOptions\DisplayResult.xaml"
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
            
            #line 4 "..\..\..\UCOptions\DisplayResult.xaml"
            ((PhoneDirectory.UCOptions.DisplayResult)(target)).Loaded += new System.Windows.RoutedEventHandler(this.UserControl_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.textBlock1 = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.ckHomePhone = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 4:
            this.ckMobilePhone = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 5:
            this.ckBusinessPhone = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 6:
            this.ckBusinessFax = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 7:
            this.ckEmail = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 8:
            this.ckAddress = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 9:
            this.btnSave = ((System.Windows.Controls.Button)(target));
            
            #line 6 "..\..\..\UCOptions\DisplayResult.xaml"
            this.btnSave.Click += new System.Windows.RoutedEventHandler(this.btnSave_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
