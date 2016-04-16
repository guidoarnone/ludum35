using UnityEngine;
using System.Collections;

public class Lock : MonoBehaviour {

	public int digits;
	public int password;
	public Dial[] numbers;

	//PONER LOCKS DE ATRAS PARA ADELANTE

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Space)) {
			tryOpen ();
		}
	}

	public bool tryOpen() {
		int multiplier = 1;
		int pass = 0;
		for (int i = 0; i < digits; i++) {
			pass += numbers[numbers.Length - i - 1].dialGet () * multiplier;
			multiplier *= 10;
		}

		if (pass == password) {
			return true;

		}
		return false;

	}
}
