using UnityEngine;
using System.Collections;

public class SequenceManager : MonoBehaviour {

	public float blinkDelay;

	public StudioButton[] buttons;
	public int[] sequence;
	private int[] inputSequence;
	private int currentPos;
	private bool solved;

	public void Start() {
		solved = false;
		StartCoroutine (blinky());
		currentPos = 0;
		inputSequence = new int[sequence.Length];
	}

	public void getButtonPress(int pos) {
		inputSequence [currentPos] = pos;
		currentPos++;
		if (currentPos >= sequence.Length) {
			validateSequence ();
		}
	}

	public void validateSequence() {
		for (int i = 0; i < sequence.Length; i++) {
			if (inputSequence[i] != sequence[i]) {
				failSequence ();
				return;
			}
		}
		correctSequence ();
	}

	public void failSequence() {
		Debug.Log ("no " + inputSequence);
		currentPos = 0;
		foreach (StudioButton b in buttons) {
			b.unlockButton ();
		}
	}

	public void correctSequence() {
		Debug.Log ("yes");
		solved = true;
		foreach (StudioButton b in buttons) {
			b.win ();
		}
	}

	IEnumerator blinky() {
		
		yield return new WaitForSeconds (blinkDelay);
		foreach (StudioButton b in buttons) {
			b.blinkTexture ();
		}
		if (!solved) {
		StartCoroutine (blinky());
		}

	}
}
