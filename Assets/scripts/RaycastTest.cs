using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RaycastTest : MonoBehaviour {

	public float animationSpeed = 1.0f;
	public float followDistance = 2.0f;
	
	private List<Vector3> _activeBreadcrumbs;

	private Camera _mainCamera; 
	private Player _player; 

	// Use this for initialization
	void Start () {
		_player = GameObject.Find("player").GetComponent<Player>();
		_mainCamera = Camera.main;
		_activeBreadcrumbs = new List<Vector3>();
//		EventCenter.Instance.onPlayerBreadcrumb += this.onPlayerBreadcrumb;
	}

	public void onPlayerBreadcrumb(Vector3 position) {
		_activeBreadcrumbs.Add(position);
	}

	// Update is called once per frame
	void Update () {
		var distance = Vector3.Distance(this.transform.position, _mainCamera.transform.position);
		if(distance > followDistance) {
			_updatePosition();
		} else {
			_facePlayer();
		}

	}

	private void _updatePosition() {

		Vector3 newDestination = _mainCamera.transform.position;
//		var direction = (newDestination - this.transform.position).normalized;
//		transform.rotation = Quaternion.LookRotation(direction);
		var direction = this.transform.forward;
		bool leftHit = false;
		bool rightHit = false;
		bool directHit = false;
		RaycastHit hit;

		// OBSTACLE AVOIDANCE:
		// left 45°
		Debug.DrawRay(this.transform.position, (transform.forward+transform.right*-.5f) * 3, Color.blue);
		if(Physics.Raycast(this.transform.position, (transform.forward+transform.right*-.5f) * 3, out hit, 3f)) {
			if(hit.transform != this.transform) {
				if(hit.transform.tag != "Player") {
					Debug.Log("transform.left hit: " + hit.transform.name);
				} else if(hit.transform.tag == "Player") {
					Debug.Log("Found player");
				}
				transform.Rotate(Vector3.up, 30 * 2 * Time.smoothDeltaTime);
				leftHit = true;
			}
		}
		
		// right 45°
		Debug.DrawRay(this.transform.position, (transform.forward+transform.right*.5f) * 3, Color.yellow);
		if(Physics.Raycast(this.transform.position, (transform.forward+transform.right*.5f) * 3, out hit, 3f)) {
			if(hit.transform != this.transform) {
				if(hit.transform.tag != "Player") {
					Debug.Log("transform.right hit: " + hit.transform.name);
				} else if(hit.transform.tag == "Player") {
					Debug.Log("Found player");
				}
				transform.Rotate(Vector3.up, -30 * 2 * Time.smoothDeltaTime);
				rightHit = true;
			}
		}

		// front
		Debug.DrawRay(this.transform.position, this.transform.forward * 2, Color.red);
		if(Physics.Raycast(this.transform.position, this.transform.forward * 2, out hit, 2f)) {
			if(hit.transform != this.transform) {
				if(hit.transform.tag != "Player") {
					Debug.Log("transform.forward hit: " + hit.transform.name);
				} else if(hit.transform.tag == "Player") {
					Debug.Log("Found player");
				}
				if(leftHit) {
					transform.Rotate(Vector3.up, 90 * 5 * Time.smoothDeltaTime);
				} else {
					transform.Rotate(Vector3.up, -90 * 5 * Time.smoothDeltaTime);
				}
				directHit = true;
			}
		}

		if(!directHit) {
			this.transform.position += this.transform.forward * 2 * Time.deltaTime;
		}
		// END OBSTACLE AVOIDANCE


	}

	private void _facePlayer() {
		var targetPos = _mainCamera.transform.position - transform.position;
		//		targetPos.y = 0;
		Quaternion newRotation = Quaternion.LookRotation(targetPos);
		this.transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * animationSpeed);
	}
}
