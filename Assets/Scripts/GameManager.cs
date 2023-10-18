using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public IntVariable gameScore;
    // Events
    public SimpleGameEvent gameStart;
    // public IntGameEvent scoreUpdated;
    // public UnityEvent<int> increaseScore;
    public SimpleGameEvent updateScore;


    // private int score = 0;

    void Start()
    {
        gameStart.Raise(this);
        Time.timeScale = 1.0f;
        // subscribe to scene manager scene change
        SceneManager.activeSceneChanged += SceneSetup;
    }
    public void SceneSetup(Scene current, Scene next)
    {
        gameStart.Raise(this);
        // SetScore(gameScore.Value);
    }
    public void IncreaseScore(int i)
    {
        gameScore.ApplyChange(i);
        updateScore.Raise(this);
    }
    // public void SetScore(int score)
    // {
    //     updateScore.Raise(score);
    // }
    public void PauseGame()
    {
        Time.timeScale = 0.0f;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1.0f;
    }
    public void GameOver()
    {
        Time.timeScale = 0.0f;
    }
    public void GameRestart()
    {
        // reset score
        gameScore.Value = 0;
    }
    public void RequestPowerupEffect(PowerupInterface i)
    {
        // wtf does this do
    }
}