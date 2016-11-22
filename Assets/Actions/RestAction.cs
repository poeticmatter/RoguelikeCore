using UnityEngine;
using System.Collections;

public class RestAction : Action {

	override public void Perform()
	{
		//Default action, do nothing.
		Debug.Log("Performed default action.");
		state = ActionState.FINISHED;
	}

	override public bool CanPerform()
	{
		return true;
	}

	override public Action GetAlternate()
	{
		return null; //Not needed, as can always perform.
	}
}
