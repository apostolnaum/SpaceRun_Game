using UnityEngine;
using System.Collections;

public class HitFinishLine : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider)
	{
				GameObject hitObj = collider.gameObject;

				if (hitObj.tag == "Player") {
			Rect buttonRect = new Rect(Screen.width * 0.35f, Screen.height * 0.60f, Screen.width * 0.30f, Screen.height * 0.1f);
			if (GUI.Button(buttonRect, "Start!"))
			{
				Application.LoadLevel (1);
			}
			Rect buttonRect1 = new Rect(Screen.width * 0.35f, Screen.height * 0.75f, Screen.width * 0.30f, Screen.height * 0.1f);
			if (GUI.Button(buttonRect1, "Quit?"))
			{
				Application.Quit();
			}
		}
}
}
