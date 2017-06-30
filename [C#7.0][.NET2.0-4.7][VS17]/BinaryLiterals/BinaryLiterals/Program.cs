using System;
using static System.Console;

namespace BinaryLiterals

{
    class Program
    {
        [Flags]
        enum MyEnum
        {
            Mon= 0b00001001,
            Tue = 0b00000010,
            Wed = 0b00001000
        }

        static void Main()
        {
            #region LiteralsRecap

            var IntegerLiteralExample = 7; // value is 7
            var HexadecimalLiteralExample = 0x7; // value is 7
            var BinaryLiteralExample = 0b0111; // value is 7

            WriteLine(IntegerLiteralExample); // output: 7
            WriteLine(HexadecimalLiteralExample); // output: 7
            WriteLine(BinaryLiteralExample); // output: 7

            WriteLine(IntegerLiteralExample.GetType()); // output: System.Int32
            WriteLine(HexadecimalLiteralExample.GetType()); // output: System.Int32
            WriteLine(BinaryLiteralExample.GetType()); // output: System.Int32

            #endregion

            #region DataTypesCheck

            // Lets check which data types can be assigned with binary
            // https://msdn.microsoft.com/en-us/library/cs7y5x0x%28v=vs.90%29.aspx?f=255&MSPPError=-2147217396

            byte byte1 = 0b1111;
            WriteLine(byte1);
            sbyte sbyte1 = 0b1111;
            WriteLine(sbyte1);

            short short1 = 0b1111;
            WriteLine(short1);
            ushort ushort1 = 0b1111;
            WriteLine(ushort1);

            Int16 int1 = 0b1111;
            WriteLine(int1);
            Int32 int2 = 0b1111;
            WriteLine(int2);
            Int64 int3 = 0b1111;
            WriteLine(int3);
            UInt16 int4 = 0b1111;
            WriteLine(int4);
            UInt32 int5 = 0b1111;
            WriteLine(int5);
            UInt64 int6 = 0b1111;
            WriteLine(int6);

            long long1 = 0b1111;
            WriteLine(long1);
            ulong ulong1 = 0b1111;
            WriteLine(ulong1);

            float float1 = 0b1111;
            WriteLine(float1);

            double double1 = 0b1111;
            WriteLine(double1);

            decimal decimal1 = 0b1111;
            WriteLine(decimal1);

            //char char1 = 0b1111; // not possible to implicitly convert
            char char2 = (char) 0b1111;
            WriteLine(char2);

            //string str1 = 0b1111; // not possible to implicitly convert
            //string str2 = (string)0b1111; // Cannot convert type 'int' to 'string'
            string str3 = 0b1111.ToString();
            WriteLine(str3);

            //bool bool1 = 0b0001; // not possible to implicitly convert
            //bool bool2 = (bool)0b0001; // Cannot convert type 'int' to 'string'
            bool bool3 = Convert.ToBoolean(0b0001);
            WriteLine(bool3);

            object obj = 0b1111;
            WriteLine(obj);

            #endregion

            MyEnum _myEnum = MyEnum.Mon;
            _myEnum |= MyEnum.Tue;
            _myEnum |= MyEnum.Wed;
            MyEnum _MyEnum2;

            Console.WriteLine(_myEnum);
            Console.WriteLine(Convert.ToString((int)_myEnum, 2));


            var test = 0b00000010 | 0b00000100;

            var test2 = 0b00000001;
            var test3 = test2 |= 0b0000010;

            var test4 = 0b0000010;
            var test5 = test4 |= 0b00000001;

            // 1.
            // Set the first type.
            RenderType type1 = RenderType.ContentPage;

            // 2.
            // Set the second type if the condition matches.
            if (true)
            {
                type1 |= RenderType.GZip;
            }

            // 3.
            // Check the enum flags.
            Check(type1);

            // 4.
            // Set a new enum in three statements.
            RenderType type2 = RenderType.ViewPage;
            type2 |= RenderType.DataUri;
            type2 |= RenderType.GZip;

            // 5.
            // See if the enum contains this flag.
            if ((type2 & RenderType.DataUri) == RenderType.DataUri)
            {
                Console.WriteLine("True");
            }

            // 6.
            // See if the enum contains this flag.
            if ((type2 & RenderType.ContentPage) == RenderType.ContentPage)
            {
                throw new Exception();
            }

            // 7.
            // Check the enum flags.
            Check(type2);

            ReadKey();
        }

        [Flags]
        enum RenderType
        {
            None = 0x0,
            DataUri = 0x1,
            GZip = 0x2,
            ContentPage = 0x4,
            ViewPage = 0x8,
            HomePage = 0x10 // Next two values could be 0x20, 0x40
        }

        enum RenderType2
        {
            None = 0x0,
            DataUri = 0x1,
            GZip = 0x2,
            ContentPage = 0x4,
            ViewPage = 0x8,
            HomePage = 0x10 // Next two values could be 0x20, 0x40
        }

        static void Check(RenderType type)
        {
            // Switch on the flags.
            switch (type)
            {
                case RenderType.ContentPage | RenderType.DataUri | RenderType.GZip:
                {
                    Console.WriteLine("content, datauri, gzip");
                    break;
                }
                case RenderType.ContentPage | RenderType.GZip: // < first match
                {
                    Console.WriteLine("content, gzip");
                    break;
                }
                case RenderType.ContentPage:
                {
                    Console.WriteLine("content");
                    break;
                }
                case RenderType.ViewPage | RenderType.DataUri | RenderType.GZip: // < second match
                {
                    Console.WriteLine("view, datauri, gzip");
                    break;
                }
                case RenderType.ViewPage | RenderType.GZip:
                {
                    Console.WriteLine("view, gzip");
                    break;
                }
                case RenderType.ViewPage:
                {
                    Console.WriteLine("view");
                    break;
                }
                case RenderType.HomePage | RenderType.DataUri | RenderType.GZip:
                {
                    Console.WriteLine("home, datauri, gzip");
                    break;
                }
                case RenderType.HomePage | RenderType.GZip:
                {
                    Console.WriteLine("home, gzip");
                    break;
                }
                case RenderType.HomePage:
                {
                    Console.WriteLine("home");
                    break;
                }
            }
        }
    }
}
