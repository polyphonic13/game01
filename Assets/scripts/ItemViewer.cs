using UnityEngine;
using System.Collections;

public class ItemViewer : MonoBehaviour {

	public Camera viewer;
	public Transform tgt;
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
		tgt = target.transform;
		Debug.Log("ItemViewer, new tgt.position = " + tgt.position);
		hasItem = true;
	}

	public void removeItem() {
		if(hasItem) {
			Destroy(_target);
			tgt = null;
			transform.rotation = _startRot;
			transform.position = _startPos;
			hasItem = false;
		}
	}

	void Start () {
		_startRot = transform.rotation;
		_startPos = transform.position;
		Debug.Log("tgt bounds = " + tgt.renderer.bounds.size.z + " tgt = " + tgt.renderer.bounds.center.z);
		float maxFront = tgt.renderer.bounds.center.z + (tgt.renderer.bounds.size.z/2);
		Debug.Log("maxFront = " + maxFront);
	}
	
	void Update () {
		if(tgt != null) {

			if(Input.GetKeyDown(KeyCode.R)) {
				// reset rotation and position
				transform.rotation = _startRot;
				transform.position = _startPos;
			} else {
				int orbitX = 0;
				int orbitY = 0;
				int move = 0;
				float dist = (transform.position.z - tgt.position.z);
				if(dist < 0) { dist = -dist; }

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
				Debug.Log("dist = " + dist + ", zoonMin = " + zoomMin + ", zoomMax = " + zoomMax);
				// POSITION
				if(Input.GetKey (KeyCode.Z) || Input.GetKey(KeyCode.Plus)) {
					if(dist > zoomMin) {
						move = -1;
					}
				} else if(Input.GetKey (KeyCode.X) || Input.GetKey (KeyCode.Minus)) {
					if(dist < zoomMax) {
						move = 1;
					}
				}

				if(move != 0) {
					_move (move);
				}
			}
		}
	}

	private void _orbit(Vector3 axis) {
		transform.RotateAround (tgt.position, axis, rotationSpeed * Time.deltaTime);
	}

	private void _move(int forwardFactor) {
		float speed = zoomSpeed * forwardFactor;
		transform.position += this.transform.forward * speed * Time.deltaTime;
	}
}
