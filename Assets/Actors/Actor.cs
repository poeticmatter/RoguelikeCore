using UnityEngine;
using System.Collections;

[RequireComponent(typeof(RestAction))]
[RequireComponent(typeof(MoveAction))]
[RequireComponent(typeof(BoardPosition))]
public abstract class Actor : MonoBehaviour {

	private BoardPosition boardPosition = null;
	public BoardPosition BoardPosition
	{
		get {
			if (boardPosition == null)
			{
				boardPosition = GetComponent<BoardPosition>();
			}
			return boardPosition;
		}
	}

	void Start () {
		GameLoop.instance.RegisterActor(this);
	}


	abstract public Action GetAction();

	protected Action GetMoveAction(int xDirection, int yDirection)
	{
		MoveAction action = GetComponent<MoveAction>();
		action.xDirection = xDirection;
		action.yDirection = yDirection;
		return action;
	}

	public void Unregister()
	{
		GameLoop.instance.UnregisterActor(this);
	}

}
