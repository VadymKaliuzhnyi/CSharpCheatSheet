namespace OutVariables
{
    static partial class Program
    {
        // The out keyword causes arguments to be passed by reference. This is like the ref keyword,
        // except that ref requires that the variable be initialized before it is passed.
        static void SomeMethod(out int x, out string y) // To use an out parameter, both the method
                                                        // definition and the calling method must explicitly use the out keyword.
        {
            x = 5; // init the variable
            y = "some text"; // init the variable
        }

    }
}