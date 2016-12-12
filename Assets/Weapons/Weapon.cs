using UnityEngine;
using System.Collections;

public abstract class Weapon : MonoBehaviour {

	public int damage;
	public string weapomName;
	protected Destructible target;

	public void Target(Destructible target)
	{
		this.target = target;
	}

	abstract public bool IsTargetValid();

	abstract public void UseWeapon();
}
