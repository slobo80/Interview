<Query Kind="Program" />

// Calculates fibonacci sequence for n
void Main()
{
	var n = 16;
	var result = Fibonacci(n);
	result.Dump();
}

public int Fibonacci(int n)
{
	if (n == 0)
	{
		return 0;
	}

	if (n == 1)
	{
		return 1;
	}

	var result = Fibonacci(n - 1) + Fibonacci(n - 2);
	return result;
}