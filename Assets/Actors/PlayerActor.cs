using UnityEngine;
using System.Collections;

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

	
}
