using UnityEngine;
using System.Collections;

public class Actor : MonoBehaviour {

	
	void Start () {
		GameLoop.instance.RegisterActor(this);
	}


	public Action GetAction()
	{
		return null;
	}



}
