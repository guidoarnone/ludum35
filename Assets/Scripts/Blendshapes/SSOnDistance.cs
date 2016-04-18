using UnityEngine;
using System.Collections;

public class SSOnDistance : MonoBehaviour {


	public bool invert;
	public bool useSelf;
	public Transform origin;
	public Transform target;


	public int index;

	public float startDistance;
	public float endDistance;

	public float startValue;
	public float endValue;

	private float range;
	private Shapeshifter shapeshifter;

	void Start () {
		if (useSelf) {
			origin = gameObject.transform;
		}

		shapeshifter = GetComponent<Shapeshifter> ();

		if (invert) {
			float aux = startValue;
			startValue = endValue;
			endValue = aux;
		}

		range = startDistance - endDistance;
	}

	// Update is called once per frame
	void Update () {
		float distance = Vector3.Distance (origin.position, target.position);
		if (distance < startDistance) {
			if (!(distance < endDistance)) {
				shapeshifter.setShapeshift (index, (Mathf.Abs(distance - startDistance) / range + startValue) * 100f);
			}
		}
	}
}
