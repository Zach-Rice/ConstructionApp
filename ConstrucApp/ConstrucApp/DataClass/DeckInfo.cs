using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ConstrucApp
{
    public abstract class DeckInfo
    {
        public int TotalDeckLengthFT;
        public int TotalDeckWidthFT;
        public int TotalDeckLengthIN;
        public int TotalDeckWidthIN;

        
        protected DeckInfo(int a, int b)
        {
            TotalDeckLengthFT = a;
            TotalDeckWidthFT = b;
            TotalDeckLengthIN = TotalDeckLengthFT * 12;
            TotalDeckWidthIN = TotalDeckWidthFT * 12;
        }
    }
}
