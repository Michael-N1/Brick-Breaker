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
        }
    }

    public void StartNextLevel() {
        ui.levelTransitionPanel.SetActive(false);
        ball.Reset();
        bar.Reset();
        groupBlocksLeft = spawner.SpawnNextLevel();
        if (groupBlocksLeft == -1) {
            EndGame();
        }
    }

    public void StartGame() {
        groupBlocksLeft = spawner.SpawnNextLevel();  // spawn first level
    }

    public void EndGame() {
        ;  // TODO: implement
    }
}
