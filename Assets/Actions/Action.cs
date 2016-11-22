using UnityEngine;
using System.Collections;

public abstract class Action : MonoBehaviour {
	public enum ActionState { IDLE, EXECUTING, FINISHED };
	public ActionState state = ActionState.IDLE;

	abstract public void Perform();

	abstract public bool CanPerform();

	abstract public Action GetAlternate();
}
