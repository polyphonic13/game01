using UnityEngine;
using System.Collections;

public class BathroomDoor : MonoBehaviour {
	
	public Bathroom bathroom;
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
	} 
	
	public void Interact() {
		if( isDoorOpen ) {
            bathroom.transform.animation.Play("close_door");
			isDoorOpen = false;			
		} else {
            bathroom.transform.animation.Play("open_door");
			isDoorOpen = true;
		}
	}

	public void OnMouseDown() {
		//Debug.Log ( "Mouse down on " + this.name );
		//gameObject.animation.Play( "door_open" );	
		Debug.Log( "bathroom = " + bathroom );

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
}
