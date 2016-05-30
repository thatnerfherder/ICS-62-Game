using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed;
    public RectTransform healthTransform;
    private float cachedY;
    private float minXValue;
    private float maxXValue;
    private int currentHealth;

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

        rb.AddForce(movement * speed);
    }

    void Update()
    {
        if(transform.localScale.x > 0.75)
            transform.localScale += new Vector3(-0.001f, -0.001f, -0.001f);
        if (!onCD && currentHealth > 0)
        {
            StartCoroutine(CoolDownDmg());
            CurrentHealth -= 1;
        }

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
    }

    private float MapValues(float x, float inMin, float inMax, float outMin, float outMax)
    {
        return (x - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }


   
}
