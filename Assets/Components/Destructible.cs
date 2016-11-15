using UnityEngine;
using System.Collections;

public class Destructible : MonoBehaviour {

	public int startingHP;
	private int currentHP;

	void Awkake ()
	{
		currentHP = startingHP;
	}

	public void ApplyDamage(int damage)
	{
		currentHP -= damage;
		if (currentHP <= 0)
		{
			Destroy(gameObject);
		}
	}	
}
