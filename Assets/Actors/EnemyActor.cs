using UnityEngine;
using System.Collections;

public class EnemyActor : Actor
{

	public override Action GetAction()
	{
		PlayerActor target = FindObjectOfType<PlayerActor>();
		AStar a = GetAStar(BoardPosition, target.BoardPosition);
		a.findPath();
		if (a.solution.Count > 1)
		{
			AStarNode2D node = (AStarNode2D) a.solution[1];
			Direction direction = Direction.GetDirection(node.x - BoardPosition.X, node.y - BoardPosition.Y);
			return GetAttackAction(direction);
		}
		return GetComponent<RestAction>();
	}

	private AStar GetAStar(BoardPosition from, BoardPosition to)
	{
		return new AStar(new BoardManagerAStarCost(to), from.X, from.Y, to.X, to.Y);
    }

}
