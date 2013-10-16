﻿using UnityEngine;
using System.Collections;

public class CollidableParent : MonoBehaviour {
	
	private GameObject _containerSpot;
	
	// Use this for initialization
	void Awake () {
		init ();	
	}
	
	public void init() {
		initCollidableChildren();
	}
	
	public void initCollidableChildren() {
		var childTransforms = gameObject.GetComponentsInChildren<Transform>();
		
		foreach(Transform childTransform in childTransforms) {
			CollidableChild touchableChild = childTransform.gameObject.AddComponent<CollidableChild>();
			touchableChild.onChildCollision += this.onChildCollision;

			if(childTransform.gameObject.name == "containerSpot") {
//				Debug.Log("   FOUND CONTAINER SPOT: " + childTransform.gameObject.name);
				_containerSpot = childTransform.gameObject;
			}
		}
	}
	
	public void onChildCollision(GameObject collisionTarget) {
		_onCollision(collisionTarget);
	}
	
	private void _onCollision(GameObject target) {
//		Debug.Log("CollidableParent[ " + this.name + " ]/_onCollision, collisionTarget = " + target.name);
		if(target.name == "weight(Clone)") {
//			Debug.Log(" it is a weight");
			ItemWeight itemWeight = target.GetComponent<ItemWeight>();
//			Debug.Log("  itemWeight = " + itemWeight + ", targetContainerName = " + itemWeight.targetContainerName);
			if(itemWeight.targetContainerName != null && itemWeight.targetContainerName == this.name) {
				Debug.Log("  itemWeight.parent = " + itemWeight.parentObject);
				_positionContainerChild(itemWeight.parentObject);
			}
		}
	}
	
	void OnCollisionEnter(Collision target) {
		_onCollision(target.transform.gameObject);
	}
	
	private void _positionContainerChild(GameObject child) {
		child.transform.parent = _containerSpot.transform;
		child.transform.position = _containerSpot.transform.position;
		child.transform.rotation = _containerSpot.transform.rotation; 
		
		ItemWeight itemWeight = child.GetComponent<ItemWeight>();
		if(itemWeight != null) {
			itemWeight.killSelf();
		}
	}
}
