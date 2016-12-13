using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class AStarNode : IComparable {
	private AStarNode _parent;
	public AStarNode parent { get {return _parent;}	set {_parent = value;} }

	private float _cost;
	public float cost { get { return _cost;} set { _cost = value;} }

	private AStarNode _goalNode;
	public AStarNode goalNode { get { return _goalNode;} set { _goalNode = value;} }
	
	public float goalEstimate {
		get {
			return calculateGoalEstimate ();
		}
	}
	
	public float totalCost {
		get {
			return(cost + goalEstimate);
		}
	}
	
	public AStarNode (AStarNode parent, AStarNode goalNode, float cost) {
		_parent = parent;
		_cost = cost;
		_goalNode = goalNode;
	}
	
	public bool isGoal () {
		return isSameState (_goalNode);
	}

	public virtual bool isSameState (AStarNode node) {
		return false;
	}

	public virtual float calculateGoalEstimate () {
		return 0.0f;
	}

	public virtual List<AStarNode> getSuccessors (){
		return new List<AStarNode>();
	}

	public virtual void printNodeInfo (){}

	public override bool Equals (object obj) {
		return isSameState ((AStarNode)obj);
	}
	
	public override int GetHashCode () {
		return base.GetHashCode ();
	}

	public int CompareTo (object obj) {
		return -totalCost.CompareTo(((AStarNode)obj).totalCost);
	}	
}