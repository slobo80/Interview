<Query Kind="Program" />

void Main()
{
	int i = 20;

	var result = i << 1;
	result.Dump("Shift left == multiplies by 2");

	result = i >> 1;
	result.Dump("Shift right == divides by 2");

	Convert.ToString(i, 2).Dump("Original int to binary string");
	var mask = ~(1 << 2);
	Convert.ToString(mask,2).Dump("Mask for clering nth bit");
	result =  mask & i;
	Convert.ToString(result, 2).Dump("After clearing nth bit");
}
