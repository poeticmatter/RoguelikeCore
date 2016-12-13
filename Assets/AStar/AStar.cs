using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Tanis.Collections;

//Modified by www.timeshapers.com
//Original version of http://www.codeproject.com/Articles/5758/Path-finding-in-C

public sealed class AStar {
	
	private Heap openList;
	private Heap closedList;
	private List<AStarNode> successors;

	private List<AStarNode> _solution;
	public List<AStarNode> solution {
		get {
			return _solution;
		}
	}

	private AStarNode2D startNode;
	
	public AStar (AStarCost aStarCost, int fromX, int fromY, int toX, int toY)	{
		openList = new Heap();
		closedList = new Heap();
		_solution = new List<AStarNode>();
		AStarNode2D goalNode = new AStarNode2D(aStarCost, 0, toX, toY);
		startNode = new AStarNode2D(aStarCost, 0, fromX, fromY, goalNode);
	}
	
	private void printNodeList (List<AStarNode> nodes) {
		Console.WriteLine ("Node list:");
		foreach (AStarNode n in nodes) {
			n.printNodeInfo ();
		}
		Debug.Log("=====");
	}
	public void findPath () {
		openList.Add (startNode);
		while (openList.Count > 0) {
			AStarNode current = (AStarNode)openList.Pop();
			if (current.isGoal()) {
				recordSolution(current);
				break;					
			}
			processSuccessors(current.getSuccessors());
			closedList.Add (current);
		}
	}

	private void processSuccessors(List<AStarNode> successors) {
		foreach (AStarNode successor in successors) {
			
			AStarNode nodeOpen = getFromHeap(successor, openList);
			if (successorWorseThanExisting(successor, nodeOpen)) {
				continue; //Throw away
			}
			
			AStarNode nodeClosed = getFromHeap(successor, closedList);
			if (successorWorseThanExisting(successor, nodeClosed)) {
				continue; //Throw away
			}
			
			openList.Remove (nodeOpen);
			
			closedList.Remove (nodeClosed);
			
			openList.Add (successor);
		}
	}

	private void recordSolution (AStarNode current) {
		while (current != null) {
			_solution.Insert (0, current);
			current = current.parent;
		}
	}

	private AStarNode getFromHeap(AStarNode node, Heap list) {
		object o = list.getExisting(node);
		return o == null ? null : (AStarNode)o;
	}
	

	private bool successorWorseThanExisting(AStarNode successor, AStarNode existing) {
		return existing != null && successor.totalCost > existing.totalCost;
	}
	
}	