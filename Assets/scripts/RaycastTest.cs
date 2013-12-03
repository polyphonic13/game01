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
		EventCenter.Instance.onPlayerBreadcrumb += this.onPlayerBreadcrumb;
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
		var direction = this.transform.forward;
		bool hitSomething = false;
		RaycastHit hit;

		Debug.DrawRay(this.transform.position, this.transform.forward * 2, Color.red);
		if(Physics.Raycast(this.transform.position, this.transform.forward * 2, out hit, 2f)) {
			if(hit.transform != this.transform) {
				if(hit.transform.tag != "Player") {
					Debug.Log("transform.forward hit: " + hit.transform.name);
				} else if(hit.transform.tag == "Player") {
					Debug.Log("Found player");
				}
				transform.Rotate(Vector3.up, 90 * 5 * Time.smoothDeltaTime);
				hitSomething = true;
				direction += hit.normal * 5;
			}
		}

		Debug.DrawRay(this.transform.position, (transform.forward+transform.right*-.5f) * 2, Color.blue);
		if(Physics.Raycast(this.transform.position, (transform.forward+transform.right*-.5f) * 2, out hit, 2f)) {
			if(hit.transform != this.transform) {
				if(hit.transform.tag != "Player") {
					Debug.Log("transform.left hit: " + hit.transform.name);
				} else if(hit.transform.tag == "Player") {
					Debug.Log("Found player");
				}
				transform.Rotate(Vector3.up, 30 * 2 * Time.smoothDeltaTime);
//				hitSomething = true;
				direction += hit.normal * 5;
			}
		}
		
		Debug.DrawRay(this.transform.position, (transform.forward+transform.right*.5f) * 2, Color.yellow);
		if(Physics.Raycast(this.transform.position, (transform.forward+transform.right*.5f) * 2, out hit, 2f)) {
			if(hit.transform != this.transform) {
				if(hit.transform.tag != "Player") {
					Debug.Log("transform.right hit: " + hit.transform.name);
				} else if(hit.transform.tag == "Player") {
					Debug.Log("Found player");
				}
				transform.Rotate(Vector3.up, -30 * 2 * Time.smoothDeltaTime);
//				hitSomething = true;
				direction += hit.normal * 5;
			}
		}
		
//		var rot = Quaternion.LookRotation(direction);
//		this.transform.rotation = Quaternion.Slerp(this.transform.rotation, rot, Time.deltaTime);
		if(!hitSomething) {
			this.transform.position += this.transform.forward * 2 * Time.deltaTime;
		}
	}

	private void _facePlayer() {
		var targetPos = _mainCamera.transform.position - transform.position;
		//		targetPos.y = 0;
		Quaternion newRotation = Quaternion.LookRotation(targetPos);
		this.transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * animationSpeed);
	}
}
