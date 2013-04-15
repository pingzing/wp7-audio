using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.IO.IsolatedStorage;

namespace AudioRecorder
{
    public partial class EditPage : PhoneApplicationPage
    {
        public SavedAudio audioToEdit = new SavedAudio();
        public EditPage()
        {
            InitializeComponent();
            this.DataContext = new AudioRecorder.ViewModels.EditPageViewModel();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);            
            audioToEdit = ((App)App.Current).sharedAudio;
            fileNameBox.DataContext = audioToEdit;
            descriptionBox.DataContext = audioToEdit;
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            ((App)App.Current).sharedAudio = audioToEdit;
       }
    }
}