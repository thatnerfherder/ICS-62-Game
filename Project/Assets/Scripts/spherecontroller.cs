using UnityEngine;
using System.Collections;

public class spherecontroller : MonoBehaviour
{

    public float speed;
    private Rigidbody rb;
    public GameObject target1;
    public GameObject target2;
    private GameObject currentTarget;

    // Use this for initialization
    void Start()
    {
        currentTarget = target1;
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        Vector3 normalizedDirection = (currentTarget.transform.position - rb.transform.position).normalized;
        Vector3 movement = new Vector3(normalizedDirection.x * speed, normalizedDirection.y * speed, normalizedDirection.z * speed);
        rb.AddForce(movement);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("end of hallway"))
        {
            currentTarget = target2;
        }
        else if(other.gameObject.CompareTag("beginning of hallway"))
        {
            currentTarget = target1;
        }
    }
}
