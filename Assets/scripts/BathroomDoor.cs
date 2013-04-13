using UnityEngine;
using System.Collections;

public class BathroomDoor : MonoBehaviour {
	
	private Bathroom bathroom;
	bool isDoorOpen = false;

	public void Awake() {
		getBathroom();
	}
	
	private void getBathroom() {
        Transform nextTransform = this.transform.parent;

        while (bathroom == null && nextTransform != null)
        {
            bathroom = nextTransform.GetComponent<Bathroom>();
            nextTransform = this.transform.parent;
        }
		//Debug.Log("Bathroom/getBathroom, bathrrom = " + bathroom);
	} 
	
	public void OnMouseDown() {
		//Debug.Log ( "Mouse down on " + this.name );
		//gameObject.animation.Play( "door_open" );	
		Debug.Log( "bathroom = " + bathroom.transform.animation.GetClipCount() + ", name = " + bathroom.transform.animation.name );
		string names = GetAnimationNames (bathroom.transform.animation);
		//Debug.Log("animations = " + names );

		if( isDoorOpen ) {
            bathroom.transform.animation.Play("close_door");
			isDoorOpen = false;			
		} else {
          bathroom.transform.animation.Play("open_door");
			isDoorOpen = true;
		}

	}
	
	public void OnTriggerEnter(Collider collider) {
		Debug.Log ( "Door triggered" );
	}
	
	private string GetAnimationNames(Animation anim) {
		//string[] names;
		string names = "";
		int num = 0;
		foreach(AnimationState state in anim) {
			num++;
			Debug.Log(num);
			names += ", " + state.name;
		}	
//		names += ", total = " + num;
		return names;
	}
/*	
function GetAnimationNames(Animation anim) {
	// make an Array that can grow
	var tmpList : Array = new Array();
 
	// enumerate all states
	for (var state : AnimationState in anim) {
		// add name to tmpList
		tmpList.Add(state.name);
	}
	// convert to (faster) buildin array (but can't grow anymore)
	var list : string[] = tmpList.ToBuildin(string);
	return list;
}
*/
}
