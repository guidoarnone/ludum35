using UnityEngine;
using System.Collections;

public class Dial : MonoBehaviour {

	public virtual void dialUp() {
	}

	public virtual void dialDown() {
	}

	public virtual void dialSet(int toNumber) {
	}

	public virtual int dialGet() {
		return 0;
	}

}
