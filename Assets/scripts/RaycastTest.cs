using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RaycastTest : MonoBehaviour {

	public GameObject goal;

	public float animationSpeed = 1.0f;
	public float followDistance = 1.0f;
	public float minSafeDistance = 0.2f;
	public float sideRays = 2.5f;
	public float sideRays2 = 3.0f;
	public float frontRay = 1.0f;

//	private List<Vector3> _activeBreadcrumbs;

//	private Camera _mainCamera; 
//	private Player _player; 
	private Transform _goalTransform; 

	RaycastHit _hit;

	private float _rotationAdjustment = 0;
	private bool _updating = false;
	private bool _tooCloseToObject = false;
	private Vector3 _direction;

	private int _avoidanceSteps = 0;
	
	// Use this for initialization
	void Start () {
		_goalTransform = goal.transform;
		Vector3 newDestination = _goalTransform.position;
//		_direction = (newDestination - transform.position).normalized;
		_direction = transform.forward;
	}

	// Update is called once per frame
	void FixedUpdate () {
		Debug.Log("-------------- FixedUpdate --------------");
		var distance = Vector3.Distance(transform.position, _goalTransform.position);
		if(distance > followDistance) {
			if(!_updating) {
//				StartCoroutine("_updatePosition");
				StartCoroutine("_carPositionUpdate");
			}
		} else {
			_faceGoal();
		}

	}

	private IEnumerator _carPositionUpdate() {
		var strt = transform.position;
		var rside = transform.position;
		var fside = transform.position;
		bool rHit = false;
		bool lHit = false;
		RaycastHit hit;

		Debug.DrawRay(transform.position, transform.forward * 5, Color.red);
		Debug.DrawRay(transform.position, (transform.forward+transform.right*-.5f)*5, Color.green);
		Debug.DrawRay(transform.position , (transform.forward+transform.right*.5f)*5, Color.blue);
/*
		if(Physics.Raycast(strt,transform.forward, out hit, 5)) {
//			if(hit.collider.gameObject.tag == "Player"){
			Debug.Log("forward hit");
				transform.Rotate(Vector3.up, 90 * 5* Time.smoothDeltaTime);
//			}
		}
*/
		if(Physics.Raycast(rside,(transform.forward+transform.right*-.5f)*5, out hit, 5)) {
//			if(hit.collider.gameObject.tag == "Player"){
			lHit = true;
//			}
		}
		if(Physics.Raycast(fside,(transform.forward+transform.right*.5f)*5, out hit, 5)) {
//			if(hit.collider.gameObject.tag == "Player"){
//			}
			rHit = true;
		}

		if(lHit && rHit) {
			Debug.Log("left and right hit");
			bool l90Hit = false;
			bool r90Hit = false;
			Debug.DrawRay(transform.position, (transform.forward+transform.right*-1.0f)*10, Color.cyan);
			Debug.DrawRay(transform.position, (transform.forward+transform.right*1.0f)*10, Color.magenta);
			if(Physics.Raycast(rside,(transform.forward+transform.right*-1.0f)*10, out hit, 10)) {
				l90Hit = true;
			} 
			if(Physics.Raycast(rside,(transform.forward+transform.right*1.0f)*10, out hit, 10)) {
				r90Hit = true;
			}
//			transform.Rotate(Vector3.up, 85 * 2* Time.smoothDeltaTime);
		
//			if(Physics.Raycast(rside,(transform.forward+transform.right*-1.0f)*10, out hit, 10)) {
//				l90Hit = true;
//			}
		} else if(lHit) {
			Debug.Log("left hit");
			transform.Rotate(Vector3.up, 45 * 2* Time.smoothDeltaTime);

		} else if(rHit) {
			Debug.Log("right hit");
			transform.Rotate(Vector3.up, -45 * 2* Time.smoothDeltaTime);
		}

		transform.position += transform.forward * 3 * Time.deltaTime;

		yield return true;
	}

	private IEnumerator _updatePosition() {
		_updating = true;

		_rotationAdjustment = 0;
		_rotationAdjustment = _checkDirectionalHit(-0.5f, 60f, 5f, "left");
		_rotationAdjustment = _checkDirectionalHit(0.5f, -60f, -5f, "right");
		Debug.Log("_rotationAdjustment = " + _rotationAdjustment);
		if(_rotationAdjustment == 0) {
			Debug.Log("FINDING TARGET");
			if(_avoidanceSteps == 0) {
				Vector3 newRotation;
//				newRotation = _direction;
				newRotation = transform.forward;
				transform.rotation = Quaternion.LookRotation(newRotation);
			} else {
				Debug.Log("taking avoidance step: " + _avoidanceSteps);
				_avoidanceSteps--;
			}
		} else {
			Debug.Log("CHANGING DIRECTION TO AVOID OBSTACLE");
			_avoidanceSteps = 5;
			transform.Rotate(Vector3.up, _rotationAdjustment * 2 * Time.smoothDeltaTime);

//			newRotation = _direction;
//			newRotation.y += _rotationAdjustment;

//			Quaternion rotation = transform.rotation;
//			rotation.y += _rotationAdjustment;
//			transform.Rotate(Vector3.up, _rotationAdjustment * 2 * Time.smoothDeltaTime);
//			direction = transform.forward;
//			direction.y += _rotationAdjustment;
		}
		Debug.Log("  transform.rotation = " + transform.rotation);

		// OBSTACLE AVOIDANCE:
		// left 45°
		Debug.DrawRay(transform.position, (transform.forward+transform.right*-.5f) * sideRays, Color.blue);
		// right 45°
		Debug.DrawRay(transform.position, (transform.forward+transform.right*.5f) * sideRays, Color.yellow);
		// front
//		Debug.DrawRay(transform.position, transform.forward * frontRay, Color.red);
		Debug.DrawRay(transform.position, (transform.forward+transform.right*-.25f) * sideRays2, Color.green);

		Debug.DrawRay(transform.position, (transform.forward+transform.right*.25f) * sideRays2, Color.red);

//		if(!_tooCloseToObject) {
			transform.position += transform.forward * animationSpeed * Time.deltaTime;
//		} else {
//
//		}
		// END OBSTACLE AVOIDANCE

		_updating = false;
		yield return true;
	}

	private float _checkDirectionalHit(float rot, float rotChange, float rotAdj, string dir) { 
		float ret = 0;

		if(Physics.Raycast(transform.position, (transform.forward+transform.right*rot) * sideRays, out _hit, sideRays)) {
			if(_hit.transform != transform) {
//				if(_hit.transform.tag != "Player") {
					Debug.Log("  transform."+dir+" hit: " + _hit.transform.name);
//				}
//				transform.Rotate(Vector3.up, rotChange * 2 * Time.smoothDeltaTime);
//				Debug.Log("  rotation now: " + transform.rotation);

//				_rotationAdjustment = rotAdj;
//				ret = true;
//				ret = rotChange;
				ret = rotAdj;

				var obstacleDistance = Vector3.Distance(transform.position, _hit.transform.position);
				Debug.Log("   obstacleDistance = " + obstacleDistance + ", min = " + (minSafeDistance * 5));
				if(obstacleDistance < (minSafeDistance)*5) {
					_tooCloseToObject = true;
				} else {
					_tooCloseToObject = false;
				}
			}
		}
		return ret;
	} 

	private IEnumerator _findNewDirection() {

		yield return true;
	}

	private bool _checkLeftHit() {
		// left
		if(Physics.Raycast(transform.position, (transform.forward+transform.right*-.5f) * sideRays, out _hit, sideRays)) {
			if(_hit.transform != transform) {
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
		if(Physics.Raycast(transform.position, (transform.forward+transform.right*.5f) * sideRays, out _hit, sideRays)) {
			if(_hit.transform != transform) {
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
		transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * animationSpeed);
	}
}
