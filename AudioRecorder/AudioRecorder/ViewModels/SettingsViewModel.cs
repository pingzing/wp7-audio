using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;

namespace AudioRecorder.ViewModels
{
    public class SettingsViewModel : ViewModelBase
    {
        private IsolatedStorageSettings appSettings = IsolatedStorageSettings.ApplicationSettings;

        public SettingsViewModel()
        {           
            if(appSettings.Contains("timeLimitOn"))
            {
                _Switch1_Value = (bool?)appSettings["timeLimitOn"];
            }
            else
            {
                _Switch1_Value = Switch1_Value;       
            }

            if (appSettings.Contains("timeLimitValue"))
            {
                _TimeSpan_Value = (TimeSpan)appSettings["timeLimitValue"];
            }
            else
            {
                _TimeSpan_Value = TimeSpan_Value;
            }
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
                if (!(appSettings.Contains("timeLimitOn")))
                {
                    try
                    {
                        appSettings.Add("timeLimitOn", value);
                    }
                    catch(ArgumentException ex)
                    {
                        System.Diagnostics.Debug.WriteLine(ex.Message);
                    }
                }
               else
               {
                    appSettings["timeLimitOn"] = value;
               }
                _Switch1_Value = (bool?)appSettings["timeLimitOn"];
                appSettings.Save();
                OnPropertyChanged("Switch1_Value");
            }
                        
        }

        public TimeSpan TimeSpanMaxTime { get { return TimeSpan.FromMinutes(50); } }
        public TimeSpan TimeSpan5Min { get { return TimeSpan.FromMinutes(5); } }
        private TimeSpan _TimeSpan_Value = TimeSpan.Zero;
        public TimeSpan TimeSpan_Value
        {
            get
            {
                return _TimeSpan_Value;
            }

            set
            {
                if (!(appSettings.Contains("timeLimitValue")))
                {
                    try
                    {
                        appSettings.Add("timeLimitValue", value);
                    }
                    catch (ArgumentException ex)
                    {
                        System.Diagnostics.Debug.WriteLine(ex.Message);
                    }
                }
                else
                {
                    appSettings["timeLimitValue"] = value;
                }
                _TimeSpan_Value = (TimeSpan)appSettings["timeLimitValue"];
                appSettings.Save();
                OnPropertyChanged("TimeSpan_Value");
            }
        }

        


    }
}
