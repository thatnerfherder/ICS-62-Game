using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public float speed;
    public RectTransform healthTransform;
    private float cachedY;
    private float minXValue;
    private float maxXValue;
    public int currentHealth;
	//private float currentSpeed;

    private int CurrentHealth
    {
        get { return currentHealth; }
        set {
            currentHealth = value;
            HandleHealth();
        }
    }
    public int maxHealth;
    public Image visualHealth;
    public float coolDown;
    private bool onCD;

    private Rigidbody rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
		rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY;;

        cachedY = healthTransform.position.y;
        maxXValue = healthTransform.position.x;
        minXValue = healthTransform.position.x - healthTransform.rect.width;
        currentHealth = maxHealth;
        onCD = false;
	
	}

	// Update is called once per frame

	void FixedUpdate () {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

		//currentSpeed += idk
        rb.AddForce(movement * speed);

    }

    void Update()
    {
        //HandleMovement();
		if(transform.localScale.x > 1.2)
            transform.localScale += new Vector3(-0.001f, -0.001f, -0.001f);
		if (!onCD && currentHealth > 0) {
			StartCoroutine (CoolDownDmg ());
			CurrentHealth -= 1;
		} 
		///if (currentHealth == 0)
		{
		///	SceneManager.LoadScene ("_Scene/room");
		}
        ///
    }

    private void HandleHealth()
    {
        float currentXValue = MapValues(currentHealth, 0, maxHealth, minXValue, maxXValue);

        healthTransform.position = new Vector3(currentXValue, cachedY);

        if(currentHealth > maxHealth / 2)//more than 50%
        {
            visualHealth.color = new Color32((byte)MapValues(currentHealth, maxHealth / 2, maxHealth, 255, 0), 255, 0, 255);
        }
        else//less than 50%
        {
            visualHealth.color = new Color32(255, (byte)MapValues(currentHealth, 0, maxHealth / 2, 0, 255), 0, 255);
        }
    }

    IEnumerator CoolDownDmg()
    {
        onCD = true;
        yield return new WaitForSeconds(coolDown);
        onCD = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Capsule"))
        {
            Destroy(other.gameObject);
            transform.localScale += new Vector3(.1f, .1f, .1f);
            if(currentHealth < maxHealth)
            {
                StartCoroutine(CoolDownDmg());
				if (CurrentHealth + 25 <= 100)
					CurrentHealth += 25;
				else
					CurrentHealth = 100;
            }
        }
		if (other.gameObject.CompareTag ("backpack")) 
		{
			SceneManager.LoadScene("_Scene/hallway");
		}
    }

    private float MapValues(float x, float inMin, float inMax, float outMin, float outMax)
    {
        return (x - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }

    private void HandleMovement()
    {
        float translation = speed * Time.deltaTime;

        transform.Translate(new Vector3(Input.GetAxis("Horizontal") * translation, 0, Input.GetAxis("Vertical") * translation));
    }
}
