﻿#pragma checksum "..\..\..\UCOptions\SearchApplications.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "EDA4283A7713D64629282C902DA4C376"
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
    /// SearchApplications
    /// </summary>
    public partial class SearchApplications : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 6 "..\..\..\UCOptions\SearchApplications.xaml"
        internal System.Windows.Controls.TextBlock textBlock1;
        
        #line default
        #line hidden
        
        
        #line 7 "..\..\..\UCOptions\SearchApplications.xaml"
        internal System.Windows.Controls.CheckBox ckOutlook;
        
        #line default
        #line hidden
        
        
        #line 8 "..\..\..\UCOptions\SearchApplications.xaml"
        internal System.Windows.Controls.CheckBox ckAcctiveDirectory;
        
        #line default
        #line hidden
        
        
        #line 8 "..\..\..\UCOptions\SearchApplications.xaml"
        internal System.Windows.Controls.TextBox txtDomainName;
        
        #line default
        #line hidden
        
        
        #line 8 "..\..\..\UCOptions\SearchApplications.xaml"
        internal System.Windows.Controls.TextBlock textBlock2;
        
        #line default
        #line hidden
        
        
        #line 9 "..\..\..\UCOptions\SearchApplications.xaml"
        internal System.Windows.Controls.CheckBox ckOutlookExpress;
        
        #line default
        #line hidden
        
        
        #line 9 "..\..\..\UCOptions\SearchApplications.xaml"
        internal System.Windows.Controls.Button btnCheckDomain;
        
        #line default
        #line hidden
        
        
        #line 9 "..\..\..\UCOptions\SearchApplications.xaml"
        internal System.Windows.Controls.Image imgCheck;
        
        #line default
        #line hidden
        
        
        #line 9 "..\..\..\UCOptions\SearchApplications.xaml"
        internal System.Windows.Controls.Image imgFail;
        
        #line default
        #line hidden
        
        
        #line 9 "..\..\..\UCOptions\SearchApplications.xaml"
        internal System.Windows.Controls.TextBlock lbDomainStatus;
        
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
            System.Uri resourceLocater = new System.Uri("/ControlPanel;component/ucoptions/searchapplications.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UCOptions\SearchApplications.xaml"
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
            
            #line 4 "..\..\..\UCOptions\SearchApplications.xaml"
            ((ControlPanel.UCOptions.SearchApplications)(target)).Loaded += new System.Windows.RoutedEventHandler(this.UserControl_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.textBlock1 = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.ckOutlook = ((System.Windows.Controls.CheckBox)(target));
            
            #line 7 "..\..\..\UCOptions\SearchApplications.xaml"
            this.ckOutlook.Checked += new System.Windows.RoutedEventHandler(this.ckOutlook_Checked);
            
            #line default
            #line hidden
            
            #line 7 "..\..\..\UCOptions\SearchApplications.xaml"
            this.ckOutlook.Unchecked += new System.Windows.RoutedEventHandler(this.ckOutlook_Unchecked);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ckAcctiveDirectory = ((System.Windows.Controls.CheckBox)(target));
            
            #line 8 "..\..\..\UCOptions\SearchApplications.xaml"
            this.ckAcctiveDirectory.Checked += new System.Windows.RoutedEventHandler(this.ckAcctiveDirectory_Checked);
            
            #line default
            #line hidden
            
            #line 8 "..\..\..\UCOptions\SearchApplications.xaml"
            this.ckAcctiveDirectory.Unchecked += new System.Windows.RoutedEventHandler(this.ckAcctiveDirectory_Unchecked);
            
            #line default
            #line hidden
            return;
            case 5:
            this.txtDomainName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.textBlock2 = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.ckOutlookExpress = ((System.Windows.Controls.CheckBox)(target));
            
            #line 9 "..\..\..\UCOptions\SearchApplications.xaml"
            this.ckOutlookExpress.Checked += new System.Windows.RoutedEventHandler(this.ckOutlookExpress_Checked);
            
            #line default
            #line hidden
            
            #line 9 "..\..\..\UCOptions\SearchApplications.xaml"
            this.ckOutlookExpress.Unchecked += new System.Windows.RoutedEventHandler(this.ckOutlookExpress_Unchecked);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnCheckDomain = ((System.Windows.Controls.Button)(target));
            
            #line 9 "..\..\..\UCOptions\SearchApplications.xaml"
            this.btnCheckDomain.Click += new System.Windows.RoutedEventHandler(this.btnCheckDomain_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.imgCheck = ((System.Windows.Controls.Image)(target));
            return;
            case 10:
            this.imgFail = ((System.Windows.Controls.Image)(target));
            return;
            case 11:
            this.lbDomainStatus = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}