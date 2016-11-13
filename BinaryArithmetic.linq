<Query Kind="Program" />

void Main()
{
	int i = 0x15.Dump("Original");

	//Convert.ToString(~0, 2).Dump("All ones mask");

	var result = i << 1;
	//result.Dump("Shift left == multiplies by 2");

	result = i >> 1;
	//result.Dump("Shift right == divides by 2");

	var nth = 2;
	Convert.ToString(i, nth).Dump("Original int to binary string");
	var mask = ~(1 << nth);
	//Convert.ToString(mask, 2).Dump("Mask for clering nth bit");
	result = mask & i;
	//Convert.ToString(result, 2).Dump("After clearing nth bit");

	mask = (1 << nth) - 1;
	Convert.ToString(mask, 2).Dump("Mask for setting range from 0 to nth bit");

	// Clear range of bits from 0 to nth bit
	mask = ~((1 << nth + 1) - 1);
	//mask = (~0 << nth + 1); // another way of creating the mask
	//Convert.ToString(mask, 2).Dump("Mask for clering range from 0 to nth bit");
	result = mask & i;
	//Convert.ToString(result, 2).Dump("After clearing range 0 to nth bit");

	// Clear range of bits from nth to MSB bit
	mask = ~0 << nth;
	//mask = mask << nth;
	Convert.ToString(mask, 2).Dump("Mask for setting range from nth to MSB bit");

	//mask = (1 << nth + 1) - 1;
	mask = ~(~0 << nth + 1);
	//Convert.ToString(mask, 2).Dump("Mask for clering range from nth to MSB bit");
	result = mask & i;
	//Convert.ToString(result, 2).Dump("After clearing range from nth to MSB bit");

	mask = 1 << nth;
	result = mask & i;
	//Convert.ToString(result, 2).Dump("Getting nth bit");

	mask = 1 << nth - 1;
	result = mask | i;
	//Convert.ToString(result, 2).Dump("Setting nth bit");

	mask = ~(1 << nth);
	//mask = 1 << nth;
	//Convert.ToString(mask, 2).Dump("Mask for clearing bit");
	result = mask & i;
	//result = mask ^ i;
	//Convert.ToString(result, 2).Dump("Clear nth bit");

	result = i ^ 0x0;
	//Convert.ToString(result, 2).Dump("XOR with 0s returns i");

	result = i ^ 0x7ffff;
	//Convert.ToString(result, 2).Dump("XOR with 1s bit, returns ~i");

	result = i ^ i;
	//Convert.ToString(result, 2).Dump("XOR with itself, returns i");
}