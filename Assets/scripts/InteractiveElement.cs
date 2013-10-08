using UnityEngine;
using System.Collections;

public class InteractiveElement : MonoBehaviour {

	public float interactDistance = 3;
	public MouseManager mouseManager;
	public string containingRoom; 

	private int _activeCursor;

	void Awake() {
		init ();
	}

	public void init(int activeCursor = 1) {
		mouseManager = GameObject.Find ("player").GetComponent<MouseManager>();
		_activeCursor = activeCursor;
	}

	public void OnMouseOver() {
		mouseOver ();
	}

	public void mouseOver() {
		var difference = Vector3.Distance(Camera.mainCamera.gameObject.transform.position, this.transform.position);
		if (difference < interactDistance) {
//			Debug.Log ("InteractiveElement[ " + this.name + " ]/OnMouseOver");
			mouseManager.setCursorType(_activeCursor);
		}
	}

	public void OnMouseExit() {
		mouseExit ();
	}

	public void mouseExit() {
		mouseManager.setCursorType (0);
	}
}
