using static System.Console;
namespace OutVariables
{
    partial class Program
    {
        public static void IsItCanBeParsedToInt(string input)
        {
            // *** Microsoft reference:
            // http://referencesource.microsoft.com/#mscorlib/system/int32.cs,325507e509229dbc
            //
            // public static bool TryParse(String s, out Int32 result)
            // {
            //    return Number.TryParseInt32(s, NumberStyles.Integer, NumberFormatInfo.CurrentInfo, out result);
            // }

            var WhatIsThisStatementResult = int.TryParse(input, out var LocalIntVar); // bool

            var WhatIsTheOutVarType = LocalIntVar.GetType(); // int

            // Real world use case
            if (int.TryParse(input, out var i)) // no need declare out variable and know it type
            { WriteLine($"You've entered: {i}"); }
            else { WriteLine("You've entered not int value"); }
        }
    }
}
