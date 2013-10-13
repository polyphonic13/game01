using UnityEngine;
using System.Collections;

public class InventoryItem
{
	public string name = "";
	public string description = "";
	
	public Texture iconTexture;
	public Texture detailTexture;

	public CollectableItem collectableItem;
	public string prefabName; 
	
	private GameObject _gameObj;
	private Player _player;


	public bool isInUse { get; set; }
	
	void Awake() {	
		isInUse = false;
		_player = GameObject.Find("player").GetComponent<Player>();
	}
	
	public virtual void use(bool handAttach = false) {
		if(!isInUse) {
			_gameObj = (GameObject)Instantiate(Resources.Load(prefabName));
			if(handAttach) {
				attachToHands(_gameObj.transform);
			} else {
				_gameObj.transform.position = _player.transform.position;
				_gameObj.transform.rotation = _player.transform.rotation;
				_gameObj.transform.parent = _player.transform;
			}	
			this.isInUse = true;
		}
	}
	
	public virtual void drop() {
		if(isInUse) {
			_gameObj.transform.parent = null;
		}
	}
	
	public virtual void store() {
		if(isInUse) {
			Destroy(_gameObj);
			this.isInUse = false;
		}
	}

	public void attachToHands(Transform transform) {
		var hand = Camera.main.transform.Search("right_hand");
		transform.position = hand.transform.position;
		transform.rotation = hand.transform.rotation;
		transform.parent = hand.transform;	
	}

}

