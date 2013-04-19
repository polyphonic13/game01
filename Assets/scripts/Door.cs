using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {
	
	public AnimationParent pops;
	public string openClip;
	public string closeClip;
	bool isDoorOpen = false;

	public void Awake() {
		getparent();
	}
	
	private void getparent() {
        Transform nextTransform = this.transform.parent;

        while (pops == null && nextTransform != null)
        {
            pops = nextTransform.GetComponent<AnimationParent>();
            nextTransform = this.transform.parent;
        }
	} 
	
	public void OnMouseDown() {
		Debug.Log( "pops = " + pops.transform.animation.GetClipCount() + ", name = " + pops.transform.animation.name );
		if( isDoorOpen ) {
            pops.transform.animation.Play(closeClip);
			isDoorOpen = false;			
		} else {
          pops.transform.animation.Play(openClip);
			isDoorOpen = true;
		}

	}
	
}
