using UnityEngine;
using System.Collections;

public class Puerta : Button {

	public float openRotation = 90;
	public float closedRotation = 0;

	public float rotationTime = 10;
	public bool opened = false;
	public bool requiresKey;
	public int[] keysRequired;

	private float currentAngle;
	private float desiredAngle;

	private float startingTime;
	private float finishTime;

	public override void Start ()
	{
		if (startsOn) {
			unlockButton ();
		} 
		else {
			activatable = false;
		}
		startRotation ();
	}

	public override void pressButton () {
		if (activatable) {
			if (requiresKey) {
				GameObject player = GameObject.FindGameObjectWithTag ("Player");
				Inventory inventory = player.GetComponent<Inventory> ();
				if (inventory.getHasKey (keysRequired)) {
					opened = !opened;
					startRotation ();
				}
			} else {
				opened = !opened;
				startRotation ();
			}
			lockButton (cooldown);
		}
	}

	public override void lockButton (float time) {
		activatable = false;
		StartCoroutine (waitForIt(time));
	}

	public override void unlockButton () {
		activatable = true;
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

	IEnumerator waitForIt(float t) {
		yield return new WaitForSeconds (t);
		unlockButton ();
	}
}
