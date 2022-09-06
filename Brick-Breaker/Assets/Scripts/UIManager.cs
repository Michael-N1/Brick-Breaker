using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    private GameManager gameManager;

    public GameObject startPanel;
    public GameObject levelTransitionPanel;
    public GameObject victoryPanel;
    public GameObject lossPanel;
    public GameObject muteAudioToggle;
    

    public TMP_Text pressSpaceText;
    public TMP_Text levelClearedText;
    public TMP_Text pausedText;

    // Start is called before the first frame update
    void Start() {
        gameManager = FindObjectOfType<GameManager>();
        startPanel.SetActive(true);
    }

    public void StartButton() {
        startPanel.SetActive(false);
        muteAudioToggle.SetActive(false);
        pressSpaceText.gameObject.SetActive(true);
        gameManager.healthBar.gameObject.SetActive(true);
        gameManager.StartNextLevel();
    }

    public void FinishLevel(int levelNum) {
        levelNum++;  // ++ because the levels are 0-indexed,
                     // unlike what the user expects
        levelClearedText.text = "You cleared level " + levelNum.ToString();
        pressSpaceText.gameObject.SetActive(true);
        levelTransitionPanel.gameObject.SetActive(true);
    }

    public void Pause(bool pause) {
        if (pause) {
            pausedText.gameObject.SetActive(true);
            muteAudioToggle.SetActive(true);
        }
        else {  // resume
            pausedText.gameObject.SetActive(false);
            muteAudioToggle.SetActive(false);
        }
    }

    public void EndGame(bool isVictory) {
        if (isVictory) {
            victoryPanel.SetActive(true);
        }
        else {
            lossPanel.SetActive(true);
        }
    }

    public void MuteToggle(bool mute) {
        gameManager.MuteToggle(mute);
    }
}
