using System;
using System.Linq;
using static System.Console;
using System.Collections.Generic;

namespace OutVariables
{
    static partial class Program
    {
        static void Main()
        {
            #region OldStyle
            // Old C# 6.0 approach

            int xOldApproach; // declare the variables here...
            string yOldApproach; // .. but not initialize them (as you would normally do)

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

            WriteLine($"xNewWildcardApproach is: {xNewApproach}");
            WriteLine(Environment.NewLine);
            #endregion

            #region UseCase
            // Real world use case

            CanThisStringBeParsedToInt("Here we are passing wrong input");
            CanThisStringBeParsedToInt("137");
            #endregion

            #region NewStyleWithAnonymousType
            // new out variables can be used even with anonymous type

            // for the sake of example imagine you are working with some array and running linq thru it
            var a = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var groupedByMod2 = a
                .Select(x => new
                {
                    Source = x,
                    Mod2 = x % 2
                })
                .GroupBy(x => x.Mod2)
                .ToDictionary(g => g.Key, g => g.ToArray());

            // Now imagine you want to use TryGetValue method for "groupedByMod2" variable
            // http://referencesource.microsoft.com/#mscorlib/system/collections/generic/dictionary.cs,2e5bc6d8c0f21e67
            //public bool TryGetValue(TKey key, out TValue value)
            //{
            //    int i = FindEntry(key);
            //    if (i >= 0)
            //    {
            //        value = entries[i].value;
            //        return true;
            //    }
            //    value = default(TValue);
            //    return false;
            //}

            #region C#6.0
            // in C# 6.0 you should:
            // 1. create a variable
            // 2. of anonymous type
            // 3. which will exactly match anonymous of your post-linq variable

            // System.Collections.Generic.Dictionary<int, <>f__AnonymousType0<int, int>[]>
            var temp = new[] {
                                new { Source = 108, Mod2 = 5 }
                              };

            // now you can pass it with "out" modifier to the abovementioned method.
            if (groupedByMod2.TryGetValue(1, out temp))
            {
                WriteLine(temp.Length);
            }
            #endregion

            #region C# 7.0
            // in C# 7.0 you can just type "out var" and compiler will do everything for you

            if (groupedByMod2.TryGetValue(1, out var oddElements))
            {
                WriteLine(oddElements.Length);
            }
            #endregion

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