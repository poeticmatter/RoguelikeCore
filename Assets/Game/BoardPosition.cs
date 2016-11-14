using UnityEngine;
using System.Collections;

public class BoardPosition : MonoBehaviour {

	private int xPosition;
	private int yPosition;

	private BoardManager boardManager;

	void Start ()
	{
		boardManager.RegisterPosition(xPosition, yPosition, this);
	}

	public void TeleportTo(int x, int y)
	{
		boardManager.UnregisterPosition(xPosition, yPosition);
		xPosition = x;
		yPosition = y;
		boardManager.RegisterPosition(xPosition, yPosition, this);
	}
}
