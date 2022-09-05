using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject startPanel;
    public GameObject levelTransitionPanel;
    public TMP_Text pressSpaceText;
    public TMP_Text levelClearedText;

    // Start is called before the first frame update
    void Start() {
        startPanel.SetActive(true);
        pressSpaceText.gameObject.SetActive(false);
        levelTransitionPanel.gameObject.SetActive(false);
    }

    public void StartButton() {
        startPanel.SetActive(false);
        pressSpaceText.gameObject.SetActive(true);
        FindObjectOfType<GameManager>().StartGame();
    }

    public void FinishLevel(int levelNum) {
        levelNum++;  // ++ because the levels are 0-indexed,
                     // unlike what the user expects
        levelClearedText.text = "You cleared level: " + levelNum.ToString();
        pressSpaceText.gameObject.SetActive(true);
        levelTransitionPanel.gameObject.SetActive(true);
    }

}
