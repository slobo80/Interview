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

	int result1 = InsertInPlace(i, j, N, M);
	int result2 = InsertIteratively(i, j, N, M);
	result1.Equals(result2).Dump("Results are equal?");
	Convert.ToString(result1, 2).Dump("Inserted");
}

public int InsertInPlace(int i, int j, int N, int M)
{
	int allOnes = ~0;
	int rightMask = allOnes << j + 1;
	int leftMask = (1 << i) - 1;
	int mask = rightMask | leftMask;
	Convert.ToString(rightMask, 2).Dump("right mask");
	Convert.ToString(leftMask, 2).Dump("left mask");
	Convert.ToString(mask, 2).Dump("mask");
	
	N = N & mask; // Clear bit range 
	M = M << i; // Shift M into the range position

	return N | M;
}

public int InsertIteratively(int i, int j, int N, int M)
{
	int mc = 0;

	for (int c = i; c <= j; c++)
	{

		N = UpdateBit(N, c, GetBit(M, mc++));
	}

	return N;
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