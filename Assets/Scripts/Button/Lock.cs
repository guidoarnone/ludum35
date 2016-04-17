using UnityEngine;
using System.Collections;

public class Lock : MonoBehaviour {

	public int digits;
	public int password;
	public Dial[] numbers;

	public void tryOpen() {
		int multiplier = 1;
		int pass = 0;
		for (int i = 0; i < digits; i++) {
			pass += numbers[numbers.Length - i - 1].dialGet () * multiplier;
			multiplier *= 10;
		}
			
		Debug.Log (pass);

		if (pass == password) {
			Debug.Log ("win");
			open ();

		}
	}

	private void open() {
	}
}
