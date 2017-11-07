using System;
using static System.Console;

namespace BinaryLiterals
{
	partial class Program
	{
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

			WriteLine();

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

			WriteLine();
			#endregion

			#region BinaryLiteralsAndEnums
			DaysOfWeek d = DaysOfWeek.Monday; // assign initial value
			d |= DaysOfWeek.Wednesday; // + additional flag
			d |= DaysOfWeek.Sunday; // + one more flag
			WriteLine(d); // Monday, Wednesday, Sunday

			DaysOfWeekWithBinary d2 = DaysOfWeekWithBinary.Monday;
			d2 |= DaysOfWeekWithBinary.Wednesday;
			d2 |= DaysOfWeekWithBinary.Sunday;
			WriteLine(d); // Monday, Wednesday, Sunday
			#endregion

			ReadKey();
		}

	}
}