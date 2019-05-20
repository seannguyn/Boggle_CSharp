using System;
namespace Boggle.Common
{
    public static class ExtensionMethod
    {
        public static int checkBoardDimension(this string boggleString)
        {
            double result = Math.Sqrt(boggleString.Length);
            if (!(result % 1 == 0) && boggleString.Length >= 9)
            {
                Logger.Error("Invalid Board Dimentsion. Board dimension has to be perfect square and >= 9");
            }
            return (int) result;
        }
    }
}
