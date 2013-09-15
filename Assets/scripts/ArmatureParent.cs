using UnityEngine;
using System.Collections;

public class ArmatureParent : MonoBehaviour {

	//public ArmatureTrigger currentOpen;

	/*public abstract void OpenChild(OpenCloseChild child);
	public abstract void CloseChild(OpenCloseChild child);
	*/
	public AnimationClip defaultAnimation; 
	
	private Animation _animation;
	
	public void PlayAnimation(string clip) {
		//this.transform.animation.Play(clip);	
		_animation[clip].wrapMode = WrapMode.Once;
		//_animation[clip].blendMode = AnimationBlendMode.Additive;
		//_animation[clip].layer = 10;
		_animation.Play(clip);
	}
	
	void Start() {
		_animation = GetComponent<Animation>();
		Debug.Log("ArmatureParent/Start, defaultAnimation = " + defaultAnimation.name);
		if(defaultAnimation != null) {
			_animation[defaultAnimation.name].wrapMode = WrapMode.Once;
			_animation.Play(defaultAnimation.name);
		}
	}
}
