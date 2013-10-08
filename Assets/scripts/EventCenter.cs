using UnityEngine;
using System.Collections;

public class EventCenter : MonoBehaviour {

	public delegate void onEnterRoom(string room);
	public delegate void onLeaveRoom(string room);
	public event onEnterRoom roomEntered;
	public event onLeaveRoom roomLeft;

	private static EventCenter instance;
	private EventCenter() {}
	
	public static EventCenter Instance {
		get {
			if(instance == null) {
	                instance = GameObject.FindObjectOfType(typeof(EventCenter)) as EventCenter;      
			}
			return instance;
		}
	}

/*
	void OnTriggerEnter(Collider tgt) {
		Debug.Log("EventCenter/OnTriggerEnter, tgt = " + tgt);
	}
*/
	

}
