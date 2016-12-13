using UnityEngine;
using System.Collections;

public class BoardManager : MonoBehaviour {

	public static BoardManager instance = null;
	private BoardPosition[,] boardPositions;

	void Awake()
	{
		if (instance == null) instance = this;
		else Debug.LogError("More than one BoardManager");
		SetupBoard(8,8);
	}

	
	public void SetupBoard(int width, int height)
	{
		boardPositions = new BoardPosition[width, height];
	}

	public void UnregisterPosition(BoardPosition toUnregister)
	{
		if (!IsWithinBounds(toUnregister.xPosition, toUnregister.yPosition))
		{
			Debug.LogError("Attempt to UnregisterPosition out of board boaunds");
			return;
		}
		if (!IsOccupied(toUnregister.xPosition, toUnregister.yPosition))
		{
			Debug.LogError("Attempt to UnregisterPosition an empty board position");
			return;
		}
		if (boardPositions[toUnregister.xPosition, toUnregister.yPosition] != toUnregister)
		{
			Debug.LogError("FATAL ERROR: Unregistering postion not occupied by the same BoardPosition component");
			return;
		}

		boardPositions[toUnregister.xPosition, toUnregister.yPosition] = null;
	}

	public void RegisterPosition(BoardPosition toRegister)
	{
		if (!IsWithinBounds(toRegister.xPosition, toRegister.yPosition))
		{
			Debug.LogError("Attempt to RegisterPosition out of board boaunds");
			return;
		}

		if (IsOccupied(toRegister.xPosition, toRegister.yPosition))
		{
			Debug.LogError("Attempt to RegisterPosition occupied board position " + boardPositions[toRegister.xPosition, toRegister.yPosition].name);
			return;
		}
		boardPositions[toRegister.xPosition, toRegister.yPosition] = toRegister;
	}

	public bool IsWithinBounds(int x, int y)
	{
		return x >= 0 && x < boardPositions.GetLength(0) && y >= 0 && y < boardPositions.GetLength(1);
	}

	public BoardPosition GetOccupied(int x, int y)
	{
		if (!IsWithinBounds(x, y))
		{
			Debug.LogError("Attempt to GetOccupied out of bounds");
			return null;
		}
		return boardPositions[x, y];
	}

	public bool IsOccupied(int x, int y)
	{
		return GetOccupied(x, y) != null;
	}

}
