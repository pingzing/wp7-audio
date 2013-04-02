using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.Collections.ObjectModel;

namespace AudioRecorder
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {            
            InitializeComponent();
            this.DataContext = new AudioRecorder.ViewModels.MainPageViewModel();
        }

        private void Settings_Click(object sender, System.EventArgs e)
        {
            ((PhoneApplicationFrame)App.Current.RootVisual).Navigate(new Uri("/Settings.xaml", UriKind.Relative));
        }

        private void Save_Click(object sender, System.EventArgs e)
        {
            var viewModel = (AudioRecorder.ViewModels.MainPageViewModel)this.DataContext;
            viewModel.SaveRecording();
        }
    }
}