﻿#pragma checksum "..\..\Options.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "8445A49C96CDEC528C8B76B0838F043F"
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
using ZonaTools.XPlorerBar;


namespace Wollundra.ControlPanel {
    
    
    /// <summary>
    /// Options
    /// </summary>
    public partial class Options : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\Options.xaml"
        internal ZonaTools.XPlorerBar.XPlorerBar ZT_XPlorerBar;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\Options.xaml"
        internal ZonaTools.XPlorerBar.XPlorerItem itLookAndFeel;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\Options.xaml"
        internal ZonaTools.XPlorerBar.XPlorerItem itSearchApplications;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\Options.xaml"
        internal ZonaTools.XPlorerBar.XPlorerItem itDisplayResult;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\Options.xaml"
        internal ZonaTools.XPlorerBar.XPlorerItem itGeneralSettings;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\Options.xaml"
        internal ZonaTools.XPlorerBar.XPlorerItem itBackupandRestore;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\Options.xaml"
        internal ZonaTools.XPlorerBar.XPlorerItem itProductLicense;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\Options.xaml"
        internal System.Windows.Controls.StackPanel SPContainer;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\Options.xaml"
        internal System.Windows.Controls.Image image1;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\Options.xaml"
        internal System.Windows.Controls.TextBlock txtTitle;
        
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
            System.Uri resourceLocater = new System.Uri("/ControlPanel;component/options.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Options.xaml"
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
            
            #line 5 "..\..\Options.xaml"
            ((Wollundra.ControlPanel.Options)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            
            #line 5 "..\..\Options.xaml"
            ((Wollundra.ControlPanel.Options)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ZT_XPlorerBar = ((ZonaTools.XPlorerBar.XPlorerBar)(target));
            return;
            case 3:
            this.itLookAndFeel = ((ZonaTools.XPlorerBar.XPlorerItem)(target));
            
            #line 17 "..\..\Options.xaml"
            this.itLookAndFeel.Click += new System.Windows.RoutedEventHandler(this.itLookAndFeel_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.itSearchApplications = ((ZonaTools.XPlorerBar.XPlorerItem)(target));
            
            #line 18 "..\..\Options.xaml"
            this.itSearchApplications.Click += new System.Windows.RoutedEventHandler(this.itSearchApplications_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.itDisplayResult = ((ZonaTools.XPlorerBar.XPlorerItem)(target));
            
            #line 19 "..\..\Options.xaml"
            this.itDisplayResult.Click += new System.Windows.RoutedEventHandler(this.itDisplayResult_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.itGeneralSettings = ((ZonaTools.XPlorerBar.XPlorerItem)(target));
            
            #line 20 "..\..\Options.xaml"
            this.itGeneralSettings.Click += new System.Windows.RoutedEventHandler(this.itGeneralSettings_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.itBackupandRestore = ((ZonaTools.XPlorerBar.XPlorerItem)(target));
            
            #line 21 "..\..\Options.xaml"
            this.itBackupandRestore.Click += new System.Windows.RoutedEventHandler(this.itBackupandRestore_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.itProductLicense = ((ZonaTools.XPlorerBar.XPlorerItem)(target));
            
            #line 22 "..\..\Options.xaml"
            this.itProductLicense.Click += new System.Windows.RoutedEventHandler(this.itProductLicense_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.SPContainer = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 10:
            this.image1 = ((System.Windows.Controls.Image)(target));
            return;
            case 11:
            this.txtTitle = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
