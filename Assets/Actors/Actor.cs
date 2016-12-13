using UnityEngine;
using System.Collections;

[RequireComponent(typeof(RestAction))]
[RequireComponent(typeof(MoveAction))]
[RequireComponent(typeof(BoardPosition))]
public abstract class Actor : MonoBehaviour {

	public int activationCost;
	private int energy = 0;

	private BoardPosition boardPosition = null;
	public BoardPosition BoardPosition
	{
		get {
			if (boardPosition == null)
			{
				boardPosition = GetComponent<BoardPosition>();
			}
			return boardPosition;
		}
	}

	void Start () {
		GameLoop.instance.RegisterActor(this);
	}


	abstract public Action GetAction();

	protected Action GetMoveAction(Direction direction)
	{
		MoveAction action = GetComponent<MoveAction>();
		action.direction = direction;
		return action;
	}

	protected Action GetAttackAction(Direction direction)
	{
		AttackAction action = GetComponent<AttackAction>();
		action.direction = direction;
		return action;
	}

	public void Unregister()
	{
		GameLoop.instance.UnregisterActor(this);
	}

	public bool HasEnergyToActivate()
	{
		return energy >= activationCost;
	}

	public void SpendEnergyForActivation()
	{
		energy -= activationCost;
	}

	public void GainEnergy(int amount)
	{
		energy += amount;
	}

}
