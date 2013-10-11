using UnityEngine;
using System.Collections;

public class InteractiveElement : MonoBehaviour {

	public float interactDistance = 3;
	public string containingRoom; 

	private MouseManager _mouseManager;
	private int _activeCursor;
	
	void Awake() {
		init();
	}

	public bool isRoomActive { get; set; }
	
	public void init(int activeCursor = 1) {
		_mouseManager = GameObject.Find ("player").GetComponent<MouseManager>();
		_activeCursor = activeCursor;

		if (this.transform.tag == "persistentItem") {
			this.isRoomActive = true;
		} else {
			this.isRoomActive = false;
	
			var eventCenter = EventCenter.Instance;
			eventCenter.onRoomEntered += this.onRoomEntered;
			eventCenter.onRoomExited += this.onRoomExited;
		}
	}

	public void onRoomEntered (string room) {
		if (room == this.containingRoom) {
//			Debug.Log ("InteractiveElement[ " + this.name + " ]/onRoomEntered");
			this.isRoomActive = true;
		}
	}

	public void onRoomExited(string room) {
		if (room == this.containingRoom) {
//			Debug.Log ("InteractiveElement[ " + this.name + " ]/onRoomExited");
			this.isRoomActive = false;
		}
	}

	public void OnMouseOver() {
		mouseOver();
	}

	public void mouseOver() {
//		Debug.Log("InteractiveItem[ " + this.name + " ]/OnMouseOver, this.isRoomActive = " + this.isRoomActive);
		if (this.isRoomActive) {
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
		if (this.isRoomActive) {
			_mouseManager.setCursorType (0);
		}
	}
}
