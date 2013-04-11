using UnityEngine;
using System.Collections;

public class GrabCS : MonoBehaviour {

	private Transform pickObj = null;
	private Transform pickParentObj = null;
	private RaycastHit hit;
	private float dist;
	private Vector3 newPos;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetMouseButton(0)){ // if left button creates a ray from the mouse
	        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
	        if (!pickObj){ // if nothing picked yet...
	            if (Physics.Raycast(ray, out hit, 1) && hit.transform.tag == "pickable"){
					Debug.Log(hit.transform.parent.name);
	                // if it's a rigidbody, zero its physics velocity
	                if (hit.rigidbody) hit.rigidbody.velocity = Vector3.zero;
					if(hit.transform.parent.tag == "pickable") {
						pickParentObj = hit.transform.parent.transform;
					}
	                pickObj = hit.transform; // now there's an object picked
	                // remember its distance from the camera
	                dist = Vector3.Distance(pickObj.position, Camera.main.transform.position);
	            }
	        }
	        else { // if object already picked...
	            newPos = ray.GetPoint(dist); // transport the object
	            //pickObj.position = newPos;   // to the mouse position 
				pickObj.rigidbody.MovePosition(newPos);
				if(pickParentObj != null) {
					pickParentObj.rigidbody.MovePosition(newPos);
				}
	        }    
	    }
	    else { // when button released free pickObj
	        pickObj = null;
			if(pickParentObj != null) {
				pickParentObj = null;
			}
	    }
	}
}
