using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameLoop : MonoBehaviour {


	public static GameLoop instance = null;
	void Awake()
	{
		if (instance == null) instance = this;
		else Debug.LogError("More than one GameLoop");
	}


	private List<Actor> actors = new List<Actor>();
	private int currentActor = 0;
	private Action currentAction = null;

	public void RegisterActor(Actor actor)
	{
		actors.Add(actor);
	}

	public void UnregisterActor(Actor actor)
	{
		int index = actors.IndexOf(actor);
		if (index < currentActor) index--;
		actors.RemoveAt(index);
	}

	private void IncrementCurrentActor()
	{
		currentActor = (currentActor + 1) % actors.Count;
	}

	private Actor GetCurrentActor()
	{
		return actors[currentActor];
	}
	
	void Update () {

		Loop();
	}

	private void Loop()
	{
		UpdateActionIfFinished();
		while (currentAction == null || !currentAction.CanPerform())
		{
			currentAction = GetCurrentActor().GetAction();
			if (currentAction == null) return;
			
		}
		currentAction.Perform();
	}

	private void UpdateActionIfFinished()
	{
		if (currentAction == null) return;
		if (currentAction.state == Action.ActionState.EXECUTING) return;
		currentAction.state = Action.ActionState.IDLE;
		currentAction = null;
	}


}
