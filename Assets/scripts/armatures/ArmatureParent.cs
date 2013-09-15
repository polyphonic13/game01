using UnityEngine;
using System.Collections;

public class ArmatureParent : MonoBehaviour {

	public AnimationClip defaultAnimation; 
	
	private Animation _animation;
	
	public void PlayAnimation(string clip) {
		_animation[clip].wrapMode = WrapMode.Once;
		_animation.Play(clip);
	}
	
	void Start() {
		_animation = GetComponent<Animation>();
		//Debug.Log("ArmatureParent/Start, defaultAnimation = " + defaultAnimation.name);
		if(defaultAnimation != null) {
			_animation[defaultAnimation.name].wrapMode = WrapMode.Once;
			_animation.Play(defaultAnimation.name);
		}
	}
}
