using UnityEngine;
using System.Collections;

public class Lock : MonoBehaviour {

	public int digits;
	public int password;
	public lockNumber[] numbers;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public bool tryOpen() {
		int multiplier = 1;
		int pass = 0;
		for (int i = 0; i < digits; i++) {
			pass += numbers[i].getNumber () * multiplier;
			multiplier *= 10;
		}

		if (pass == password) {
			return true;
		}
		return false;
	}
}
