using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BoxManager : MonoBehaviour {

	public static BoxManager INSTANCE;
	public List<bool> boxes;

	void Start () {
		INSTANCE = this;
	}

	public void setSwitch(int index, bool value) {
		boxes [index] = value;
		this.check ();
	}

	private void check() {
		bool win = true;
		foreach(bool b in boxes) {
			win = win && b;
		}
		if (win) {
			this.win ();
		}
	}

	private void win() {
		//Implement
		Debug.Log("win!");
	}

}
