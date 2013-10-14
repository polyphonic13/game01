using UnityEngine;
using System.Collections;

public class RoomTriggerParent : MonoBehaviour {
	// Use this for initialization
	public bool startingRoom = false; 
	public string roomName = ""; 

	private string _currentRoom;

	void Start() {
		if (startingRoom) {
			_currentRoom = roomName;
			EventCenter.Instance.enterRoom(roomName);
		}
	}
	
	public void roomTriggered(string room) {
	Debug.Log("RoomTriggerParent[ " + roomName + " ]/roomTrigged, _currentRoom = " + _currentRoom + ", room = " + room);
		var eventCenter = EventCenter.Instance;
		if (room == _currentRoom) {
			EventCenter.Instance.exitRoom(room);
		} else {
			EventCenter.Instance.enterRoom(room);
			_currentRoom = room;
		}
	}

}
