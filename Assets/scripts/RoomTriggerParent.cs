using UnityEngine;
using System.Collections;

public class RoomTriggerParent : MonoBehaviour {
	// Use this for initialization
	public bool startingRoom = false; 
	public string roomName = ""; 

	private string _currentRoom;

	void Start () {
		if (startingRoom) {
				_currentRoom = roomName;
		}
		var eventCenter = EventCenter.Instance;
		eventCenter.roomEntered += this.roomEntered;
				eventCenter.roomExited += this.roomExited;
	}
	
	public void roomTriggered(string room) {
		var eventCenter = EventCenter.Instance;
		Debug.Log ("RoomTriggerParent/roomTriggered, room = " + room + ", eventCenter = " + eventCenter);
		if (room == _currentRoom) {
			EventCenter.Instance.onRoomWasLeft (room);
		} else {
			EventCenter.Instance.onRoomWasEntered (room);
			_currentRoom = room;
		}
	}

	public void roomEntered(string room) {
	}

	public void roomExited(string room) {
	}
	/*
	void OnTriggerEnter(Collider tgt) {
		Debug.Log("Room/OnTriggerEnter, tgt = " + tgt);
		Debug.Log("EventCenter = " + EventCenter.Instance);
		EventCenter.Instance.roomEntered(this.roomName);
	}
	*/
}
