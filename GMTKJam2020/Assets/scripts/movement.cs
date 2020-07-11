using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float moveSpd;
    public float moveLimit;
    public float maxMoveRight;
    public float maxMoveLeft;
    void Update()
    {
        move();
    }
    void move()
    {
        if (Input.GetAxisRaw("Horizontal") == 1 && moveLimit < maxMoveRight) // if holding right
        {
            moveLimit += 1; // adds 1 to the moveLimit every frame right is held (basically limits how far right char can go)
            transform.Translate(new Vector2(moveSpd * Time.deltaTime, 0)); // translate by moveSpd to the right
            transform.localScale = (new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z)); // sets char facing right
        }
        if (Input.GetAxisRaw("Horizontal") == -1 && moveLimit > maxMoveLeft) // if holding left
        {
            moveLimit -= 1; // subtracts 1 from the moveLimit every frame left is held (basically limits how far left char can go)
            transform.Translate(new Vector2(-moveSpd * Time.deltaTime, 0)); // translate by moveSpd to the left
            transform.localScale = (new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z)); // sets char facing left
        }
    }
}
