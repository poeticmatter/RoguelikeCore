using UnityEngine;
using System.Collections;

[RequireComponent(typeof(RestAction))]
public class MoveAction : Action {

	public Direction direction;

	override public void Perform()
	{
		BoardPosition boardPosition = GetComponent<BoardPosition>();
		boardPosition.MoveDirection(direction);
		//Temporary movement.
		transform.Translate(new Vector2(direction.X, direction.Y));
		state = ActionState.FINISHED;
	}

	override public bool CanPerform()
	{
		return GetComponent<BoardPosition>().CanMoveDirection(direction);
	}

	override public Action GetAlternate()
	{
		return GetComponent<RestAction>();
	}
}
