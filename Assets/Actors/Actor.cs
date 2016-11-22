using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Action))]
[RequireComponent(typeof(BoardPosition))]
public class Actor : MonoBehaviour {

	
	void Start () {
		GameLoop.instance.RegisterActor(this);
	}


	virtual public Action GetAction()
	{
		return GetComponent<Action>();
	}

}
