using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BoardManager : MonoBehaviour {

	public static BoardManager instance = null;
	private char[,] board;
	private Dictionary<Position, BoardPosition> dynamicPositions;


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
		if (dynamicPositions[toUnregister.Position] == null)
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

	public BoardPosition GetOccupied(Position position)
	{
		return dynamicPositions[position];
	}

	public bool IsOccupied(Position position)
	{
		return GetOccupied(position) != null;
	}

	public bool IsPassable(int x, int y)
	{
		return IsWithinBounds(x, y) && board[x,y] == 'p';
	}

}
