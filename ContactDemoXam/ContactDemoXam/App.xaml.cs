using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ContactDemoXam.Views;
using Xamarin.Forms;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

namespace ContactDemoXam
{
	public partial class App : Application
	{
		public App ()
		{
		    InitializeComponent();

		    MainPage = new NavigationPage(new ContactListPage());
        }

	    protected override void OnStart()
	    {
	        AppCenter.Start("android=9660fdb0-7729-4ab0-9b43-8c1caac57d09;" +
                            "ios=9a3891f2-4420-448e-9132-d86f9f38f4ae",
	            typeof(Analytics), typeof(Crashes));
        }

	    protected override void OnSleep() { }

	    protected override void OnResume() { }
    }
}
