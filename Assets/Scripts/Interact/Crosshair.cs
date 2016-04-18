using UnityEngine;
using System.Collections;

public class Crosshair : MonoBehaviour 
{
	public Texture2D crosshairTexture; 
	public Rect position; 
	static bool crossHair = true;

	void Start() 
	{
		position = new Rect((Screen.width - crosshairTexture.width) / 2, (Screen.height - crosshairTexture.height) /2, crosshairTexture.width, crosshairTexture.height);
	}

	void OnGUI() 
	{
		if(crossHair == true) 
			GUI.DrawTexture(position, crosshairTexture); 
	}
}