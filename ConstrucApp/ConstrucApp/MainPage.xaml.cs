using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ConstrucApp
{
    public partial class MainPage : ContentPage 
    {
        public MainPage()
        {
            InitializeComponent();
            DeckBase newDeck = new DeckBase(DeckLength(), DeckWidth());
            this.BindingContext = newDeck;
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            
            var a = Length.Text;
            var b = Width.Text;
            int length = Convert.ToInt32(a);
            int width = Convert.ToInt32(b);
            DeckBase newDeck = new DeckBase(length, width);
            
            DisplayInfo(newDeck);
        }

        public void DisplayInfo(DeckBase a)
        {
            MaterialsGrid.IsVisible = true;
            ReqMaterials.Text = a.ReqDeckBaseMaterials();
        }

        private int DeckLength()
        {
            var a = Length.Text;
            int length = Convert.ToInt32(a);

            return length;
        }

        private int DeckWidth()
        {
            var b = Width.Text;
            int width = Convert.ToInt32(b);

            return width;
        }
    }
}
