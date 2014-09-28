using UnityEngine;
using System.Collections;

public class PlayerMeshController : MonoBehaviour {

	public float sensitivityY = 15F;

	public float minimumY = -60F;
	public float maximumY = 60F;
	
	public bool isEnabled = true;
	
	float rotationY = 0F;

	public GameObject head;

	// Use this for initialization
	void Start () {
		// Make the rigid body not change rotation
//		if (rigidbody)
//			rigidbody.freezeRotation = true;

	}
	
	// Update is called once per frame
	void Update () {
		if (isEnabled) {
			rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
			rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
			
			head.transform.localEulerAngles = new Vector3(-rotationY, head.transform.localEulerAngles.y, 0);

		}
	}
}
