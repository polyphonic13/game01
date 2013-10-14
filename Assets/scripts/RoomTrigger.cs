using UnityEngine;
using System.Collections;

public class RoomTrigger : MonoBehaviour {

	public string roomName;

	private RoomTriggerParent _roomTriggerParent;
	
	void Awake() {
		_roomTriggerParent = transform.parent.gameObject.GetComponent<RoomTriggerParent>();
	}
		
	void OnTriggerEnter(Collider tgt) {
		Debug.Log("RoomTrigger[ " + roomName + " ]/OnTriggerEnter");
		_roomTriggerParent.roomTriggered(this.roomName);
	}
}
