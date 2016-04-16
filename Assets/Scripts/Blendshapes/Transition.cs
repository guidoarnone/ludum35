using UnityEngine;
using System.Collections;

public class Transition {

	private float initialValue;
	private float currentValue;
	private float rate;
	private float finalValue;

	public Transition() {
		this.initialValue = 0f;
		this.currentValue = 0f;
		this.rate = 0f;
		this.finalValue = 0f;
	}

	public Transition(float i, float r, float f) {
		this.initialValue = i;
		this.currentValue = this.initialValue;
		this.rate = r;
		this.finalValue = f;
	}

	public void setInitialValue(float v) {
		this.initialValue = v;
	}

	public float getInitialValue() {
		return this.initialValue;
	}

	public void setCurrentValue(float v) {
		this.currentValue = v;
	}

	public float getCurrentValue() {
		return this.currentValue;
	}

	public void setRate(float r) {
		this.rate = r;
	}

	public float getRate() {
		return this.rate;
	}

	public void setFinalValue(float v) {
		this.finalValue = v;
	}

	public float getFinalValue() {
		return this.finalValue;
	}

}
