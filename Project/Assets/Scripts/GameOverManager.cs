using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public PlayerController playerHealth; // Reference to the player's health.
	 float restartDelay = 1.5f;
	public static bool diedOnce = false;



    Animator anim;                          // Reference to the animator component.
    float restartTimer;

    void Awake()
    {
        // Set up the reference.
        anim = GetComponent<Animator>();
    }



    void Update()
    {
        // If the player has run out of health...
        if (playerHealth.currentHealth <= 0)
        {
			playerHealth.currentHealth = 0;
			playerHealth.speed = 0;
			diedOnce = true;
            // ... tell the animator the game is over.
            anim.SetTrigger("GameOver");

            restartTimer += Time.deltaTime;

			if (restartTimer >= restartDelay) 
			{
				SceneManager.LoadScene ("_Scene/room");
			}

            // quit button stuff, needs some work
				//if (restartTimer >= restartDelay)
            {
                // .. then reload the currently loaded level.
                //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}