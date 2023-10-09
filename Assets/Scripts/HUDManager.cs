using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDManager : MonoBehaviour
{
    public GameObject highscoreText;
    public IntVariable gameScore;

    private Vector3[] scoreTextPosition = {
        new Vector3(-827, 472, 0),
        new Vector3(0, 0, 0)
        };
    private Vector3[] restartButtonPosition = {
        new Vector3(868, 444, 0),
        new Vector3(0, -179, 0)
    };

    public GameObject scoreText;
    public GameObject finalScoreText;
    public GameObject restartButton;

    public GameObject deathOverlay;
    void Awake()
    {
        // subscribe to events
        GameManager.instance.gameStart.AddListener(GameStart);
        GameManager.instance.gameOver.AddListener(GameOver);
        GameManager.instance.gameRestart.AddListener(GameStart);
        GameManager.instance.scoreChange.AddListener(SetScore);
    }

    public void GameStart()
    {
        // hide gameover panel
        deathOverlay.SetActive(false);
        scoreText.SetActive(true);
        restartButton.SetActive(true);
        // scoreText.transform.localPosition = scoreTextPosition[0];
        // restartButton.localPosition = restartButtonPosition[0];
    }

    public void SetScore(int score)
    {
        scoreText.GetComponent<TextMeshProUGUI>().text = "Score: " + score.ToString();
    }


    public void GameOver()
    {
        deathOverlay.SetActive(true);
        scoreText.SetActive(false);
        restartButton.SetActive(false);

        finalScoreText.GetComponent<TextMeshProUGUI>().text = "Score: " + gameScore.Value.ToString();

        // set highscore
        highscoreText.GetComponent<TextMeshProUGUI>().text = "TOP- " + gameScore.previousHighestValue.ToString("D6");
        // show
        highscoreText.SetActive(true);
    }
}
