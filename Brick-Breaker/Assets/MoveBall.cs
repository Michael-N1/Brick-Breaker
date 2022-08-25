using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBall : MonoBehaviour
{
    public float speed = 75;  // TODO: remove magic number

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
    }

    /// <summary>
    /// This method calculates where the ball hit the bar, and returns the
    /// relative horizontal position:
    /// -1 = left side of the bar
    ///  0 = center
    /// +1 = right
    /// </summary>

    float hitFactor(Vector2 ballPos, Vector2 barPos, float barWidth) {
        return (10 * (ballPos.x - barPos.x)) / barWidth;  // multiply by 10 to make the angle steeper
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.name == "Bar") {
            float hitPos = hitFactor(transform.position,
                other.transform.position,
                other.collider.bounds.size.x);
            
            // calculate new direction, normalized vector
            Vector2 dir = new Vector2(hitPos, 1).normalized;

            // change direction
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }
    }

        
    
}
