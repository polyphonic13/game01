using UnityEngine;
using System.Collections;

public class ItemViewer : MonoBehaviour {

	public Camera viewer;
	public Transform tgt;
	public float rotationSpeed = 150.0f;
	public float zoomSpeed = 3f; 
	public float zoomMax = 4.0f;
	public float zoomMin = 0.05f;

	public bool hasItem { get; set; }

	private Quaternion _startRot;
	private Vector3 _startPos;

	private GameObject _target;

	public void addItem(GameObject target) {
		if(hasItem) {
			removeItem();
		}
		_target = target;
		tgt = target.transform;
		hasItem = true;
	}

	public void removeItem() {
		if(hasItem) {
			Destroy(_target);
			tgt = null;
			reset ();
			hasItem = false;
		}
	}

	public void reset() {
		viewer.transform.rotation = _startRot;
		viewer.transform.position = _startPos;
	}
	
	void Start () {
		_startRot = viewer.transform.rotation;
		_startPos = viewer.transform.position;
	}
	
	void Update () {
		if(tgt != null) {

			if(Input.GetKeyDown(KeyCode.R)) {
				// reset rotation and position
				reset ();
			} else {
				int orbitX = 0;
				int orbitY = 0;
				int move = 0;
				var distance = Vector3.Distance(viewer.transform.position, tgt.transform.position);

				// ROTATION
				// up/down orbit (y axis)
				if(Input.GetKey(KeyCode.A) || Input.GetKey (KeyCode.LeftArrow)) {
					orbitY = 1;
				} else if(Input.GetKey(KeyCode.D) || Input.GetKey (KeyCode.RightArrow)) {
					orbitY = -1;
				}
				// left/right orbit (x axis)
				if(Input.GetKey(KeyCode.W) || Input.GetKey (KeyCode.UpArrow)) {
					orbitX = 1;
				} else if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) {
					orbitX = -1;
				}
				
				_orbit(new Vector3(orbitX, orbitY, 0));
				Debug.Log("distance = " + distance + ", zoonMin = " + zoomMin + ", zoomMax = " + zoomMax);
				// POSITION
				if(Input.GetKey (KeyCode.Z) || Input.GetKey(KeyCode.Plus)) {
					if(distance > zoomMin) {
						move = 1;
					}
				} else if(Input.GetKey (KeyCode.X) || Input.GetKey (KeyCode.Minus)) {
					if(distance < zoomMax) {
						move = -1;
					}
				}

				if(move != 0) {
					_move (move);
				}
			}
		}
	}

	private void _orbit(Vector3 axis) {
		viewer.transform.RotateAround (tgt.position, axis, rotationSpeed * Time.deltaTime);
	}

	private void _move(int forwardFactor) {
		float speed = zoomSpeed * forwardFactor;
		viewer.transform.position += viewer.transform.forward * speed * Time.deltaTime;
	}
}
