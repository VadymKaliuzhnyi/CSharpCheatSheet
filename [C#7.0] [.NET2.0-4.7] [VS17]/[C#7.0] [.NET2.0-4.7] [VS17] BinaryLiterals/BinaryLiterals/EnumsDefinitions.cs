using System;

namespace BinaryLiterals
{
	// Previously if you want to use enum as a collection of flags rather than single value
	// you should:
	// 1. Put flags attribute
	// 2. Make the enum values powers of two

	[Flags]
	public enum DaysOfWeek
	{
		Monday = 1, // it's 0x01 in hex
		Tuesday = 2, // 0x02
		Wednesday = 4, // 0x04
		Thursday = 8, // 0x08
		Friday = 16, // 0x10
		Saturday = 32, // 0x20
		Sunday = 64, // 0x40
	}

	// Now with binary literals using of flagged enums have good visual representation
	// i.e. you can see shift of a digit to left (<<)
	[Flags]
	public enum DaysOfWeekWithBinary
	{
		Monday = 0b00000001, // it's 0x01 in hex and 1 in decimal
		Tuesday = 0b00000010, // 0x02 and 2
		Wednesday = 0b00000100, // 0x04 and 4
		Thursday = 0b00001000, // 0x08 and 8
		Friday = 0b00010000, // 0x10 and 16
		Saturday = 0b00100000, // 0x20 and 32
		Sunday = 0b01000000, // 0x40 and 64
	}
}
