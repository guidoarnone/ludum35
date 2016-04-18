using UnityEngine;
using System.Collections;

public class EToStuff : MonoBehaviour {

	public Texture2D texel;
	public Texture2D button1;
	public Texture2D button2;
	public float interactDistance;
	public Transform rayOrigin;
	public bool openMenu;

	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.E) || Input.GetMouseButton (0)) {
			interact ();
		}
		if (Input.GetKeyDown (KeyCode.Escape)) {
			menu ();
		}
	}

	private void interact(){
		RaycastHit hit;

		Vector3 dir = transform.forward;
		int layer = LayerMask.NameToLayer ("Interactable");;
		int layermask = 1 << layer;

		Physics.Raycast (rayOrigin.position, dir, out hit, interactDistance, layermask);
		Debug.DrawRay (rayOrigin.position, dir, Color.red, 5f);

		if (hit.transform != null && hit.transform.tag == "Button") {
			hit.transform.GetComponent<Button> ().pressButton ();
		}
	}

	private void menu() {
		openMenu = !openMenu;
	}

	void OnGUI() {
		if (openMenu) {
			Rect rect = new Rect (Screen.width / 4f, Screen.height / 4f, Screen.width / 2f, Screen.height / 2f);
			GUI.Window (0, new Rect(Screen.width/4f, Screen.height/4f, Screen.width / 2f, Screen.height / 2f), test, "hey");

		}
	}

	void test(int windowID) {
		Rect rect = new Rect (0, 0, Screen.width / 2f, Screen.height / 2f);
		Rect rect2 = new Rect (Screen.width / 16f, Screen.height / 32f, Screen.width / 2.65f, Screen.height / 8f);
		Rect rect3 = new Rect (Screen.width / 16f, Screen.height / 11f + Screen.height / 4f, Screen.width / 2.65f, Screen.height / 8f);
		GUI.DrawTexture (rect, texel);
		if(GUI.Button(rect2, button1)){
			Debug.Log ("yes");
		}

		if(GUI.Button(rect3, button2)){
			Debug.Log ("yes");
		}
	}
}
