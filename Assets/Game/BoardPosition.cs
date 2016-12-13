using UnityEngine;
using System.Collections;

public class BoardPosition : MonoBehaviour {

	public int xPosition;
	public int yPosition;


	void Start ()
	{
		BoardManager.instance.RegisterPosition(this);
	}

	public void TeleportTo(int x, int y)
	{
		BoardManager.instance.UnregisterPosition(this);
		xPosition = x;
		yPosition = y;
		BoardManager.instance.RegisterPosition(this);
	}

	public void MoveDirection(Direction direction)
	{
		if (!CanMoveDirection(direction))
		{
			Debug.LogError("Cannot ModeDirection");
			return;
		}
		TeleportTo(xPosition + direction.X, yPosition + direction.Y);
	}

	public bool CanMoveDirection (Direction direction)
	{
		int xTo = xPosition + direction.X;
		int yTo = yPosition + direction.Y;
		if (!BoardManager.instance.IsWithinBounds(xTo, yTo))
		{
			return false;
		}
		return !BoardManager.instance.IsOccupied(xTo, yTo);
	}

	public BoardPosition GetAdjacent(Direction direction)
	{
		return BoardManager.instance.GetOccupied(xPosition + direction.X, yPosition + direction.Y);
	}

	public int ManhattanDistance(BoardPosition to)
	{
		return Mathf.Abs(xPosition - to.xPosition) + Mathf.Abs(yPosition - to.yPosition);
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
