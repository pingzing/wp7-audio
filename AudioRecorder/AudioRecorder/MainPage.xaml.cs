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

namespace AudioRecorder
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            SavedAudio testSaved = new SavedAudio();
            List<SavedAudio> savedItems = new List<SavedAudio>();
            savedItems.Add(testSaved);
            for (int i = 0; i < 5; i++)
            {
                savedItems.Add(new SavedAudio());                
            }
            savedItemsList.ItemsSource = savedItems;
        }

        private void ApplicationBarMenuItem_Click(object sender, EventArgs e)
        {

        }

        
    }
}