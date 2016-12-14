using UnityEngine;
using System.Collections;

public class BoardPosition : MonoBehaviour {

	private Position _position;
	public Position Position
	{
		get { return _position; }
	}

	public int X
	{
		get { return _position.X; }
	}

	public int Y
	{
		get { return _position.Y; }
	}


	void Start ()
	{
		BoardManager.instance.RegisterPosition(this);
	}

	public void TeleportTo(int x, int y)
	{
		BoardManager.instance.UnregisterPosition(this);
		_position = new Position(x, y);
		BoardManager.instance.RegisterPosition(this);
	}

	public void MoveDirection(Direction direction)
	{
		if (!CanMoveDirection(direction))
		{
			Debug.LogError("Cannot ModeDirection");
			return;
		}
		TeleportTo(X + direction.X, Y + direction.Y);
	}

	public bool CanMoveDirection (Direction direction)
	{
		int xTo = X + direction.X;
		int yTo = Y + direction.Y;
		if (!BoardManager.instance.IsWithinBounds(xTo, yTo))
		{
			return false;
		}
		return !BoardManager.instance.IsOccupied(xTo, yTo);
	}

	public BoardPosition GetAdjacent(Direction direction)
	{
		return BoardManager.instance.GetOccupied(X + direction.X, Y + direction.Y);
	}

	public int ManhattanDistance(BoardPosition to)
	{
		return Mathf.Abs(X - to.X) + Mathf.Abs(Y - to.Y);
	}

	public bool IsAdjacent(BoardPosition to)
	{
		return ManhattanDistance(to) == 1;
    }

	public void Unregister()
	{
		BoardManager.instance.UnregisterPosition(this);
	}
}
