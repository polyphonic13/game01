using UnityEngine;
using System.Collections;

public class CollectableItem : InteractiveElement {

	public string itemName = "";
	public string description = "";
	// TBD: extend class with ContainableItem:
	public string targetContainerName = "";
	
	public Texture iconTexture;
	public Texture detailTexture;

	public bool isEquipable = false;
	public bool isDroppable = false;

	private Vector3 _originalSize;

	public bool isCollected { get; set; }
	public bool isEquipped { get; set; }
	
	
	private Player _player;
	
	public ItemWeight weight; 
	private Vector3 _previousRigidBodyPos;
	
	void Awake() {
		initCollectableItem();
		
	}
	
	public void initCollectableItem() {
		init(2);
		this.isCollected = false;
		this.isEquipped = false;
		_player = GameObject.Find("player").GetComponent<Player>();
		_originalSize = this.transform.localScale;

		EventCenter.Instance.onEquipItem += this.onEquipItem;
	}

	public void onEquipItem(string itemName) {
		if(this.isCollected) {
			Debug.Log("CollectableItem[ " + this.name + " ]/onEquipItem, itemName = " + itemName + ", isEquipped = " + this.isEquipped);
			if(this.name == itemName) {
				if(this.isEquipped) { 					// item is already in use, store it
					unequip();
				} else { 								// item is not being used, equip it
					equip();
				}
			} else { 									// a different item is being equipped; store this one
				unequip();
			}
		}
	}

	public void OnMouseDown() {
		if(this.isRoomActive) {
			mouseDown();
		}
	}

	public void mouseDown() {
		Debug.Log("CollectableItem/OnMouseDown, name = " + this.name);
		var difference = Vector3.Distance(Camera.mainCamera.gameObject.transform.position, this.transform.position);
		if(difference < interactDistance) {
			if(!this.isCollected) {
				addToInventory();
			}
		}
	}
	
	public void addToInventory() {
		mouseExit();
		this.isCollected = true;
		_player.inventory.addItem(this);
		unequip();
		attach();
	}

	public virtual void attach() {
//		Debug.Log("CollectableItem/attach");
		attachToRightHand();
	}
	 
	public void attachToRightHand() {
		attachToHand("right_hand");
	}
	
	public void attachToLeftHand() {
		attachToHand ("left_hand");
	}
	
	public void attachToHand(string handName) {
		var hand = Camera.main.transform.Search(handName);
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
		this.isEquipped = true;
		this.transform.localScale = _originalSize;
	}
	
	public virtual void unequip() {
		store();
	}
	
	public void store() {
//		Debug.Log("CollableItem[ " + this.name + " ]/putAway");
		this.isEquipped = false;
		this.transform.localScale = new Vector3(0, 0, 0);
	}

	public virtual void drop() {
		this.isEquipped = false;
		this.isCollected = false;
		this.transform.localScale = _originalSize;
		this.transform.parent = null;

		float right = this.transform.position.x;
		float up = this.transform.position.y + 1.2f;
		float forward = this.transform.position.z;
		ItemWeight _weightClone = (ItemWeight) Instantiate(weight, this.transform.position, this.transform.rotation);
		_weightClone.targetContainerName = this.targetContainerName;
		_weightClone.parentObject = this.gameObject;
		_weightClone.transform.parent = this.transform;
	}
	
}
