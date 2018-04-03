﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Doppler.Mobile.DI;
using Xamarin.Forms;

namespace Doppler.Mobile
{
	public partial class App : Application
	{
		public App ()
		{
            //InitializeComponent();
            var appSetup = new AppSetup();
            AppContainer.Container = appSetup.CreateContainer();

            MainPage = new NavigationPage(new Doppler.Mobile.Views.HomePage());
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