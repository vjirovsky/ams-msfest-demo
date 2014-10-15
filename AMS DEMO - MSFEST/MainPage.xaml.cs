using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;
using System.Net.Http;
using AMS_DEMO___MSFEST.Models;
using Newtonsoft.Json;
using System.Windows.Threading;
using Microsoft.Phone.Notification;
using Microsoft.WindowsAzure.Messaging;
using System.Diagnostics;

namespace AMS_DEMO___MSFEST
{
    public partial class MainPage : PhoneApplicationPage
    {

        private string PUSH_CHANNEL_NAME = "msfestamsdemo";
        private string PUSH_HUB_NAME = "amsmsfestdemobus";
        private string PUSH_HUB_CONNECTION = "<FILL_YOUR_ENDPOINT>"; // looks like Endpoint=sb://something.servicebus.windows.net/;...

        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Set the data context of the listbox control to the sample data
            DataContext = App.ViewModel;
        }

        private void RegisterPushChannel() {

            try
            {

                var channel = HttpNotificationChannel.Find(PUSH_CHANNEL_NAME);
                if (channel == null)
                {
                    channel = new HttpNotificationChannel(PUSH_CHANNEL_NAME);

                    channel.Open();
                    channel.BindToShellToast();

                }


                channel.ChannelUriUpdated += new EventHandler<NotificationChannelUriEventArgs>(async (o, args) =>
                {
                    var hub = new NotificationHub(PUSH_HUB_NAME, PUSH_HUB_CONNECTION);
                    try
                    {
                        var result = await hub.RegisterNativeAsync(args.ChannelUri.ToString());
                        Debug.WriteLine(result.NotificationHubPath);
                        if (result.RegistrationId != null)
                        {
                            Debug.WriteLine("Registration successful; Id of device:" + result.RegistrationId);

                        }
                        else {
                            Debug.WriteLine("Registration failed! No registrationId recieved");
                        }
                    }
                    catch (RegistrationAuthorizationException e)
                    {
                        Debug.WriteLine("Registration failed;"+ e.Message);
                        App.ViewModel.PushStatus = "Registration failed!";
                    }
                });
            }
            catch(Exception e){
                MessageBox.Show("Registration of push channel failed!" + e.ToString());

            }
        }

        private async Task Authenticate(ProviderModel provider)
        {

            if (provider.User == null)
            {
                string message = String.Empty;
                
                try
                {
                    //we recieve only user ID
                    provider.User = await App.MobileService.LoginAsync(provider.Provider);
                    
                    // we have to get user details from our custom API 'userdetails'
                    var userDetails = await App.MobileService.InvokeApiAsync("userdetails", HttpMethod.Get, null);
                    var stringUserDetails = userDetails.ToString();
                    
                    provider.UserDetails = await JsonConvert.DeserializeObjectAsync<ProviderUserModel>(stringUserDetails);
                    provider.ImageURL = provider.UserDetails.picture;
                    provider.Message = "Connected!";
                    
                    var insertData = new User(){ userid = provider.User.UserId, provider = provider.Name, first_name = provider.UserDetails.first_name, profile_picture = provider.UserDetails.picture};

                    await App.MobileService.GetTable<User>().InsertAsync(insertData);


                }   
                catch (InvalidOperationException e)
                {
                    MessageBox.Show("Login has failed with error: " + e.Message + "");
                    provider.Message = "Connection failed! Tap to connect";
                    return;
                }
            }
        }

        // Load data for the ViewModel Items
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
                
            }

            await LoadDataStorage();
        }

        private async Task LoadDataStorage(){
            var progressbar = new ProgressIndicator
            {
                IsVisible = true,
                IsIndeterminate = true,
                Text = "Updating data storage"
            };
            SystemTray.SetProgressIndicator(this, progressbar);

            try
            {
                var users = await App.MobileService.GetTable<User>().OrderByDescending(u => u.added_at).ToCollectionAsync<User>();

                App.ViewModel.DataStorageItems.Clear();

                App.ViewModel.DataStorageItems = users;
                App.ViewModel.NotifyPropertyChanged("DataStorageItems");
            }
            catch (Exception e) {

                MessageBox.Show("Downloading data from azure storage failed!");
            }

            progressbar = new ProgressIndicator
            {
                IsVisible = false,
                IsIndeterminate = false,
                Text = ""
            };
            SystemTray.SetProgressIndicator(this, progressbar);
            
        }

        private async void ProviderList_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            var provider = ((FrameworkElement)e.OriginalSource).DataContext
                                                             as ProviderModel;

            if (provider == null)
                return;

            await Authenticate(provider);
            await LoadDataStorage();

        }

        private async void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            await LoadDataStorage();
        }

        private void registerButton_Click(object sender, RoutedEventArgs e)
        {
            RegisterPushChannel();
        }

        private async void unregisterButton_Click(object sender, RoutedEventArgs e)
        {
               var channel = HttpNotificationChannel.Find(PUSH_CHANNEL_NAME);
                if (channel != null)
                {
                    try
                    {
                        var hub = new NotificationHub(PUSH_HUB_NAME, PUSH_HUB_CONNECTION);
                        await hub.UnregisterAllAsync(channel.ChannelUri.ToString());
                    }
                    catch (Exception ee) {
                        Debug.WriteLine("Unregistration failed!");
                
                    }
                }
        }

        private void ShowInBrowser(string url)
        {
            Microsoft.Phone.Tasks.WebBrowserTask wbt = new Microsoft.Phone.Tasks.WebBrowserTask();
            wbt.Uri = new Uri(url);
            wbt.Show();
        }

        private void HyperlinkMSFest_Click(object sender, RoutedEventArgs e)
        {
            ShowInBrowser("http://www.ms-fest.cz?utm_source=msfest2013amsdemo&utm_medium=wp8app&utm_campaign=aboutpage");
        }

        private void HyperlinkAzure_Click(object sender, RoutedEventArgs e)
        {
            ShowInBrowser("http://www.azure.com");
        }

        private void HyperlinkGithub_Click(object sender, RoutedEventArgs e)
        {
            ShowInBrowser("https://github.com/vjirovsky/ams-msfest-demo");
        }

        private void HyperlinkAuthor_Click(object sender, RoutedEventArgs e)
        {
            ShowInBrowser("http://www.vjirovsky.cz?utm_source=msfest2013amsdemo&utm_medium=wp8app&utm_campaign=aboutpage");
        }
        
        


    }

}