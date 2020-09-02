﻿using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AnorocMobileApp.Models
{
    public class NotificationDB : INotifyPropertyChanged 
    {
        string relevantTime = string.Empty;

        [PrimaryKey, AutoIncrement]
        public int Id
        {
            get;
            set;
        }

        public string Title
        {
            get;
            set;
        }

        public string Body
        {
            get;
            set;
        }
        
        public string Time
        {
            get => relevantTime;
            set
            {
                if(relevantTime == value)
                {
                    return;
                }
                relevantTime = value;
                onPropertyChanged(nameof(relevantTime));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void onPropertyChanged(string relTime)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(relTime));
        }
    }
}
