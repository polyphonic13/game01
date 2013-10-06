using UnityEngine;
using System.Collections;

public class InteractiveElement : MonoBehaviour {

	public float interactDistance = 3;
	public MouseManager mouseManager;

	private int _activeCursor;

	void Awake() {
		init ();
	}

	public void init(int activeCursor = 1) {
		mouseManager = GameObject.Find ("player").GetComponent<MouseManager>();
				_activeCursor = activeCursor;
	}

	public void OnMouseOver() {
		var difference = Vector3.Distance(Camera.mainCamera.gameObject.transform.position, this.transform.position);
		if (difference < interactDistance) {
//			Debug.Log ("InteractiveElement/OnMouseOver");
			mouseManager.setCursorType(_activeCursor);
		}
	}

	public void OnMouseExit() {
		//		var difference = Vector3.Distance(Camera.mainCamera.gameObject.transform.position, this.transform.position);
		//		if (difference < interactDistance) {
//		Debug.Log ("InteractiveElement/OnMouseExit");
		mouseManager.setCursorType (0);
		//		}
	}


}
