using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConstrucApp.Views;
using Xamarin.Forms;

namespace ConstrucApp
{
    public partial class DeckDimensions : ContentPage 
    {
        public DeckDimensions()
        {
            InitializeComponent();
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            Confirmation.IsVisible = true;
            ConfirmButton.IsVisible = true;
        }
        async void OnConfirmClick(object sender, EventArgs e)
        {
            DeckBase NewDeck = new DeckBase(Convert.ToInt32(Length.Text), Convert.ToInt32(Width.Text));
            
            await Navigation.PushAsync(new DeckMaterials(NewDeck));
        }
    }
}
