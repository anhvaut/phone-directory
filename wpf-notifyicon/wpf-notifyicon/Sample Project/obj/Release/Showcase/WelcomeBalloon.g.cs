﻿#pragma checksum "..\..\..\Showcase\WelcomeBalloon.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "4328C65DF9CE73451B575E83AC4365DF"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3082
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Hardcodet.Wpf.TaskbarNotification;
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


namespace Samples {
    
    
    /// <summary>
    /// WelcomeBalloon
    /// </summary>
    public partial class WelcomeBalloon : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\Showcase\WelcomeBalloon.xaml"
        internal Samples.WelcomeBalloon me;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\Showcase\WelcomeBalloon.xaml"
        internal System.Windows.Media.Animation.BeginStoryboard FadeInAndOut_BeginStoryboard;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\Showcase\WelcomeBalloon.xaml"
        internal System.Windows.Controls.Grid grid;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\Showcase\WelcomeBalloon.xaml"
        internal System.Windows.Controls.Border border;
        
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
            System.Uri resourceLocater = new System.Uri("/Sample Project;component/showcase/welcomeballoon.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Showcase\WelcomeBalloon.xaml"
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
            this.me = ((Samples.WelcomeBalloon)(target));
            return;
            case 2:
            this.FadeInAndOut_BeginStoryboard = ((System.Windows.Media.Animation.BeginStoryboard)(target));
            return;
            case 3:
            this.grid = ((System.Windows.Controls.Grid)(target));
            return;
            case 4:
            this.border = ((System.Windows.Controls.Border)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
