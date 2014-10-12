using UnityEngine;
using System.Collections;

public class CameraZoom : MonoBehaviour {
	
	Camera _camera;
	int zoom = 20;
	int normal = 60;
	float smooth = 5;
	bool isZoomed = false;

	void Start() {
		_camera = GameObject.Find("mainCamera").GetComponent<Camera>();
		EventCenter.Instance.onCameraZoom += onCameraZoom;
	}

	void Update() {
//		if(Input.GetKeyDown(KeyCode.Z)) {
//			isZoomed = !isZoomed;
//		}
		zoomCamera();
	}

	void zoomCamera() {
		if(isZoomed) {
			_camera.fieldOfView = Mathf.Lerp(camera.fieldOfView,zoom,Time.deltaTime*smooth);
		} else {
			_camera.fieldOfView = Mathf.Lerp(camera.fieldOfView,normal,Time.deltaTime*smooth);
		}

	}

	public void onCameraZoom(bool zoom) {
		isZoomed = zoom;
//		zoomCamera();
	}
	
}
