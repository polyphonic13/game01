#pragma strict
private var pickObj: Transform = null;
private var hit: RaycastHit;
private var dist: float;
private var newPos: Vector3;

function Update(){

    if (Input.GetMouseButton(0)){ // if left button creates a ray from the mouse
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (!pickObj){ // if nothing picked yet...
//            if (Physics.Raycast(ray, hit) && hit.transform.tag == "Pick"){
            if (Physics.Raycast(ray, hit, 5) && hit.transform.tag == "pickable"){
                // if it's a rigidbody, zero its physics velocity
                if (hit.rigidbody) hit.rigidbody.velocity = Vector3.zero;
                pickObj = hit.transform; // now there's an object picked
                // remember its distance from the camera
                dist = Vector3.Distance(pickObj.position, Camera.main.transform.position);
            }
        }
        else { // if object already picked...
            newPos = ray.GetPoint(dist); // transport the object
            pickObj.position = newPos;   // to the mouse position 
        }    
    }
    else { // when button released free pickObj
        pickObj = null;
    }
}