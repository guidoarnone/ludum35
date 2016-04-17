using UnityEngine;
using System.Collections;

public class Puerta : Button {

	public float openRotation = 90;
	public float closedRotation = 0;

	public float rotationTime = 10;
	public bool opened = false;
	public bool requiresKey;

	private float currentAngle;
	private float desiredAngle;

	private float startingTime;
	private float finishTime;

	public override void Start ()
	{
		startRotation ();
	}

	public override void pressButton () {

		if (requiresKey) {
			GameObject player = GameObject.FindGameObjectWithTag ("Player");
			Inventory inventory = player.GetComponent<Inventory> ();
			if (inventory.getHasKey ()) {
				opened = !opened;
				startRotation ();
			}
		} 

		else {
			opened = !opened;
			startRotation ();
		}
	}

	private void startRotation () {
		startingTime = Time.time;
		finishTime = startingTime + rotationTime;
		if (opened) {
			desiredAngle = openRotation;
		}
		else {
			desiredAngle = closedRotation;
		}
		StartCoroutine (Rotatiiing());
	}

	IEnumerator Rotatiiing() {

		float a = Mathf.LerpAngle (currentAngle, desiredAngle, (Time.time - startingTime) / rotationTime);

		transform.RotateAround(transform.position, transform.up, a - currentAngle);
		currentAngle = a;
		//transform.eulerAngles = currentAngle;

		yield return new WaitForSeconds (Time.deltaTime);

		if (!(Time.time >= finishTime)) {
			StartCoroutine(Rotatiiing ());
		}
	}
}
