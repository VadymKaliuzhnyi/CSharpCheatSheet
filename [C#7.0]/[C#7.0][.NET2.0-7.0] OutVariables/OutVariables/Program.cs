using static System.Console;

namespace OutVariables
{
    static partial class Program
    {
        static void Main()
        {
            #region OldStyle
            // Old C# 6.0 approach

            int xOldApproach; // declare the variables here...
            string yOldApproach; // .. but not initialize them (as you would normally do with ref parameter modifier)

            SomeMethod(out xOldApproach, out yOldApproach); // pass variables to the method where they will be initialized

            WriteLine($"xOldApproach is: {xOldApproach}\n" + // use variables after initialization and assignment
                      $"yOldApproach is: {yOldApproach}");
            #endregion

            #region NewStyle
            // New C# 7.0 approach - explicit type declaration

            SomeMethod(out int xNewApproach, out string yNewApproach); // declare variables in line with passing them

            WriteLine($"xNewApproach is: {xNewApproach}\n" +
                      $"yNewApproach is: {yNewApproach}");
            #endregion

            #region NewStyleVar
            // New C# 7.0 approach - var usage

            SomeMethod(out var xNewVarApproach, out var yNewVarApproach); // declare implicitly typed local variable

            WriteLine($"xNewVarApproach is: {xNewApproach}\n" +
                      $"yNewVarApproach is: {yNewApproach}");
            #endregion

            #region UseCase
            // Real world use case

            IsItCanBeParsedToInt("Here we are passing wrong input");
            IsItCanBeParsedToInt("137");
            #endregion

            ReadKey();
        }
    }
}