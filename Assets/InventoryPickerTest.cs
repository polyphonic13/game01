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
	
	// Update is called once per frame
	void Update () {
	
	}

	public void showRabbit() {
		Debug.Log("show rabbit");
		GameObject bunny = (GameObject) Instantiate(rabbit, new Vector3(0,0,0), new Quaternion(0,0,0,0));
		_itemViewer.addItem(bunny);
	}

	public void showDog() {
		Debug.Log("show dog");
		GameObject puppy = (GameObject) Instantiate(dog, new Vector3(0,0,0), new Quaternion(0,0,0,0));
		_itemViewer.addItem(puppy);
	}

	public void clear() {
		_itemViewer.removeItem();
	}
}
