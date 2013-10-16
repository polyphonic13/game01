using UnityEngine;
using System.Collections;

public class ItemContainer : CollidableParent {

	private GameObject _containerSpot;
	
	// Use this for initialization
	void Awake() {
		init ();
		_containerSpot = this.transform.Search("containerSpot").gameObject;
		Debug.Log("ItemContainer/Awake, _containerSpot = " + _containerSpot);
	}
	
	// Update is called once per frame
	public override void positionChild(GameObject child) {
		Debug.Log("ItemContainer/positionChild, child = " + child.name + ", _containerSpot = " + _containerSpot.name);
		child.transform.parent = _containerSpot.transform;
		child.transform.position = _containerSpot.transform.position;
		child.transform.rotation = _containerSpot.transform.rotation; 
		
		ItemWeight itemWeight = child.GetComponent<ItemWeight>();
		if(itemWeight != null) {
			itemWeight.killSelf();
		}
	}
}
