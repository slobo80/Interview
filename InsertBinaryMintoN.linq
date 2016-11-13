<Query Kind="Program" />

// Insert M into N at starting position i and ending at j. Both are 32 bit ints.
void Main()
{
	int N = 21;
	int M = 2;
	int j = 3.Dump("j");
	int i = 2.Dump("i");

	Convert.ToString(N, 2).Dump("N");
	Convert.ToString(M, 2).Dump("M");
	int mc = 0;

	for (int c = i; c <= j; c++)
	{

		N = UpdateBit(N, c, GetBit(M, mc++));
	}

	Convert.ToString(N, 2).Dump("Inserted");
}

public static int SetBit(int num, int bit)
{
	return (1 << bit) | num;
}

public static int ClearBit(int num, int bit)
{
	return ~(1 << bit) & num;
}

public static int GetBit(int num, int bit)
{
	return (1 << (bit)) & num;
}

public static int UpdateBit(int num, int bit, int value)
{
	int idx = GetBit(num, bit);

	if (value > 0)
	{
		return SetBit(num, bit);
	}

	return ClearBit(num, bit);
}