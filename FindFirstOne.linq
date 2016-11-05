<Query Kind="Program" />

// You have a sorted array consisting of zeroes and ones where all the zeroes are on the left and all the ones are on the right. 
// Write a method that returns the position of the first one.

void Main()
{
	//int[] arr = null; // -1
	//int[] arr = new int[] { }; // -1
	//int[] arr = new int[] { 0 }; // -1
	//int[] arr = new int[] { 1 }; // 0
	//int[] arr = new int[] { 1, 1 }; // 0
	//int[] arr = new int[] { 0, 0, 1, 1 }; // 2
	//int[] arr = new int[] { 0, 0, 0, 1, 1, 1 }; // 3
	//int[] arr = new int[] { 0, 0, 0, 0, 1, 1, 1, 1 }; // 4

	var iter = FindIdxIteratively(arr).Dump("Iteratively");
	var rec = FindIdxRecursively(arr).Dump("Recursively");
	(iter == rec).Dump("Both match");
}

public int FindIdxRecursively(int[] arr)
{
	if (arr == null || arr.Length == 0)
	{
		return -1;
	}

	if (arr[arr.Length - 1] == 0)
	{
		return -1;
	}

	if (arr[0] == 1)
	{
		return 0;
	}

	return Recurse(arr, 0, arr.Length - 1);
}

public int Recurse(int[] arr, int left, int right)
{
	if (left > right)
	{
		return left;
	}

	int mid = (right - left) / 2 + left;

	if (arr[mid] == 0)
	{
		return Recurse(arr, mid + 1, right);
	}
	else
	{
		return Recurse(arr, left, mid - 1);
	}
}

public int FindIdxIteratively(int[] arr)
{
	if (arr == null || arr.Length == 0)
	{
		return -1;
	}

	if (arr[arr.Length - 1] == 0)
	{
		return -1;
	}

	if (arr[0] == 1)
	{
		return 0;
	}

	int right = arr.Length - 1;
	int left = 0;

	while (left < right)
	{
		var mid = (right - left) / 2 + left;

		if (arr[mid] == 0)
		{
			// go right
			left = mid + 1;
		}
		else
		{
			// go left
			right = mid - 1;
		}

		Console.WriteLine("left: {0}, mid: {1}, right: {2}", left, mid, right);
	}

	return left;
}