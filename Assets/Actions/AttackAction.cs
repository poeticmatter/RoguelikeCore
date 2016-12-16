using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MoveAction))]
public class AttackAction : Action {

	public IntVector2 direction;

	private Weapon weapon = null;

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
		state = ActionState.FINISHED;
	}

	override public bool CanPerform()
	{
		weapon = GetComponent<Weapon>();
		if (weapon == null)
		{
			Debug.Log("No weapon");
			return false;
		}

		return weapon.AcquireTarget(direction);
	}

	override public Action GetAlternate()
	{
		MoveAction alternate = GetComponent<MoveAction>();
		alternate.direction = direction;
		return alternate;
	}
}
