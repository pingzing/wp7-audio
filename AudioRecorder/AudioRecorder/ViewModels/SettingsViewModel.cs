using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AudioRecorder.ViewModels
{
    public class SettingsViewModel : ViewModelBase
    {
        public SettingsViewModel()
        {
            _TimeSpan_Value = TimeSpan_Value;
            _Switch1_Value = Switch1_Value;
        }

        private System.Nullable<Boolean> _Switch1_Value = false;
        public System.Nullable<Boolean> Switch1_Value           
        {
            get
            {
                return _Switch1_Value;
            }
            set
            {
                _Switch1_Value = value;
                System.Diagnostics.Debug.WriteLine("Value set to " + value);
                OnPropertyChanged("Switch1_Value");
            }
            
        }

        private TimeSpan _TimeSpan_Value = TimeSpan.MinValue;
        public TimeSpan TimeSpan_Value
        {
            get
            {
                return _TimeSpan_Value;
            }
            set
            {
                _TimeSpan_Value = value;
                System.Diagnostics.Debug.WriteLine("Timespan set to " + _TimeSpan_Value.TotalSeconds);
                OnPropertyChanged("TimeSpan_Value");
            }
        }


    }
}
