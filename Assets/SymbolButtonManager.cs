using UnityEngine;
using System.Collections;

public class SymbolButtonManager : MonoBehaviour {

	public SymbolButton[] buttons;
	public int[] sequence;
	private bool solved;

	public void Update() {
		if (Input.GetKeyDown (KeyCode.Space)) {
			validateSequence ();
		}
	}

	public void Start() {
		solved = false;
	}

	public void validateSequence() {
		if (!solved) {
			for (int i = 0; i < sequence.Length; i++) {
				if (buttons [i].getSymbol () != sequence [i]) {
					failSequence ();
					return;
				}
			}
			correctSequence ();
		}
	}

	public void failSequence() {
		foreach (SymbolButton b in buttons) {
			b.unlockButton ();
		}
	}

	public void correctSequence() {
		solved = true;
		foreach (SymbolButton b in buttons) {
			b.win ();
			Debug.Log ("Win");
		}
	}
}
