namespace DigitSeparators
{
    class Program
    {
        static void Main()
        {
            #region intro
            // The underscore _ may be used as a digit separator.
            // Being able to group digits in large numeric literals has a significant impact on readability.
            #endregion

            #region Scope
            // Separator can be applied to binary, hexadecimal and decimal values.
            int binary = 0b1001_1010_0001_0100;
            int hexadecimal = 0x1b_a0_44_fe;
            int dec = 33_554_432;
            #endregion

            #region HowMuchUnderscores?
            // Different groupings may make sense in different scenarios or with different numeric bases.
            // Any sequence of digits may be separated by one or more underscores.
            // The separators have no semantic impact - they are simply ignored.
            int dec2 = 1_000_000; // Million
            int dec3 = 1___0_0_0___0_0_0; // Million
            #endregion

            #region Exceptions
            // The underscore may occur anywhere in a numeric literal but with the below exceptions.
            // Where the _ digit separator may NOT be used:

            //int dec4 = _213123; //at the beginning of the value
            //int dec5 = 36546456_; //at the end of the value
            //int dec6 = 17_.0; //next to the decimal
            //int dec7 = 1.1e_1; //next to the exponent character
            //int dec8 = 10_f; //next to the type specifier
            //int binary2 = 0b_1001_1000; //immediately following the 0x or 0b in binary and hexadecimal literals
            #endregion
        }
    }
}
