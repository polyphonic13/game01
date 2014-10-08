using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GridItem : MonoBehaviour {
	
	public bool isOccupied = false;
	public GameObject icon;
	public GameObject name;
	
	private Text nameTxt;
	private Image iconImg;
	
	// Use this for initialization
	void Start () {
		nameTxt = name.GetComponent<Text>();
		iconImg = icon.GetComponent<Image>();
		//		Debug.Log(this.gameObject.name + "/Start, nameTxt = " + nameTxt + ", iconImg = " + iconImg);
		name.SetActive(false);
		icon.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void addItem(string n, Sprite s) {
		name.SetActive(true);
		icon.SetActive(true);
		nameTxt.text = n;
		
		if(s != null) {
			iconImg.sprite = s;
		}
	}
}
