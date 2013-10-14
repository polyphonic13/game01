using UnityEngine;
using System.Collections;

public class InspectableItem : InteractiveElement {

	public string description = "";

	private const int CURSOR_TYPE = 3;

	void Awake() {
		initInteractiveElement();
	}

	public void initInteractiveElement() {
		init(3);
	}

	public void OnMouseDown() {
		Debug.Log("InspectableItem/OnMouseDown, this.isRoomActive = " + this.isRoomActive);
		if(this.isRoomActive) {
			EventCenter.Instance.addNote(description);
		}
	}
}
