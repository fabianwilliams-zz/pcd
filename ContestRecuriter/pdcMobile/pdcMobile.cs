﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;
//using UIKit;
#if __IOS__
using UIContext = UIKit.UIViewController;
#elif __ANDROID__
using UIContext = global::Android.Content.Context;
#endif

namespace pdcMobile
{
	public class App : Application
	{
		public static UIContext UIContext { get; set; }

		public App ()
		{
			// The root page of your application
			MainPage = new NavigationPage(new HomePage());
		}

		public static Page GetMainPage()
		{
			return new NavigationPage (new HomePage ());
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

