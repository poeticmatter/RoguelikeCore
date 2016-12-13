using UnityEngine;
using System.Collections;

public class AStarCost {

	public virtual float getCost(int toX, int toY, int fromX, int fromY)
	{
		return -1;
	}
}
