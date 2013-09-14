using UnityEngine;
using System.Collections;

public class LockableChild : OpenCloseChild {

	public bool isLocked = false;
	public string keyName;
	
	public void Awake() {
		//Debug.Log("LockableChild/Awake, this.name = " + this.gameObject.name);
		isOpen = false;
	}
	
	public void OnMouseDown() {
		//Debug.Log("LockableChild/OnMouseDown, pops = " + pops + ", isLocked = " + isLocked);
		if(pops != null) {
			if(!isLocked) {
				handleAnimation();
			} else {
				Debug.Log("can not open, it is locked");
				var player = GameObject.Find("player").GetComponent<Player>();
				if(player.inventory.HasItem(keyName)) {
					player.notification.AddNote("unlocked with " + this.keyName);
					isLocked = false;
					handleAnimation();
				} else {
					player.notification.AddNote("locked");
				}
			}
		}
	}
}
