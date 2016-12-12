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

	public void MoveDirection(int xDirection, int yDirection)
	{
		if (!CanMoveDirection(xDirection,yDirection))
		{
			Debug.LogError("Cannot ModeDirection");
			return;
		}
		TeleportTo(xPosition + xDirection, yPosition + yDirection);
	}

	public bool CanMoveDirection (int xDirection, int yDirection)
	{
		if (Mathf.Abs(xDirection) > 1 || Mathf.Abs(yDirection) > 1)
		{
			Debug.LogError("Attempt to MoveDirection more than 1 space");
			return false;
		}
		if (Mathf.Abs(xDirection) == Mathf.Abs(yDirection))
		{
			Debug.LogError("Attempt to MoveDirection diagonally or 0/0");
			return false;
		}
		int xTo = xPosition + xDirection;
		int yTo = yPosition + yDirection;
		if (!BoardManager.instance.IsWithinBounds(xTo, yTo))
		{
			return false;
		}
		return !BoardManager.instance.IsOccupied(xTo, yTo);
	}

	public BoardPosition GetAdjacent(int xDirection, int yDirection)
	{
		return BoardManager.instance.GetOccupied(xPosition + xDirection, yPosition + yDirection);
	}

	public int ManhattanDistance(BoardPosition to)
	{
		return Mathf.Abs(xPosition - to.xPosition) + Mathf.Abs(yPosition - to.yPosition);
	}

	public bool IsAdjacent(BoardPosition to)
	{
		return ManhattanDistance(to) == 1;
    }
}
