using UnityEngine;
using System.Collections;

public abstract class CollisionSwitch : MonoBehaviour {

	public string tag;

	void OnTriggerEnter(Collider c) {
		if (c.tag.Equals (this.tag)) {
			this.executeEnter (c);
		}
	}

	void OnTriggerExit(Collider c) {
		if (c.tag.Equals (this.tag)) {
			this.executeExit (c);
		}
	}

	protected abstract void executeEnter(Collider c);
	protected abstract void executeExit(Collider c);

}
