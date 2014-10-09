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

	private Vector3 _startPos;
	private bool _left = false;
	private bool _right = false; 
	private bool _up = false; 
	private bool _down = false; 

	void Start () {
//		transform.position = (transform.position - center.position).normalized * radius + center.position;
		_startPos = transform.position;
		radius = 2.0f;
		Debug.Log("vector 3 up = " + (-Vector3.up));
	}
	
	void Update () {
		if(Input.GetKeyDown(KeyCode.R)) {
			transform.rotation = new Quaternion(0,0,0,0);
			transform.position = _startPos;
		} else {
			int x;
			int y;
			
			if(Input.GetKey(KeyCode.A)) {
				y = 1;
			} else if(Input.GetKey(KeyCode.D)) {
				y = -1;
			} else {
				y = 0;
			}
			
			if(Input.GetKey(KeyCode.W)) {
				x = 1;
			} else if(Input.GetKey(KeyCode.S)) {
				x = -1;
			} else {
				x = 0;
			}
			
			_orbit(new Vector3(x, y, 0));
			//_orbit(Vector3.up);
		}

	}

	private void _orbit(Vector3 axis) {
		transform.RotateAround (center.position, axis, rotationSpeed * Time.deltaTime);
//		desiredPosition = (transform.position - center.position).normalized * radius + center.position;
//		transform.position = Vector3.MoveTowards(transform.position, desiredPosition, Time.deltaTime * radiusSpeed);
	}
}
