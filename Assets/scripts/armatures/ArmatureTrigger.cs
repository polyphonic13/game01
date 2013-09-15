using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ArmatureTrigger : MonoBehaviour {
	public int interactDistance = 3;
	public ArmatureParent pops;
	public string mainClipName;
	
	public void OnMouseDown() {
		var difference = Vector3.Distance(Camera.mainCamera.gameObject.transform.position, this.transform.position);
		if(difference <= interactDistance) {
			handleAnimation();
		}
	}
	
	public virtual void handleAnimation() {
		Debug.Log("ArmatureTrigger[ " + this.name + " ]/handleAnimation");
		sendAnimationToPops(mainClipName);
	}
	
	public void sendAnimationToPops(string clipName) {
		Debug.Log("ArmatureTrigger[ " + this.name + " ]/sendAnimationToPops, clipName = " + clipName);
		pops.PlayAnimation(clipName);
	}
}
