using AudioRecorder.ViewModels;
using Microsoft.Phone.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Navigation;

namespace AudioRecorder.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {

        private ObservableCollection<SavedAudio> collection;

        public MainPageViewModel()
        {
            ObservableCollection<SavedAudio> temp = new ObservableCollection<SavedAudio>();
            SavedAudio file1 = new SavedAudio();
            SavedAudio file2 = new SavedAudio();
            temp.Add(file1);
            temp.Add(file2);
            ListItemsSource = temp;
        }

        public ObservableCollection<SavedAudio> ListItemsSource
        {
            get { return collection; }
            set
            {
                if (collection != value)
                {
                    collection = value;
                }
                OnPropertyChanged("ListItemsSource");
            }
        }

        public void navigateToSettings()
        {
            (Application.Current.RootVisual as PhoneApplicationFrame).Navigate(new Uri("/Settings.xaml", UriKind.Relative));
        }
    }
}
