<Query Kind="Program" />

// There is a 3x3 matrix where each cell has a letter. Write a method that returns all the possible words.

void Main()
{
	char[][] matrix = new char[][] {
	new char[] { 'a', 'b', 'c' },
	new char[] { 'd', 'e', 'f' },
	new char[] { 'g', 'h', 'i' } };

	FindAllWords(matrix);
}

public static void FindAllWords(char[][] matrix)
{
	var graph = BuildGraph(matrix);
	
	foreach (var element in graph)
	{
		string cur = element.Value.Edge.ToString().Dump("Cell");
		Print(element.Value, cur, Direction.Right);
		Print(element.Value, cur, Direction.Bottom);
		Print(element.Value, cur, Direction.Diagonal);
	}
}

public static void Print(Node element, string cur, Direction dir)
{
	dir.Dump("Direction");
	var neighbor = element.N.Where(e => e.direction.Equals(dir)).FirstOrDefault();

	while (neighbor != null)
	{
		cur += neighbor.node.Edge;
		Console.WriteLine(cur);
		neighbor = neighbor.node.N.Where(e => e.direction.Equals(dir)).FirstOrDefault();
	}
}

public static Dictionary<string, Node> BuildGraph(char[][] matrix)
{
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
				current = new Node(matrix[r][c], r, c);
				hash.Add(current.id, current);
			}

			if (c < matrix[c].Length - 1)
			{
				AddNeighbor(Direction.Right, current, hash, matrix[r][c + 1], r, c + 1);
			}

			if (r < matrix.Length - 1)
			{
				AddNeighbor(Direction.Bottom, current, hash, matrix[r + 1][c], r + 1, c);
			}

			if (r < matrix.Length - 1 && c < matrix[c].Length - 1)
			{
				AddNeighbor(Direction.Diagonal, current, hash, matrix[r + 1][c + 1], r + 1, c + 1);
			}
		}
	}

	return hash;
}

public class Neighbor
{
	public Direction direction;
	public Node node;

	public Neighbor(Direction dir, Node node)
	{
		this.direction = dir;
		this.node = node;
	}
}

public class Node
{
	public string id;
	public char Edge;
	public List<Neighbor> N = new List<Neighbor>();

	public Node(char edge, int r, int c)
	{
		this.id = Node.KeyFrom(r, c);
		Edge = edge;
	}

	public void AddNeighbor(Neighbor child)
	{
		N.Add(child);
	}

	public static string KeyFrom(int c, int r)
	{
		return r.ToString() + (c).ToString();
	}
}

public static void AddNeighbor(Direction dir, Node current, Dictionary<string, Node> hash, char edge, int r, int c)
{
	Node node;
	string key = Node.KeyFrom(r, c);

	if (hash.ContainsKey(key))
	{
		node = hash[key];
	}
	else
	{
		node = new Node(edge, r, c);
		hash.Add(node.id, node);
	}

	var n = new Neighbor(dir, node);
	current.AddNeighbor(n);
}



public enum Direction
{
	Top,
	Bottom,
	Left,
	Right,
	Diagonal
}

