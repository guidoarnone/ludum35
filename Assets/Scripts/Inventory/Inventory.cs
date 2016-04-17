using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour {

	public bool hasKey;

	public void setHasKey(bool hasKey){
		this.hasKey = hasKey;
	}

	public bool getHasKey(){
		return hasKey;
	}
}
