﻿using UnityEngine;
using System.Collections;

public class LockableArmatureTrigger : OpenCloseArmatureTrigger {

	public bool isLocked = false;
	public string lockedItemName = ""; 
	public string keyName = "";
	
	private Player _player;

	public void Awake() {
		init();
//		Debug.Log("LockableArmatureTrigger/awake, name = " + pops.transform.parent.name);
		_player = GameObject.Find("player").GetComponent<Player>();
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

