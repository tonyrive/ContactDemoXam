﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ContactDemoXam.iOS.Services;
using ContactDemoXam.Services;
using Foundation;
using UIKit;

[assembly: Xamarin.Forms.Dependency(typeof(PhoneDialer))]
namespace ContactDemoXam.iOS.Services
{
    public class PhoneDialer : IDialer
    {
        public bool Dial(string number)
        {
            return UIApplication.SharedApplication.OpenUrl(
                new NSUrl("tel:" + number));
        }
    }
}