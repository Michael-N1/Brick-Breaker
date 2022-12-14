using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour
{
    static float DEFAULT_SPEED = 75f;

    private Rigidbody2D rigidBody;
    private Vector2 vecInitPos;
    private AudioSource audioSource;
    public float speed = DEFAULT_SPEED;

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
