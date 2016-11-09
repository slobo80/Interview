<Query Kind="Program" />

// Print matrix elements in the clockwise order
// 12345
// 67890
// 09876
// Prints: 12345 06 7890 6 789

void Main()
{
	int[][] input = new int[][] { new int[] { 1, 2, 3, 4, 5 }, new int[] { 6, 7, 8, 9, 0 }, new int[] { 0, 9, 8, 7, 6 } };
	var colC = input[0].Length;
	var rowC = input.Length;
	var startCol = 0;
	var startRow = 0;
	var endCol = colC - 1;
	var endRow = rowC - 1;

	while (startCol <= endCol && startRow <= endRow)
	{
		// Print top
		"Top".Dump();

		for (int i = startCol; i <= endCol; i++)
		{
			input[startRow][i].Dump();
		}

		startRow++;

		// Print right
		"Right".Dump();

		for (int i = startRow; i <= endRow; i++)
		{
			input[i][endCol].Dump();
		}

		endCol--;

		// Print bottom
		"Bottom".Dump();

		for (int i = endCol; i >= startCol && startRow <= endRow; i--)
		{
			input[endRow][i].Dump();
		}

		endRow--;

		// Print left
		"Left".Dump();

		for (int i = endRow; i >= startRow; i--)
		{
			input[i][startCol].Dump();
		}

		startCol++;
	}
}