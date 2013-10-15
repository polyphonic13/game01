using UnityEngine;
using System.Collections;

public class CollectableItem : InteractiveElement {
	
	public string itemName = "";
	public string description = "";
	
	public Texture iconTexture;
	public Texture detailTexture;

	public bool isEquipable = false;
	public bool isDroppable = false;

	private Vector3 _originalSize;

	public bool isCollected { get; set; }
	public bool isEquipped { get; set; }
	
	
	private Player _player;
	
	private Rigidbody _rigidBody; 
	private Vector3 _previousRigidBodyPos;
	
	void Awake() {
		initCollectableItem();
		var weight = transform.Search("weight");
		if(weight != null) {
			_rigidBody = transform.Search("weight").GetComponent<Rigidbody>();
			if(_rigidBody != null) {
				Debug.Log("CollectableItem[ " + this.name + " ]/Awake, _rigidBody = " + _rigidBody);
				_previousRigidBodyPos = _rigidBody.position;
			}
		}
	}
	
	void Update() {
		if(_rigidBody != null) {
			if(_rigidBody.transform.position != _previousRigidBodyPos) {
				_previousRigidBodyPos = _rigidBody.position;
				Debug.Log("new rigidbody position = " + _rigidBody.position.y + ", position = " + this.transform.position.y);
				Vector3 curPos = this.transform.position;
				Vector3 newPos = new Vector3(curPos.x, _rigidBody.position.y, curPos.z);
//				this.transform.position = newPos;
			}
		}
	}
	
	void OnCollisionEnter(Collision target) {
		Debug.Log("CollectableItem[ " + this.name + " ]/OnCollisionEnter, target = " + target);
		
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
	 
	public void attachToBackpack() {
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
		
		// gravity
		/*
		_rigidBody = this.gameObject.AddComponent<Rigidbody>();
		_rigidBody.mass = 1;
		_rigidBody.collisionDetectionMode =  CollisionDetectionMode.ContinuousDynamic;
		*/
	}
	
}
