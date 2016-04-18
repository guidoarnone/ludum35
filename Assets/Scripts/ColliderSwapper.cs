using UnityEngine;
using System.Collections;

public class ColliderSwapper : MonoBehaviour {

	public Collider first;
	public Collider second;

	// Use this for initialization
	void Start () {
		gameObject.AddComponent (first.GetType());
	}

	public void swap(){
		Object.Destroy (gameObject.GetComponent<Collider> ());
		gameObject.AddComponent (second.GetType());
	}
}
