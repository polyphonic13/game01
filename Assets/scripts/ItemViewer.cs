using UnityEngine;
using System.Collections;

public class ItemViewer : MonoBehaviour {

	public Camera viewer;
	public Transform center;
//	public Vector3 axis = Vector3.up;
	public Vector3 desiredPosition;
	public float radius = 2.0f;
	public float radiusSpeed = 0.5f;
	public float rotationSpeed = 80.0f;
	public float zoomSpeed = 0.2f; 

	private Vector3 _startPos;
	private bool _left = false;
	private bool _right = false; 
	private bool _up = false; 
	private bool _down = false; 

	void Start () {
		_startPos = transform.position;
//		transform.position = (transform.position - center.position).normalized * radius + center.position;
	}
	
	void Update () {

		if(Input.GetKeyDown(KeyCode.R)) {
			// reset rotation and position
			transform.rotation = new Quaternion(0,0,0,0);
			transform.position = _startPos;
		} else {
			int orbitX = 0;
			int orbitY = 0;
			int move = 0;

			// rotation
			if(Input.GetKey(KeyCode.A)) {
				orbitY = 1;
			} else if(Input.GetKey(KeyCode.D)) {
				orbitY = -1;
			}
			
			if(Input.GetKey(KeyCode.W)) {
				orbitX = 1;
			} else if(Input.GetKey(KeyCode.S)) {
				orbitX = -1;
			}
			
			_orbit(new Vector3(orbitX, orbitY, 0));

			// position
			if(Input.GetKey (KeyCode.Z)) {
				move = 1;
			} else if(Input.GetKey (KeyCode.X)) {
				move = -1;
			}

			if(move != 0) {
				_move (move);
			}
		}

	}

	private void _orbit(Vector3 axis) {
		transform.RotateAround (center.position, axis, rotationSpeed * Time.deltaTime);
//		desiredPosition = (transform.position - center.position).normalized * radius + center.position;
//		transform.position = Vector3.MoveTowards(transform.position, desiredPosition, Time.deltaTime * radiusSpeed);
	}

	private void _move(int forwardFactor) {
//		transform.position = Vector3.MoveTowards();
		float speed = zoomSpeed * forwardFactor;
		this.transform.position += this.transform.forward * speed * Time.deltaTime;
	}
}
