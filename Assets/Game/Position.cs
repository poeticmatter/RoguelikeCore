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
		return p1._x == p2._x && p1._y == p2._y;
	}

	public static bool operator != (Position p1, Position p2)
	{
		return p1._x != p2._x || p1._y != p2._y;
	}

	public static Position operator + (Position p1, Position p2)
	{
		return new Position(p1._x + p2._x, p1._y + p2._y);
	}

}
