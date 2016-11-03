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
	stack.Push(8);
	stack.Pop().Dump("should be 8");

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
	private static Semaphore sem = new Semaphore(1, 1);

	public void Push(T item)
	{
		sem.WaitOne();
		
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
		
		sem.Release();
	}

	public T Pop()
	{
		sem.WaitOne();

		if (this.IsEmpty())
		{
			throw new Exception("Stack empty");
		}

		var value = top.value;
		top = top.prev;
		sem.Release();

		return value;
	}

	public T Peek()
	{
		sem.WaitOne();

		if (this.IsEmpty())
		{
			throw new Exception("Stack empty");
		}

		var value = top.value;
		sem.Release();
		
		return value;
	}

	public bool IsEmpty()
	{
		return top == null;
	}
}