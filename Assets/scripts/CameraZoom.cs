using UnityEngine;
using System.Collections;

public class CameraZoom : MonoBehaviour {
	
	Camera camera;
	Transform fpc;
	CharacterController controller;
	float altHeightChange = 3.0f;
	int zoom = 20;
	int normal = 60;
	float smooth = 5;
	bool isZoomed = false;
	bool isCrouched = false;
	
	void Start() {
//		Debug.Log( "CameraZoom, this = " + this + ", gameobject = " + this.gameObject );
		camera = Camera.main;
	    //controller = GetComponent<CharacterController>();
		//controller = (CharacterController)GetComponent(typeof(CharacterController));
		fpc = GameObject.Find("player").transform;
		Debug.Log("fpc = " + fpc);
//		controller = fpc.GetComponent<CharacterController>();
//		Debug.Log("controller = " + controller);
	}
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("z")) {
			isZoomed = !isZoomed;
		}
		if(isZoomed) {
			camera.fieldOfView = Mathf.Lerp(camera.fieldOfView,zoom,Time.deltaTime*smooth);
		} else {
			camera.fieldOfView = Mathf.Lerp(camera.fieldOfView,normal,Time.deltaTime*smooth);
		}
		if(Input.GetKeyDown("c")) {
			isCrouched = !isCrouched;
		}
		if(isCrouched) {
			Vector3 tempCenter = controller.center;
			tempCenter.y -= altHeightChange * 0.5f;
            controller.center = tempCenter;
            controller.height -= altHeightChange;
		} else {
			Vector3 tempCenter = controller.center;
			tempCenter.y += altHeightChange * 0.5f;
            controller.center = tempCenter;
            controller.height += altHeightChange;
		}
	}
}
