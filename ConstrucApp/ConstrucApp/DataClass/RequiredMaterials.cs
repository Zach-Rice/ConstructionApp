using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace ConstrucApp.DataClass
{
    public class RequiredMaterials
    {
        public Dictionary<string,string> Req;

        public RequiredMaterials(DeckBase a)
        {
            Req = new Dictionary<string, string>();
            var keys = populateKey(a);
            var values =populateValue(a);
            int listLength = keys.Count;

            for (int i = 0; i < listLength; i++)
            {
                Req.Add(keys[i], values[i]);
            }
        }

        private List<string> populateKey(DeckBase a)
        {
            List<string> keyList = new List<string>();

            int? extraDeckLength = null;
            string extraDeckBoard = null;
            if (a.ExtraDeckLength != 0) { extraDeckLength = a.ExtraDeckLength; }
            if (extraDeckLength != null) { extraDeckBoard = $"5/8x6x{extraDeckLength}"; }
            string mainDeckBoard = $"5/8x6x{a.MainDeckLength}";


            int? extraBeamLength = null;
            string extraBeamBoard = null;
            if (a.ExtraBeamLength != 0) { extraBeamLength = a.ExtraBeamLength; }
            if (extraBeamLength != null) { extraBeamBoard = $"2x8x{extraBeamLength}"; }
            string mainBeamBoard = $"2x8x{a.MainBeamLength}";

            keyList.Add(mainDeckBoard);
            if (extraDeckBoard != null) { keyList.Add(extraDeckBoard); }
            keyList.Add(mainBeamBoard);
            if (extraBeamBoard != null) { keyList.Add(extraBeamBoard); }

            return keyList;
        }

        private List<string> populateValue(DeckBase a)
        {
            List<int> valueList = new List<int>();

            valueList.Add(a.NumMainDeckBoards);
            if(a.NumExtraDeckBoards != 0) { valueList.Add(a.NumExtraDeckBoards);}
            valueList.Add(a.NumMainBeams);
            if (a.NumExtraBeam != 0) { valueList.Add(a.NumExtraBeam);}

            List<string> values = new List<string>();
            foreach (int b in valueList)
            {
                values.Add(Convert.ToString(b));
            }

            return values;
        }
    }
}
