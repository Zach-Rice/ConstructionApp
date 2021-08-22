using System;

namespace ConstrucApp
{
    public class DeckBase : DeckInfo
    {
        #region fields
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
            NumMainDeckBoards = NumMainBoards(TotalDeckWidthFT, MainDeckLength, NumDeckBoardsAcross, null);
            NumExtraDeckBoards = ExtraDeckLength != 0 ? 1 : 0;
            MainBeamLength = DeckBoardLength(TotalDeckWidthFT);
            ExtraBeamLength = ExtraBoardLength(TotalDeckLengthFT, MainBeamLength, NumBeamAcross, TotalDeckWidthFT);
            NumMainBeams = NumMainBoards(TotalDeckLengthFT, MainBeamLength, NumBeamAcross, TotalDeckWidthFT);
            NumExtraBeam = ExtraBeamLength != 0 ? 1 : 0;
        }
        #endregion
        #region methods
        public string ReqDeckBaseMaterials()
        {
            string output = $"5/8x6x{MainDeckLength}FT boards: {NumMainDeckBoards}";
            if (NumExtraDeckBoards != 0) { output += $"\n5/8x6x{ExtraDeckLength} FT boards: {NumExtraDeckBoards}"; }
            output += $"\n\n2x8x{MainBeamLength}FT boards: {NumMainBeams}";
            if (NumExtraBeam != 0) { output += $"\n2x{ExtraBeamLength} FT boards: {NumExtraBeam}"; }
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
                if (sideBeam != null) { side = Convert.ToInt32(sideBeam); }
                int extra = (side % length) * 2;
                int newExtra = extra % length;
                extraLength += newExtra;
            }
            if (extraLength > length) { extraLength = extraLength % length; }
            if (extraLength != 0) { extraLength = DeckBoardLength(extraLength); }
            if (extraLength == length) { return 0; }
            return extraLength;
        }
        private int NumMainBoards(int param, int length, int across, int? side)
        {
            int numMain = param / length;
            int totalMainBoards = numMain * across;

            if (param % length != 0)
            {
                int totalExtraLength = (param % length) * across;
                int extraMain = totalExtraLength / length;
                totalMainBoards += extraMain;
            }
            if (side != null)
            {
                int numSideBoard = (Convert.ToInt32(side) * 2) / length;
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
        #endregion
    }
}
