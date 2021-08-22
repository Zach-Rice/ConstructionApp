using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Convert = System.Convert;

namespace ConstrucApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new DeckDimensions());
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
