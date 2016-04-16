using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float cameraSpeed;

	private Vector3 lastMousePosition;

	private Camera cam;

	// Use this for initialization
	void Start () {
		cam = GetComponent<Camera> ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate() 
	{
		Vector3 fwd = transform.TransformDirection(Vector3.forward);

		if (Physics.Raycast (transform.position, fwd, 10)) {
			print ("There is something in front of the object!");
		}

	}
}
