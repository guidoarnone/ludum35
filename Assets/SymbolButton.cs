using UnityEngine;
using System.Collections;

public class SymbolButton : Button {

	public int startSymbol;
	public Texture2D[] symbols;
	private int selectedIndex;

	public void Update() {
		if (Input.GetKeyDown (KeyCode.Space)) {
			pressButton ();
		}
	}

	public override void Start() {
		if (startsOn) {
			unlockButton ();
		} 
		else {
			activatable = false;
		}

		setSymbol (startSymbol);
	}

	public override void pressButton () {
		if (activatable) {
			setSymbol (selectedIndex+1);
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

	public void setSymbol(int index) {
		selectedIndex = index;
		Debug.Log ("symbol " + selectedIndex%symbols.Length);
		gameObject.GetComponent<Renderer> ().material.mainTexture = symbols[selectedIndex%symbols.Length];
	}

	IEnumerator waitForIt(float t) {
		yield return new WaitForSeconds (t);
		unlockButton ();
	}
}
