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
			EventCenter.Instance.roomEntered(roomName);
		}
	}
	
	public void roomTriggered(string room) {
		var eventCenter = EventCenter.Instance;
		if (room == _currentRoom) {
			EventCenter.Instance.roomExited(room);
		} else {
			EventCenter.Instance.roomEntered(room);
			_currentRoom = room;
		}
	}

}
