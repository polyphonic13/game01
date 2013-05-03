using UnityEngine;
using System.Collections;

public class CollectableItem : MonoBehaviour {
	
	public int interactDistance = 3;
	public bool collected = false;
	public Texture icon;
	public string description;
	
	Player player;
	
	void Awake() {
		player = GetComponent<Player>();
	}
	
	public void addToInventory() {
		Debug.Log("collectable item/add to inventory, this = " + this + ", inventory = " + player.inventory);
		//player.inventory.AddItem(this);	
	}
}
