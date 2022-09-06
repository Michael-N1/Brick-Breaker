using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private int currLevel = -1;

    public GameObject[] levels;

    /// <summary>
    /// This function spawns the next group of bricks, which makes a level.
    /// </summary>
    /// <returns>
    /// Amount of brick groups in the level spawned, 
    /// or -1 if the game is over (no levels left)
    /// </returns>
    public int SpawnNextLevel() {
        if (currLevel + 1 < levels.Length) {
            currLevel++;
            Instantiate(levels[currLevel],
                        transform.position, Quaternion.identity);
            levels[currLevel].SetActive(true);
            return levels[currLevel].transform.childCount;
        }
        return -1;
    }

    public int GetCurrLevelNum() {
        return currLevel;
    }
}
