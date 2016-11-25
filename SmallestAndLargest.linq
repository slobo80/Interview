<Query Kind="Program" />

// Given a positive int, print the next smallest and largest number that has the same number of 1 bits 
// in their binary representation.
void Main()
{
	int num = 7.Dump();
	Convert.ToString(num, 2).Dump("Original");
	int count = GetCount();

	int largest = (1 << (31 - count)) - 1;
	Convert.ToString(largest, 2).Dump("Largest");
	Convert.ToString(largest, 10).Dump("Largest");

	int smallest = (1 << count) - 1;
	Convert.ToString(smallest, 2).Dump("Smallest");
	Convert.ToString(smallest, 10).Dump("Smallest");

}

public static int GetCount()
{
	return 3;
}