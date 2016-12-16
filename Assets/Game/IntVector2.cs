using UnityEngine;
/// <summary>
/// Immutable IntVector2
/// </summary>
[System.Serializable]
public class IntVector2 {
	[SerializeField]
	private int _x;
	public int X
	{
		get { return _x; }
	}
	[SerializeField]
	private int _y;
	public int Y
	{
		get { return _y; }
	}
	public IntVector2(int x, int y)
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
		if (!(obj is IntVector2))
		{
			return false;
		}
		IntVector2 other = (IntVector2)obj;
		return other.X == _x && other.Y == _y;
	}

	public override int GetHashCode()
	{
		return _x * 31 + _y;
	}

	public static bool operator == (IntVector2 p1, IntVector2 p2)
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

	public static bool operator != (IntVector2 p1, IntVector2 p2)
	{
		return !(p1 == p2);
	}

	public static IntVector2 operator + (IntVector2 p1, IntVector2 p2)
	{
		return new IntVector2(p1._x + p2._x, p1._y + p2._y);
	}

	public static IntVector2 operator - (IntVector2 p1, IntVector2 p2)
	{
		return new IntVector2(p1._x - p2._x, p1._y - p2._y);
	}

	public static IntVector2 UP = new IntVector2(0, 1);

	public static IntVector2 DOWN = new IntVector2(0, -1);

	public static IntVector2 LEFT = new IntVector2(-1, 0);

	public static IntVector2 RIGHT = new IntVector2(1, 0);

	public static IntVector2 GetDirection(int xDirection, int yDirection)
	{
		if (Mathf.Abs(xDirection) > 1 || Mathf.Abs(yDirection) > 1)
		{
			Debug.LogError("Direction cannot be greater than 1");
			return null;
		}
		if (Mathf.Abs(xDirection) == Mathf.Abs(yDirection))
		{
			Debug.LogError("Direction cannot be diagonnal or 0/0 " + xDirection + "," + yDirection);
			return null;
		}
		return new IntVector2(xDirection, yDirection);
	}

}
