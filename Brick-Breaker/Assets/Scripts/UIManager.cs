using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject startPanel;
    public GameObject levelTransitionPanel;
    public GameObject endPanel;
    public TMP_Text pressSpaceText;
    public TMP_Text levelClearedText;
    public TMP_Text pausedText;

    // Start is called before the first frame update
    void Start() {
        startPanel.SetActive(true);
        pressSpaceText.gameObject.SetActive(false);
        levelTransitionPanel.gameObject.SetActive(false);
        pausedText.gameObject.SetActive(false);
        endPanel.SetActive(false);
    }

    public void StartButton() {
        startPanel.SetActive(false);
        pressSpaceText.gameObject.SetActive(true);
        FindObjectOfType<GameManager>().StartNextLevel();
    }

    public void FinishLevel(int levelNum) {
        levelNum++;  // ++ because the levels are 0-indexed,
                     // unlike what the user expects
        levelClearedText.text = "You cleared level: " + levelNum.ToString();
        pressSpaceText.gameObject.SetActive(true);
        levelTransitionPanel.gameObject.SetActive(true);
    }

    public void Pause(bool pause) {
        if (pause) {
            pausedText.gameObject.SetActive(true);
        }
        else {  // resume
            pausedText.gameObject.SetActive(false);
        }
    }

    public void EndGame() {
        endPanel.SetActive(true);
    }
}
