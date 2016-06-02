using UnityEngine;
using System.Collections;

public class Heart : MonoBehaviour {
	public int position;
	public bool up;
	//public bool down;

	void Start()
	{
		position = 1;
		up = true;
		//down = false
	}

	void Update () 
	{
		if (up) {
			Up ();
		} 
		else
		{
			Down ();
		}

		if (position == 0) 
		{
			up = true;
		}
		else if (position == 10)
		{
			up = false;
		}
		//Up ();
		//Down ();
		//Down ();
		//transform.Translate (new Vector3 (15, 30, 45) * Time.deltaTime);
	}

	void Up()
	{
		//for (int i = 0; i < 3; i++)
		transform.Translate (new Vector3 (0, 0, 1) * Time.deltaTime);
		position += 1;

	}
	void Down()
	{
		transform.Translate (new Vector3 (0, 0, -1) * Time.deltaTime);
		position -= 1;
	}
}