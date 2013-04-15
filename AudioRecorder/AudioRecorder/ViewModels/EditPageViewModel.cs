using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AudioRecorder.ViewModels
{
    public class EditPageViewModel : ViewModelBase
    {
        public SavedAudio editedAudio;
        public SavedAudio EditedAudio { get; set; }
    }
}
