﻿#pragma checksum "C:\Users\Neil\Desktop\Repositories\wp7_audio\AudioRecorder\AudioRecorder\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "CCF5AA14E488F8BCF661A7688B0AC324"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18033
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace AudioRecorder {
    
    
    public partial class MainPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal Microsoft.Phone.Shell.ApplicationBarIconButton AppBarIconButton;
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal Microsoft.Phone.Controls.Pivot MainPagePivot;
        
        internal System.Windows.Controls.Button recordButton;
        
        internal System.Windows.Controls.Button stopButton;
        
        internal Microsoft.Phone.Controls.PivotItem savedPivotItem;
        
        internal System.Windows.Controls.Grid Pivot2Root;
        
        internal System.Windows.Controls.ListBox savedItemsList;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/AudioRecorder;component/MainPage.xaml", System.UriKind.Relative));
            this.AppBarIconButton = ((Microsoft.Phone.Shell.ApplicationBarIconButton)(this.FindName("AppBarIconButton")));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.MainPagePivot = ((Microsoft.Phone.Controls.Pivot)(this.FindName("MainPagePivot")));
            this.recordButton = ((System.Windows.Controls.Button)(this.FindName("recordButton")));
            this.stopButton = ((System.Windows.Controls.Button)(this.FindName("stopButton")));
            this.savedPivotItem = ((Microsoft.Phone.Controls.PivotItem)(this.FindName("savedPivotItem")));
            this.Pivot2Root = ((System.Windows.Controls.Grid)(this.FindName("Pivot2Root")));
            this.savedItemsList = ((System.Windows.Controls.ListBox)(this.FindName("savedItemsList")));
        }
    }
}

