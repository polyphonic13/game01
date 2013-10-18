using UnityEngine;
using System.Collections;

public class EventUnlockTrigger : LockableArmatureTrigger {
	
	public string unlockEvent;
	
	void Start () {
		EventCenter.Instance.onTriggerEvent += 	onTriggerEvent;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void onTriggerEvent(string evt) {
		if(evt == unlockEvent) {
			
			EventCenter.Instance.onTriggerEvent -= onTriggerEvent;
		}
	}
}
