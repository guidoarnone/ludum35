using UnityEngine;
using System.Collections;

public class BoxSwitch : CollisionSwitch {

	public int boxIndex;

	protected override void executeEnter(Collider c) {
		BoxManager.INSTANCE.setSwitch (boxIndex, c.tag.Equals (this.tag));
	}

	protected override void executeExit(Collider c) {
		BoxManager.INSTANCE.setSwitch (boxIndex, false);
	}

}
