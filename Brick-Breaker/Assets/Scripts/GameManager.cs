using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is the general game manager.
/// </summary>
public class GameManager : MonoBehaviour
{
    private Spawner spawner;
    private Ball ball;
    private Bar bar;
    private UIManager ui;
    private bool isGameRunning = false;
    public int groupBlocksLeft;
    
    // Start is called before the first frame update
    void Start()
    {
        spawner = FindObjectOfType<Spawner>();
        ball = FindObjectOfType<Ball>();
        bar = FindObjectOfType<Bar>();
        ui = FindObjectOfType<UIManager>();
    }

    void Update() {
        if (Input.GetKeyDown("space")) {
            if (ui.startPanel.activeSelf) {
                ui.StartButton();
                isGameRunning = true;
            }
            else if (ui.levelTransitionPanel.activeSelf) {
                StartNextLevel();
            }
            else if (ball.IsStatic()) {
                ball.StartMovement();
                if (ui.pressSpaceText.gameObject.activeSelf) {
                    ui.pressSpaceText.gameObject.SetActive(false);
                }
            }
        }
        else if (Input.GetKeyDown("escape")) {
            Pause();
        }
    }

    private void Pause() {
        if (isGameRunning) {
            Time.timeScale = 0;
            ui.Pause(true);
            isGameRunning = false;
        }
        else {
            // if the game is paused and hasn't ended, resume it
            if (ui.pausedText.gameObject.activeSelf && !ui.endPanel.activeSelf){
                ui.Pause(false);
                Time.timeScale = 1;
                isGameRunning = true;
            }
        }
    }

    /// <summary>
    /// This function checks if the current level is over and 
    /// spawns the next one only if it's necessary.
    /// </summary>
    public void UpdateLevel() {
        if (groupBlocksLeft  == 0) {  // level is over
            ui.FinishLevel(spawner.GetCurrLevelNum());
            ball.gameObject.SetActive(false);
            bar.gameObject.SetActive(false);
            isGameRunning = false;
        }
    }

    public void StartNextLevel() {
        if (ui.levelTransitionPanel.activeSelf) {
            ui.levelTransitionPanel.SetActive(false);
        }
        ball.Reset();
        bar.Reset();
        groupBlocksLeft = spawner.SpawnNextLevel();
        if (groupBlocksLeft == -1) {
            EndGame();
        }
        isGameRunning = true;
    }

    public void EndGame() {
        Pause();
        ui.EndGame();
        StartCoroutine(Waiter());
        Application.Quit();
    }

    IEnumerator Waiter() {
        yield return new WaitForSeconds(7);
    }
}
