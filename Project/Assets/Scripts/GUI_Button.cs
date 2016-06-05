using UnityEngine;
using System.Collections;

public class GUI_Button : MonoBehaviour {

	public static int buttonClicks;
	public PlayerController playerHealth;
	public Texture2D buttonImage = null;
	private System.Random rnd = new System.Random();
	private Rect position = new Rect (Screen.width - 200, Screen.height - 100, 150, 75);
	//private GUI_Button theButton = GUI.Button (position, buttonImage);
	public static bool buttonPressed = false;
	public int responseTime;


//	void FixedUpdate()
//	{
//		Debug.Log (buttonClicks);
//	}

	void OnGUI()
	{
		if (playerHealth.currentHealth > 0 && GameOverManager.diedOnce) {
			if (GUI.Button (position, buttonImage)) 
			{
				buttonClicks += 1;
				position.x = rnd.Next (100, Screen.width - 200);
				position.y = rnd.Next (100, Screen.height - 100);
				StartCoroutine (ButtonPressed ());
			}
		}


	}

	IEnumerator ButtonPressed()
	{
		buttonPressed = true;
		yield return new WaitForSeconds(responseTime);
		buttonPressed = false;
	}
}
