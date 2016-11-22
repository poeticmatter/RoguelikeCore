using UnityEngine;
using System.Collections;

[RequireComponent(typeof(RestAction))]
public class MeleeAction : Action {

	public int damage;

	public int xDirection;
	public int yDirection;

	override public void Perform()
	{
		BoardPosition boardPosition = GetComponent<BoardPosition>();
		BoardPosition adjacent = boardPosition.GetAdjacent(xDirection, yDirection);
		if (adjacent == null)
		{
			Debug.LogError("Nothing to attack");
			return;
		}
		Destructible target = adjacent.GetComponent<Destructible>();
		if (target == null)
		{
			Debug.LogError("Target Indestructible");
			return;
		}
		target.ApplyDamage(damage);
		state = ActionState.FINISHED;

	}

	override public bool CanPerform()
	{
		BoardPosition boardPosition = GetComponent<BoardPosition>();
		BoardPosition adjacent = boardPosition.GetAdjacent(xDirection, yDirection);
		if (adjacent == null)
		{
			return false;
		}
		Destructible target = adjacent.GetComponent<Destructible>();
		if (target == null)
		{
			return false;
		}
		return true;
	}

	override public Action GetAlternate()
	{
		return GetComponent<RestAction>();
	}
}
