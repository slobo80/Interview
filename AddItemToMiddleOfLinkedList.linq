<Query Kind="Program" />

// Add an item to the middle of the linked list
void Main()
{
	// Item do add to the middle of the list
	var item = new Node(666);


	var head = BuildTree.Build();

	Console.WriteLine("Old list:");
	DumpList(head);

	var fast = head;
	var slow = head;

	while (fast.next != null && fast.next.next != null)
	{
		fast = fast.next.next;
		slow = slow.next;
	}

	slow.value.Dump("Middle");

	item.next = slow.next;
	slow.next = item;

	Console.WriteLine("New list:");
	DumpList(head);
}

public static void DumpList(Node head)
{
	var current = head;

	while (current != null)
	{
		Console.Write(" {0}", current.value);
		current = current.next;
	}
}

public class Node
{
	public int value;
	public Node next;

	public Node(int v)
	{
		value = v;
	}
}

public static class BuildTree
{
	public static Node Build()
	{
		var head = new Node(10);
		var n1 = new Node(1);
		var n2 = new Node(2);
		var n3 = new Node(3);
		var n4 = new Node(4);
		var n5 = new Node(5);
		var n6 = new Node(6);
		var n7 = new Node(7);
		var n8 = new Node(8);
		var n9 = new Node(9);


		head.next = n8;
		n8.next = n4;
		n4.next = n2;
		n2.next = n1;
		n1.next = n3;
		n3.next = n5;
		n5.next = n7;
		n7.next = n9;
		//		n9.next = n6;


		return head;
	}
}