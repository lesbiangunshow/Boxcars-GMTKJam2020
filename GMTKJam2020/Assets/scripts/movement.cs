using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpd;
    public bool leftBorder, rightBorder;
    [Header("Jumping")]
    public bool onGround;
    public float jSpd;
    public Rigidbody rb;
    public int jumpJuice; // stupid name but it is how many frames you can hold jump for before you stop ascending
    public float gravScale;
    public static float Gravity = -9.81f;
    [Header("Raycast Stuffs")]
    public float raycastLength;
    public LayerMask ground;
    void Update()
    {
        move();
        jump();
        jumpDetectionRaycast();
    }
    void FixedUpdate()
    {
        Vector3 gravity = Gravity * gravScale * Vector3.up; // gravity stuffs
        rb.AddForce(gravity, ForceMode.Acceleration); // adding the gravity
    }
    void move()
    {
        if (Input.GetAxisRaw("Horizontal") == 1 && !rightBorder) // if holding right, if not in right border
        {
            transform.Translate(new Vector2(moveSpd * Time.deltaTime, 0)); // translate by moveSpd to the right
            transform.localScale = (new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z)); // sets char facing right
        }
        if (Input.GetAxisRaw("Horizontal") == -1 && !leftBorder) // if holding left, if not in left border
        {
            transform.Translate(new Vector2(-moveSpd * Time.deltaTime, 0)); // translate by moveSpd to the left
            transform.localScale = (new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z)); // sets char facing left
        }
    }
    void jump()
    {
        jumpJuice -= 1; // subtract jump juice every frame
        if (Input.GetButton("Jump") && jumpJuice > 0) // if you press jump and have jump juice still
        {
            rb.velocity = new Vector3(rb.velocity.x, jSpd, rb.velocity.z); // set jump velocity
        }
        if (Input.GetButtonUp("Jump")) // when you release jump
        {
            jumpJuice = 0; // no more jump juice
        }
        if (jumpJuice <= 0) // if you have no jump juice left
        {
            gravScale = 4; // more gravity for faster fall (feels good i swear)
        }

    }
    void jumpDetectionRaycast()
    {
        if (Physics.Raycast(transform.position, Vector3.down, raycastLength, ground)) // casts a ray down of raycastLength distance that only returns info if it hits ground
        {
            gravScale = 1; // normal gravity
            jumpJuice = 30; // you are on ground so you have full juice
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "left border")
        {
            leftBorder = true;
        }
        if (collision.gameObject.tag == "right border")
        {
            rightBorder = true;
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "left border")
        {
            leftBorder = false;
        }
        if (collision.gameObject.tag == "right border")
        {
            rightBorder = false;
        }
    }
}
