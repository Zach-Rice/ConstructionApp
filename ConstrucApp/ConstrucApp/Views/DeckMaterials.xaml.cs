using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ConstrucApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DeckMaterials : ContentPage
    {
        public DeckMaterials(DeckBase newDeck)
        {
            InitializeComponent();
            DeckBase deck = newDeck;
            this.BindingContext = deck;

            Req.Text = deck.ReqDeckBaseMaterials();
        }
    }
}