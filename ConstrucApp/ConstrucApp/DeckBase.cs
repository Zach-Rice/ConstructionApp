using System;

namespace ConstrucApp
{
    public class DeckBase : DeckInfo
    {
        public int MainDeckLength;
        public int ExtraDeckLength;
        public int NumMainDeckBoards;
        public int NumExtraDeckBoards;
        public int MainBeamLength;
        public int ExtraBeamLength;
        public int NumMainBeams;
        public int NumExtraBeam;
        public int NumDeckBoardsAcross;
        public int NumBeamAcross;

        public DeckBase(int length, int width) : base(length, width)
        {
            NumDeckBoardsAcross = Convert.ToInt32(TotalDeckLengthIN / 5.5);
            NumBeamAcross = TotalDeckWidthIN / 16;
            MainDeckLength = DeckBoardLength(TotalDeckLengthFT);
            ExtraDeckLength = ExtraBoardLength(TotalDeckWidthFT, MainDeckLength, NumBeamAcross, null);
            NumMainDeckBoards = NumMainBoards(TotalDeckWidthFT, MainDeckLength, NumDeckBoardsAcross);
            NumExtraDeckBoards = ExtraDeckLength != 0 ? 1 : 0;
            MainBeamLength = DeckBoardLength(TotalDeckWidthFT);
            ExtraBeamLength = ExtraBoardLength(TotalDeckLengthFT, MainBeamLength, NumBeamAcross, TotalDeckWidthFT);
            NumMainBeams = NumMainBoards(TotalDeckLengthFT, MainBeamLength, NumBeamAcross);
            NumExtraBeam = ExtraBeamLength != 0 ? 1 : 0;
        }
             
        public string ReqDeckBaseMaterials()
        {
            string output = $"Decking\n\tNum of {MainDeckLength}FT boards: {NumMainDeckBoards}";
            if (NumExtraDeckBoards != 0) { output += $"\n\tNum of {ExtraDeckLength} FT boards: {NumExtraDeckBoards}"; }
            output += $"\nDeck Frame\n\tNum of {MainBeamLength}FT boards: {NumMainBeams}";
            if (NumExtraBeam != 0) { output += $"\n\tNum of {ExtraBeamLength} FT boards: {NumExtraBeam}"; }
            return output;
        }
        
        private int ExtraBoardLength(int param, int length, int across, int? sideBeam)
        {
            int extraLength = 0;
            if (param % length != 0)
            {
                int totalExtraLength = (param % length) * across;
                int newExtra = totalExtraLength % length;
                extraLength += newExtra;
            }

            if (sideBeam % length != 0)
            {
                int side = 0;
                if (sideBeam != null) {side = Convert.ToInt32(sideBeam);}
                int extra = (side % length) * 2;
                int newExtra = extra % length;
                extraLength += newExtra;
            }
            if(extraLength > length) { extraLength = extraLength % length; }
            if (extraLength != 0) { extraLength = DeckBoardLength(extraLength); }
            return extraLength;
        }
        private int NumMainBoards(int param, int length, int across)
        {
            int numMain = param / length;
            int totalMainBoards = numMain * across;

            if (param % length != 0)
            {
                int totalExtraLength = (param % length) * across;
                int extraMain = totalExtraLength / length;
                totalMainBoards += extraMain;
            }

            if (param == TotalDeckWidthFT && length == MainBeamLength)
            {
                int numSideBoard = (param / length) * 2;
                totalMainBoards += numSideBoard;
            }
            return totalMainBoards;
        }
        private int DeckBoardLength(int length)
        {
            int boardLength = 0;
            if (length <= 4)
            {
                boardLength = 4;
            }
            else if (length > 4 && length <= 8)
            {
                boardLength = 8;
            }
            else if (length > 8 && length <= 10)
            {
                boardLength = 10;
            }
            else if (length > 10 && length <= 12)
            {
                boardLength = 12;
            }
            else if (length > 12)
            {
                boardLength = 16;
            }
            return boardLength;
        }
    }
}
