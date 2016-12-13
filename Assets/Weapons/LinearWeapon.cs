using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(BoardPosition))]
public class LinearWeapon : Weapon
{
	public int range;

	public override bool AcquireTarget(Direction direction)
	{
		int i = 1;
		BoardPosition position = GetComponent<BoardPosition>();
		BoardPosition targetPostion = null;
        while (targetPostion == null && i <= range)
		{
			targetPostion = BoardManager.instance.GetOccupied(position.xPosition + direction.X*i, position.yPosition + direction.Y*i);
			i++;
			
		}
		if (targetPostion == null)
		{
			Debug.Log("Nothing in that direction.");
			return false;
		}
		target = targetPostion.GetComponent<Destructible>();
		if (target == null)
		{
			Debug.Log("Something indestructible in the way.");
			return false;
		}
		return true;
	}

	public override void UseWeapon()
	{
		target.ApplyDamage(damage);
	}
}
