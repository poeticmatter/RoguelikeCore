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
		if (index < currentActor) currentActor--;
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
		if (currentAction != null)
		{
			if (currentAction.state == Action.ActionState.EXECUTING)
			{
				return;
			}
			ResetCurrentAction();
			IncrementCurrentActor();
		}
		PerformAction();
	}

	private void PerformAction ()
	{
		currentAction = GetCurrentActor().GetAction();
		if (currentAction == null) return; //Should only happen for player actor

		while (true)
		{
			ActionResult result = currentAction.Perform();
			if (result.Succeeded)
			{
				if (!GetCurrentActor().HasEnergyToActivate(currentAction.EnergyCost))
				{
					Debug.LogError(currentAction +  "Perform should check if actor has sufficient energy, and return an alternate if it does not. Defaulting to rest action.");
					currentAction = GetCurrentActor().GetRestAction();

				}
				GetCurrentActor().SpendEnergyForActivation(currentAction.EnergyCost);
				break;
			}
			currentAction = result.Alternate;
		}
	}

	private void ResetCurrentAction()
	{
		currentAction.state = Action.ActionState.IDLE;
	}
}
