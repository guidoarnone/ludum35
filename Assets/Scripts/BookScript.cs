using UnityEngine;
using System.Collections;

public class BookScript : MonoBehaviour {

	public float waitTime;
	public Animator anima;
	public AngleDetector angle;
	public int maxPages;

	public int currentPage;
	public int startingPage; 

	public Texture2D[] pages;

	public int desiredPage;
	private bool busy = false;

	public void changeState(int page) {
		desiredPage = page;
		if (!busy) {
			busy = true;
			evaluate ();
		}
	}

	private void evaluate() {
		if (desiredPage != currentPage) {
			if (desiredPage != 0 && desiredPage != maxPages) {
				if (desiredPage < currentPage) {
					turnLeft ();
				} 
				else {
					turnRight ();
				}
			} 

			else {
				Debug.Log ("Else");
				if (desiredPage == 0) {
					specTurnRight ();
				} 
				else {
					specTurnLeft ();
				}
			}
		} 
		else {
			busy = false;
		}
	}

	private void turnLeft() {
		if (currentPage == 0) {
			currentPage = maxPages - 1;
		} 
		else {
			currentPage--;
		}
		anima.Play ("Left");
		StartCoroutine(waitForIt (waitTime));
	}

	private void specTurnLeft() {
		currentPage = maxPages - 1;
		anima.Play ("Left");
		StartCoroutine(waitForIt (waitTime));
	}

	private void turnRight() {
		currentPage = (currentPage + 1) % maxPages;
		anima.Play ("Right");
		StartCoroutine(waitForIt (waitTime));
	}

	private void specTurnRight() {
		currentPage = 0;
		anima.Play ("Right");
		StartCoroutine(waitForIt (waitTime));
	}

	private void changeTexture() {
	}

	IEnumerator waitForIt(float t) {
		yield return new WaitForSeconds (t);
		Debug.Log ("waiting");
		changeTexture ();
		evaluate ();
	}
}
