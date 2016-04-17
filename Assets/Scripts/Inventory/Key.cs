using UnityEngine;
using System.Collections;

public class Key : Button {

	// Use this for initialization
	public override void pressButton () {
		GameObject player=GameObject.FindGameObjectWithTag ("Player");
		player.GetComponent<Inventory> ().setHasKey (true);
		this.gameObject.SetActive (false);
	}
}
