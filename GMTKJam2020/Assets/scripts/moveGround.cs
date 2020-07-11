using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveGround : MonoBehaviour
{
    void Update()
    {
        transform.Translate(new Vector3(-4 * Time.deltaTime, 0, 0));
    }
}
