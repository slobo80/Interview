<Query Kind="Program" />

// Print binary representation of a number passed in as a double (e.g. 0.72) in the range 0-1. 
// If it cannot be represented accurately with 32 chars, print "error".
void Main()
{
	double x = 0.625;
	string result = string.Empty;
	int count = 1;

	while (x > 0 && count <= 32)
	{
		x = x * 2;

		if (x >= 1)
		{
			result += 1;
			x -= 1;
		}
		else
		{
			result += 0;
		}

		count++;
	}
	
	if (x > 0)
	{
		"ERROR".Dump();
		count.Dump();
	}
	else
	{
		result.Dump();
	}
}
