using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Actor))]
[RequireComponent(typeof(RestAction))]
[RequireComponent(typeof(Weapon))]
public class AttackAction : Action {

	public IntVector2 direction;

	private Weapon weapon = null;

	override public ActionResult Perform()
	{
		if (!GetComponent<Actor>().HasEnergyToActivate(EnergyCost))
		{
			return ActionResult.FAILURE(GetComponent<RestAction>());
		}
		if (!CanPerform())
		{
			MoveAction alternate = GetMoveAction();
			//If actor has a MoveAction attached, do that instead of attack.
			//Otherwise rest.
			if (alternate == null)
			{
				return ActionResult.FAILURE(GetComponent<RestAction>());
			}

			return ActionResult.FAILURE(alternate);
		}
		state = ActionState.EXECUTING;
		return ActionResult.SUCCESS;	
	}

	void Update()
	{
		if (state == ActionState.EXECUTING)
		{
			Debug.Log(name + " performed attack action.");
			weapon.UseWeapon();
			state = ActionState.FINISHED;
		}
	}

	private bool CanPerform()
	{
		weapon = GetComponent<Weapon>();
		return weapon.AcquireTarget(direction);
	}

	protected MoveAction GetMoveAction()
	{
		MoveAction action = GetComponent<MoveAction>();
		if (action == null)
		{
			return null;
		}
		action.direction = direction;
		return action;
	}

}
