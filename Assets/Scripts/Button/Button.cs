﻿using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

	public float cooldown;
	public bool startsOn;
	protected bool activatable;

	public virtual void Start() {
		if (startsOn) {
			unlockButton ();
		} 
		else {
			activatable = false;
		}
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
