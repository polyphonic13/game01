using UnityEngine;
using System.Collections;

public class EventAnimationParent : MonoBehaviour {
	
	public AnimationClip animationClip;
	public string eventName = "";
	
	// Use this for initialization
	void Awake() {
		if(eventName != "") {
			EventCenter.Instance.onTriggerEvent += this.onTriggerEvent;
		}
	}
	
	// Update is called once per frame
	void onTriggerEvent(string evt) {
		if(evt == eventName && animationClip != null) {
			_animation[animationClip.name].wrapMode = WrapMode.Once;
			_animation.Play(animationClip.name);
		}
	}
}
