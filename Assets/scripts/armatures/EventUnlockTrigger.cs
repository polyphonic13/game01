using UnityEngine;
using System.Collections;

public class EventUnlockTrigger : LockableArmatureTrigger {
	
	public AnimationClip unlockClip;
	
	public string unlockEvent;
	
	void Awake() {
		EventCenter.Instance.onTriggerEvent += 	onTriggerEvent;
	}
	
	void onTriggerEvent(string evt) {
		Debug.Log("EventUnlockTrigger[ " + this.name + " ]/onTriggerEvent, evt = " + evt + ", unlockEvent = " + unlockEvent);
		if(evt == unlockEvent) {
			this.isLocked = false;
			this.isEnabled = true;
			if(unlockClip != null) {
				sendAnimationToPops(unlockClip.name, parentBone);
			}
			var eventCenter = EventCenter.Instance;
			eventCenter.addNote(this.name + " unlocked");
			eventCenter.onTriggerEvent -= onTriggerEvent;
		}
	}
}
