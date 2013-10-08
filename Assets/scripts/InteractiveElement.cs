using UnityEngine;
using System.Collections;

public class InteractiveElement : MonoBehaviour {

	public float interactDistance = 3;
	public MouseManager mouseManager;
	public string containingRoom; 
	public bool roomActive = false; 

	private int _activeCursor;

	void Awake() {
		init ();
	}

	public void init(int activeCursor = 1) {
		mouseManager = GameObject.Find ("player").GetComponent<MouseManager>();
		_activeCursor = activeCursor;

				var eventCenter = EventCenter.Instance;
				eventCenter.roomWasEntered += this.roomEntered;
				eventCenter.roomWasLeft += this.roomLeft;
	}

	public void roomEntered(string room) {
		if (room == this.containingRoom) {
				Debug.Log ("InteractiveElement[ " + this.name + " ]/roomEntered");
						roomActive = true;
		}
	}

	public void roomLeft(string room) {
		if (room == this.containingRoom) {
			Debug.Log ("InteractiveElement[ " + this.name + " ]/roomLeft");
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
								mouseManager.setCursorType (_activeCursor);
						}
				}
		}

	public void OnMouseExit() {
		mouseExit ();
	}

	public void mouseExit() {
				if (roomActive) {
						mouseManager.setCursorType (0);
				}
	}
}
