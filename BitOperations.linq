<Query Kind="Program" />

void Main()
{
	const int num = 21;
	Convert.ToString(num, 2).Dump("Original");
	var result = SetBit(num, 1);
	Convert.ToString(result, 2).Dump("Set bit 1");
	result = GetBit(num, 2);
	Convert.ToString(result, 2).Dump("Get bit 2");
	result = ClearBit(num, 2);
	Convert.ToString(result, 2).Dump("Clear bit 2");
	result = UpdateBit(num, 2, 0);
	Convert.ToString(result, 2).Dump("Update bit 2 to 0");
	result = UpdateBit(num, 1, 1);
	Convert.ToString(result, 2).Dump("Update bit 1 to 1");
}

public int SetBit(int num, int bit)
{
	return (1 << bit) | num;
}

public int ClearBit(int num, int bit)
{
	return ~(1 << bit) & num;
}

public int GetBit(int num, int bit)
{
	return (1 << (bit)) & num;
}

public int UpdateBit(int num, int bit, int value)
{
	int idx = GetBit(num, bit);

	if (value > 0)
	{
		return SetBit(num, bit);
	}

	return ClearBit(num, bit);
}
