<Query Kind="Program" />

// There is a point P on a plane surrounded by n number of points. 
// Write a method that returns the closest point to point P.

void Main()
{
	Point p = new Point(3, 4);
	Point[] points = new Point[] { new Point(2, 5), new Point(1, 2), new Point(5, 3), new Point(6, 6) };

	FindClosest(points, p).Dump("Closest point is ");
}

public static Point FindClosest(Point[] points, Point p)
{
	var result = points[0];
	var shortest = double.MaxValue;

	for (int i = 0; i < points.Length; i++)
	{
		var distance = p.DistanceFrom(points[i]);

		points[i].Dump();
		for (int c = 0; c < Math.Round(distance * 10, 0); c++)
		{
			Console.Write("-");
		}

		if (distance < shortest)
		{
			shortest = distance;
			result = points[i];
		}
	}

	return result;
}

public class Point
{
	public int x;
	public int y;

	public Point(int x, int y)
	{
		this.x = x;
		this.y = y;
	}

	public double DistanceFrom(Point p)
	{
		var distance = Math.Sqrt(Math.Pow(p.x - this.x, 2) + Math.Pow(p.y - this.y, 2));
		return distance;
	}
}
