using UnityEngine;
using System.Collections;

public class CollectableItem : InteractiveElement {
	
	public string itemName = "";
	public string description = "";
	
	public Texture iconTexture;
	public Texture detailTexture;

	public bool isEquipable = false;

	private Renderer[] _renderers;
	private Vector3 _originalSize;

	public bool isCollected { get; set; }
	public bool isInUse { get; set; }

	private Player _player;

	void Awake() {
		initCollectableItem();
	}

	public void initCollectableItem () {
		init(2);
		this.isCollected = false;
		this.isInUse = false;
		_player = GameObject.Find("player").GetComponent<Player>();
		_originalSize = this.transform.localScale;

		EventCenter.Instance.onEquipItem += this.onEquipItem;
	}

	public void onEquipItem(string itemName) {
		if(this.isCollected) {
			Debug.Log("CollectableItem[ " + this.name + " ]/onEquipItem, itemName = " + itemName + ", isInUse = " + this.isInUse);
			if(this.name == itemName) {
				if(this.isInUse) { // item is already in use, store it
					store();
				} else { // item is not being used, equip it
					equip();
				}
			} else { // a different item is being equipped; store this one
				store();
			}
		}
	}

	public void OnMouseDown () {
		if (this.roomActive) {
			mouseDown ();
		}
	}

	public void mouseDown() {
		Debug.Log ("CollectableItem/OnMouseDown, name = " + this.name);
		var difference = Vector3.Distance (Camera.mainCamera.gameObject.transform.position, this.transform.position);
		if (difference < interactDistance) {
			if (!this.isCollected) {
				addToInventory();
				this.isCollected = true;
			}
		}
	}
	
	public void addToInventory() {
		mouseExit();
		_player.inventory.addItem(this);
		store();
		attach();
	}

	public virtual void attach () {
//		Debug.Log("CollectableItem/attach");
		attachToRightHand();
	}
	 
	public void attachToBackpack () {
		var backpack = _player.transform.Search("backpack");
		transform.position = backpack.transform.position;
		transform.rotation = backpack.transform.rotation;
		transform.parent = backpack.transform;
	}

	public void attachToPlayer() {
		transform.position = _player.transform.position;
		transform.rotation = _player.transform.rotation;
		transform.parent = _player.transform;
	}

	public void attachToRightHand() {
		var hand = Camera.main.transform.Search("right_hand");
		transform.position = hand.transform.position;
		transform.rotation = hand.transform.rotation;
		transform.parent = hand.transform;	
	}

	public void removeFromInventory() {
		this.isCollected = false;
	}
	
	public virtual void equip() {
		use();
	}

	public void use() {
//		Debug.Log("CollectableItem[ " + this.name + " ]/use");
		this.isInUse = true;
		this.transform.localScale = _originalSize;
	}
	
	public virtual void store() {
		putAway ();
	}
	
	public void putAway() {
//		Debug.Log("CollableItem[ " + this.name + " ]/putAway");
		this.isInUse = false;
		this.transform.localScale = new Vector3(0, 0, 0);
	}

	public virtual void drop () {
		this.isInUse = false;
		this.isCollected = false;
		this.transform.localScale = _originalSize;
//		this.transform.parent = 
	}
}

/*
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

		_renderers = gameObject.GetComponentsInChildren<Renderer>();
		foreach(Renderer r in _renderers) {
			r.enabled = enable;
		}

	}		

*/