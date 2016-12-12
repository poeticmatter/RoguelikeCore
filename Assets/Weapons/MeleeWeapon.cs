using UnityEngine;
using System.Collections;

public class MeleeWeapon : Weapon
{
	
	public override bool IsTargetValid()
	{
		return target != null && GetComponent<BoardPosition>().IsAdjacent(target.GetComponent<BoardPosition>());
	}

	public override void UseWeapon()
	{
		target.ApplyDamage(damage);
	}
}
