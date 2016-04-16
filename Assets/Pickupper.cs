using UnityEngine;
using System.Collections;

public class Pickupper : MonoBehaviour {

	private Camera cam;
	private bool carrying;
	private GameObject carried;

	public float smooth;
	public float distance;

	// Use this for initialization
	void Start () {
		cam = GetComponent<Camera> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (carrying) {
			carry ();
		} else {
			pickup ();
		}
	}

	void carry(){
		Vector3 actualPos = cam.transform.position + cam.transform.forward * distance;
		carried.transform.position = Vector3.Lerp (carried.transform.position, actualPos, Time.deltaTime * smooth);
	}

	void pickup(){
		if (Input.GetMouseButtonDown (0)) {
			RaycastHit hit;
			if (Physics.Raycast (cam.transform.position, cam.transform.forward, out hit)) {
				Pickupable p = hit.collider.GetComponent<Pickupable>();
				if (p != null) {
					carrying = true;
					carried = p.gameObject;
				}
			}
		}
	}
}
