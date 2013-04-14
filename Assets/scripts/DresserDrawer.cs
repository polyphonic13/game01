using UnityEngine;
using System.Collections;

public class DresserDrawer : MonoBehaviour {
	
	public int drawerIdx;
	bool isOpen = false;
	Dresser dresser;
	
	public void Awake() {
		getDresser();
	}
	
	private void getDresser() {
        Transform nextTransform = this.transform.parent;

        while (dresser == null && nextTransform != null)
        {
            dresser = nextTransform.GetComponent<Dresser>();
            nextTransform = this.transform.parent;
        }
		//Debug.Log("Bathroom/getBathroom, bathrrom = " + bathroom);
	} 
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseDown() {
		Debug.Log ("OnMouseDown, idx = " + drawerIdx + ", isOpen = " + isOpen);
		if(isOpen) {
			//dresser.transform.animation.Play(open_clip);
			dresser.CloseDrawer(drawerIdx);
			isOpen = false;
		} else {
			//dresser.transform.animation.Play(close_clip);
			dresser.OpenDrawer(drawerIdx);
			isOpen = true;
		}
	}
}
