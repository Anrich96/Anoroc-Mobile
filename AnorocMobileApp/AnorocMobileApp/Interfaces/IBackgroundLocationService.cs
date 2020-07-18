﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AnorocMobileApp.Interfaces
{
    public interface IBackgroundLocationService
    {
        bool isTracking();
        void Start_Tracking();
        void Stop_Tracking();
    }
}
