using UnityEngine;
using System.Collections;

public class ActionResult {

	private bool _succeeded;

	public bool Succeeded
	{
		get
		{
			return _succeeded;
		}
	}

	private Action _alternate;
	public Action Alternate
	{
		get
		{
			return _alternate;
		}
	}

	public static ActionResult SUCCESS
	{
		get { return new ActionResult(); }
	}

	public static ActionResult FAILURE(Action alternate)
	{
		return new ActionResult(alternate);
	}

	private ActionResult()
	{
		_succeeded = true;
	}

	private ActionResult(Action alternate)
	{
		_succeeded = false;
		_alternate = alternate;
	}

}
