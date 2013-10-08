using UnityEngine;
using System.Collections;

public class RoomTrigger : MonoBehaviour {

	public string roomName;

	// Use this for initialization
	private RoomTriggerParent _parentRoom;

	void Start () {
		_parentRoom = transform.parent.gameObject.GetComponent<RoomTriggerParent> ();
				Debug.Log ("RoomTrigger[ " + this.roomName + " ]/Start, _parentRoom = " + _parentRoom);
	}

	void OnTriggerEnter(Collider tgt) {
		Debug.Log ("RoomTrigger/OnTriggerEnter, name = " + this.name);
				_parentRoom.roomTriggered (this.roomName);
	}
}
