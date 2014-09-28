using UnityEngine;
using System.Collections;

public class LockableArmatureTrigger : OpenCloseArmatureTrigger {

	public bool isLocked = false;
	public string lockedItemName = ""; 
	public string keyName = "";
	
	private Player _player;

	public void Awake() {
		initLockableArmatureTrigger();
	}
	
	public void initLockableArmatureTrigger(int activeCursor = 1) {
		initOpenCloseArmatureTrigger();
		init(activeCursor);
		_player = GameObject.Find("player").GetComponent<Player>();
//		Debug.Log("LockableArmatureTrigger["+this.name+"]/awake, name = " + pops.transform.parent.name + ", _player = " + _player);
	}

	public override void handleAnimation() {
		handleLockCheck();
	}
	
	public void handleLockCheck() {
//		Debug.Log("LockableArmatureTrigger[ " + this.name + " ]/handleLockCheck, isLocked = " + isLocked);
		if(!isLocked) {
			handleOpenClose();
		} else {
			if(_player.inventory.hasItem(keyName)) {
				string itemName = _player.inventory.getItemName(keyName);
				EventCenter.Instance.addNote(lockedItemName + " unlocked with " + itemName);
				isLocked = false;
				handleOpenClose();
			} else {
				EventCenter.Instance.addNote("The " + lockedItemName + " is locked");
			}
		}
	}

}

