using UnityEngine;
using System.Collections;

public class OVRCrossHair : MonoBehaviour {

	public OVRCameraController pops;
	public OVRCamera cameraRight;
	public float animationSpeed = 0.1f;

	private RaycastHit hit;
	// Use this for initialization
	void Start () 
	{
//		Debug.Log ("pops = " + pops.transform.position + ", " + pops.transform.rotation);
		cameraRight = GameObject.Find ("CameraRight").GetComponent<OVRCamera> ();

	}
	
	// Update is called once per frame
	void Update () 
	{
//		Debug.Log ("cameraRight = " + cameraRight.transform.position + ", " + cameraRight.transform.rotation);
		var mousePos = Camera.main.ScreenPointToRay (Input.mousePosition);
//		Debug.Log ("mousePos = " + mousePos + " cameraRight = " + cameraRight.transform.position);

//		Debug.DrawLine (cameraRight.transform.forward, mousePos.direction, Color.red);

//		var targetPos = cameraRight.transform.position - this.transform.position;
//		Quaternion newRotation = Quaternion.LookRotation(targetPos);
//		this.transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * animationSpeed);


//		Vector3 fwd = transform.TransformDirection(Vector3.forward);
//		if (Physics.Raycast (transform.position, fwd, 10)) {
//			print ("There is something in front of the object!");
//		}

//		if (Physics.Raycast (transform.position, (transform.forward * 0.5f) * 2, out hit, 5)) {
//			Debug.Log("hit " + hit.transform.name);
//			Debug.DrawLine(transform.position, hit.point, Color.blue);
//		}
	}

	void OnMouseDown() {
		Debug.Log ("ON MOUSE DOWN");
	}
}
