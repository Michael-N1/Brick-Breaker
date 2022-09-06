using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private int livesLeft;
    public GameObject[] hearts;

    void Start () {
        livesLeft = hearts.Length;
    }

    /// <summary>
    /// decrement one life from the health bar
    /// </summary>
    /// <returns>amount of lives left (after decrementing)</returns>
    public int DecrementLife() {
        if (livesLeft > 0) {
            livesLeft--;
            Destroy(hearts[livesLeft]);
        }
        return livesLeft;
    }

}
