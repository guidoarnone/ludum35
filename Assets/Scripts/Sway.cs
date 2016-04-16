using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Sway : MonoBehaviour {

	public List<float> rates;
	public List<float> initialValues;
	public List<float> finalValues;
	private Shapeshifter shapeshifter;

	void Start () {
		shapeshifter = this.GetComponent<Shapeshifter> ();
		shapeshifter.setShapeshift (this.initialValues);
		shapeshifter.startSwayTransition (shapeshifter.makeTransitionsFromCurrentState (this.rates, this.finalValues));
	}
		
	
}