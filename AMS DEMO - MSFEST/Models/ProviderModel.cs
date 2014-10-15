using Microsoft.WindowsAzure.MobileServices;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace AMS_DEMO___MSFEST.Models
{
    public class ProviderModel : INotifyPropertyChanged
    {
        private string _name;
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (value != _name)
                {
                    _name = value;
                    NotifyPropertyChanged("Name");
                }
            }
        }


        private string _imageUrl;
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public string ImageURL
        {
            get
            {
                return _imageUrl;
            }
            set
            {
                if (value != _imageUrl)
                {
                    _imageUrl = value;
                    NotifyPropertyChanged("ImageURL");
                }
            }
        }


        private string _message;
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public string Message
        {
            get
            {
                return _message;
            }
            set
            {
                if (value != _message)
                {
                    _message = value;
                    NotifyPropertyChanged("Message");
                }
            }
        }
        private MobileServiceAuthenticationProvider _provider;
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public MobileServiceAuthenticationProvider Provider
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
                    NotifyPropertyChanged("Provider");
                }
            }
        }


        private MobileServiceUser _user;
        public MobileServiceUser User
        {
            get
            {
                return _user;
            }
            set
            {
                if (value != _user)
                {
                    _user = value;
                    NotifyPropertyChanged("User");
                }
            }
        }

        private ProviderUserModel _userDetails;

        public ProviderUserModel UserDetails
        {
            get
            {
                return _userDetails;
            }
            set
            {
                if (value != _userDetails)
                {
                    _userDetails = value;
                    NotifyPropertyChanged("UserDetails");
                }
            }
        }

        public ProviderModel()
        {
            Message = "Not connected, tap to connect";

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