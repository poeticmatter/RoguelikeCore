using UnityEngine;
/// <summary>
/// 2D Orthogonal direction.
/// Immutable object defining up down left or right only.
/// </summary>
public class Direction
{

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

	private Direction(int x, int y)
	{
		_x = x;
		_y = y;
	}

	public static Direction UP()
	{
		return new Direction(0, 1);
	}

	public static Direction DOWN()
	{
		return new Direction(0, -1);
	}

	public static Direction LEFT()
	{
		return new Direction(-1, 0);
	}

	public static Direction RIGHT()
	{
		return new Direction(1, 0);
	}

	public static Direction GetDirection(int xDirection, int yDirection)
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
		return new Direction(xDirection, yDirection);
	}

	override public string ToString()
	{
		return X + "," + Y;
	}
}
