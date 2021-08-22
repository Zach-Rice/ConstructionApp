using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConstrucApp.DataClass;
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
            PopulateReqGrid(newDeck);

            //ReqGrid.RowDefinitions.Add(new RowDefinition());
            //Label r = new Label {Text = newDeck.ReqDeckBaseMaterials()};
            //ReqGrid.Children.Add(r, 0, 1);
        }

        public void PopulateReqGrid(DeckBase a)
        {
            RequiredMaterials newMaterials = new RequiredMaterials(a);
            var dic = newMaterials.Req;
            int Index = 1;
            foreach (KeyValuePair<string, string> pair in dic)
            {
                ReqGrid.RowDefinitions.Add(new RowDefinition());
                Label size = new Label {Text = pair.Key, HorizontalOptions = LayoutOptions.Center, FontSize = 20};
                Label quant = new Label {Text = pair.Value, HorizontalOptions = LayoutOptions.Center, FontSize = 20};
                ReqGrid.Children.Add(size, 0, Index);
                ReqGrid.Children.Add(quant, 1, Index);
                Index++;
            }
        }
    }
}