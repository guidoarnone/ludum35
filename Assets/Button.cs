using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

	public float cooldown;
	protected bool activatable;

	public void Start() {
		activatable = false;
	}

	// Use this for initialization
	public virtual void pressButton () {
	
	}

	public virtual void lockButton (float time) {

	}

	public virtual void unlockButton () {

	}

	public virtual void blinkButton () {

	}
}
