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
using Microsoft.Phone.Shell;
using System.Windows.Navigation;

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
            NavigationService.Navigate(new Uri("/Settings.xaml", UriKind.Relative));
        }

        private void Play_Click(object sender, System.EventArgs e)
        {
            var viewModel = (AudioRecorder.ViewModels.MainPageViewModel)this.DataContext;
            viewModel.PlaySelected();
        }

        private void Edit_Click(object sender, System.EventArgs e)
        {
            ((App)App.Current).sharedAudio = (SavedAudio)savedItemsList.SelectedItem;
            string indexParam = savedItemsList.SelectedIndex.ToString();
            NavigationService.Navigate(new Uri(string.Format("/EditPage.xaml?index={0}", indexParam), UriKind.Relative));
        }

        private void Select_Click(object sender, System.EventArgs e)
        {
           //Move this code into viewModel later
            //For this to pop up the checkbox, gonna have to look into Visual Styles. See http://stackoverflow.com/questions/4957336/wp7-change-the-visibility-of-an-item-in-a-selected-listbox-item
            //for details
        }

        private void Delete_Click(object sender, System.EventArgs e)
        {
            //TODO: Implement me
        }

        private void Save_Click(object sender, System.EventArgs e)
        {
            var viewModel = (AudioRecorder.ViewModels.MainPageViewModel)this.DataContext;
            viewModel.SaveRecording();
        }

        private void Pivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (((Pivot)sender).SelectedIndex)
            {
                case 0:
                    this.ApplicationBar = this.Resources["recordAppBar"] as ApplicationBar;
                    break;

                case 1:
                    this.ApplicationBar = this.Resources["savedAppBar"] as ApplicationBar;
                    break;    

                default:
                    break;
            }
        }

        private void savedItemsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //try to find a way to move this into the viewmodel if possible. hack-fix for now, may have to ship it anyway
            if (e.AddedItems != null)
            {
                ((ApplicationBarIconButton)ApplicationBar.Buttons[0]).IsEnabled = true;
                ((ApplicationBarIconButton)ApplicationBar.Buttons[1]).IsEnabled = true;
                ((ApplicationBarIconButton)ApplicationBar.Buttons[2]).IsEnabled = true;
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            //Make sure we only update the file if we actually came from the EditPage
            var prevPage = NavigationService.BackStack.FirstOrDefault();
            if (prevPage != null && prevPage.Source.ToString().Contains("/EditPage.xaml"))
            {
                string strIndex = null;
                NavigationContext.QueryString.TryGetValue("index", out strIndex);
                var viewModel = (AudioRecorder.ViewModels.MainPageViewModel)this.DataContext;
                viewModel.UpdateEditedFile(((App)App.Current).sharedAudio, Convert.ToInt32(strIndex));

                //Bring us back to the "saved" pivot page
                string pivotIndex = "";
                if (NavigationContext.QueryString.TryGetValue("id", out pivotIndex))
                {
                    MainPagePivot.SelectedIndex = Convert.ToInt32(pivotIndex);
                }               
            }
        }
    }
}