using UnityEngine;
using System.Collections;

public class AngleDetector : MonoBehaviour {

	public float activeDistance;
	public Transform player;
	public BookScript book;

	public int angleNumber;
	private int previousNumber;
	// Use this for initialization
	void Start () {
		previousNumber = getAngleNumber ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance(player.position, transform.position) < activeDistance) {
			angleNumber = getAngleNumber ();
			if (previousNumber != angleNumber) {
				book.changeState (angleNumber);
				previousNumber = angleNumber;
			}
		}
	}

	int getAngleNumber(){
		Vector3 dir = player.position - transform.position;
		dir = this.transform.InverseTransformDirection(dir);
		float angle = Mathf.Atan2(dir.z, dir.x) * Mathf.Rad2Deg;
		angle += 180;
		return (int) angle / (360/8);
	}
}
