<Query Kind="Program" />

// 	Write a method that takes a number and returns the number of binary ones. How would you optimize it?
void Main()
{
	uint value = 123;
	get(value).Dump(Convert.ToString(value, 2));
}

public int get(uint input)
{
	var c = 0;
	var a = input;

	while (a > 0)
	{
		if ((0x1 & a) == 1)
		{
			c++;
		}

		a = a >> 1;
	}

	return c;
}
