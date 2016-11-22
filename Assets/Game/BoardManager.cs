using UnityEngine;
using System.Collections;

public class BoardManager : MonoBehaviour {

	public static BoardManager instance = null;
	private BoardPosition[,] boardPositions;

	void Awake()
	{
		if (instance == null) instance = this;
		else Debug.LogError("More than one GameLoop");
		SetupBoard(8,8);
	}

	
	public void SetupBoard(int width, int height)
	{
		boardPositions = new BoardPosition[width, height];
	}

	public void UnregisterPosition(int x, int y)
	{
		if (!IsWithinBounds(x, y))
		{
			Debug.LogError("Attempt to UnregisterPosition out of board boaunds");
			return;
		}
		if (!IsOccupied(x, y))
		{
			Debug.LogError("Attempt to UnregisterPosition an empty board position");
			return;
		}

		boardPositions[x, y] = null;
	}

	public void RegisterPosition(int x, int y, BoardPosition toRegister)
	{
		if (!IsWithinBounds(x, y))
		{
			Debug.LogError("Attempt to RegisterPosition out of board boaunds");
			return;
		}

		if (IsOccupied(x, y))
		{
			Debug.LogError("Attempt to RegisterPosition occupied board position " + boardPositions[x, y].name);
		}

		boardPositions[x, y] = toRegister;
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
