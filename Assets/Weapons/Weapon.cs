using UnityEngine;
using System.Collections;

public abstract class Weapon : MonoBehaviour {

	public int damage;
	public string weapomName;
	protected Destructible target;

	abstract public void UseWeapon();

	abstract public bool AcquireTarget(Direction direction);
}
