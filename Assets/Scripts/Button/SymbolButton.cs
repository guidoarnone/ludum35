using UnityEngine;
using System.Collections;

public class SymbolButton : Button {

	public int startSymbol;
	public Texture2D[] symbols;
	private int selectedIndex;

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
		gameObject.GetComponent<Renderer> ().material.mainTexture = symbols[selectedIndex%symbols.Length];
	}

	public int getSymbol() {
		return selectedIndex;
	}

	IEnumerator waitForIt(float t) {
		yield return new WaitForSeconds (t);
		unlockButton ();
	}

	public void win() {
		Debug.Log ("Win");
		activatable = false;
	}
}
