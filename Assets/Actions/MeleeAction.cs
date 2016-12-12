using UnityEngine;
using System.Collections;

[RequireComponent(typeof(RestAction))]
public class MeleeAction : Action {

	public int damage;

	public int xDirection;
	public int yDirection;

	private Destructible target = null;
	private MeleeWeapon weapon = null;

	override public void Perform()
	{
		state = ActionState.EXECUTING;
		if (!CanPerform())
		{
			Debug.LogError("Atempting to perform a melee action that cannot be performed");
			state = ActionState.FINISHED;
			return;
		}
		weapon.UseWeapon();
	}

	override public bool CanPerform()
	{
		weapon = GetComponent<MeleeWeapon>();
		if (weapon == null)
		{
			Debug.Log("No weapon");
			return false;
		}
		BoardPosition adjacent = BoardPosition.GetAdjacent(xDirection, yDirection);
		if (adjacent == null)
		{
			Debug.Log("Nothing in that direction");
			return false;
		}
		target = adjacent.GetComponent<Destructible>();
		if (target == null)
		{
			Debug.Log("Target Indestructible");
			return false;
		}
		weapon.Target(target);
		return weapon.IsTargetValid();
	}

	override public Action GetAlternate()
	{
		return GetComponent<RestAction>();
	}
}
