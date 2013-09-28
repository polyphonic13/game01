using UnityEngine;
using System.Collections;

public class LockableChild : OpenCloseChild {

	public bool isLocked = false;
	public string keyName;
	
	private Player _player;
	
	public void Awake() {
		//Debug.Log("LockableChild/Awake, this.name = " + this.gameObject.name);
		isOpen = false;
		_player = GameObject.Find("player").GetComponent<Player>();
		mouseManager = GameObject.Find ("player").GetComponent<MouseManager>();
	}
	
	public void OnMouseOver() {
		var difference = Vector3.Distance(Camera.mainCamera.gameObject.transform.position, this.transform.position);
		if (difference < interactDistance) {
			Debug.Log ("LockableChild/OnMouseOver");
			mouseManager.setCursorType (1);
		}
	}

	public void OnMouseExit() {
		Debug.Log ("LockableChild/OnMouseOut");
		mouseManager.setCursorType (0);
	}

	public void OnMouseDown() {
		//Debug.Log("LockableChild/OnMouseDown, pops = " + pops + ", isLocked = " + isLocked);
		if(pops != null) {
			if(!isLocked) {
				handleAnimation();
			} else {
				Debug.Log("can not open, it is locked");
				if(_player.inventory.hasItem(keyName)) {
					_player.notification.addNote("unlocked with " + this.keyName);
					isLocked = false;
					handleAnimation();
				} else {
					_player.notification.addNote("locked");
				}
			}
		}
	}
}
