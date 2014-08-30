using UnityEngine;
using System.Collections;

public class HeadPointer : MonoBehaviour {

	public Light laser;

//	private OVRCamera camera;
	private Camera screenCamera;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		var mousePos = Input.mousePosition;
		this.transform.position = (new Vector3(mousePos.x, mousePos.y, 0));
//		this.transform.position = screenCamera.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 0));

	}
}
