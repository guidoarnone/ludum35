using UnityEngine;
using System.Collections;

public class Lock : MonoBehaviour {

	public int digits;
	public int password;
	public Dial[] numbers;

	public bool tryOpen() {
		int multiplier = 1;
		int pass = 0;
		for (int i = 0; i < digits; i++) {
			pass += numbers[numbers.Length - i - 1].dialGet () * multiplier;
			multiplier *= 10;
			Debug.Log (numbers[numbers.Length - i - 1].dialGet ());
		}


		if (pass == password) {
			Debug.Log ("win");
			return true;

		}
		return false;

	}
}
