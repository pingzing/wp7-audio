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
using System.Xml.Serialization;

namespace AudioRecorder
{      
    public class SavedAudio : INotifyPropertyChanged
    {
        const int BYTES_PER_GIGABYTE = 1073741824;
        const int BYTES_PER_MEGABYTE = 1048576;
        const int BYTES_PER_KILOBYTE = 1024;

        private int fileSize;
        public int FileSize
        {
            get 
            {
                return this.fileSize; 
            }
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
        
        [XmlIgnore]
        private TimeSpan duration;
        public TimeSpan Duration
        {
            get { return this.duration; }
            set 
            {
                if (this.duration != value)
                {
                    this.duration = value;
                    OnPropertyChanged("Duration");
                }
            }
        }

        //Workaround to avoid inability to serialze TimeSpans
        [XmlElement("Duration")]
        public long DurationTicks
        {
            get { return duration.Ticks; }
            set { duration = new TimeSpan(value); }
        }
        
        private string formattedDuration;
        public string FormattedDuration
        {
            get {return duration.ToString("mm\\:ss");}
            set 
            {
                if (this.formattedDuration != value)
                {
                    this.formattedDuration = value;
                    OnPropertyChanged("FormattedDuration");
                }
            }
        }

        [XmlIgnore]
        private string formattedFileSize;
        public string FormattedFileSize
        {
            get 
            {
                if (this.fileSize > BYTES_PER_GIGABYTE)
                {
                    return ((float)this.fileSize / BYTES_PER_GIGABYTE).ToString("n2") +" GB";
                }
                else if (this.fileSize > BYTES_PER_MEGABYTE)
                {
                    return ((float)this.fileSize / BYTES_PER_MEGABYTE).ToString("n2") +" MB";
                }
                else if (this.fileSize > BYTES_PER_KILOBYTE)
                {
                    return ((float)this.fileSize / BYTES_PER_KILOBYTE).ToString("n2") +" KB";
                }
                else
                {
                    return this.fileSize + " B";
                }
            }
            set 
            {
                if (this.formattedFileSize != value)
                {
                    this.formattedFileSize = value;
                    OnPropertyChanged("FormattedFileSize");
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

        public SavedAudio(int fileSize, string fileName, string description, DateTime timeStamp, string filePath, TimeSpan duration)
        {
            this.fileSize = fileSize;
            this.fileName = fileName;
            this.description = description;
            this.timeStamp = timeStamp;
            this.filePath = filePath;
            this.duration = duration;
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
