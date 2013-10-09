using UnityEngine;
using System.Collections;

public class RoomTrigger : MonoBehaviour {

	public string roomName;

	void OnTriggerEnter(Collider tgt) {
		var parentRoom = transform.parent.gameObject.GetComponent<RoomTriggerParent>();
		parentRoom.roomTriggered (this.roomName);
	}
}
