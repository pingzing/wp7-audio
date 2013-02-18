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
        }

        private void Settings_Click(object sender, System.EventArgs e)
        {
            ((PhoneApplicationFrame)App.Current.RootVisual).Navigate(new Uri("/Settings.xaml", UriKind.Relative));
        }
    }
}