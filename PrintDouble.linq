<Query Kind="Program" />

// Print binary representation of a number passed in as a double (e.g. 0.72) in the range 0-1. 
// If it cannot be represented accurately with 32 chars, print "error".
void Main()
{
	double x = 0.72;
	string result = string.Empty;

	while (x > 0 && (result.Length <= 32))
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
	}
	
	if (x > 0)
	{
		"ERROR".Dump();
	}
	else
	{
		result.Dump();
	}
}
