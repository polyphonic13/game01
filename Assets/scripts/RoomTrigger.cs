using UnityEngine;
using System.Collections;

public class RoomTrigger : MonoBehaviour {

	public string roomName;

	void OnTriggerEnter(Collider tgt) {
		Debug.Log ("RoomTrigger/OnTriggerEnter, name = " + this.name);
		var parentRoom = transform.parent.gameObject.GetComponent<RoomTriggerParent> ();
		parentRoom.roomTriggered (this.roomName);
	}
}
