using UnityEngine;
using System.Collections;

public class AngleDetector : MonoBehaviour {

	private GameObject player;

	public int angleNumber;
	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		angleNumber = getAngleNumber ();
	}

	int getAngleNumber(){
		Vector3 dir = player.transform.position - transform.position;
		dir = this.transform.InverseTransformDirection(dir);
		float angle = Mathf.Atan2(dir.z, dir.x) * Mathf.Rad2Deg;
		angle += 180;
		return (int) angle / (360/8);
	}
}
