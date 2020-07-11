using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item : MonoBehaviour
{
    private Rigidbody rb;
    public float xStartVelo; // starting x velocity (SHOULD BE NEGATIVE)
    public float yStartVelo; // starting y velocity
    public float xVelo; // x velocity after initial 
    public float yHitGroundVelo; // set to 0 if it should travel along the ground
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(xStartVelo, yStartVelo, 0);
    }

    void Update()
    {
        rb.velocity = new Vector3(xVelo, rb.velocity.y, rb.velocity.z);
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 8)
        {
            rb.velocity = new Vector3(xVelo, yHitGroundVelo, rb.velocity.z);
        }
        if (collision.gameObject.tag == "ITEM DESTROYER")
        {
            Destroy(gameObject);
        }
    }
}
