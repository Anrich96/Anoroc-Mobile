﻿using System;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using Xamarin.UITest.Utils;

namespace AnorocMobileAppTests
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            if (platform == Platform.Android)
            {
                return ConfigureApp
                    .Android
                    .ApkFile("C:/Users/kevin/source/repos/COS301-SE-2020/Anoroc-Mobile/AnorocMobileApp/AnorocMobileApp.Android/bin/Release/com.anorocmobileapp.apk")
                    .WaitTimes(new WaitTimes())
                    .StartApp();
            }

            return ConfigureApp.iOS
                                .WaitTimes(new WaitTimes())
                                .StartApp();
        }

        public class WaitTimes : IWaitTimes
        {
            public TimeSpan GestureCompletionTimeout => TimeSpan.FromMinutes(1);

            public TimeSpan GestureWaitTimeout => TimeSpan.FromMinutes(1);

            public TimeSpan WaitForTimeout => TimeSpan.FromMinutes(1);
        }
    }
}