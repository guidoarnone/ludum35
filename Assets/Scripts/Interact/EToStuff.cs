﻿using UnityEngine;
using System.Collections;

public class EToStuff : MonoBehaviour {

	public float interactDistance;
	public Transform rayOrigin;

	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.E) || Input.GetMouseButton (0)) {
			interact ();
		}
	}

	private void interact(){
		RaycastHit hit;

		Vector3 dir = transform.forward;
		int layer = LayerMask.NameToLayer ("Interactable");;
		int layermask = 1 << layer;

		Physics.Raycast (rayOrigin.position, dir, out hit, interactDistance, layermask);
		Debug.DrawRay (rayOrigin.position, dir, Color.red, 5f);

		if (hit.transform != null && hit.transform.tag == "Button") {
			hit.transform.GetComponent<Button> ().pressButton ();
		}
	}
}
