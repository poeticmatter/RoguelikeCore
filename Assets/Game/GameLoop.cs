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
		if (IsCurrentActionExecuting())
		{
			return;
		}
		SetFinishedActionToIdle();

		currentAction = GetCurrentActor().GetAction();
		if (currentAction == null) return; //Should only happen for player actor

		while(!currentAction.CanPerform())
		{
			currentAction = currentAction.GetAlternate();
		}
		currentAction.Perform();

		while (!GetCurrentActor().HasEnergyToActivate())
		{
			IncrementCurrentActor();
			GetCurrentActor().GainEnergy(1);
		}
		GetCurrentActor().SpendEnergyForActivation();

	}

	private bool IsCurrentActionExecuting()
	{
		if (currentAction == null) return false;
		return currentAction.state == Action.ActionState.EXECUTING;
	}

	private void SetFinishedActionToIdle()
	{
		if (currentAction!= null)
		{
			currentAction.state = Action.ActionState.IDLE;
		}
	}


}
