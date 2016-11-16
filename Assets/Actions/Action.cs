using UnityEngine;
using System.Collections;

public class Action : MonoBehaviour {
	public enum ActionState { IDLE, EXECUTING, FINISHED };
	public ActionState state = ActionState.IDLE;

	virtual public void Perform()
	{
		//Default action, do nothing.
		Debug.Log("Performed default action.");
		state = ActionState.FINISHED;
	}

	virtual public bool CanPerform()
	{
		return true;
	}

	virtual public Action GetAlternate()
	{
		return null; //Not needed, as can always perform.
	}
}
