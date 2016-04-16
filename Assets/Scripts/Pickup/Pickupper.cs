using UnityEngine;
using System.Collections;

public class Pickupper : MonoBehaviour {

	private Camera cam;
	private bool carrying;
	private GameObject carried;
	private int hangerslayerMask;

	public float smooth = 15;
	public float distance = 3;

	// Use this for initialization
	void Start () {
		cam = GetComponent<Camera> ();
		hangerslayerMask = 1 << LayerMask.NameToLayer ("Hangers");
	}

	void FixedUpdate () {
		if (Input.GetMouseButtonDown (0)) {
			togglePickup ();
		} else if (carrying) {
			carry ();
		}
	}

	void carry(){
		setKinematic (true);
		Vector3 actualPos = cam.transform.position + cam.transform.forward * distance;
		carried.transform.position = Vector3.Lerp (carried.transform.position, actualPos, Time.deltaTime * smooth);
	}

	void togglePickup(){
		if (carrying) {
			drop ();
		} else {
			RaycastHit hit;
			if (Physics.Raycast (cam.transform.position, cam.transform.forward, out hit)) {
				Pickupable p = hit.collider.GetComponent<Pickupable> ();
				if (p != null) {
					carrying = true;
					carried = p.gameObject;
				}
			}
		}
	}

	void setKinematic(bool kinematic){
		Rigidbody body = carried.GetComponent<Rigidbody> ();
		if (body != null) {
			body.isKinematic = kinematic;
		}
	}

	void drop(){
		carrying = false;
		setKinematic (false);
		RaycastHit hit;
		if (Physics.Raycast (cam.transform.position, cam.transform.forward,out hit, 10,hangerslayerMask)) {
			Hanger hanger = hit.collider.GetComponent<Hanger> ();
			hanger.hang (carried);
		}
	}
}
