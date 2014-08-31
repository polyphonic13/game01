using UnityEngine;
using System.Collections;

public class OVRCameraZoom : MonoBehaviour {

	public OVRCameraController camera;

	public float zoom = 20;
	private float normal = 60;
	float smooth = 5;
	bool isZoomed = false;

	void Start() {
		EventCenter.Instance.onCameraZoom += onCameraZoom;
		camera.GetVerticalFOV (ref normal);
		Debug.Log ("normal FOV = " + normal);
	}

	void Update() {
		if(Input.GetKeyDown(KeyCode.Z)) {
			isZoomed = !isZoomed;
		}
		zoomCamera();
	}
	
	void zoomCamera() {
		if(isZoomed) {
			camera.SetVerticalFOV(zoom);
		} else {
			camera.SetVerticalFOV(normal);
		}
		
	}
	
	public void onCameraZoom(bool zoom) {
		isZoomed = zoom;			
	}
}
