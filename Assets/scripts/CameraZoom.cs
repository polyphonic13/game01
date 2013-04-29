using UnityEngine;
using System.Collections;

public class CameraZoom : MonoBehaviour {
	
	Camera camera;
	float initialHeight;
	int zoom = 20;
	int normal = 60;
	float smooth = 5;
	bool isZoomed = false;
	bool isCrouched = false;
	
	void Start() {
//		Debug.Log( "CameraZoom, this = " + this + ", gameobject = " + this.gameObject );
		camera = Camera.main;
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
//		if(isCrouched) {
//			camera.transform.position = 
//		} else {
			
//		}
	}
}
