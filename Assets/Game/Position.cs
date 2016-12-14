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

}
