using UnityEngine;
using System.Collections;

public class LockableArmatureTrigger : OpenCloseArmatureTrigger {

	public bool isLocked = false;
	public string lockedItemName = ""; 
	public string keyName = "";
	
	private Player _player;

	public void Awake() {
		init ();
		Debug.Log("LockableArmatureTrigger/awake, name = " + pops.transform.parent.name);
		_player = GameObject.Find("player").GetComponent<Player>();
	}

	public override void handleAnimation() {
		handleLockCheck();
	}
	
	public void handleLockCheck() {
		Debug.Log("LockableArmatureTrigger[ " + this.name + " ]/handleLockCheck, isLocked = " + isLocked);
		if(!isLocked) {
			handleOpenClose();
		} else {
			if(_player.inventory.HasItem(keyName)) {
				_player.notification.AddNote("Unlocked " + lockedItemName + " with " + keyName);
				isLocked = false;
				handleOpenClose();
			} else {
				_player.notification.AddNote("The " + lockedItemName + " is locked");
			}
		}
	}

}

