using UnityEngine;
using System.Collections;

public class InteractiveElement : MonoBehaviour {

	public float interactDistance = 3;
	public string containingRoom; 
	public bool roomActive; 

	private MouseManager _mouseManager;
	private int _activeCursor;

	void Awake() {
		init();
	}

	public void init(int activeCursor = 1) {
		_mouseManager = GameObject.Find ("player").GetComponent<MouseManager>();
		_activeCursor = activeCursor;

		if (this.transform.tag == "persistentItem") {
			roomActive = true;
		} else {
			roomActive = false;
	
			var eventCenter = EventCenter.Instance;
			eventCenter.onRoomEntered += this.onRoomEntered;
			eventCenter.onRoomExited += this.onRoomExited;
		}
	}

	public void onRoomEntered(string room) {
		if (room == this.containingRoom) {
//			Debug.Log ("InteractiveElement[ " + this.name + " ]/onRoomEntered");
			roomActive = true;
		}
	}

	public void onRoomExited(string room) {
		if (room == this.containingRoom) {
//			Debug.Log ("InteractiveElement[ " + this.name + " ]/onRoomExited");
			roomActive = false;
		}
	}

	public void OnMouseOver() {
		mouseOver();
	}

	public void mouseOver() {
//		Debug.Log("InteractiveItem[ " + this.name + " ]/OnMouseOver, roomActive = " + roomActive);
		if (roomActive) {
			var difference = Vector3.Distance (Camera.mainCamera.gameObject.transform.position, this.transform.position);
			if (difference < interactDistance) {
				_mouseManager.setCursorType (_activeCursor);
			}
		}
	}

	public void OnMouseExit() {
		mouseExit();
	}

	public void mouseExit() {
		if (roomActive) {
			_mouseManager.setCursorType (0);
		}
	}
}
