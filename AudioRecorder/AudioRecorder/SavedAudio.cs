﻿using System;
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
    public class SavedAudio
    {
        public int FileSize { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }

        public SavedAudio()
        {
            this.FileSize = 0;
            this.FileName= "Default";
            this.Description = "Blah";
        }
    }
}
