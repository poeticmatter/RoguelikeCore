using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoardPosition))]
public abstract class Action : MonoBehaviour {
	[SerializeField]
	private int _energyCost;
	public int EnergyCost
	{
		get { return _energyCost; }
	}

	public enum ActionState { IDLE, EXECUTING, FINISHED };
	public ActionState state = ActionState.IDLE;

	abstract public ActionResult Perform();

	private BoardPosition boardPosition = null;
	public BoardPosition BoardPosition
	{
		get
		{
			if (boardPosition == null)
			{
				boardPosition = GetComponent<BoardPosition>();
			}
			return boardPosition;
		}
	}
}
