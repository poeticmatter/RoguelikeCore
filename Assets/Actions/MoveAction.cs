using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeleeAction))]
public class MoveAction : Action {

	public int xDirection;
	public int yDirection;

	override public void Perform()
	{
		BoardPosition boardPosition = GetComponent<BoardPosition>();
		boardPosition.MoveDirection(xDirection, yDirection);
		//Temporary movement.
		transform.Translate(new Vector2(xDirection, yDirection));
		state = ActionState.FINISHED;
	}

	override public bool CanPerform()
	{
		return GetComponent<BoardPosition>().CanMoveDirection(xDirection, yDirection);
	}

	override public Action GetAlternate()
	{
		MeleeAction alternate = GetComponent<MeleeAction>();
		alternate.xDirection = xDirection;
		alternate.yDirection = yDirection;
		return alternate;
	}
}
