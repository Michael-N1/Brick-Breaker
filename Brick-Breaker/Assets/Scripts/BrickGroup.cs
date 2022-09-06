using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickGroup : MonoBehaviour
{
    private GameManager manager = null;
    protected int brickAmount;

    // Start is called before the first frame update
    void Start() {
        manager = FindObjectOfType<GameManager>();
        brickAmount = transform.childCount;
    }

    private void OnDisable() {
        manager.UpdateLevel();  // spawns next level if needed
    }

    public void OnChildCollision() {
        brickAmount--;
        if (brickAmount == 0) {  // ball collided with the last brick
            manager.DecrementBrickGroup();
            Destroy(gameObject);
        }
    }

}
