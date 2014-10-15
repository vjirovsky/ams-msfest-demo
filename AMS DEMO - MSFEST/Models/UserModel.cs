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

    public class User : INotifyPropertyChanged
    {
        private string _id;
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>

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

        private DateTime _added_at;
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>

        public DateTime added_at
        {
            get
            {
                return _added_at;
            }
            set
            {
                if (value != _added_at)
                {
                    _added_at = value;
                    NotifyPropertyChanged("added_at");
                }
            }
        }

        private string _profile_picture;
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>


        public string profile_picture
        {
            get
            {
                return _profile_picture;
            }
            set
            {
                if (value != _profile_picture)
                {
                    _profile_picture = value;
                    NotifyPropertyChanged("profile_picture");
                }
            }
        }


        private string _provider;
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>


        public string provider
        {
            get
            {
                return _provider;
            }
            set
            {
                if (value != _provider)
                {
                    _provider = value;
                    NotifyPropertyChanged("provider");
                }
            }
        }

        private string _userid;
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>


        public string userid
        {
            get
            {
                return _userid;
            }
            set
            {
                if (value != _userid)
                {
                    _userid = value;
                    NotifyPropertyChanged("userid");
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