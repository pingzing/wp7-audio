using System;
using System.ComponentModel;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace AudioRecorder
{
    public class SavedAudio : INotifyPropertyChanged
    {
        private int fileSize;
        public int FileSize
        {
            get { return this.fileSize; }
            set
            {
                if (this.fileSize != value)
                {
                    this.fileSize = value;
                    OnPropertyChanged("FileSize");
                }
            }
        }

        private string fileName;
        public string FileName 
        {
            get { return this.fileName; }
            set
            {
                if (this.fileName != value)
                {
                    this.fileName = value;
                    OnPropertyChanged("FileName");
                }
            }
        }

        private string description;
        public string Description 
        {
            get { return this.description; }
            set
            {
                if (this.description != value)
                {
                    this.description = value;
                    OnPropertyChanged("Description");
                }
            }
        }

        private DateTime timeStamp;
        public DateTime TimeStamp 
        {
            get { return this.timeStamp; }
            set
            {
                if (this.timeStamp != value)
                {
                    this.timeStamp = value;
                    OnPropertyChanged("TimeStamp");
                }
            }
        }

        private string filePath;
        public string FilePath 
        {
            get { return this.filePath; }
            set
           {
               if (this.filePath != value)
               {
                   this.filePath = value;
                   OnPropertyChanged("FilePath");
               }
            }
        }

        private string sourcePath;
        public string SourcePath 
        {
            get { return this.sourcePath; }
            set
            {
                if (this.sourcePath != value)
                {
                    this.sourcePath = value;
                    OnPropertyChanged("SourcePath");
                }
            }
        }


        //Default constructor
        public SavedAudio()
        {
            this.FileSize = 0;
            this.FileName= "Default";
            this.Description = "Blah";
        }

        public SavedAudio(int fileSize, string fileName, string description, DateTime timeStamp, string filePath, string sourcePath)
        {
            this.fileSize = fileSize;
            this.fileName = fileName;
            this.description = description;
            this.timeStamp = timeStamp;
            this.filePath = filePath;
            this.sourcePath = sourcePath;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
