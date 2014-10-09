using UnityEngine;
using System.Collections;

public class InventoryPickerTest : MonoBehaviour {
	// public GameObject[] inventoryItems; 
	public GameObject rabbit; 
	public GameObject dog; 

	private ItemViewer _itemViewer;

	// Use this for initialization
	void Start () {
		_itemViewer = GameObject.Find("itemViewer").GetComponent<ItemViewer>();

	}
	
	public void showRabbit() {
		GameObject bunny = (GameObject) Instantiate(rabbit, new Vector3(0,0,0), new Quaternion(0,0,0,0));
//		Debug.Log("show rabbit, center  = " + bunny.renderer.bounds.center);
		_itemViewer.addItem(bunny);
	}

	public void showDog() {
		Debug.Log("show dog");
		GameObject puppy = (GameObject) Instantiate(dog, new Vector3(0,0,0), new Quaternion(0,0,0,0));
//		Debug.Log("show rabbit, center  = " + puppy.renderer.bounds.center);
		_itemViewer.addItem(puppy);
	}

	public void clear() {
		_itemViewer.removeItem();
	}
}
