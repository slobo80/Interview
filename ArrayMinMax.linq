<Query Kind="Program" />

// Find the smalles and the largest elements in an array

void Main()
{
	int[] arr = new int[] { 1, 3, 2, 5, -1, -3, -7, 6 };
	var min = arr[0];
	var max = arr[0];
	var c = 0;

	for (int i = 1; i < arr.Length - 1; i++)
	{
		var diff = arr[i] - arr[i + 1];

		c++;
		if (diff > 0)
		{
			var tmpMax = arr[i];

			c++;
			if (tmpMax > max)
			{
				max = tmpMax;
			}
		}
		else
		{
			var tmpMin = arr[i];

			c++;
			if (tmpMin < min)
			{
				min = tmpMin;
			}
		}
		i++;
	}


	c++;
	if (arr[arr.Length - 1] > max)
	{
		max = arr[arr.Length - 1];
	}

	c++;
	if (arr[arr.Length - 1] < min)
	{
		min = arr[arr.Length - 1];
	}

	min.Dump("min");
	max.Dump("max");
	c.Dump("comparisons");
	arr.Length.Dump("length");
}