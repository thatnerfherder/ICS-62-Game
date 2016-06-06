using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SphereScript1 : MonoBehaviour {
	public TextMesh sphere;
	public string sphere1;
//	public string phrase1 = "Ugh, I'm so fat.";
//	public string phrase2 = "Come on, it's easy to fit through.";
//	public string phrase3 = "Maybe you shouldn't eat so much.";
	public int dialogueTime;
	public string[] phrases; 

	// Use this for initialization
	void Start () {
		//sphere1 = "";
		//dialogueTime = 0;
		//phrases = [phrase1, phrase2, phrase3];

	}

	void Awake()
	{
		StartCoroutine (Wait ());
	}

//	void FixedUpdate () {
//		for(int i = 0; i < phrases.Length; i++)
//		{
//			sphere1 = phrases[i];
//			Debug.Log(phrases[i]);
//			//StartCoroutine (Wait());
//		}
//	
//	}
	IEnumerator Wait()
	{
		//Debug.Log (phrases[1]);
		for(int i = 0; i < phrases.Length; i++)
		{
			sphere1 = phrases[i];
			sphere.text = sphere1;
			//Debug.Log(phrases[i]);
			yield return new WaitForSeconds(dialogueTime);
		}
		Awake (); // lol this is probably jank
}
}