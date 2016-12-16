using UnityEngine;
using System.Collections;

public class PlayerActor : Actor {

	public override Action GetAction()
	{
		if (Input.GetKeyDown(KeyCode.W)) {
			return GetAttackAction(IntVector2.UP);
		}
		if (Input.GetKeyDown(KeyCode.A))
		{
			return GetAttackAction(IntVector2.LEFT);
		}
		if (Input.GetKeyDown(KeyCode.S))
		{
			return GetAttackAction(IntVector2.DOWN);
		}
		if (Input.GetKeyDown(KeyCode.D))
		{
			return GetAttackAction(IntVector2.RIGHT);
		}
		return null;

	}

	
}
