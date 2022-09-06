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
    private int brickGroupsLeft;

    private bool isGameRunning = false;

    public AudioSource loss;
    public HealthBar healthBar;

    
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
            else if (ball.IsStatic() && isGameRunning) {
                ball.StartMovement();
                if (ui.pressSpaceText.gameObject.activeSelf) {
                    ui.pressSpaceText.gameObject.SetActive(false);
                }
            }
        }
        else if (Input.GetKeyDown("escape")) {
            isGameRunning = Pause(isGameRunning);
        }
    }

    /// <summary>
    /// Pauses and resumes the game
    /// </summary>
    /// <param name="pause">true will pause the game. false will resume</param>
    /// <returns>true if the game is running</returns>
    private bool Pause(bool pause) {
        if (pause) {
            Time.timeScale = 0;
            ui.Pause(true);
        }
        else {  // resume
            if (ui.pausedText.gameObject.activeSelf) {

                ui.Pause(false);
                Time.timeScale = 1;
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// This function checks if the current level is over and 
    /// spawns the next one only if it's necessary.
    /// </summary>
    public void UpdateLevel() {
        if (brickGroupsLeft  == 0) {  // level is over
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
        brickGroupsLeft = spawner.SpawnNextLevel();
        if (brickGroupsLeft == -1) {
            EndGame(true);
        }
        isGameRunning = true;
    }

    /// <summary>
    /// End the game with the appropriate end game panel.
    /// </summary>
    /// <param name="isVictory">true if the game was won</param>
    public void EndGame(bool isVictory) {
        ui.EndGame(isVictory);
        isGameRunning = Pause(true);
        StartCoroutine(Waiter());
        Application.Quit();
    }

    IEnumerator Waiter() {
        yield return new WaitForSeconds(7);
    }

    public void MuteToggle(bool mute) {
        if (mute) {
            AudioListener.volume = 0;
        }
        else {
            AudioListener.volume = 1;
        }
    }

    public void DecrementLife() {
        int livesLeft = healthBar.DecrementLife();
        loss.Play();
        if (livesLeft == 0) {
            EndGame(false);
        }
    }

    public void DecrementBrickGroup() {
        brickGroupsLeft--;
    }
}
