using System;
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
            var range = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var groupedByMod2 = range
                .Select(x => new
                {
                    Source = x,
                    ModBy2 = x % 2
                })
                .GroupBy(input => input.ModBy2)
                .ToDictionary(k => k.Key, v => v.ToArray());

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
                                new { Source = 108, ModBy2 = 5 }
                              };

            // now you can pass it with "out" modifier to the above mentioned method.
            if (groupedByMod2.TryGetValue(1, out temp))
            {
                WriteLine(temp.Length);
            }
            #endregion

            #region C# 7.0
            // in C# 7.0 you can just type "out var" and compiler will do everything for you

            if (groupedByMod2.TryGetValue(1, out var oddEl))
            {
                WriteLine(oddEl.Length);
            }
            #endregion

            #endregion

            #region NewStyleLimitations
            // In current version of C# (7.0) out var declarations are of limited use in LINQ queries.
            // Since expressions are interpreted as expression lambdas,
            // so the scope of the input variables is limited to these lambdas.

            var SomeRange = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // var CanItBeParsedToInt =
            // from item in SomeRange

            // let result = int.TryParse(item.ToString(), out var tmp)
            //// "Out variable and pattern variable declarations are not allowed within a query clause."

            // select result ? tmp : 0;
            ///// "The name does not exist in the current context"

            // some developers notes:
            // https://github.com/dotnet/csharplang/blob/master/meetings/2016/LDM-2016-12-07-14.md#expression-variables-in-query-expressions
            // We won't have time to do this feature in C# 7.0.
            // If we want to leave ourselves room to do it in the future, we need to make sure
            // that we don't allow expression variables in query clauses to mean something else today,
            // that would contradict such a future.
            // The current semantics is that expression variables in query clauses are scoped
            // to only the query clause.That means two subsequent query clauses can use the same
            // name in expression variables, for instance.That is inconsistent with a future that
            // allows those variables to share a scope across query clause boundaries.
            // Thus, if we want to allow this in the future we have to put in some restrictions
            // in C# 7.0 to protect the design space.

            #endregion

            ReadKey();
        }
    }
}