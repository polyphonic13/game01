using UnityEngine;
using System.Collections;

public class CollidableParent : MonoBehaviour {

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
			Debug.Log("  adding CollidableChild class to " + childTransform.gameObject.name);
			CollidableChild touchableChild = childTransform.gameObject.AddComponent<CollidableChild>();
			touchableChild.onChildCollision += this.onChildCollision;
		}
	}
	
	public void onChildCollision(GameObject collisionTarget) {
		_onCollision(collisionTarget);
	}
	
	private void _onCollision(GameObject target) {
		Debug.Log("CollidableParent[ " + this.name + " ]/_onCollision, collisionTarget = " + target.name);
		if(target.name == "weight(Clone)") {
			Debug.Log(" it is a weight");
			ItemWeight itemWeight = target.GetComponent<ItemWeight>();
			Debug.Log("  itemWeight = " + itemWeight + ", containerName = " + itemWeight.containerName);
			if(itemWeight.containerName != null && itemWeight.containerName == this.name) {
				Debug.Log("  itemWeight.parent = " + itemWeight.parentObject);
			}
		}
	}
	
	void OnCollisionEnter(Collision target) {
		_onCollision(target.transform.gameObject);
	}
	
}
