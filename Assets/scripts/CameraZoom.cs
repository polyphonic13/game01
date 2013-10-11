using UnityEngine;
using System.Collections;

public class CameraZoom : MonoBehaviour {
	
	private Camera _camera;
	private int _zoom = 20;
	private int _normal = 60;
	private float _smooth = 5;
	private bool _isZoomed = false;	

	void Start() {
		_camera = Camera.main;
	}
	// Update is called once per frame
	void Update() {
		if(Input.GetKeyDown(KeyCode.Z)) {
			_isZoomed = !_isZoomed;
		}
		if(_isZoomed) {
			_camera.fieldOfView = Mathf.Lerp(_camera.fieldOfView,_zoom,Time.deltaTime*_smooth);
		} else {
			_camera.fieldOfView = Mathf.Lerp(_camera.fieldOfView,_normal,Time.deltaTime*_smooth);
		}
	}
}
