using UnityEngine;
using System.Collections;

public class ItemViewer : MonoBehaviour {

	public Camera viewer;
	public Transform center;
//	public Vector3 axis = Vector3.up;
	public float radius = 2.0f;
	public float radiusSpeed = 0.5f;
	public float rotationSpeed = 80.0f;
	public float zoomSpeed = 0.5f; 
	public float zoomMax = 2f;
	public float zoomMin = 0.5f;

	public bool hasItem { get; set; }

	private Quaternion _startRot;
	private Vector3 _startPos;

	private GameObject _target;

	public void addItem(GameObject target) {
		if(hasItem) {
			removeItem();
		}
		_target = target;
		center = target.transform;
		Debug.Log("ItemViewer, new center.position = " + center.position);
		hasItem = true;
	}

	public void removeItem() {
		if(hasItem) {
			Destroy(_target);
			center = null;
			transform.rotation = _startRot;
			transform.position = _startPos;
			hasItem = false;
		}
	}

	void Start () {
		_startRot = transform.rotation;
		_startPos = transform.position;
	}
	
	void Update () {
		if(center != null) {

			if(Input.GetKeyDown(KeyCode.R)) {
				// reset rotation and position
				transform.rotation = _startRot;
				transform.position = _startPos;
			} else {
				int orbitX = 0;
				int orbitY = 0;
				int move = 0;
				float dist = (transform.position.z - center.position.z);

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

				// POSITION
				if(Input.GetKey (KeyCode.Z) || Input.GetKey(KeyCode.Plus)) {
					if(dist > zoomMin) {
						move = 1;
					}
				} else if(Input.GetKey (KeyCode.X) || Input.GetKey (KeyCode.Minus)) {
					if(dist < zoomMax) {
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
		transform.RotateAround (center.position, axis, rotationSpeed * Time.deltaTime);
	}

	private void _move(int forwardFactor) {
		float speed = zoomSpeed * forwardFactor;
		transform.position += this.transform.forward * speed * Time.deltaTime;
	}
}
