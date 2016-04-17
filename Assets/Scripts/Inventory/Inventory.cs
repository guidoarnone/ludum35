using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour {

	public int keychainSize;
	public bool[] keys;

	public void Start() {
		keys = new bool[keychainSize];
		for (int i = 0; i < keychainSize; i++) {
			keys[i] = false;
		}
	}

	public void setHasKey(bool state, int index){
		keys [index] = state;
	}

	public bool getHasKey(int[] indexes){
		for (int i = 0; i < indexes.Length; i++) {
			if (keys [indexes[i]] == false) {
				return false;
			}
		}
		return true;
	}
}
