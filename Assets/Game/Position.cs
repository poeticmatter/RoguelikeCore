/// <summary>
/// Immutable position
/// </summary>
public class Position {
	private int _x;
	public int X
	{
		get { return _x; }
	}

	private int _y;
	public int Y
	{
		get { return _y; }
	}
	public Position (int x, int y)
	{
		_x = x;
		_y = y;
	}

	public override bool Equals(object obj)
	{
		if (ReferenceEquals(this, obj))
		{
			return true;
		}
		if (obj == null)
		{
			return false;
		}
		if (!(obj is Position))
		{
			return false;
		}
		Position other = (Position)obj;
		return other.X == _x && other.Y == _y;
	}

	public override int GetHashCode()
	{
		return _x * 31 + _y;
	}

	public static bool operator == (Position p1, Position p2)
	{
		if (ReferenceEquals(p1, p2))
		{
			return true;
		}
		if (p1 == null || p2 == null)
		{
			return false;
		}
		return p1.Equals(p2);
	}

	public static bool operator != (Position p1, Position p2)
	{
		return !(p1 == p2);
	}

	public static Position operator + (Position p1, Position p2)
	{
		return new Position(p1._x + p2._x, p1._y + p2._y);
	}

	public static Position operator - (Position p1, Position p2)
	{
		return new Position(p1._x - p2._x, p1._y - p2._y);
	}

}
