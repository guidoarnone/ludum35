using UnityEngine;
using System.Collections;

public class ButtonDialDown : Button {

	public Dial[] dials;

	public override void pressButton() {
		if (activatable) {
			foreach (Dial d in dials) {
				d.dialDown ();
				lockButton (cooldown);
			}
		}
	}

	public override void lockButton (float time) {
		StartCoroutine (waitForIt(time));
		activatable = false;
	}

	public override void unlockButton () {
		activatable = true;
	}

	IEnumerator waitForIt(float t) {
		yield return new WaitForSeconds (t);
		unlockButton ();
	}
}
