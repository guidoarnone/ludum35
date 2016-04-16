using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Sway : MonoBehaviour {

	public List<float> rates;
	public List<float> initialValues;
	public List<float> finalValues;

	private Shapeshifter shapeshifter;
	private int iterator = 0;

	void Start () {
		shapeshifter = this.GetComponent<Shapeshifter> ();
		shapeshifter.setShapeshift (this.initialValues);
		shapeshifter.startTransition (shapeshifter.makeTransitionsFromCurrentState (this.rates, this.finalValues));
	}
	
	void Update () {
		if (!shapeshifter.isOnTransition()) {
			this.invert ();
			Debug.Log (this.finalValues[0]);
			shapeshifter.setShapeshift (this.initialValues);
			shapeshifter.startTransition (shapeshifter.makeTransitionsFromCurrentState (this.rates, this.finalValues));
		}
	}

	public void invert() {
		for (int i = 0; i < rates.Count; i++) {
			rates [i] *= -1;
		}
		List<float> auxiliar = initialValues;
		this.initialValues = this.finalValues;
		this.finalValues = auxiliar;
	}
	
}