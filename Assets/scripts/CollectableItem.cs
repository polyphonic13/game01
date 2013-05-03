using UnityEngine;
using System.Collections;

public class CollectableItem : MonoBehaviour {
	
	public int interactDistance = 3;
	public bool collected = false;
	public Texture icon;
	public string description;
	
	void Awake() {}
	
	public virtual void OnMouseDown() {
		AddToInventory();
	}
	
	public void AddToInventory() {
		var player = GameObject.Find("player").GetComponent<Player>();
		player.inventory.AddItem(this);	
		Destroy(this.gameObject);
	}
}
