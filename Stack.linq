<Query Kind="Program" />

void Main()
{
	var stack = new StackX<int>();
	stack.Push(1);
	stack.Push(3);
	stack.Push(5);
	stack.Push(7);
	stack.Pop().Dump("should be 7");
	stack.Peek().Dump("should be 5");
	stack.Pop().Dump("should be 5");
	stack.Pop().Dump("should be 3");
	stack.Pop().Dump("should be 1");
 }

public class StackX<T>
{
	class Item<D>
	{
		public D value;
		public Item<D> prev;

		public Item(D value)
		{
			this.value = value;
		}
	}

	private Item<T> top;

	public void Push(T item)
	{
		if (top == null)
		{
			top = new Item<T>(item);
		}
		else
		{
			var newItem = new Item<T>(item);
			newItem.prev = top;
			top = newItem;
		}
	}

	public T Pop()
	{
		if (this.IsEmpty())
		{
			throw new Exception("Stack empty");
		}

		var value = top.value;
		top = top.prev;
		return value;
	}

	public T Peek()
	{
		if (this.IsEmpty())
		{
			throw new Exception("Stack empty");
		}

		return top.value;
	}

	public bool IsEmpty()
	{
		return top == null;
	}
}