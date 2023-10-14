using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class HUDManager : MonoBehaviour
{
    public GameObject highscoreText;
    public IntVariable gameScore;
    public GameObject scoreText;
    public GameObject finalScoreText;
    public GameObject restartButton;
    public GameObject deathOverlay;
    void Awake()
    {
        // subscribe to events
        // GameManager.instance.gameStart.AddListener(GameStart);
        // GameManager.instance.gameOver.AddListener(GameOver);
        // GameManager.instance.gameRestart.AddListener(GameStart);
        // GameManager.instance.scoreChange.AddListener(SetScore);
        gameScore.Value = 0;
    }
    void Update()
    {

    }
    public void GameStart()
    {
        Time.timeScale = 1.0f;
        gameScore.Value = 0;
        scoreText.GetComponent<TextMeshProUGUI>().text = "SCORE: " + gameScore.Value.ToString();
        deathOverlay.SetActive(false);
        scoreText.SetActive(true);
        restartButton.SetActive(true);
    }
    // public void SetScore(int score)
    // {
    //     // Debug.Log("HUDManager SetScore");
    //     // Debug.Log(score);
    //     scoreText.GetComponent<TextMeshProUGUI>().text = "SCORE: " + score.ToString();
    // }
    public void IncrementScore(int score)
    {
        gameScore.ApplyChange(score);
        scoreText.GetComponent<TextMeshProUGUI>().text = "SCORE: " + gameScore.Value.ToString();
    }
    public void GameOver()
    {
        Time.timeScale = 0.0f;
        deathOverlay.SetActive(true);
        scoreText.SetActive(false);
        restartButton.SetActive(false);

        finalScoreText.GetComponent<TextMeshProUGUI>().text = "SCORE: " + gameScore.Value.ToString();

        // set highscore
        highscoreText.GetComponent<TextMeshProUGUI>().text = "TOP- " + gameScore.previousHighestValue.ToString("D6");
        // show
        highscoreText.SetActive(true);
    }
    public void ReturnToMain()
    {
        SceneManager.LoadSceneAsync("Main Menu", LoadSceneMode.Single);
    }
}
