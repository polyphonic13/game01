using UnityEngine;
using System.Collections;

public class EventCenter : MonoBehaviour {

	public delegate void RoomHandler (string room);

	public event RoomHandler onRoomEntered;
	public event RoomHandler onRoomExited;

	private static EventCenter _instance;
	private EventCenter() {}
	
	public static EventCenter Instance {
		get {
			if(_instance == null) {
	                _instance = GameObject.FindObjectOfType(typeof(EventCenter)) as EventCenter;      
			}
			return _instance;
		}
	}

	public void roomEntered(string room) {
		Debug.Log ("EventCenter/roomEntered, room = " + room);
		if (onRoomEntered != null) {
			onRoomEntered (room);
		}
	}

	public void roomExited(string room) {
		Debug.Log ("EventCenter/roomExited, room = " + room);
		if (onRoomExited != null) {
				onRoomExited (room);
		}
	}

}
