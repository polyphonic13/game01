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
	}
	
	public void OnMouseDown() {
		//Debug.Log("LockableChild/OnMouseDown, pops = " + pops + ", isLocked = " + isLocked);
		if(pops != null) {
			if(!isLocked) {
				handleAnimation();
			} else {
				Debug.Log("can not open, it is locked");
				if(_player.inventory.HasItem(keyName)) {
					_player.notification.AddNote("unlocked with " + this.keyName);
					isLocked = false;
					handleAnimation();
				} else {
					_player.notification.AddNote("locked");
				}
			}
		}
	}
}
