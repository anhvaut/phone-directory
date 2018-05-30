﻿#pragma checksum "..\..\QuickSearch.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "5EC31C0EA9CFBD2342C1306920076D00"
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


namespace PhoneDirectory {
    
    
    /// <summary>
    /// QuickSearch
    /// </summary>
    public partial class QuickSearch : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\QuickSearch.xaml"
        internal System.Windows.Media.Animation.BeginStoryboard HighlightCloseButton_BeginStoryboard;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\QuickSearch.xaml"
        internal System.Windows.Media.Animation.BeginStoryboard FadeCloseButton_BeginStoryboard;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\QuickSearch.xaml"
        internal System.Windows.Controls.Image btnClose;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\QuickSearch.xaml"
        internal System.Windows.Controls.TextBlock lbOrganisationName;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\QuickSearch.xaml"
        internal System.Windows.Controls.Image imgLogo;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\QuickSearch.xaml"
        internal System.Windows.Controls.TextBox txtName;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\QuickSearch.xaml"
        internal System.Windows.Controls.ListBox lbName;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\QuickSearch.xaml"
        internal System.Windows.Controls.TextBlock textBlock2;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\QuickSearch.xaml"
        internal System.Windows.Controls.TextBlock lbNumberOfContacts;
        
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
            System.Uri resourceLocater = new System.Uri("/PhoneDirectory;component/quicksearch.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\QuickSearch.xaml"
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
            
            #line 4 "..\..\QuickSearch.xaml"
            ((PhoneDirectory.QuickSearch)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            
            #line 4 "..\..\QuickSearch.xaml"
            ((PhoneDirectory.QuickSearch)(target)).Activated += new System.EventHandler(this.Window_Activated);
            
            #line default
            #line hidden
            
            #line 4 "..\..\QuickSearch.xaml"
            ((PhoneDirectory.QuickSearch)(target)).Deactivated += new System.EventHandler(this.Window_Deactivated);
            
            #line default
            #line hidden
            
            #line 4 "..\..\QuickSearch.xaml"
            ((PhoneDirectory.QuickSearch)(target)).SizeChanged += new System.Windows.SizeChangedEventHandler(this.Window_SizeChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.HighlightCloseButton_BeginStoryboard = ((System.Windows.Media.Animation.BeginStoryboard)(target));
            return;
            case 3:
            this.FadeCloseButton_BeginStoryboard = ((System.Windows.Media.Animation.BeginStoryboard)(target));
            return;
            case 4:
            this.btnClose = ((System.Windows.Controls.Image)(target));
            
            #line 29 "..\..\QuickSearch.xaml"
            this.btnClose.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.btnClose_MouseDown);
            
            #line default
            #line hidden
            return;
            case 5:
            this.lbOrganisationName = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.imgLogo = ((System.Windows.Controls.Image)(target));
            return;
            case 7:
            this.txtName = ((System.Windows.Controls.TextBox)(target));
            
            #line 52 "..\..\QuickSearch.xaml"
            this.txtName.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txtName_TextChanged);
            
            #line default
            #line hidden
            
            #line 52 "..\..\QuickSearch.xaml"
            this.txtName.KeyDown += new System.Windows.Input.KeyEventHandler(this.txtName_KeyDown);
            
            #line default
            #line hidden
            return;
            case 8:
            this.lbName = ((System.Windows.Controls.ListBox)(target));
            
            #line 53 "..\..\QuickSearch.xaml"
            this.lbName.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.lbName_SelectionChanged);
            
            #line default
            #line hidden
            
            #line 53 "..\..\QuickSearch.xaml"
            this.lbName.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.lbName_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 9:
            this.textBlock2 = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 10:
            this.lbNumberOfContacts = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
