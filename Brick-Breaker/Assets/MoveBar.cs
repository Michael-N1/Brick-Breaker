using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// const float SPEED = 50;  // bar movement speed

public class MoveBar : MonoBehaviour
{
    public float speed = 50;  // TODO: remove the magic number
    void FixedUpdate()
    {
        float v = Input.GetAxisRaw("Horizontal");
        GetComponent<Rigidbody2D>().velocity = new Vector2(v, 0) * speed;
    }
}
