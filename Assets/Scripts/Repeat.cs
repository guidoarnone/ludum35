using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Repeat : MonoBehaviour {

	public List<float> rates;
	public List<float> initialValues;
	public List<float> finalValues;

	private Shapeshifter shapeshifter;

	void Start () {
		shapeshifter = this.GetComponent<Shapeshifter> ();
	}

	void Update () {
		this.repeat();
	}

	void repeat() {
		if (!shapeshifter.isOnTransition()) {
			shapeshifter.setShapeshift (this.initialValues);
			shapeshifter.startTransition (shapeshifter.makeTransitionsFromCurrentState (this.rates, this.finalValues));
		}
	}
}