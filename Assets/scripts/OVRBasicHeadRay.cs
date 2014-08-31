using UnityEngine;
using System.Collections;

public class OVRBasicHeadRay : MonoBehaviour {
	public float ballCastLength = 0.5f;
	public float yMovement = 0.5f;
	public float yMax = 2.0f;
	public float yMin = 1.0f;
	public float yStart = 1.5f;
	// Use this for initialization

	public CursorIcon cursorScreen;
	public OVRCamera parentCam;

	private GameObject previousHit = null;
	private Color previousColor;
	private RaycastHit hit;

	void Start () {
		var position = this.transform.position;
//		Debug.Log ("ball position y = " + position.y);
		Debug.Log ("cursorScreen position = " + cursorScreen.transform.position);
//		this.transform.position = new Vector3 (position.x, yStart, position.z);

		Screen.showCursor = false;

		if(parentCam != null) {
			this.gameObject.transform.parent = parentCam.transform;
		}
	}
	
	// Update is called once per frame
	void Update () {

//		var cameraForward = Camera.main.transform.forward;
		var cameraForward = parentCam.transform.forward;
//		Ray ballForward = new Ray (transform.position, Vector3.forward);
		Ray ballForward = new Ray (transform.position, cameraForward);
		Debug.DrawRay (transform.position, cameraForward, Color.red);


		if (Physics.Raycast (ballForward, out hit, ballCastLength)) {
			var hitObj = hit.collider.gameObject;

//			if(hit.collider.gameObject.tag != "interactable" && hit.collider.gameObject.tag != "persistentItem") {
			if((hitObj.GetComponent("InteractiveElement") as InteractiveElement) != null) {
//				Debug.Log ("ball ray cast hit: " + hit.collider.gameObject.name);
				if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.R)) {
					Debug.Log("mouse click on " + hit.collider.gameObject.name + ", tag = " + hit.collider.gameObject.tag);
//					Destroy(hit.collider.gameObject);
					EventCenter.Instance.mouseClick(hit.collider.gameObject.name);
				}
				cursorScreen.updateActiveIcon(true);
			}
		} else {

			cursorScreen.updateActiveIcon(false);
		}
		
//		if (Input.GetAxis ("Mouse Y") < 0) {
//			var position = this.transform.position;
//			if(position.y > yMin) {
//
//				this.transform.position = new Vector3 (position.x, (position.y + (Input.GetAxis ("Mouse Y") * yMovement)), position.z);
//				var newY = this.transform.position.y;
//				Debug.Log("< new y = " + newY);
//			}
//		}
//		if (Input.GetAxis ("Mouse Y") > 0) {
//			var position = this.transform.position;
//			if(position.y < yMax) {
//
//				this.transform.position = new Vector3 (position.x, (position.y + (Input.GetAxis ("Mouse Y") * yMovement)), position.z);
//				var newY = this.transform.position.y;
//				Debug.Log("> new y = " + newY);
//			
//			}
//		}
	}

}
