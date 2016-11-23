using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoardPosition))]
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
			Die();
		}
	}

	public void Die()
	{
		Destroy(gameObject);
		BoardManager.instance.UnregisterPosition(GetComponent<BoardPosition>());

	}
}
