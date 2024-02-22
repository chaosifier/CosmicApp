using Cosmic.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cosmic
{
    public partial class App : Application
    {
        public static NavigationPage MainNavigation { get; private set; }
        public App()
        {
            InitializeComponent();

            MainNavigation = new NavigationPage(new HomePage());
            MainPage = MainNavigation;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
