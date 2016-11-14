using UnityEngine;
using System.Collections;

public class BoardManager : MonoBehaviour {

	private BoardPosition[,] boardPositions;
	
	void Awake()
	{
		SetupBoard(8,8);
	}

	
	public void SetupBoard(int width, int height)
	{
		boardPositions = new BoardPosition[width, height];
	}

	public void UnregisterPosition(int x, int y)
	{
		if (x > boardPositions.GetLength(0) || 0 > x || y > boardPositions.GetLength(1) || 0 > y)
		{
			Debug.LogError("Trying to unregister out of board boaunds");
			return;
		}
		if (boardPositions[x,y] ==null)
		{
			Debug.LogError("Attempting to unregister an empty location");
		}

		boardPositions[x, y] = null;
	}

	public void RegisterPosition(int x, int y, BoardPosition toRegister)
	{
		if (x > boardPositions.GetLength(0) || 0 > x || y > boardPositions.GetLength(1) || 0 > y)
		{
			Debug.LogError("Trying to register out of board boaunds");
			return;
		}

		if (boardPositions[x, y] != null)
		{
			Debug.LogError("Overriding exisiting board postion " + boardPositions[x, y].name);
		}

		boardPositions[x, y] = toRegister;
	}

}
