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
        ObservableCollection<SavedAudio> savedAudio = new ObservableCollection<SavedAudio>();

        public MainPageViewModel()
        {
            //Test values. Remove these later            
            SavedAudio file1 = new SavedAudio();
            SavedAudio file2 = new SavedAudio();
            savedAudio.Add(file1);
            savedAudio.Add(file2);
            ListItemsSource = savedAudio;
            //End test values

            this.recordCommand = new DelegateCommand(this.RecordAction);
            this.stopCommand = new DelegateCommand(this.RequestStopRecordingAction);

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

            //Write the initial header to the WAVE file. This'll be updated after we finish recording.
            WriteHeader(this.currentRecordingStream, (int)this.currentMicrophone.SampleRate);
            this.currentMicrophone.Start();
        }

        public void RequestStopRecordingAction(object p)
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
            UpdateHeader(this.currentRecordingStream);

            var isoStore = System.IO.IsolatedStorage.IsolatedStorageFile.GetUserStoreForApplication();

            using (var targetFile = isoStore.CreateFile("newFile.wav"))
            {
                //Write to Isolated Storage, update list, create WAVE header, etc etc etc.                
                var dataBuffer = this.currentRecordingStream.GetBuffer();
                targetFile.Write(dataBuffer, 0, (int)this.currentRecordingStream.Length);                
                SavedAudio newFile = new SavedAudio((int)targetFile.Length, "newFile", "Loooooooooooooong Description", DateTime.Now, "\newFile.wav", "\\");
                savedAudio.Add(newFile);
                targetFile.Flush();
                targetFile.Close();
            }
        }

        public void WriteHeader(Stream stream, int sampleRate)
        {
            const int bitsPerSample = 16;
            const int bytesPerSample = bitsPerSample / 8;
            var encoding = System.Text.Encoding.UTF8;

            // ChunkID Contains the letters "RIFF" in ASCII form (0x52494646 big-endian form).
            stream.Write(encoding.GetBytes("RIFF"), 0, 4);

            // NOTE this will be filled in later
            stream.Write(BitConverter.GetBytes(0), 0, 4);

            // Format Contains the letters "WAVE"(0x57415645 big-endian form).
            stream.Write(encoding.GetBytes("WAVE"), 0, 4);

            // Subchunk1ID Contains the letters "fmt " (0x666d7420 big-endian form).
            stream.Write(encoding.GetBytes("fmt "), 0, 4);

            // Subchunk1Size 16 for PCM.  This is the size of the rest of the Subchunk which follows this number.
            stream.Write(BitConverter.GetBytes(16), 0, 4);

            // AudioFormat PCM = 1 (i.e. Linear quantization) Values other than 1 indicate some form of compression.
            stream.Write(BitConverter.GetBytes((short)1), 0, 2);

            // NumChannels Mono = 1, Stereo = 2, etc.
            stream.Write(BitConverter.GetBytes((short)1), 0, 2);

            // SampleRate 8000, 44100, etc.
            stream.Write(BitConverter.GetBytes(sampleRate), 0, 4);

            // ByteRate =  SampleRate * NumChannels * BitsPerSample/8
            stream.Write(BitConverter.GetBytes(sampleRate * bytesPerSample), 0, 4);

            // BlockAlign NumChannels * BitsPerSample/8 The number of bytes for one sample including all channels.
            stream.Write(BitConverter.GetBytes((short)(bytesPerSample)), 0, 2);

            // BitsPerSample    8 bits = 8, 16 bits = 16, etc.
            stream.Write(BitConverter.GetBytes((short)(bitsPerSample)), 0, 2);

            // Subchunk2ID Contains the letters "data" (0x64617461 big-endian form).
            stream.Write(encoding.GetBytes("data"), 0, 4);

            // NOTE to be filled in later
            stream.Write(BitConverter.GetBytes(0), 0, 4);
        }

        public void UpdateHeader(Stream stream)
        {
            if (!stream.CanSeek)
            {
                throw new Exception("Cant properly update audio file's header to reflect changes.");
                var oldPos = stream.Position;

                //ChunkSize  36 + SubChunk2Size
                stream.Seek(4, SeekOrigin.Begin);
                stream.Write(BitConverter.GetBytes((int)stream.Length - 8), 0, 4);

                //Subchunk2Size == NumSamples * NumChannels * BitsPerSample/8 This is the number of bytes in the data.
                stream.Seek(40, SeekOrigin.Begin);
                stream.Write(BitConverter.GetBytes((int)stream.Length - 44), 0, 4);

                //seek the stream back to the end of the stream.
                stream.Seek(oldPos, SeekOrigin.Begin);
            }
        }

        private DelegateCommand recordCommand;
        public DelegateCommand RecordCommand
        {
            get
            {
                return this.recordCommand;
            }
        }

        private DelegateCommand stopCommand;
        public DelegateCommand StopCommand
        {
            get 
            {
                return this.stopCommand;
            }
        }
    }
}
