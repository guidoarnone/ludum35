using UnityEngine;
using System.Collections;

public class lockNumber : MonoBehaviour {

	public int DEBUGNUMBER;
	public int currentNum;

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
		currentNumber = DEBUGNUMBER;
		setNumber (DEBUGNUMBER);
	}

	void Update () {
		if (Input.GetKey(KeyCode.Space)) {
			nextNumber ();
		}
		currentNum = getNumber();
	}

	public void prevNumber() {
		setNumber (currentNumber - 1);
	}

	public void nextNumber() {
		setNumber (currentNumber + 1);
	}

	public void setNumber(int toNumber) {
		startingAngle = transform.eulerAngles;
		startingTime = Time.time;
		finishTime = startingTime + rotationTime;
		desiredNumber = toNumber;
		desiredRotation = toNumber * 360f / numbersNumber;
		StartCoroutine(Rotatiiing ());
	}

	public int getNumber() {
		return currentNumber % numbersNumber;
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

	private float interFunction(float value) {
		return 0;
	}

}
