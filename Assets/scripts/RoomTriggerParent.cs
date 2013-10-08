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
	}
	
	public void roomTriggered(string room) {
		var eventCenter = EventCenter.Instance;
		Debug.Log ("RoomTriggerParent/roomTriggered, room = " + room + ", eventCenter = " + eventCenter);
		if (room == _currentRoom) {

		} else {
			_currentRoom = room;
		}
	}
	/*
	void OnTriggerEnter(Collider tgt) {
		Debug.Log("Room/OnTriggerEnter, tgt = " + tgt);
		Debug.Log("EventCenter = " + EventCenter.Instance);
		EventCenter.Instance.roomEntered(this.roomName);
	}
	*/
}
