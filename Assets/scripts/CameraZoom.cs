using UnityEngine;
using System.Collections;

public class CameraZoom : MonoBehaviour {
	
	Camera camera;
	int zoom = 20;
	int normal = 60;
	float smooth = 5;
	bool isZoomed = false;

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
			camera.fieldOfView = Mathf.Lerp (camera.fieldOfView,zoom,Time.deltaTime*smooth);
		} else {
			camera.fieldOfView = Mathf.Lerp (camera.fieldOfView,normal,Time.deltaTime*smooth);
		}
	}
}
