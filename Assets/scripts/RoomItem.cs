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
		eventCenter.roomWasExited += this.roomExited;
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

	public void roomExited(string room) {
		if (room == this.containingRoom) {
			Debug.Log ("RoomItem[ " + this.name + " ]/roomExited");
						if (ieScript != null) {
								ieScript.enabled = false;
						}
			roomActive = false;
		}
	}

}
