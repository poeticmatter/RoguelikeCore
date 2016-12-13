using UnityEngine;
using System.Collections;

public class EnemyActor : Actor
{

	public override Action GetAction()
	{
		PlayerActor target = FindObjectOfType<PlayerActor>();
		int xDirection = Mathf.Clamp(target.BoardPosition.xPosition - BoardPosition.xPosition, -1, 1);
		if (xDirection!=0)
		{
			return GetAttackAction(Direction.GetDirection(xDirection, 0));
		}
		int yDirection = Mathf.Clamp(target.BoardPosition.yPosition - BoardPosition.yPosition, -1, 1);
		if (yDirection != 0)
		{
			return GetAttackAction(Direction.GetDirection(0, yDirection));
		}
		return GetComponent<RestAction>();
	}

}
