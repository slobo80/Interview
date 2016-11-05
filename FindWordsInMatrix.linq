<Query Kind="Program" />

// There is a 3x3 matrix where each cell has a letter. Write a method that returns all the possible words.

void Main()
{
	char[][] matrix = new char[][] { 
	new char[] { 'a', 'b', 'c' },
	new char[] { 'd', 'e', 'f' },
	new char[] { 'g', 'h', 'i' } };

	FindAllWords(matrix).Dump();
}

public static List<string> FindAllWords(char[][] matrix)
{
	var root = BuildGraph(matrix).Dump();
	Console.Write(root.Edge);

	return null;
}

public static Node BuildGraph(char[][] matrix)
{
	var root = new Node(matrix[0][0], new List<Node>());
	Dictionary<string, Node> hash = new Dictionary<string, Node>();

	for (int r = 0; r < matrix.Length; r++)
	{
		for (int c = 0; c < matrix[r].Length; c++)
		{
			Node current;
			var key = Node.KeyFrom(r, c);

			if (hash.ContainsKey(key))
			{
				current = hash[key];
			}
			else
			{
				current = new Node(matrix[r][c], key);
				hash.Add(current.id, current);
			}

			if (c < matrix[c].Length - 1)
			{
				AddChild(current, hash, matrix[r][c + 1], c + 1, r);
			}

			if (r < matrix.Length - 1)
			{
				AddChild(current, hash, matrix[r + 1][c], c, r + 1);
			}

			if (r < matrix.Length - 1 && c < matrix[c].Length - 1)
			{
				AddChild(current, hash, matrix[r + 1][c + 1], c + 1, r + 1);
			}
		}
	}

	return hash[Node.KeyFrom(0, 0)];
}

public static void AddChild(Node current, Dictionary<string, Node> hash, char edge, int c, int r)
{
	Node right;
	string key = Node.KeyFrom(r, c);

	if (hash.ContainsKey(key))
	{
		right = hash[key];
	}
	else
	{
		right = new Node(edge, key);
		hash.Add(right.id, right);
	}

	current.AddChild(right);
}

public class Node
{
	public string id;
	public char Edge;
	public bool Visited = false;
	public List<Node> N = new List<Node>();

	public Node(char edge, List<Node> n)
	{
		Edge = edge;
		N = n;
		//Visited = true;
	}

	public Node(char edge, string key)
	{
		this.id = key;
		Edge = edge;
	}

	public void AddChild(Node child)
	{
		N.Add(child);
	}

	public static string KeyFrom(int c, int r)
	{
		return r.ToString() + (c + 1).ToString();
	}
}
