using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private int nextLevelNum = 0;

    public GameObject[] blockGroups;

    /// <summary>
    /// This function spawns the next group of blocks, which makes a level.
    /// </summary>
    /// <returns>
    /// Amount of block groups in the level spawned, 
    /// or -1 if the game is over (no levels left)
    /// </returns>
    public int SpawnNextLevel() {
        if (nextLevelNum < blockGroups.Length) {
            Instantiate(blockGroups[nextLevelNum],
                        transform.position, Quaternion.identity);
            nextLevelNum++;
            return blockGroups[nextLevelNum - 1].transform.childCount;
        }
        return -1;
    }

    public int GetCurrLevelNum() {
        return nextLevelNum - 1;
    }
}
