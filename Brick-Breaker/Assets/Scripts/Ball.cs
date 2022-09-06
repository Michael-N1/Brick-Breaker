using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private AudioSource audioSource;
    private Vector2 vecInitPos;
    private Bar bar;

    private bool isStatic = true; 
    public float speed = 75;  // TODO: remove magic number

    // Start is called before the first frame update
    void Start()
    {
        vecInitPos = transform.position;
        rigidBody = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();  // audio = BrickBreak
        bar = FindObjectOfType<Bar>();
    }

    /// <summary>
    /// Move ball with bar at the beginning of a level.
    /// </summary>
    void FixedUpdate() {
        if (isStatic) {
            transform.position = new Vector2(
                bar.gameObject.transform.position.x, transform.position.y);
        }
    }

    /// <summary>
    /// This method calculates where the ball hit the bar, and returns the
    /// relative horizontal position:
    /// -1 = left side of the bar
    ///  0 = center
    /// +1 = right
    /// </summary>
    float hitFactor(Vector2 ballPos, Vector2 barPos, float barWidth) {
        // multiply by 5 to make the angle steeper
        return (5 * (ballPos.x - barPos.x)) / barWidth;  
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.name == "Bar") {
            float hitPos = hitFactor(transform.position,
                other.transform.position,
                other.collider.bounds.size.x);
            
            // calculate new direction, normalized vector
            Vector2 dir = new Vector2(hitPos, 1).normalized;

            // change direction
            rigidBody.velocity = dir * speed;
        }
        else if (other.gameObject.name.StartsWith("Brick")) {
            audioSource.Play();
        }
    }

    public void Reset() {
        if (gameObject.activeSelf == false) {
            gameObject.SetActive(true);
        }
        transform.position = vecInitPos;
        rigidBody.velocity = Vector2.zero;
        isStatic = true;
    } 

    public void StartMovement() {
        rigidBody.velocity = Vector2.up * speed;
        isStatic = false;
    }

    public bool IsStatic() {
        return isStatic;
    }
    
}
