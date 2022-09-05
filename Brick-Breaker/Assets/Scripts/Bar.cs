using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// const float SPEED = 50;  // bar movement speed

public class Bar : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private Vector2 vecInitPos;
    private AudioSource audioSource;
    public float speed = 50;  // TODO: remove the magic number

    void Awake() {  // using awake since it runs before FixedUpdate(), unlike Start
        rigidBody = GetComponent<Rigidbody2D>();
        vecInitPos = transform.position;
        audioSource = GetComponent<AudioSource>();  // audio = BrickBreak
    }

    void FixedUpdate() {
        float v = Input.GetAxisRaw("Horizontal");
        rigidBody.velocity = new Vector2(v, 0) * speed;
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.name == "Ball") { 
            audioSource.Play();
        }
    }

    public void Reset() {
        if (gameObject.activeSelf == false) {
            gameObject.SetActive(true);
        }
        transform.position = vecInitPos;
    } 
}
