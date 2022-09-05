using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    public BlockGroup prefabParent = null;
     
    void OnCollisionEnter2D(Collision2D other) {  // can only collide with ball
        prefabParent.OnChildCollision();
        Destroy(gameObject);
    }
}
