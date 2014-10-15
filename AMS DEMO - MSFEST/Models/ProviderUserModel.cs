using Microsoft.WindowsAzure.MobileServices;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Runtime.Serialization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace AMS_DEMO___MSFEST.Models
{

    [DataContract]
    public class ProviderUserModel : INotifyPropertyChanged
    {
        private string _id;
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>

        [DataMember]
        public string id
        {
            get
            {
                return _id;
            }
            set
            {
                if (value != _id)
                {
                    _id = value;
                    NotifyPropertyChanged("id");
                }
            }
        }
        
        
        private string _first_name;
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>

        [DataMember]
        public string first_name
        {
            get
            {
                return _first_name;
            }
            set
            {
                if (value != _first_name)
                {
                    _first_name = value;
                    NotifyPropertyChanged("first_name");
                }
            }
        }

        private string _picture;
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>


        [DataMember]
        public string picture
        {
            get
            {
                return _picture;
            }
            set
            {
                if (value != _picture)
                {
                    _picture = value;
                    NotifyPropertyChanged("picture");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}