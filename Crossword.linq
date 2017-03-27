<Query Kind="Program" />

// Given a crossword puzzle like matrix. Print all possible words. 
// Valid words are along horizontal, vertical and diagonal axis and they must flow from top to bottom.
void Main()
{
	var matrix = new char[][] {
		new char[]{ 'A', 'B', 'C', 'D' },
		new char[]{ 'E', 'F', 'G', 'H' },
		new char[]{ 'I', 'J', 'K', 'L' },
	};

	var root = BuildGraph(matrix);
	TraverseGraph(root);
}

public class Node
{
	public char Value;
	public Node East;
	public Node SEast;
	public Node Sout;
	public Node SWest;
}

private void VisitNbs(char[][] matrix, int row, int col, Dictionary<char, Node> visited, Node current)
{
	// w: row, col-1
	Node visitedNode;

	if (TryGetVisitedNode(matrix, row, col - 1, visited, out visitedNode))
	{
		visitedNode.East = current;
	}

	//	AddVisited(matrix, row, col - 1, visited, current);

	// nw: row-1, col-1
	if (TryGetVisitedNode(matrix, row - 1, col - 1, visited, out visitedNode))
	{
		visitedNode.SEast = current;
	}
	//	AddVisited(matrix, row - 1, col - 1, visited, current);

	// n: row-1, col
	if (TryGetVisitedNode(matrix, row - 1, col, visited, out visitedNode))
	{
		visitedNode.Sout = current;
	}
	//	AddVisited(matrix, row - 1, col, visited, current);

	// ne: row-1, col+1
	if (TryGetVisitedNode(matrix, row - 1, col + 1, visited, out visitedNode))
	{
		visitedNode.SWest = current;
	}
	//AddVisited(matrix, row - 1, col + 1, visited, current);
}

private bool TryGetVisitedNode(char[][] matrix, int row, int col, Dictionary<char, Node> visited, out Node visitedNode)
{
	if (row < 0 || col < 0 || row >= matrix.Length || col >= matrix[0].Length)
	{
		visitedNode = null;
		return false;
	}

	char nodeKey = matrix[row][col];
	visitedNode = visited[nodeKey];
	//visitedNode.Nb.Add(current);
	return true;
}

private Node BuildGraph(char[][] matrix)
{
	DumpMatrix(matrix);

	//	var root = new Node { Value = matrix[0][0] };
	var visited = new Dictionary<char, Node>();

	for (int row = 0; row < matrix.Length; row++)
	{
		for (int col = 0; col < matrix[row].Length; col++)
		{
			// Create new node
			var node = new Node { Value = matrix[row][col] };
			visited.Add(node.Value, node);
			VisitNbs(matrix, row, col, visited, node);
		}
	}

	return visited[matrix[0][0]];
}

private void GoEast(Queue<Node> visited, Node visiting, List<char> word)
{
	if (visiting == null)
	{
		return;
	}

	var nb = visiting.East;
	if (nb != null)
	{
		if (!visited.Contains(nb))
		{
			visited.Enqueue(nb);
		}
		word.Add(nb.Value);
		string.Concat(word).Dump();
		GoEast(visited, nb, word);
	}
}

private void TraverseGraph(Node root)
{
	Queue<Node> visited = new Queue<Node>();
	visited.Enqueue(root);

	while (visited.Count > 0)
	{
		var visiting = visited.Dequeue();
		visiting.Value.Dump();
		GoEast(visited, visiting, new List<char> { visiting.Value });

	}


	//	GoSout();
	//	GoSEast();
	//	GoSWest();


}

private void DumpMatrix(char[][] matrix)
{

	for (int row = 0; row < matrix.Length; row++)
	{
		for (int col = 0; col < matrix[row].Length; col++)
		{
			Console.Write(matrix[row][col]);
		}
		Console.WriteLine("");
	}
}