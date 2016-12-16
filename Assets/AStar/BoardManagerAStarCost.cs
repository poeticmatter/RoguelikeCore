using UnityEngine;
using System.Collections;

public class BoardManagerAStarCost : AStarCost
{

	private BoardPosition target;

	public BoardManagerAStarCost (BoardPosition target)
	{
		this.target = target;
	}


	public override float getCost(int toX, int toY, int fromX, int fromY)
	{
		if (toX != fromX && toY != fromY)
		{
			//Diagonal, so check if can move in both orthogonal directions.
			if (isPassable(toX, fromY, fromX, fromY) && isPassable(fromX, toY, fromX, fromY))
			{
				return SpaceConstants.GRID_DIAG;
			}
		}
		else if (isPassable(toX, toY, fromX, fromY))
		{
			return 1;
		}
		return -1;
	}

	private bool isPassable(int toX, int toY, int fromX, int fromY)
	{
		if (!BoardManager.instance.IsWithinBounds(toX, toY))
		{
			return false;
		}
		if (BoardManager.instance.IsPassable(toX, toY))
		{
			return true;
		}
		return target.Equals(BoardManager.instance.GetOccupied(new IntVector2(toX,toY)));
    }
}
