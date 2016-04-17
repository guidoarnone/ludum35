using UnityEngine;
using System.Collections;

public class Puerta : Button {

	int rotation=0;

	public int speed=10;
	public bool opened=false;

	public override void pressButton () {
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		Inventory inventory = player.GetComponent<Inventory> ();
		if (inventory.getHasKey ()) {
			opened = true;
			inventory.setHasKey (false);
		}
	}

	void Update(){
		if (rotation < 90 && opened) {
			transform.RotateAround (transform.right + transform.position, transform.up, speed);
			rotation += speed;
		}
	}
}
