using static System.Console;

namespace OutVariables
{
    partial class Program
    {
        public static void IsItCanBeParsedToInt(string input)
        {
            #region TryParse definition
            // *** Microsoft reference:
            // http://referencesource.microsoft.com/#mscorlib/system/int32.cs,325507e509229dbc
            //
            // public static bool TryParse(String s, out Int32 result)
            // {
            //    return Number.TryParseInt32(s, NumberStyles.Integer, NumberFormatInfo.CurrentInfo, out result);
            // }
            #endregion

            #region TryParse detailed view
            var WhatIsThisStatementResult = int.TryParse(input, out var LocalIntVar); // bool

            var WhatIsTheOutVarType = LocalIntVar.GetType(); // int
            #endregion

            #region Real use case demo
            if (int.TryParse(input, out var i)) // no need declare out variable beforehand and know it's type
            {
                WriteLine($"You've passed number: {i}");
            }
            else
            {
                WriteLine("You've passed not int value");
            }
            #endregion
        }
    }
}