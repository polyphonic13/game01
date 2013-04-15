using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ExclusiveAnimationParent : MonoBehaviour {
	public Dictionary<string, string> animationGroup;
	
	public void Awake() {
		animationGroup = new Dictionary<string, string>();
		
	}
}

