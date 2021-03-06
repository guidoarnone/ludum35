﻿using UnityEngine;
using System.Collections;

public class lockNumber : Dial {

	public Lock locky;

	public int startNumber;
	public int numbersNumber;
	public float rotationTime;

	private float startingTime;
	private float finishTime;
	private float currentAngle;
	private float desiredAngle;

	private int currentNumber;
	private int desiredNumber;

	private bool isRotating;

	// Use this for initialization
	void Start () {
		isRotating = false;
		currentNumber = startNumber;
		currentAngle = 0;
		dialSet (startNumber);
	}

	public override void dialUp() {
		if (!isRotating) {
			dialSet (currentNumber + 1);
		}
	}

	public override void dialDown() {
		if (!isRotating) {
			dialSet (currentNumber - 1);
		}
	}

	public override void dialSet(int toNumber) {
		startingTime = Time.time;
		finishTime = startingTime + rotationTime;
		desiredNumber = toNumber;
		//INVERT FOR DIAL SAFDASFPJFAJ
		desiredAngle = toNumber * (360f / numbersNumber);
		isRotating = true;
		StartCoroutine(Rotatiiing ());
	}

	public override int dialGet() {
		if (currentNumber >= 0) {
			return currentNumber % numbersNumber;
		}
		else {
			return numbersNumber + (currentNumber % numbersNumber);
		}

	}

	private void chageState() {
		locky.tryOpen ();
	}

	IEnumerator Rotatiiing() {

		float a = Mathf.LerpAngle (currentAngle, desiredAngle, (Time.time - startingTime) / rotationTime);

		transform.RotateAround(transform.position, transform.right, a - currentAngle);
		currentAngle = a;
		//transform.eulerAngles = currentAngle;

		yield return new WaitForSeconds (Time.deltaTime);

		if (Time.time >= finishTime) {
			currentNumber = desiredNumber;
			isRotating = false;
			chageState ();
		}
		else {
			StartCoroutine(Rotatiiing ());
		}
	}
}
