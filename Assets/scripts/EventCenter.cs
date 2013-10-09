using UnityEngine;
using System.Collections;

public class EventCenter : MonoBehaviour {

	public delegate void onEnterRoom(string room);
	public delegate void onLeaveRoom (string room);

				public delegate void EventHandler (string room);

				public event EventHandler roomWasEntered;
				public event EventHandler roomWasExited;

	public event onEnterRoom roomEntered;
	public event onLeaveRoom roomExited;

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

	public void onRoomWasEntered(string room) {
				Debug.Log ("EventCenter/onRoomWasEntered, room = " + room);
		if (roomWasEntered != null) {
			roomWasEntered (room);
		}
	}

	public void onRoomWasLeft(string room) {
		Debug.Log ("EventCenter/onRoomWasLeft, room = " + room);
		if (roomWasExited != null) {
				roomWasExited (room);
		}
	}

}
