using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GUI_Button : MonoBehaviour {

	public static int buttonClicks;
	public PlayerController playerHealth;
	public Texture2D buttonImage = null;
	private System.Random rnd = new System.Random();
	private Rect position = new Rect (Screen.width - 200, Screen.height - 100, 150, 75);
	//private GUI_Button theButton = GUI.Button (position, buttonImage);
	public static bool buttonPressed = false;
	public int responseTime;
	public GameObject trigger; 
	//public OnEnableNarrationTrigger onEnable;


//	void FixedUpdate()
//	{
//		Debug.Log (buttonClicks);
//	}

//	void Awake()
//	{
//		onEnable = GetComponent<OnEnableNarrationTrigger> ();
//	}

	void OnGUI()
	{
		if (playerHealth.currentHealth > 0 && GameOverManager.diedOnce && buttonClicks < 10) {
			if (GUI.Button (position, buttonImage)) 
			{
				buttonClicks += 1;
				position.x = rnd.Next (100, Screen.width - 200);
				position.y = rnd.Next (100, Screen.height - 100);
				//ButtonPressed ();
				StartCoroutine (ButtonPressed ());
			}
		}
		if (buttonClicks >= 10)
			SceneManager.LoadScene ("_Scene/THE ROOM");

	}

//	void ButtonPressed()
//	{
//		trigger.gameObject.SetActive (true);
//		trigger.gameObject.SetActive (false);
//
//	}

	IEnumerator ButtonPressed()
	{
		trigger.gameObject.SetActive (true);
		yield return new WaitForSeconds(responseTime);
		trigger.gameObject.SetActive (false);
	}
}
