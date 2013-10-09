using UnityEngine;
using System.Collections;

public class InteractiveElement : MonoBehaviour {

	public float interactDistance = 3;
	public string containingRoom; 
	public bool roomActive; 

	private MouseManager _mouseManager;
	private int _activeCursor;

	void Awake() {
		init ();
	}

	public void init(int activeCursor = 1) {
		_mouseManager = GameObject.Find ("player").GetComponent<MouseManager> ();
		_activeCursor = activeCursor;

		if (this.transform.tag == "persistentDoor") {
						roomActive = true;
				} else {

						roomActive = false;

						var eventCenter = EventCenter.Instance;
						eventCenter.roomWasEntered += this.roomEntered;
						eventCenter.roomWasExited += this.roomExited;
				}
	}

	public void roomEntered(string room) {
		if (room == this.containingRoom) {
				Debug.Log ("InteractiveElement[ " + this.name + " ]/roomEntered");
						roomActive = true;
		}
	}

	public void roomExited(string room) {
		if (room == this.containingRoom) {
			Debug.Log ("InteractiveElement[ " + this.name + " ]/roomExited");
						roomActive = false;
		}
	}

	public void OnMouseOver() {
		mouseOver ();
	}

	public void mouseOver() {
				if (roomActive) {
						var difference = Vector3.Distance (Camera.mainCamera.gameObject.transform.position, this.transform.position);
						if (difference < interactDistance) {
								//			Debug.Log ("InteractiveElement[ " + this.name + " ]/OnMouseOver");
								_mouseManager.setCursorType (_activeCursor);
						}
				}
		}

	public void OnMouseExit() {
		mouseExit ();
	}

	public void mouseExit() {
				if (roomActive) {
						_mouseManager.setCursorType (0);
				}
	}
}
