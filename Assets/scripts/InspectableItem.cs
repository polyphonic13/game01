using UnityEngine;
using System.Collections;

public class InspectableItem : InteractiveElement {

	public string description = "";

	private const int CURSOR_TYPE = 3;

	void Awake() {
		Debug.Log("InspectableItem[ " + this.name + " ]/Awake");
		initInteractiveElement();
		initTouchableChildren();
	}

	public void initInteractiveElement() {
		init(3);
	}
	
	public void initTouchableChildren() {
		foreach(Transform childTransform in transform) {
			TouchableChild touchableChild = childTransform.gameObject.AddComponent<TouchableChild>();
			touchableChild.onChildTouched += this.onChildTouched;
		}
	}
	
	public void onChildTouched(GameObject touchedChild) {
		Debug.Log("InspectableItem[ " + this.name + " ]/onChildTouched, touchedChild = " + touchedChild.name);
	}
	
	public void OnMouseDown() {
		var difference = Vector3.Distance(Camera.mainCamera.gameObject.transform.position, this.transform.position);
		if(difference < interactDistance) {
			Debug.Log("InspectableItem/OnMouseDown, this.isRoomActive = " + this.isRoomActive);
			if(this.isRoomActive) {
				EventCenter.Instance.addNote(description);
			}
		}
	}
}
