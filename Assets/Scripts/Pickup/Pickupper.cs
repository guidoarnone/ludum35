using UnityEngine;
using System.Collections;

public class Pickupper : MonoBehaviour {

	private Camera cam;
	private bool carrying;
	private GameObject carried;
	private int hangerslayerMask;

	public float distance = 3;
	public float force=10;

	// Use this for initialization
	void Start () {
		cam = GetComponent<Camera> ();
		hangerslayerMask = 1 << LayerMask.NameToLayer ("Hangers");
	}

	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			togglePickup ();
		} else if (carrying) {
			carry ();
		}
	}

	void carry(){
		Rigidbody body = carried.GetComponent<Rigidbody> ();
		body.velocity = Vector3.zero;
		body.angularVelocity = Vector3.zero;
		Vector3 actualForce = cam.transform.position + cam.transform.forward * distance-carried.transform.position;
		actualForce *= force*100;
		body.AddForce (actualForce);
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
					Rigidbody body = carried.GetComponent<Rigidbody> ();
					body.useGravity=false;
					Physics.IgnoreCollision (GetComponentInParent<Collider>(), carried.GetComponent<Collider>());
				}
			}
		}
	}

	void drop(){
		carrying = false;
		RaycastHit hit;
		if (Physics.Raycast (cam.transform.position, cam.transform.forward,out hit, 10,hangerslayerMask)) {
			Hanger hanger = hit.collider.GetComponent<Hanger> ();
			hanger.hang (carried);
		}
		Rigidbody body = carried.GetComponent<Rigidbody> ();
		body.useGravity=true;
		Physics.IgnoreCollision (GetComponentInParent<Collider>(), carried.GetComponent<Collider>(), false);
	}
}
