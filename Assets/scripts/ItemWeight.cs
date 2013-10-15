using UnityEngine;
using System.Collections;

public class ItemWeight : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter(Collision target) {
		Debug.Log("ItemWeight/OnCollisionEnter, target = " + target.gameObject.name + ", parent = " + this.transform.parent.name);	
	}
}
