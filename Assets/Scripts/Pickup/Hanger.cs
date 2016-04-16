using UnityEngine;
using System.Collections;

public class Hanger : MonoBehaviour {

	private GameObject hanged;
	// Use this for initialization
	void Start () {
		gameObject.layer = LayerMask.NameToLayer ("Hangers");
	}

	// Update is called once per frame
	void Update () {

	}

	public void hang(GameObject obj){
		hanged=obj;
		hanged.transform.position=transform.position;
		Rigidbody body = hanged.GetComponent<Rigidbody> ();
		if (body != null) {
			body.isKinematic = true;
		}
	}
}
