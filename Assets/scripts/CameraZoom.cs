using UnityEngine;
using System.Collections;

public class CameraZoom : MonoBehaviour {
	
	Camera camera;
	//Transform fpc;
	//CharacterController controller;
	float initHeight;
	float altHeightChange = 0.5f;
	int zoom = 20;
	int normal = 60;
	float smooth = 5;
	bool isZoomed = false;
	bool isCrouched = false;
	bool firstCrouch = false;
	
	void Start() {
//		Debug.Log( "CameraZoom, this = " + this + ", gameobject = " + this.gameObject );
		camera = Camera.main;
	    //controller = GetComponent<CharacterController>();
		//controller = (CharacterController)GetComponent(typeof(CharacterController));
		//fpc = GameObject.Find("player").transform;
		//Debug.Log("fpc = " + fpc);
		//controller = fpc.GetComponent<CharacterController>();
		//Debug.Log("controller = " + controller + ", center = " + controller.center + ", height = " + controller.height);
		//initHeight = controller.height;
	}
	// Update is called once per frame
	void Update () {
		//Debug.Log("camera.transform.position.y = " + camera.gameObject.transform.position.y);
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
			firstCrouch = true;
		}
		if(isCrouched) {
			Vector3 tempPosition = camera.gameObject.transform.position;
			tempPosition.y -= 0.05f;
			Debug.Log("position = " + camera.gameObject.transform.position.y + ", tempPosition = " + tempPosition.y);
			//camera.gameObject.transform.position = tempPosition;
			//Vector3 tempCenter = controller.center;
			//tempCenter.y -= altHeightChange * 0.5f;
			//tempCenter.y -= altHeightChange;
			//Debug.Log("tempCenter.y = " + tempCenter.y);
            //controller.center = tempCenter;
            //controller.height = altHeightChange;
		} else if(firstCrouch) {
			//Vector3 tempCenter = controller.center;
			//tempCenter.y += altHeightChange;
            //controller.center = tempCenter;
			//controller.height = initHeight;
            //controller.height += altHeightChange;
		}
	}
}
