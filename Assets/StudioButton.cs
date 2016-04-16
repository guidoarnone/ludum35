using UnityEngine;
using System.Collections;

public class StudioButton : Button {

	public Texture2D noBlink;
	public Texture2D blink;
	public SequenceManager manager;
	public int pos;

	private bool on;

	public override void pressButton() {
	if (activatable) {
		lockButton (cooldown);
		manager.getButtonPress (pos);
		}
	}

	public override void lockButton (float time) {
		activatable = false;
		turnOn ();
	}

	public override void unlockButton () {
		activatable = true;
	}

	public void blinkTexture() {

		if (!activatable) {
			return;
		}

		on = !on;
		if (on) {
			turnOn ();
		} 
		else {
			turnOff();
		}
	}
		
	public void turnOn() {
		gameObject.GetComponent<Renderer> ().material.mainTexture = blink;
	}

	public void turnOff() {
		gameObject.GetComponent<Renderer> ().material.mainTexture = noBlink;
	}

	public void win() {
		Debug.Log ("win");
		gameObject.GetComponent<Renderer> ().material.mainTexture = noBlink;
		activatable = false;
	}
}
