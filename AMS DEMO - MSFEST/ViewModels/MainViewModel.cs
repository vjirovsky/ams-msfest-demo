using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using AMS_DEMO___MSFEST.Resources;
using AMS_DEMO___MSFEST.Models;
using Microsoft.WindowsAzure.MobileServices;
using System.Collections.Generic;

namespace AMS_DEMO___MSFEST.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            this.Providers = new ObservableCollection<ProviderModel>();
            this.DataStorageItems = new ObservableCollection<User>();
            this.PushStatus = "";
        }

        /// <summary>
        /// A collection for user identity providers
        /// </summary>
        public ObservableCollection<ProviderModel> Providers { get; private set; }


        public ObservableCollection<User> DataStorageItems { get; set; }


        private string _pushStatus;
        public string PushStatus {
            get {
                return _pushStatus;
            }
            set {
                if (_pushStatus != value) {
                    _pushStatus = value;
                    NotifyPropertyChanged("PushStatus");

                }

            }
        }

        public bool IsDataLoaded
        {
            get;
            private set;
        }


        /// <summary>
        /// Creates and adds a few ItemViewModel objects into the Items collection.
        /// </summary>
        public void LoadData()
        {
            // Sample data; replace with real data
            this.Providers.Add(new ProviderModel() { Name = "Microsoft Account", Provider = MobileServiceAuthenticationProvider.MicrosoftAccount });
            this.Providers.Add(new ProviderModel() { Name = "Facebook", Provider = MobileServiceAuthenticationProvider.Facebook });
            this.Providers.Add(new ProviderModel() { Name = "Twitter", Provider = MobileServiceAuthenticationProvider.Twitter });
            this.Providers.Add(new ProviderModel() { Name = "Google", Provider = MobileServiceAuthenticationProvider.Google });

            this.IsDataLoaded = true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}