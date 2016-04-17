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
		turnOff ();
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
		on = true;
	}

	public void turnOff() {
		gameObject.GetComponent<Renderer> ().material.mainTexture = noBlink;
		on = false;
	}

	public void win() {
		gameObject.GetComponent<Renderer> ().material.mainTexture = noBlink;
		activatable = false;
	}
}
