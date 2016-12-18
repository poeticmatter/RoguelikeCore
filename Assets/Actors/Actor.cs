using UnityEngine;
using System.Collections;

[RequireComponent(typeof(RestAction))]
[RequireComponent(typeof(BoardPosition))]
public abstract class Actor : MonoBehaviour {

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

	public void Unregister()
	{
		GameLoop.instance.UnregisterActor(this);
	}

	public bool HasEnergyToActivate(int activationCost)
	{
		return energy >= activationCost;
	}

	public void SpendEnergyForActivation(int activationCost)
	{
		energy -= activationCost;
	}

	public void GainEnergy(int amount)
	{
		energy += amount;
	}

	public Action GetRestAction()
	{
		return GetComponent<RestAction>();
	}

}
