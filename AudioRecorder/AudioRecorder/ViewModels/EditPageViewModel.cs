using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AudioRecorder.ViewModels
{
    public class EditPageViewModel : ViewModelBase
    {
        public SavedAudio editedAudio = new SavedAudio();
        public String FileName
        {
            get{return editedAudio.FileName;}
            set 
            {
                if (value != null && value is String)
                {
                    editedAudio.FileName = value;
                }
            }
        }
        public String Description
        {
            get { return editedAudio.Description; }
            set
            {
                if (value != null && value is String)
                {
                    editedAudio.Description = value;
                }
            }
        }
    }
}
