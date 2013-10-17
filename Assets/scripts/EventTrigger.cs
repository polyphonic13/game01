using UnityEngine;
using System.Collections;

public class EventTrigger : MonoBehaviour {
	
	public string[] eventNames;
	
	// Use this for initialization
	void Awake() {
		EventCenter.Instance.onTriggerEvent += this.onTriggerEvent;
	}
	
	public void onTriggerEvent(string evt) {
		Debug.Log("EventTrigger[ " + this.name + " ]/onTriggerEvent, evt = " + evt);
		foreach(string en in eventNames) {
			if(evt == en) {
				Debug.Log(" evt matched: " + en);
				handleTriggeredEvent(evt);
			}
		}
	}
	
	public virtual void handleTriggeredEvent(string evt) {
		Debug.Log("EventTrigger[ " + this.name + " ]/handleTriggeredEvent, evt = " + evt);
	}
}
