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
        private SavedAudio oldAudio = new SavedAudio();
        string indexToPass = null;

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

            //fill in oldAudio with all of sharedAudio's attributes, but don't make it a reference type
            oldAudio.Description = ((App)App.Current).sharedAudio.Description;
            oldAudio.FileName = ((App)App.Current).sharedAudio.FileName;
            oldAudio.FilePath = ((App)App.Current).sharedAudio.FilePath;
            oldAudio.FileSize = ((App)App.Current).sharedAudio.FileSize;
            oldAudio.Duration = ((App)App.Current).sharedAudio.Duration;
            oldAudio.TimeStamp = ((App)App.Current).sharedAudio.TimeStamp;
            
            NavigationContext.QueryString.TryGetValue("index", out this.indexToPass);
        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            ((App)App.Current).sharedAudio = audioToEdit;
            PhoneApplicationService.Current.State["pageFrom"] = "editPage";
            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            ((App)App.Current).sharedAudio = oldAudio;
            if (NavigationService.CanGoBack)
            {
                PhoneApplicationService.Current.State["pageFrom"] = "editPage";
                NavigationService.GoBack();
            }
        }

        private void fileNameBox_GotFocus(object sender, RoutedEventArgs e)
        {
            fileNameBox.SelectAll();
        }

        private void descriptionBox_GotFocus(object sender, RoutedEventArgs e)
        {
            descriptionBox.SelectAll();
        }
    }
}