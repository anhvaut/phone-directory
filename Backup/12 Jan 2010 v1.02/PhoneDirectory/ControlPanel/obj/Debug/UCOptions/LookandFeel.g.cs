﻿#pragma checksum "..\..\..\UCOptions\LookandFeel.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "0AA77F3B0E2BF0911072F499A348EE29"
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


namespace ControlPanel.UCOptions {
    
    
    /// <summary>
    /// LookandFeel
    /// </summary>
    public partial class LookandFeel : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 6 "..\..\..\UCOptions\LookandFeel.xaml"
        internal System.Windows.Controls.TextBlock textBlock1;
        
        #line default
        #line hidden
        
        
        #line 7 "..\..\..\UCOptions\LookandFeel.xaml"
        internal System.Windows.Controls.Button btnSave;
        
        #line default
        #line hidden
        
        
        #line 7 "..\..\..\UCOptions\LookandFeel.xaml"
        internal System.Windows.Controls.TextBlock textBlock2;
        
        #line default
        #line hidden
        
        
        #line 7 "..\..\..\UCOptions\LookandFeel.xaml"
        internal System.Windows.Controls.TextBox txtOrganisationName;
        
        #line default
        #line hidden
        
        
        #line 7 "..\..\..\UCOptions\LookandFeel.xaml"
        internal System.Windows.Controls.TextBlock textBlock3;
        
        #line default
        #line hidden
        
        
        #line 7 "..\..\..\UCOptions\LookandFeel.xaml"
        internal System.Windows.Controls.TextBox txtOrganisationLogo;
        
        #line default
        #line hidden
        
        
        #line 7 "..\..\..\UCOptions\LookandFeel.xaml"
        internal System.Windows.Controls.Button button2;
        
        #line default
        #line hidden
        
        
        #line 7 "..\..\..\UCOptions\LookandFeel.xaml"
        internal System.Windows.Controls.TextBlock txtBackGround;
        
        #line default
        #line hidden
        
        
        #line 7 "..\..\..\UCOptions\LookandFeel.xaml"
        internal System.Windows.Shapes.Rectangle currentColor;
        
        #line default
        #line hidden
        
        
        #line 7 "..\..\..\UCOptions\LookandFeel.xaml"
        internal System.Windows.Controls.Button btnEditColor;
        
        #line default
        #line hidden
        
        
        #line 8 "..\..\..\UCOptions\LookandFeel.xaml"
        internal System.Windows.Controls.CheckBox ckDefaultLogo;
        
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
            System.Uri resourceLocater = new System.Uri("/ControlPanel;component/ucoptions/lookandfeel.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UCOptions\LookandFeel.xaml"
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
            
            #line 4 "..\..\..\UCOptions\LookandFeel.xaml"
            ((ControlPanel.UCOptions.LookandFeel)(target)).Loaded += new System.Windows.RoutedEventHandler(this.UserControl_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.textBlock1 = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.btnSave = ((System.Windows.Controls.Button)(target));
            
            #line 7 "..\..\..\UCOptions\LookandFeel.xaml"
            this.btnSave.Click += new System.Windows.RoutedEventHandler(this.btnSave_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.textBlock2 = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.txtOrganisationName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.textBlock3 = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.txtOrganisationLogo = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.button2 = ((System.Windows.Controls.Button)(target));
            
            #line 7 "..\..\..\UCOptions\LookandFeel.xaml"
            this.button2.Click += new System.Windows.RoutedEventHandler(this.button2_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.txtBackGround = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 10:
            this.currentColor = ((System.Windows.Shapes.Rectangle)(target));
            return;
            case 11:
            this.btnEditColor = ((System.Windows.Controls.Button)(target));
            
            #line 7 "..\..\..\UCOptions\LookandFeel.xaml"
            this.btnEditColor.Click += new System.Windows.RoutedEventHandler(this.btnEditColor_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.ckDefaultLogo = ((System.Windows.Controls.CheckBox)(target));
            
            #line 8 "..\..\..\UCOptions\LookandFeel.xaml"
            this.ckDefaultLogo.Checked += new System.Windows.RoutedEventHandler(this.ckDefaultLogo_Checked);
            
            #line default
            #line hidden
            
            #line 8 "..\..\..\UCOptions\LookandFeel.xaml"
            this.ckDefaultLogo.Unchecked += new System.Windows.RoutedEventHandler(this.ckDefaultLogo_Unchecked);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
