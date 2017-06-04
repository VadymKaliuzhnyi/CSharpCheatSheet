namespace OutVariables
{

    static partial class Program
    {

        static void SomeMethod(out int x, out string y)
        {
            x = 5;
            y = "some text";
        }

    }
}
