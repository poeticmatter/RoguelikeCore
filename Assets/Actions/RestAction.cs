using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Actor))]
public class RestAction : Action {
	public int energyGain = 1;

	override public ActionResult Perform()
	{
		GetComponent<Actor>().GainEnergy(energyGain);
		state = ActionState.FINISHED;
		Debug.Log(name + " performed rest action.");
		return ActionResult.SUCCESS;
	}
}
