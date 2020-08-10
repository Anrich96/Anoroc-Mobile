﻿using System;
using AnorocMobileApp.Models.Dashboard;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms.Internals;
using System.Windows.Input;
using AnorocMobileApp.Helpers;
using AnorocMobileApp.Models;
using Xamarin.Forms;

namespace AnorocMobileApp.ViewModels.Dashboard
{
    /// <summary>
    /// ViewModel for Add Itinerary page.
    /// </summary>
    [Preserve(AllMembers = true)]
    [DataContract]
    public class AddItineraryViewModel : INotifyPropertyChanged
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="AddItineraryViewModel"/> class.
        /// </summary>
        public AddItineraryViewModel()
        {
        }

        #endregion
        
        #region HttpRequest
        
        private static HttpClient _httpClientInstance;

        public static HttpClient HttpClientInstance => _httpClientInstance ?? (_httpClientInstance = new HttpClient());

        
        #endregion
        
        #region Fields

        private ObservableCollection<AddressInfo> addresses;
        private string addressText;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets a collection of value to be displayed in add itinerary page.
        /// </summary>
        [DataMember(Name = "dailyTimeline")]
        public ObservableCollection<Event> DailyTimeline { get; set; }

        public ObservableCollection<AddressInfo> Addresses
        {
            get => addresses ?? (addresses = new ObservableCollection<AddressInfo>());
            set
            {
                if (addresses != value)
                {
                    addresses = value;
                    OnPropertyChanged("Addresses");
                }
            }
        }
        
        public string AddressText 
        {
            get => addressText;
            set 
            {
                if (addressText != value) {
                    addressText = value;
                    OnPropertyChanged("AddressText");
                }
            }
        }

        #endregion
        
        #region Commands

        #endregion
        
        #region Methods

        public async Task GetPlacesPredictonAsync()
        {
            // TODO: Add some logic to slow down requests
            // Google will deny requests which are too frequent
            var cancellationToken = new CancellationTokenSource(TimeSpan.FromMinutes(2)).Token;

            using (var request = new HttpRequestMessage(HttpMethod.Get,
                string.Format(Constants.GooglePlacesApiAutoCompleteUrl,
                    Secrets.GooglePlacesApiKey,
                    WebUtility.UrlEncode(addressText))))
            {
                using (HttpResponseMessage message = await HttpClientInstance.SendAsync(
                    request, HttpCompletionOption.ResponseContentRead, cancellationToken).ConfigureAwait(false))
                {
                    
                }
            }
        }
        
        #endregion

        #region INotifyPropertyChanged
        
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

    }
}
