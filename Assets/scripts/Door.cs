using UnityEngine;
using System.Collections;

public class Door : OpenCloseChild {
	
	public bool isLocked = false;
	public string keyName;
	
	public void Awake() {
		isOpen = false;
	}
	
	public void OnMouseDown() {
		if(pops != null) {
			if(!isLocked) {
				handleAnimation();
			} else {
				//Debug.Log("can not open, it is locked");
				var player = GameObject.Find("player").GetComponent<Player>();
				if(player.inventory.HasItem(keyName)) {
					player.notification.AddNote("you unlocked this door with " + this.keyName);
					isLocked = false;
					handleAnimation();
				} else {
					player.notification.AddNote("this door is looked");
				}
			}
		}
	}
}
