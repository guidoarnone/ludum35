using UnityEngine;
using System.Collections;

public class EToStuff : MonoBehaviour {

	public float interactDistance;
	public Transform rayOrigin;

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.E) || Input.GetMouseButtonDown (0)) {
			Debug.Log ("interact");
			interact ();
		}
	}

	private void interact(){
		RaycastHit hit;

		Vector3 dir = transform.forward;
		int layer = 8;
		int layermask = 1 << layer;

		Physics.Raycast (rayOrigin.position, dir, out hit, interactDistance, layermask);
		Debug.DrawRay (rayOrigin.position, dir, Color.red, 5f);

		if (hit.transform != null && hit.transform.tag == "Button") {
			Debug.Log ("button");
			hit.transform.GetComponent<Button> ().pressButton ();
		}
	}
}
