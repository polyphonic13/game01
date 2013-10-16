using UnityEngine;
using System.Collections;

public class ItemWeight : MonoBehaviour {
	
	public string containerName = "";
	public GameObject parentObject;
	
	private Rigidbody _rigidbody;
	
	// Use this for initialization
	void Start () {
		_rigidbody = GetComponent<Rigidbody>();
//		Debug.Log("ItemWeight/Start, _rigidBody = " + _rigidbody);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter(Collision target) {
		Debug.Log("ItemWeight/OnCollisionEnter, target = " + target.gameObject.name + ", parent = " + this.transform.parent.name);	
		if(target.gameObject.name != this.transform.parent.name && target.gameObject.name != "player") {
			Debug.Log("position = " + _rigidbody.position);
			Vector3 parentPos = this.transform.parent.transform.position;
			Vector3 newPos = new Vector3(parentPos.x, _rigidbody.position.y, parentPos.z);
			this.transform.parent.transform.position = newPos;
			killSelf();			
		}
	}

	void killSelf() {
		Destroy(this.gameObject);	
	}
}
