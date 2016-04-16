using UnityEngine;
using System.Collections;

public class lockNumber : Dial {

	public int startNumber;
	public int numbersNumber;
	public float rotationTime;

	private float startingTime;
	private float finishTime;

	private int currentNumber;
	private int desiredNumber;
	private float desiredRotation;
	private Vector3 startingAngle;

	// Use this for initialization
	void Start () {
		currentNumber = startNumber;
		dialSet (startNumber);
	}

	public override void dialUp() {
		dialSet (currentNumber + 1);
	}

	public override void dialDown() {
		dialSet (currentNumber - 1);
	}

	public override void dialSet(int toNumber) {
		startingAngle = transform.eulerAngles;
		startingTime = Time.time;
		finishTime = startingTime + rotationTime;
		desiredNumber = toNumber;
		desiredRotation = toNumber * 360f / numbersNumber;
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

	IEnumerator Rotatiiing() {

		Vector3 targetAngle = new Vector3(0f, desiredRotation, 0f);
		Vector3 currentAngle = transform.eulerAngles;

		currentAngle = new Vector3(
			Mathf.LerpAngle(startingAngle.x, targetAngle.x, (Time.time - startingTime) / rotationTime),
			Mathf.LerpAngle(startingAngle.y, targetAngle.y, (Time.time - startingTime) / rotationTime),
			Mathf.LerpAngle(startingAngle.z, targetAngle.z, (Time.time - startingTime) / rotationTime));

		transform.eulerAngles = currentAngle;

		yield return new WaitForSeconds (Time.deltaTime);

		if (Time.time >= finishTime) {
			transform.eulerAngles = targetAngle;
			currentNumber = desiredNumber;
		}
		else {
			StartCoroutine(Rotatiiing ());
		}
	}
}
