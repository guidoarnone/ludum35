using UnityEngine;
using System.Collections;

public class ButtonDialUp : MonoBehaviour {

	public Dial[] dials;

	public void activate() {
		foreach (Dial d in dials) {
			d.dialUp ();
		}
	}
}
