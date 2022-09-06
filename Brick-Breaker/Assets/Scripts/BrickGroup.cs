using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickGroup : MonoBehaviour
{
    private GameManager manager = null;

    // Start is called before the first frame update
    void Start() {
        manager = FindObjectOfType<GameManager>();
    }

    private void OnDisable() {
        manager.UpdateLevel();  // spawns next level if needed
    }

    public void OnChildCollision() {
        if (transform.childCount <= 1) {  // ball collided with the last brick
            manager.DecrementBrickGroup();
            Destroy(gameObject);
        }
    }
}
