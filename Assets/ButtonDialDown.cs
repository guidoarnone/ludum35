using UnityEngine;
using System.Collections;

public class ButtonDialDown : MonoBehaviour {

	public Dial[] dials;

	public void activate() {
		foreach (Dial d in dials) {
			d.dialDown ();
		}
	}
}
