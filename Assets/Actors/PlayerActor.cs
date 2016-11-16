using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MoveAction))]
public class PlayerActor : Actor {

	public override Action GetAction()
	{
		if (Input.GetKeyDown(KeyCode.W)) {
			return GetMoveAction(0, 1);
		}
		if (Input.GetKeyDown(KeyCode.A))
		{
			return GetMoveAction(-1, 0);
		}
		if (Input.GetKeyDown(KeyCode.S))
		{
			return GetMoveAction(0, -1);
		}
		if (Input.GetKeyDown(KeyCode.D))
		{
			return GetMoveAction(1, 0);
		}
		return null;

	}

	private Action GetMoveAction(int xDirection, int yDirection)
	{
		MoveAction action = GetComponent<MoveAction>();
		action.xDirection = xDirection;
		action.yDirection = yDirection;
		return action;
	}
}
