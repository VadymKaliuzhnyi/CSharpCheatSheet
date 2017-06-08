using System.Linq;
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

            #region NewStyleWildcard
            // If some of the parameters that a function returns in out is not needed
            // you can use the discard operator '_'
            SomeMethod(out var xNewWildcardApproach, out var _ ); // I only care about first parameter
            #endregion

            #region UseCase
            // Real world use case

            IsItCanBeParsedToInt("Here we are passing wrong input");
            IsItCanBeParsedToInt("137");
            #endregion

            #region NewStyleWithAnonymousType
            // new out variables can be used even with anonymous type
            // StackOverflow example:
            // https://stackoverflow.com/documentation/c%23/1936/c-sharp-7-0-features/6326/out-var-declaration#t=201706081042420760979

            var a = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var groupedByMod2 = a.Select(x => new
            {
                Source = x,
                Mod2 = x % 2
            })
                                 .GroupBy(x => x.Mod2)
                                 .ToDictionary(g => g.Key, g => g.ToArray());
            if (groupedByMod2.TryGetValue(1, out var oddElements))
            {
                WriteLine(oddElements.Length);
            }

            #endregion

            #region NewStyleLimitations
            // https://stackoverflow.com/documentation/c%23/1936/c-sharp-7-0-features/6326/out-var-declaration#t=20170608110416266232
            // Note that out var declarations are of limited use in LINQ queries
            // as expressions are interpreted as expression lambda bodies,
            // so the scope of the introduced variables is limited to these lambdas.
            // For example, the following code will not work:

            // var nums =
            // from item in seq
            // let success = int.TryParse(item, out var tmp)
            // select success ? tmp : 0; // Error: The name 'tmp' does not exist in the current context
            #endregion

            ReadKey();
        }
    }
}