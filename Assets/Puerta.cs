using UnityEngine;
using System.Collections;

public class Puerta : Button {
	
	public override void pressButton () {
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		Inventory inventory = player.GetComponent<Inventory> ();
		if (inventory.getHasKey ()) {
			transform.RotateAround (transform.up, transform.up, 180);
			inventory.setHasKey (false);
		}
	}

}
