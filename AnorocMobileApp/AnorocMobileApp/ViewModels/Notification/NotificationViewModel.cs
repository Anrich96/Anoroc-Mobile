﻿using AnorocMobileApp.Models;
using AnorocMobileApp.Models.Notification;
using SQLite;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.Serialization;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace AnorocMobileApp.ViewModels.Notification
{
    /// <summary>
    /// ViewModel for the Notification page.
    /// </summary>
    //[SQLite.Preserve(AllMembers = true)]
    [DataContract]
    public class NotificationViewModel : BaseViewModel
    {
        #region Fields

        private Command<object> itemTappedCommand;

        private Command<object> backCommand;

        private Command<object> menuCommand;

        private ObservableCollection<NotificationModel> recentList;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="NotificationViewModel"/> class.
        /// </summary>
        public NotificationViewModel()
        {
           
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the command that will be executed when an item is selected.
        /// </summary>
        public Command<object> ItemTappedCommand
        {
            get
            {
                return this.itemTappedCommand ?? (this.itemTappedCommand = new Command<object>(this.ItemSelected));
            }
        }

        /// <summary>
        /// Gets the command that will be executed when an item is selected.
        /// </summary>
        public Command<object> BackCommand
        {
            get
            {
                return this.backCommand ?? (this.backCommand = new Command<object>(this.BackButtonClicked));
            }
        }

        /// <summary>
        /// Gets the command that will be executed when an item is selected.
        /// </summary>
        public Command<object> MenuCommand
        {
            get
            {
                return this.menuCommand ?? (this.menuCommand = new Command<object>(this.MenuButtonClicked));
            }
        }

        /// <summary>
        /// Gets or sets a collection of values to be displayed in the social notification page recent list.
        /// </summary>
        [DataMember(Name = "recentNotificationList")]
        public ObservableCollection<NotificationModel> RecentList
        {
            get => recentList ?? (recentList = new ObservableCollection<NotificationModel>());
            set
            {
                if (recentList != value)
                {
                    recentList = value;
                    OnPropertyChanged("AddressTimeline");
                }
            }
        }

        /// <summary>
        /// Gets or sets a collection of values to be displayed in the social notification page earlier list.
        /// </summary>
        [DataMember(Name = "earlierNotificationList")]
        public ObservableCollection<NotificationModel> EarlierList { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Invoked when an item is selected from the navigation list.
        /// </summary>
        /// <param name="selectedItem">Selected item from the list view.</param>
        private void ItemSelected(object selectedItem)
        {
            ((selectedItem as Syncfusion.ListView.XForms.ItemTappedEventArgs)?.ItemData as NotificationModel).IsRead = true;
            // Do something
        }

        /// <summary>
        /// Invoked when back button is clicked in the social notification page.
        /// </summary>
        /// <param name="obj">The object.</param>
        private void BackButtonClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when menu button is clicked in the social notification page.
        /// </summary>
        /// <param name="obj">The object.</param>
        private void MenuButtonClicked(object obj)
        {
            // Do something
        }

        #endregion       

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        
    }
}
