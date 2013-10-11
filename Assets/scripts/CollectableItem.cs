using UnityEngine;
using System.Collections;

public class CollectableItem : InteractiveElement {
	
	public string itemName = "";
	public string description = "";
	public Texture iconTexture;
	public Texture detailTexture;

	private Renderer[] _renderers;
	private Player _player;

	public bool isCollected { get; set; }
	
	void Awake() {
		initCollectableItem();
	}

	public void initCollectableItem () {
		init(2);
		_player = GameObject.Find("player").GetComponent<Player>();
		Debug.Log("CollectableItem[ " + this.name + " ]/awake, _player = " + _player);
	}

	public virtual void OnMouseDown() {
		mouseDown();
	}

	public void mouseDown() {
		if (this.isRoomActive) {
			Debug.Log ("CollectableItem/OnMouseDown, description = " + this.description);
			var difference = Vector3.Distance (Camera.mainCamera.gameObject.transform.position, this.transform.position);
			if (difference < interactDistance) {
				if (!this.isRoomActive) {
					addToInventory();
					this.isCollected = true;
				}
			}
		}
	}
	
	public void addToInventory() {
		_player.inventory.addItem(this);	
		// Destroy(this.gameObject);
		disableAll();
		mouseExit();
	}
	
	public void removeFromInventory() {
		this.isCollected = false;
		enableAll();
	}
	
	public void disableAll() {
		enableUtil(false);
	}
	
	public void enableAll() {
		enableUtil(true);
	}
	
	// loop through renderers in children and enable/disable
	void enableUtil(bool enable) {
		if(this.renderer) {
			this.renderer.enabled = enable;
		}

//		Renderer[] cr = GetComponentInChildren<Renderer>();
		_renderers = gameObject.GetComponentsInChildren<Renderer>();
		foreach(Renderer r in _renderers) {
			r.enabled = enable;
		}

	}		
	
	public void attachTransforms() {
		attachToHands(this.transform);

/*
		Transform[] ct = GetComponentInChildren<Transform>();
		foreach(Transform t in ct) {
			attachToHands(t.transform);
		}
*/		
	}
	
	void attachToHands(Transform transform) {
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