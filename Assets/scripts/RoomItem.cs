using UnityEngine;
using System.Collections;

public class RoomItem : MonoBehaviour {
	public InteractiveElement ieScript;

	public string containingRoom; 
	public bool roomActive = false; 

	void Awake() {
				init ();
		}

	public void init() {
		ieScript = gameObject.GetComponent<InteractiveElement> ();

		var eventCenter = EventCenter.Instance;
		eventCenter.roomWasEntered += this.roomEntered;
		eventCenter.roomWasLeft += this.roomLeft;
		}

	public void roomEntered(string room) {
		if (room == this.containingRoom) {
						if (ieScript != null) {
								ieScript.enabled = true;
						}
			Debug.Log ("RoomItem[ " + this.name + " ]/roomEntered");
			roomActive = true;
		}
	}

	public void roomLeft(string room) {
		if (room == this.containingRoom) {
			Debug.Log ("RoomItem[ " + this.name + " ]/roomLeft");
						if (ieScript != null) {
								ieScript.enabled = false;
						}
			roomActive = false;
		}
	}

}
