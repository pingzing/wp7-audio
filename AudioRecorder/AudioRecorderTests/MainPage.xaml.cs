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
using Microsoft.Silverlight.Testing;

namespace AudioRecorderTests
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            Loaded += MainPage_Loaded;

        }

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            Microsoft.Phone.Shell.SystemTray.IsVisible = false;
            var testPage = UnitTestSystem.CreateTestPage();
            IMobileTestPage imtp = testPage as IMobileTestPage;
            BackKeyPress += (s, arg) =>
            {
                bool navigateBackSuccessful = imtp.NavigateBack();
                arg.Cancel = imtp.NavigateBack();
            };
            (Application.Current.RootVisual as PhoneApplicationFrame).Content = testPage;
        }
    }
}