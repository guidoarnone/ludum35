using UnityEngine;
using System.Collections;

public class Key : Button {

	public int keyIndex;

	// Use this for initialization
	public override void pressButton () {
		GameObject player=GameObject.FindGameObjectWithTag ("Player");
		player.GetComponent<Inventory> ().setHasKey (true, keyIndex);
		this.gameObject.SetActive (false);
	}
}
