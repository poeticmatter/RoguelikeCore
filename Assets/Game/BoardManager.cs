using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BoardManager : MonoBehaviour {

	public static BoardManager instance = null;
	private char[,] board;
	private Dictionary<IntVector2, BoardPosition> dynamicPositions = new Dictionary<IntVector2, BoardPosition>();


	void Awake()
	{
		if (instance == null) instance = this;
		else Debug.LogError("More than one BoardManager");
		SetupBoard(8,8);
	}

	
	public void SetupBoard(int width, int height)
	{
		board = new char[width, height];
		for (int xi = 0; xi < board.GetLength(0); xi++)
		{
			for (int yi = 0; yi < board.GetLength(1); yi++)
			{
				board[xi, yi] = 'p';
			}
		}
	}

	public void UnregisterDynamicBoardPosition(BoardPosition toUnregister)
	{
		if (!dynamicPositions.ContainsKey(toUnregister.Position) || dynamicPositions[toUnregister.Position]!= toUnregister)
		{
			Debug.LogError(toUnregister.name + "is not registered at it's board position.");
			return;
		}
		dynamicPositions[toUnregister.Position] = null;
	}

	public void RegisterDynamicBoardPosition(BoardPosition toRegister)
	{
		if (!IsWithinBounds(toRegister.X, toRegister.Y))
		{
			Debug.LogError("Attempt to RegisterActor out of board boaunds");
			return;
		}

		if (IsOccupied(toRegister.Position))
		{
			Debug.LogError("Attempt to RegisterActor occupied board position " + GetOccupied(toRegister.Position).name);
			return;
		}
		dynamicPositions[toRegister.Position] = toRegister;
	}

	public bool IsWithinBounds(int x, int y)
	{
		return x >= 0 && x < board.GetLength(0) && y >= 0 && y < board.GetLength(1);
	}

	public BoardPosition GetOccupied(int x,int y)
	{
		return GetOccupied(new IntVector2(x, y));
		
	}

	public BoardPosition GetOccupied(IntVector2 position)
	{
		if (!dynamicPositions.ContainsKey(position))
		{
			return null;
		}
		return dynamicPositions[position];
	}

	public bool IsOccupied(IntVector2 position)
	{
		return GetOccupied(position) != null;
	}

	public bool IsOccupied(int x, int y)
	{
		return GetOccupied(new IntVector2(x, y));
	}

	public bool IsPassable(int x, int y)
	{
		return IsWithinBounds(x, y) && board[x,y] == 'p';
	}

	public bool IsPassable(IntVector2 position)
	{
		return IsPassable(position.X, position.Y);
	}

}
