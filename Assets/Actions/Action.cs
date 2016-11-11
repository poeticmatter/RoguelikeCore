using UnityEngine;
using System.Collections;

public class Action : MonoBehaviour {
	public enum ActionState { IDLE, EXECUTING, FINISHED };
	public ActionState state = ActionState.IDLE;

	virtual public void Perform()
	{

	}

	virtual public bool CanPerform()
	{
		return false;
	}
}
