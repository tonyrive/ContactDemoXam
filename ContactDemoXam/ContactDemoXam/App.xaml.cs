using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ContactDemoXam.Views;
using Xamarin.Forms;

namespace ContactDemoXam
{
	public partial class App : Application
	{
		public App ()
		{
		    InitializeComponent();

		    MainPage = new NavigationPage(new ContactListPage());
        }

	    protected override void OnStart() { }

	    protected override void OnSleep() { }

	    protected override void OnResume() { }
    }
}
