<Query Kind="Program" />

void Main()
{
	var x = 17;
	var result = BFSSearch(BuildTree.Build(), x);
	result.Dump();
}

public Node BFSSearch(Node root, int x)
{
	var q = new Queue();
	q.Enqueue(root);

	while (q.Count > 0)
	{
		var item = q.Dequeue() as Node;
		item.value.Dump("looking at");

		if (item.value == x)
		{
			return item;
		}

		q.Enqueue(item.left);
		q.Enqueue(item.right);
	}

	return null;
}

public static class BuildTree
{
	public static Node Build()
	{
		var root = new Node(10);
		var n20 = new Node(20);
		var n19 = new Node(19);
		var n18 = new Node(18);
		var n17 = new Node(17);
		var n16 = new Node(16);
		var n15 = new Node(15);
		var n14 = new Node(14);
		var n13 = new Node(13);
		var n12 = new Node(12);
		var n11 = new Node(11);
		var n1 = new Node(1);
		var n2 = new Node(2);
		var n3 = new Node(3);
		var n4 = new Node(4);
		var n5 = new Node(5);
		var n6 = new Node(6);
		var n7 = new Node(7);
		var n8 = new Node(8);
		var n9 = new Node(9);


		root.left = n8;
		root.right = n15;
		n8.left = n4;
		n8.right = n9;
		n4.left = n2;
		n4.right = n6;
		n2.left = n1;
		n2.right = n3;
		n6.left = n5;
		n6.right = n7;

		n15.left = n12;
		n15.right = n17;
		n12.left = n11;
		n12.right = n14;
		n17.left = n16;
		n17.right = n19;
		n14.left = n13;
		n19.left = n18;
		n19.right = n20;

		return root;
	}
}

public class Node
{
	public int value;
	public Node left;
	public Node right;

	public Node(int v)
	{
		value = v;
	}
}