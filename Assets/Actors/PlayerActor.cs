using UnityEngine;
using System.Collections;

public class PlayerActor : Actor {

	public override Action GetAction()
	{
		if (Input.GetKeyDown(KeyCode.W)) {
			return GetAttackAction(Direction.UP());
		}
		if (Input.GetKeyDown(KeyCode.A))
		{
			return GetAttackAction(Direction.LEFT());
		}
		if (Input.GetKeyDown(KeyCode.S))
		{
			return GetAttackAction(Direction.DOWN());
		}
		if (Input.GetKeyDown(KeyCode.D))
		{
			return GetAttackAction(Direction.RIGHT());
		}
		return null;

	}

	
}
