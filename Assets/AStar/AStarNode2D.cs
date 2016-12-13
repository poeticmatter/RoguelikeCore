using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AStarNode2D : AStarNode {
	private int _x;
	public int x { get { return _x;} }

	private int _y;
	public int y { get { return _y;} }

	private AStarCost _aStarCost;
	public bool allowDiagonal = false;

	public AStarNode2D(AStarCost aStarCost, float cost, int x, int y, AStarNode goalNode = null, AStarNode parent = null ) : base(parent, goalNode, cost){
		_x = x;
		_y = y;
		_aStarCost = aStarCost;
	}

	private void addSuccessor(List<AStarNode> successors, int x, int y) {
		float currentCost = _aStarCost.getCost(x,y,_x,_y);
		if(currentCost == -1) {
			return;
		}
		AStarNode2D newNode = new AStarNode2D(_aStarCost, cost + currentCost, x, y, goalNode, this);
		if(newNode.isSameState(parent)) {
			//Don't backtrack
			return;
		}
		successors.Add(newNode);
	}

	public override bool isSameState(AStarNode node) {
		if (node == null) {
			return false;
		}
		AStarNode2D node2d = (AStarNode2D) node;
		return node2d.x == _x && node2d.y == _y;
	}
	
	public override float calculateGoalEstimate() {
		if(goalNode != null) {
			AStarNode2D node2d = (AStarNode2D) goalNode;
			float xd = _x - node2d.x;
			float yd = _y - node2d.y;
			if (allowDiagonal) { 
			
				//"Euclidean distance" - Used when search can move at any angle.
				return Mathf.Sqrt((xd*xd) + (yd*yd));
			}
			// "Manhattan Distance" - Used when search can only move orthogonally.
			return Mathf.Abs(xd) + Mathf.Abs(yd); 
			// "Diagonal Distance" - Used when the search can move in 8 directions.
			// return Mathf.Max(Mathf.Abs(xd),Mathf.Abs(yd))*10;
		} else {
			Debug.LogError("No goal node");
			return 0;
		}
	}

	public override List<AStarNode> getSuccessors() {
		List<AStarNode> successors = new List<AStarNode>();
		int i = SpaceConstants.GRID_INCREMENT;
		addSuccessor(successors,_x-i,_y);
		addSuccessor(successors,_x  ,_y-i);
		addSuccessor(successors,_x+i,_y );
		addSuccessor(successors,_x  ,_y+i);
		if(allowDiagonal)
		{
			addSuccessor(successors,_x-i,_y-i);
			addSuccessor(successors,_x+i,_y-i);
			addSuccessor(successors,_x+i,_y+i);
			addSuccessor(successors,_x-i,_y+i);
		}
		return successors;
	}	

	public override void printNodeInfo() {
		Debug.Log(ToString());
	}

	public override string ToString() {
		return string.Format("X:\t{0}\tY:\t{1}\tCost:\t{2}\tEst:\t{3}\tTotal:\t{4}",_x,_y,cost,goalEstimate,totalCost);
	}
}
