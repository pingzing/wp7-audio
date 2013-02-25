using AudioRecorder.Helpers;
using AudioRecorder.ViewModels;
using Microsoft.Phone.Controls;
using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;

namespace AudioRecorder.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private const int MEMORY_STREAM_SIZE = 1048576;
                
        private Microphone currentMicrophone;
        private int sampleRate;
        private byte[] audioBuffer;        
        bool stopRequested;
        MemoryStream currentRecordingStream;

        public MainPageViewModel()
        {
            //Test values. Remove these later
            ObservableCollection<SavedAudio> temp = new ObservableCollection<SavedAudio>();
            SavedAudio file1 = new SavedAudio();
            SavedAudio file2 = new SavedAudio();
            temp.Add(file1);
            temp.Add(file2);
            ListItemsSource = temp;
            //End test values

            this.recordCommand = new DelegateCommand(this.RecordAction);

        }

        //The source property of the list that populates the "saved" page.
        private ObservableCollection<SavedAudio> collection;
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

        private void RecordAction(object p)
        {
            System.Diagnostics.Debug.WriteLine("Running RecordAction.");
            if (this.currentMicrophone == null)
            {
                this.currentMicrophone = Microphone.Default;
                this.currentMicrophone.BufferReady += new EventHandler<EventArgs>(currentMicrophone_BufferReady);
                this.audioBuffer = new byte[this.currentMicrophone.GetSampleSizeInBytes(this.currentMicrophone.BufferDuration)];
                this.sampleRate = this.currentMicrophone.SampleRate;
            }
            this.stopRequested = false;
            this.currentRecordingStream = new MemoryStream(MEMORY_STREAM_SIZE);
            this.currentMicrophone.Start();
        }

        public void RequestStopRecording()
        {
            this.stopRequested = true;
        }

        void currentMicrophone_BufferReady(object sender, EventArgs e)
        {
            this.currentMicrophone.GetData(this.audioBuffer);
            this.currentRecordingStream.Write(this.audioBuffer, 0, this.audioBuffer.Length);
            if (!this.stopRequested)
            {
                return;
            }
            this.currentMicrophone.Stop();

            var isoStore = System.IO.IsolatedStorage.IsolatedStorageFile.GetUserStoreForApplication();

            /*using (var targetFile = isoStore.CreateFile(FileName))
            {
                //Write to Isolated Storage, update list, create WAVE header, etc etc etc.
            }*/
        }

        private DelegateCommand recordCommand;
        public DelegateCommand RecordCommand
        {
            get
            {
                return this.recordCommand;
            }
        }
    }
}
