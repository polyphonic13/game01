using UnityEngine;
using System.Collections;

public class CollectableItem : MonoBehaviour {
	
	public int interactDistance = 3;
	public bool collected = false;
	public string itemName = "";
	public string description = "";
	public Texture icon;
	
	void Awake() {}
	
	public virtual void OnMouseDown() {
		Debug.Log("CollectableItem/OnMouseDown, description = " + this.description);
		var difference = Vector3.Distance(Camera.mainCamera.gameObject.transform.position, this.transform.position);
		if(difference < interactDistance) {
			if(!collected) {
				AddToInventory();
				collected = true;
			}
		}
	}
	
	public void AddToInventory() {
		var player = GameObject.Find("player").GetComponent<Player>();
		player.inventory.AddItem(this);	
		//Destroy(this.gameObject);
		DisableAll();
	}
	
	public void RemoveFromInventory() {
		collected = false;
		EnableAll();
	}
	
	public void DisableAll() {
		EnableUtil(false);
	}
	
	public void EnableAll() {
		EnableUtil(true);
	}
	
	// loop through renderers in children and enable/disable
	void EnableUtil(bool enable) {
		if(this.renderer) {
			this.renderer.enabled = enable;
		}
/*		
		Renderer[] cr = GetComponentInChildren<Renderer>();
		foreach(Renderer r in cr) {
			r.enabled = enable;
		}
*/		
	}		
	
	public void AttachTransforms() {
		AttachToHands(this.transform);

/*
		Transform[] ct = GetComponentInChildren<Transform>();
		foreach(Transform t in ct) {
			AttachToHands(t.transform);
		}
*/		
	}
	
	void AttachToHands(Transform transform) {
		var hand = Camera.main.transform.Search("right_hand");
		transform.position = hand.transform.position;
		transform.rotation = hand.transform.rotation;
		transform.parent = hand.transform;	
	}
}

/*
  recursive disabling
		Stack<Transform> children = new Stack<Transform>();
		children.Push(this.transform);
		
		while(children.Count > 0) {
		    Transform current = children.Pop();
		    Renderer renderer = current.GetComponent<Renderer>();
		
		    if (renderer != null) {
		        renderer.enabled = false;
		    }
		
		    foreach(Transform child in current.transform) {
		        children.Push(child);
		    }
		}

*/