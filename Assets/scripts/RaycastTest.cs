using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RaycastTest : MonoBehaviour {

	public GameObject goal;

	public float animationSpeed = 1.0f;
	public float followDistance = 1.0f;
	public float minSafeDistance = 0.5f;
	public float sideRays = 1.5f;
	public float frontRay = 1.0f;

	private List<Vector3> _activeBreadcrumbs;

	private Camera _mainCamera; 
	private Player _player; 
	private Transform _goalTransform; 

	RaycastHit _hit;

	private float _rotationAdjustment = 0;
	private bool _updating = false;
	private bool _tooCloseToObject = false;
	private Vector3 _direction;

	// Use this for initialization
	void Start () {
		_player = GameObject.Find("player").GetComponent<Player>();
		_mainCamera = Camera.main;

		if(goal != null) {
			_goalTransform = goal.transform;
		} else {
			_goalTransform = _mainCamera.transform;
		}
		Vector3 newDestination = _goalTransform.position;
		_direction = (newDestination - this.transform.position).normalized;

		_activeBreadcrumbs = new List<Vector3>();
//		EventCenter.Instance.onPlayerBreadcrumb += this.onPlayerBreadcrumb;
	}

	public void onPlayerBreadcrumb(Vector3 position) {
		_activeBreadcrumbs.Add(position);
	}

	// Update is called once per frame
	void Update () {
		var distance = Vector3.Distance(this.transform.position, _goalTransform.position);
		if(distance > followDistance) {
			if(!_updating) {
				StartCoroutine("_updatePosition");
			}
//			_updatePosition();
		} else {
			_faceGoal();
		}

	}

	private IEnumerator _updatePosition() {
		_updating = true;

		_rotationAdjustment = 0;
		_rotationAdjustment = _checkDirectionalHit(-0.5f, 60f, 5f, "left");
		_rotationAdjustment = _checkDirectionalHit(0.5f, -60f, -5f, "right");
		Debug.Log("_rotationAdjustment = " + _rotationAdjustment);
		Vector3 newRotation;
		if(_rotationAdjustment == 0) {
			Debug.Log("FINDING TARGET");
			newRotation = _direction;
		} else {
			Debug.Log("CHANGING DIRECTION TO AVOID OBSTACLE");
			newRotation = Quaternion.Euler(0, _rotationAdjustment, 0);

//			newRotation = _direction;
//			newRotation.y += _rotationAdjustment;

//			Quaternion rotation = transform.rotation;
//			rotation.y += _rotationAdjustment;
//			transform.Rotate(Vector3.up, _rotationAdjustment * 2 * Time.smoothDeltaTime);
//			direction = this.transform.forward;
//			direction.y += _rotationAdjustment;
		}
		transform.rotation = Quaternion.LookRotation(newRotation);
		Debug.Log("  transform.rotation = " + transform.rotation);

		// OBSTACLE AVOIDANCE:
		// left 45°
		Debug.DrawRay(this.transform.position, (transform.forward+transform.right*-.5f) * sideRays, Color.blue);
		// right 45°
		Debug.DrawRay(this.transform.position, (transform.forward+transform.right*.5f) * sideRays, Color.yellow);
		// front
		Debug.DrawRay(this.transform.position, this.transform.forward * frontRay, Color.red);


		if(!_tooCloseToObject) {
			this.transform.position += this.transform.forward * animationSpeed * Time.deltaTime;
		}
		// END OBSTACLE AVOIDANCE

		_updating = false;
		yield return true;
	}

	private float _checkDirectionalHit(float rot, float rotChange, float rotAdj, string dir) { 
		float ret = 0;

		if(Physics.Raycast(this.transform.position, (transform.forward+transform.right*rot) * sideRays, out _hit, sideRays)) {
			if(_hit.transform != this.transform) {
//				if(_hit.transform.tag != "Player") {
					Debug.Log("  transform."+dir+" hit: " + _hit.transform.name);
//				}
//				transform.Rotate(Vector3.up, rotChange * 2 * Time.smoothDeltaTime);
//				Debug.Log("  rotation now: " + transform.rotation);

//				_rotationAdjustment = rotAdj;
//				ret = true;
//				ret = rotChange;
				ret = rotAdj;

				var obstacleDistance = Vector3.Distance(this.transform.position, _hit.transform.position);
				if(obstacleDistance < minSafeDistance) {
					_tooCloseToObject = true;
				} else {
					_tooCloseToObject = false;
				}
			}
		}
		return ret;
	} 

	private bool _checkLeftHit() {
		// left
		if(Physics.Raycast(this.transform.position, (transform.forward+transform.right*-.5f) * sideRays, out _hit, sideRays)) {
			if(_hit.transform != this.transform) {
				if(_hit.transform.tag != "Player") {
					Debug.Log("transform.left hit: " + _hit.transform.name + ", rotation = " + transform.rotation);
				} else {
					Debug.Log("Found player");
				}
				transform.Rotate(Vector3.up, 60 * 2 * Time.smoothDeltaTime);
				_rotationAdjustment = 5;
				Debug.Log("  rotation now: " + transform.rotation);
				return true;
			} else {
				return false; // hit self
			}
		} else {
			return false; // hit nothing
		}
	}

	private bool _checkRightHit() {
		// right
		if(Physics.Raycast(this.transform.position, (transform.forward+transform.right*.5f) * sideRays, out _hit, sideRays)) {
			if(_hit.transform != this.transform) {
				if(_hit.transform.tag != "Player") {
					Debug.Log("transform.right hit: " + _hit.transform.name + ", rotation = " + transform.rotation);
				} else {
					Debug.Log("Found player");
				}
				transform.Rotate(Vector3.up, -60 * 2 * Time.smoothDeltaTime);
				_rotationAdjustment = -5;
				Debug.Log("  rotation now: " + transform.rotation);
				return true;
			} else {
				return false; // hit self
			}
		} else {
			return false; // hit nothing
		}
	}

	private bool _checkForwardHit() {
		return false;
	}

	private void _faceGoal() {
		var targetPos = _goalTransform.position - transform.position;
		//		targetPos.y = 0;
		Quaternion newRotation = Quaternion.LookRotation(targetPos);
		this.transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * animationSpeed);
	}
}
